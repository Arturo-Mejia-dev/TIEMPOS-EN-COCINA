using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.Reflection;

namespace TIEMPOS_RW
{
    public partial class ConexServ : Form
    {
        SqlConnection con;
        Conexion dirCon = new Conexion();
        public string Conexion, Minutos, MaxMin, Sucursal,sAlarma,sSonido,Version,PCRegion;
        public int statusCon = 0;

        public ConexServ()
        {
            InitializeComponent();
            comboBoxVersion.SelectedIndex = 0;
            comboBoxRegion.SelectedIndex = 0;
        }

        private void ConexServ_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            Conexion = "Data Source=" + textServidor.Text + ";Initial Catalog=" + textBase.Text + ";User Id=" + textUsuario.Text + ";Password=" + textContraseña.Text + "";
            Minutos = textMinHot.Text; MaxMin = textMaxMin.Text; Sucursal = textSucursal.Text; sSonido = checkBoxSonido.Checked.ToString(); sAlarma = numericUpComandas.Value.ToString(); Version = comboBoxVersion.Text; PCRegion = comboBoxRegion.Text;
            ConfigurationManager.AppSettings["conexion"] = Conexion;

           if (textMaxMin.Text != "" && textMinHot.Text != "" && textSucursal.Text != "")
           {
                try
                {

                    dirCon = new Conexion();
                    con = dirCon.crearConexion();
                    SqlDataAdapter query = new SqlDataAdapter();
                    SqlDataAdapter consulta = new SqlDataAdapter();
                    DataSet datos = new DataSet();
                    consulta.SelectCommand = new SqlCommand("select	* from TUsuarios ", con);
                    consulta.Fill(datos);
                    string Usuario = datos.Tables[0].Rows[0][1].ToString();
                    MessageBox.Show("Conexion Exitosa ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ConfigurationManager.AppSettings["status"] = "True";
                    textBase.Enabled = false;
                    textServidor.Enabled = false;
                    textUsuario.Enabled = false;
                    textContraseña.Enabled = false;
                    button2.Enabled = false;
                    textMaxMin.Enabled = false;
                    textMinHot.Enabled = false;
                    textSucursal.Enabled = false;
                    checkBoxSonido.Enabled = false;
                    numericUpComandas.Enabled = false;
                    comboBoxRegion.Enabled = false;
                    comboBoxVersion.Enabled = false;
                    statusCon = 1;


                }
                catch
                {
                    MessageBox.Show("Conexion no Exitosa ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    statusCon = 0;
                }
           }
           else { MessageBox.Show("Llena todos los Campos ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void CheckBoxSonido_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSonido.Checked == false)
            {
                numericUpComandas.Enabled = false;
            }
            else numericUpComandas.Enabled = true;
        }

        private void Xmlsave() {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string path = assembly.Location;

            Configuration config = ConfigurationManager.OpenExeConfiguration(path);
            config.ConnectionStrings.ConnectionStrings["TIEMPOS_RW.Properties.Settings.UAQUERETAROConnectionString"].ConnectionString = Conexion;
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

                        if (node.Attributes[0].Value == "status")
                        {
                            node.Attributes[1].Value = "True";
                        }
                        if (node.Attributes[0].Value == "conexion")
                        {
                            node.Attributes[1].Value = Conexion;
                        }
                        if (node.Attributes[0].Value == "Minutos")
                        {
                            node.Attributes[1].Value = Minutos;
                        }
                        if (node.Attributes[0].Value == "MaxMin")
                        {
                            node.Attributes[1].Value = MaxMin;
                        }
                        if (node.Attributes[0].Value == "Sucursal")
                        {
                            node.Attributes[1].Value = Sucursal;
                        }
                        if (node.Attributes[0].Value == "Alarma")
                        {
                            node.Attributes[1].Value = sAlarma;
                        }
                        if (node.Attributes[0].Value == "Sonido")
                        {
                            node.Attributes[1].Value = sSonido;
                        }
                        if (node.Attributes[0].Value == "Version")
                        {
                            node.Attributes[1].Value = Version;
                        }
                        if (node.Attributes[0].Value == "region")
                        {
                            node.Attributes[1].Value = PCRegion;
                        }
                    }

                }






            }
            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("appSettings");
            ConfigurationManager.RefreshSection("connectionStrings");

        }

        private void TextServidor_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (statusCon == 1) {
                Xmlsave();
            }
            Form1 frm = new Form1();
            frm.Show(this);
            this.Hide();
            
            
            
        }
    }
}
