using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.Reflection;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TIEMPOS_RW
{
    public partial class Limpieza : Form
    {
        public int numLecturas = 0;
        public int Limpiar= int.Parse(DateTime.Now.Day.ToString());

        public const int SW_RESTORE = 3;
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern public bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public Limpieza()
        {
            InitializeComponent();
            this.ActiveControl = textBoxPrueba;
            Process currentProcess = Process.GetCurrentProcess();
            var process = Process.GetProcessById(currentProcess.Id);
            ShowWindow(process.MainWindowHandle, SW_RESTORE);
            SetForegroundWindow(process.MainWindowHandle);
            this.Focus();
            
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                if (numLecturas < 2) {

                    if (string.IsNullOrEmpty(textBoxPrueba.Text))
                    {
                        //MessageBox.Show("INTENTA NUEVAMENTE");
                    }
                    else {
                        numLecturas++;
                        textBoxPrueba.Clear();
                        labelEscaneos.Text = " "+numLecturas;
                    }
                }
                else {
                    //REGRESAR A LA PANTALLA PRINCIPAL
                    Xmlsave();
                    Form1 frm = new Form1();
                    frm.Show(this);
                    this.Hide();

                }

            }
        }
        private void Xmlsave()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string path = assembly.Location;

            Configuration config = ConfigurationManager.OpenExeConfiguration(path);
            
            config.Save(ConfigurationSaveMode.Modified);


            //


            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement element in XmlDoc.DocumentElement)
            {
                if (element.Name.Equals("appSettings"))
                {

                    foreach (XmlNode node in element.ChildNodes)
                    {

                        if (node.Attributes[0].Value == "Limpia")
                        {
                            node.Attributes[1].Value = ""+Limpiar;
                        }
                        
                    }

                }
                                                                          
            }
            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("appSettings");
            ConfigurationManager.RefreshSection("connectionStrings");

        }

        private void Limpieza_Load(object sender, EventArgs e)
        {
            Class2.ejecuta();
        }
    }
}
