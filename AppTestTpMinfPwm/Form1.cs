using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace AppCsTp2Pwm
{
    public partial class Form1 : Form
    {
        const ushort SAUT_INDEX = 2;    // Constante pour le nombre de saut d'index avant la valeur

        public delegate void ReceiverD();
        public ReceiverD myDelegate;
        int ctsCount = 0;
        int m_SendCount = 0;
        int m_DispCount = 0;
        byte[] Mess1 = new byte[5];
        string Message = "";    // Variable de sauvegarde du message à envoyer

        const byte stx = 0xAA;
        const int m_MessSize = 5;

        // Tableau de correspondance pour les formes
        char[] tbFormes = { 'S', 'C', 'T', 'D' };  // S = sinus, C = carré, T = triangle, D = dent de scie

        public Form1()
        {
            InitializeComponent();
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            //Array.Sort(ports);
            cboPortNames.Items.AddRange(ports);
            cboPortNames.SelectedIndex = 0;
            lstDataIn.Items.Clear();

            myDelegate = new ReceiverD(DispInListRxData);

        }

        void DispTxMess(byte[] Mess, int len)
        {
            string messAffiche = "";

            for (int i = 0; i < len; i++)
            {
                messAffiche = messAffiche + NumToHex(Mess[i]) + " ";
            }
            lstDataOut.Items.Add(messAffiche);

            //ne garde que les 10 dernières lignes
            if (lstDataOut.Items.Count > 10)
                lstDataOut.Items.RemoveAt(0);
        }

        void DispTxMess(string mess)
        {
            lstDataOut.Items.Add(mess);

            //ne garde que les 10 dernières lignes
            if (lstDataOut.Items.Count > 10)
                lstDataOut.Items.RemoveAt(0);
        }

        void composeMessage( ref byte[] Mess)
        {
            string tmpVal;  // Variable de sauvegarde temporaire des valeures

            Message = "!S=";    // Commencer le message par "!S="

            // Essayer de récupérer la forme du signal
            try
            {
                tmpVal = tbFormes[cbForme.SelectedIndex].ToString();
            }
            catch   
            {
                // Mettre la forme par default
                tmpVal = tbFormes[0].ToString();
            }

            // Écriture de la forme
            Message += tmpVal + "F=";
            // Récupération de la fréquence
            tmpVal = nudFreq.Value.ToString();
            // Écriture de la fréquence
            Message += tmpVal + "A=";
            // Récupération de l'amplitude
            tmpVal = nudAmpl.Value.ToString();
            // Écriture de l'amplitude
            Message += tmpVal + "O=";
            // Écriture du signe de l'offset si nécessaire
            if (nudOffset.Value >= 0)
            {
                Message += "+";
            }
            // Récupération de l'offset
            tmpVal = nudOffset.Value.ToString();
            // Écriture de la sauvegarde
            Message += tmpVal + "W=";
            if (chkSave.Checked)
            {
                Message += "1#";
            }
            else
            {
                Message += "0#";
            }

            DispTxMess(Message);   //Affichage trame TX
        }    
               
        string NumToHex(byte val)
        {
            string tmp = val.ToString("X");
            if (tmp.Length < 2)
            {
                tmp = "0" + tmp;
            }
            return tmp;
        }

        void SendMessage(int count)
        {
            // Envoie le message si le port est ouvert
            if (serialPort1.IsOpen) {

                composeMessage(ref Mess1);  // Compose le message

                try {
                    // Écrit le message sur le port
                    serialPort1.Write(Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Erreur à l'envoi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    timer1.Stop();     // pour éviter problème en mode continu
                    btSendContinuous.Text = "Envoi continu";

                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();
                }

            } else { 
                MessageBox.Show("Port non ouvert", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer1.Stop();     // pour éviter problème en mode continu

                CloseCom(); // Fermeture du port de communication
            }
        }

        private void btOpenClose_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)    //ouverture du port
            {
                // Configuration du port
                serialPort1.PortName = (string)cboPortNames.SelectedItem;
                serialPort1.BaudRate  = 57600;
                serialPort1.Parity    = Parity.None;
                serialPort1.DataBits  = 8;
                serialPort1.StopBits  = StopBits.One;
                serialPort1.Handshake = Handshake.RequestToSend;

                // Set the read/write timeouts
                serialPort1.ReadTimeout = 100;
                serialPort1.WriteTimeout = 100;

                try
                {
                    serialPort1.Open();

                    btOpenClose.Text = "Close";
                    gbTx.Enabled = true;
                    gbRx.Enabled = true;
                    cboPortNames.Enabled = false;
                }
                catch (Exception ex)
                {
                    if (!serialPort1.IsOpen)
                        MessageBox.Show(ex.ToString(), "Erreur à l'ouverture du port !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseCom(); // Fermeture du port de communication
                }

                cbForme.SelectedIndex = 0;
            }
            else //fermeture
            {
                serialPort1.Close();

                CloseCom(); // Fermeture du port de communication
            }

        } // end btOpenClose_Click

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //lstDataIn.Invoke(myDelegate);
            lstDataIn.BeginInvoke(myDelegate);
        }

        public void DispInListRxData()
        {
            ushort i = 0;   // Index de réception
            ushort j = 0;   // Index de reécriture
            byte[] RxMess = new byte[30];   // Tableau de sauvegarde du message reçu
                        
            // Index
            ushort iForme = 0;  // Pour la forme
            ushort iFreq = 0;   // Pour la fréquence
            ushort iAmpl = 0;   // Pour l'amplitude
            ushort iOffset = 0; // Pour l'offset
            ushort iSave = 0;   // Pour la sauvegarde

            string messAffiche = "";
            int calculTmp = 0;

            // Recherche début de trame
            do
            {
                RxMess[0] = (byte)serialPort1.ReadByte();
            } while (RxMess[0] != 0x21);    // Tant que RxMess != "!"

            // Lecture des bytes dé qu'on en a reçu 18
            if (serialPort1.BytesToRead >= 18)
            {
                do
                {
                    // Lecture du port si il y a des bytes à lire
                    if (serialPort1.BytesToRead != 0)
                    {
                        i++;
                        RxMess[i] = (byte)serialPort1.ReadByte();
                        // Sauvegarde des index pour les valeurs
                        if ((RxMess[i] == 'S') && (iForme == 0))
                        {
                            iForme = i;
                        }
                        else if (RxMess[i] == 'F')
                        {
                            iFreq = i;
                        }
                        else if (RxMess[i] == 'A')
                        {
                            iAmpl = i;
                        }
                        else if (RxMess[i] == 'O')
                        {
                            iOffset = i;
                        }
                        else if (RxMess[i] == 'W')
                        {
                            iSave = i;
                        }
                    }
                } while (RxMess[i] != 0x23);    // Faire tant que Rxmess[i] n'est pas égal à #

                // Écriture de la forme dans la case prévue
                txtForme.Text = ((char)RxMess[iForme + 2]).ToString();

                // Calcul et écriture de la fréquence dans la case prévue
                j = SAUT_INDEX;
                // Reconstitution de la valeur
                for (j += iFreq ; j < iAmpl; j++)
                {
                    calculTmp *= 10;
                    calculTmp += RxMess[j] - '0';
                }
                txtFreq.Text = calculTmp.ToString();

                // Calcul et écriture de l'amplitude dans la case prévue
                j = SAUT_INDEX;
                calculTmp = 0;
                // Reconstitution de la valeur
                for (j += iAmpl; j < iOffset; j++)
                {
                    calculTmp *= 10;
                    calculTmp += RxMess[j] - '0';
                }
                txtAmpl.Text = calculTmp.ToString();

                // Calcul et écriture de l'offset dans la case prévue
                j = SAUT_INDEX + 1;
                calculTmp = 0;
                // Reconstitution de la valeur
                for (j += iOffset; j < iSave; j++)
                {
                    calculTmp *= 10;
                    calculTmp += RxMess[j] - '0';
                }
                // Ajout du signe
                if(RxMess[iOffset + SAUT_INDEX] == '-')
                {
                    calculTmp *= -1;
                }
                txtOffset.Text = calculTmp.ToString();

                //Affichage de la trame recue
                messAffiche = "";
                for (j = 0; j <= i; j++)
                {
                    //Reécriture du message reçu
                    messAffiche += ((char)RxMess[j]).ToString();
                }
                // Envoy du message reécrit dans la boite de réception
                lstDataIn.Items.Add(messAffiche);

                //ne garde que les 10 dernières lignes
                if (lstDataIn.Items.Count > 10)
                    lstDataIn.Items.RemoveAt(0);

            }
        }

        string ConvUsignedToSignedString(byte val)
        {
            string Res = "";
            short tmp;
            if (val < 128) {
                tmp = val;
            } else
            {
                tmp = val;
                tmp -= 256;
            }
            Res = tmp.ToString();
            return Res;
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            // Envoie le message si le port est ouvert
            m_SendCount = 0;
            SendMessage(m_SendCount);

            //stoppe envoi continu
            if (timer1.Enabled)
            {
                timer1.Stop();
                btSendContinuous.Text = "Envoi continu";
            }
        }

        private void btSendContinuous_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (!timer1.Enabled)
                {
                    //active envoi continu
                    timer1.Interval = 50;  // pour 1 message chaque 50 ms
                    m_SendCount = 0;
                    ctsCount = 0;
                    timer1.Start();
                    btSendContinuous.Text = "Stop envoi";
                }
                else
                {
                    //désactive envoi continu
                    timer1.Stop();
                    btSendContinuous.Text = "Envoi continu";
                }
            }
            else
            {
                MessageBox.Show("Port non ouvert", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer1.Stop();     // pour éviter problème en mode continu

                CloseCom(); // Fermeture du port de communication
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

                SendMessage(m_SendCount);
 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();

            // Fermeture du port si nécessaire.
            // Workaround pour éviter blocage de l'app à la fermeture
            // Un simple appel à serialPort1.Close() fige l'app !
            try
            {
                serialPort1.Handshake = Handshake.None;
                serialPort1.DtrEnable = false;
                serialPort1.RtsEnable = false;
                serialPort1.DataReceived -= serialPort1_DataReceived;
                Thread.Sleep(200);
                if (serialPort1.IsOpen)
                {
                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();
                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erreur à la fermeture du port !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbForme_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPortNames_DropDown(object sender, EventArgs e)
        {
            // Vérification des ports
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            //Array.Sort(ports);
            cboPortNames.Items.Clear();
            cboPortNames.Items.AddRange(ports);
            cboPortNames.SelectedIndex = 0;
        }

        private void CloseCom()
        {
            // Fermeture du port
            serialPort1.Close();
            btOpenClose.Text = "Open";
            gbTx.Enabled = false;
            gbRx.Enabled = false;
            cboPortNames.Enabled = true;
            btSendContinuous.Text = "Envoi continu";

            // Vérification des ports
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            cboPortNames.Items.Clear();
            cboPortNames.Items.AddRange(ports);
            cboPortNames.SelectedIndex = 0;

            // Nettoyage des listes de transmition récéption
            lstDataIn.Items.Clear();
            lstDataOut.Items.Clear();
        }
    }
}
