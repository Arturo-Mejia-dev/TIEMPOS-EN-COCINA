using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace TIEMPOS_RW
{
    public partial class Form1 : Form
    {

        public int al, apl = 0, lim =0;
        public string Fecha1 { get; set; }
        public string Fecha2 { get; set; }

        public string FechaSistema = "" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
        public string Status;
        public int BDone = 0, NoDatos = 1, gMinutos = int.Parse(ConfigurationManager.AppSettings["Minutos"]) - 1, maxMin = int.Parse(ConfigurationManager.AppSettings["MaxMin"]);
        //public int BDone = 0, gMinutos = 14, maxMin = 30;
        public int numComandas;
        public string dgComanda = "0", dgMinutos = "0";

        //Conexion SQL
        SqlConnection conexion;
        Conexion dirCon = new Conexion();
        SqlDataAdapter adap = new SqlDataAdapter();
        DataSet ds = new DataSet();



        public Form1()
        {


            //if (getPrevInstance()) {
            //    this.Close();
            //    Application.Exit();
            //    Application.ExitThread();
            //}
            InitializeComponent();


            labelFecha.Text = DateTime.Now.ToString("dd/MM/yyy");
            labelHora.Text = DateTime.Now.ToString("hh:mm tt");

            if (ConfigurationManager.AppSettings["status"] == "True")
            {
                conexion = dirCon.crearConexion();
                //Status = "SELECT DISTINCT IDCOMANDA, SALA, MESA, DATEDIFF(MINUTE, HORA, GETDATE()) as MINUTOS,IIF(DATEDIFF(MINUTE, HORA, GETDATE())>"+gMinutos+", 'HOT', 'WORKING') as STATUS  FROM  dbo.LISTACOCINA where (DATEPART(yy, HORA) = '2021' AND DATEPART(mm, HORA) = '12' AND DATEPART(dd, HORA) = '01') and (UDSRECIBIDAS = 0) order by IDCOMANDA desc";
                Status = "SELECT DISTINCT IDCOMANDA, SALA, MESA, DATEDIFF(MINUTE, HORA, GETDATE()) as MINUTOS,IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos + ", 'HOT', 'WORKING') as STATUS  FROM  dbo.LISTACOCINA where (DATEPART(yy, HORA) = " + DateTime.Now.Year + " AND DATEPART(mm, HORA) = " + DateTime.Now.Month + " AND DATEPART(dd, HORA) = " + DateTime.Now.Day + ") and (UDSRECIBIDAS = 0) order by IDCOMANDA ";
                mostrarOrdenes();
                MuestraDatos.ClearSelection();
                Fecha1 = dateTimeFecha1.Value.ToString("yyyy-MM-dd");
                Fecha2 = dateTimeFecha2.Value.ToString("yyyy-MM-dd");
                labelVersion.Text = ConfigurationManager.AppSettings["Version"];

                labelSucursal.Text = ConfigurationManager.AppSettings["Sucursal"];
                labelConfigura.Visible = false;
                buttonTodos.Enabled = true;
                buttonWorking.Enabled = true;
                buttonHot.Enabled = true;
                buttonDone.Enabled = true;
                
                if (int.Parse(ConfigurationManager.AppSettings["Limpia"]) != int.Parse(DateTime.Now.Day.ToString()) && int.Parse(DateTime.Now.Hour.ToString()) > 11)
                {

                    apl = 1;
                    lim = 1;
                    Limpieza frm = new Limpieza();


                    frm.Show(this);
                    this.Hide();

                }


            }
            else {
                labelConfigura.Visible = true;
                buttonTodos.Enabled = false;
                buttonWorking.Enabled = false;
                buttonHot.Enabled = false;
                buttonDone.Enabled = false;

            }
            GoFullscreen();

        }
        private void alarma()
        {
            if (int.Parse(buttonHot.Text) >= int.Parse(ConfigurationManager.AppSettings["Alarma"]) && ConfigurationManager.AppSettings["Sonido"] == "True")
            {
                SystemSounds.Exclamation.Play();
            }
        }
        private void GoFullscreen()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private void mostrarOrdenes()
        {
            try
            {
                conexion.Open();
                SqlDataAdapter datos = new SqlDataAdapter("" + Status, conexion);
                DataSet data = new DataSet();

                datos.Fill(data);

                //MuestraDatos.DataSource = data.Tables[0];



                SqlConnection con = new SqlConnection();
                //variable de tipo Sqlcommand
                SqlCommand comando = new SqlCommand();
                //variable SqlDataReader para leer los datos
                SqlDataReader dr;





                if (data.Tables[0].Rows.Count > 0 || data.Tables[0].Rows.Count != NoDatos)
                {
                    comando.Connection = conexion;
                    //declaramos el comando para realizar la busqueda
                    comando.CommandText = "" + Status;
                    //especificamos que es de tipo Text
                    comando.CommandType = CommandType.Text;
                    //se abre la conexion

                    //limpiamos los renglones de la datagridview
                    MuestraDatos.Rows.Clear();
                    //a la variable DataReader asignamos  el la variable de tipo SqlCommand
                    dr = comando.ExecuteReader();
                    //el ciclo while se ejecutará mientras lea registros en la tabla
                    while (dr.Read())
                    {
                        //variable de tipo entero para ir enumerando los la filas del datagridview
                        int renglon = MuestraDatos.Rows.Add();
                        // especificamos en que fila se mostrará cada registro
                        // nombredeldatagrid.filas[numerodefila].celdas[nombredelacelda].valor=
                        // dr.tipodedatosalmacenado(dr.getordinal(nombredelcampo_en_la_base_de_datos)conviertelo_a_string_sino_es_del_tipo_string);
                        MuestraDatos.Rows[renglon].Cells["IDCOMANDA"].Value = dr.GetInt32(dr.GetOrdinal("IDCOMANDA")).ToString();
                        MuestraDatos.Rows[renglon].Cells["SALA"].Value = dr.GetInt32(dr.GetOrdinal("SALA"));
                        MuestraDatos.Rows[renglon].Cells["MESA"].Value = dr.GetInt32(dr.GetOrdinal("MESA"));
                        if (BDone == 1)
                        {
                            MuestraDatos.Rows[renglon].Cells["MINUTOS"].Value = Convert.ToInt32(dr.GetDouble(dr.GetOrdinal("MINUTOS")));
                            MuestraDatos.Rows[renglon].Cells["ESTATUS"].Value = dr.GetString(dr.GetOrdinal("STATUS"));
                        }
                        else
                        {
                            MuestraDatos.Rows[renglon].Cells["MINUTOS"].Value = dr.GetInt32(dr.GetOrdinal("MINUTOS"));
                            MuestraDatos.Rows[renglon].Cells["ESTATUS"].Value = dr.GetString(dr.GetOrdinal("STATUS"));
                        }



                    }


                    NoDatos = data.Tables[0].Rows.Count;
                    conexion.Close();
                    Semaforo();
                    this.ActiveControl = textBoxOrden;
                    MuestraDatos.ClearSelection();
                    MuestraDatos.CurrentCell = null;
                    TiempoPromedio();
                    MatarComandas();
                    alarma();
                }
                else { conexion.Close(); }
            }
            catch (SqlException ex)
            {
                pictureBoxReconectando.Visible = true;
                labelReconectando.Visible = true;
                timerActualiza.Stop();
                timerReconecta.Start();

            }
        }
        private void CambiaFechaSistema()
        {
            string Fechahoy = "" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            if (FechaSistema != Fechahoy)
            {
                //MessageBox.Show("F:"+Fechahoy+" F2:"+FechaSistema);
                apl = 1;

                Application.Exit();
                Application.ExitThread();
                Application.Restart();
            }
            if (int.Parse(ConfigurationManager.AppSettings["Limpia"]) != int.Parse(DateTime.Now.Day.ToString()) && int.Parse(DateTime.Now.Hour.ToString()) > 11)
            {

                apl = 1;

                if (lim == 0) {
                    Application.Exit();
                    Application.ExitThread();
                    Application.Restart();
                }
            }

        }
        private void MatarComandas()
        {
            int nComandas = 0, tMinutos = 0, pPromedio = 0;

            conexion.Open();
            SqlDataAdapter consulta = new SqlDataAdapter();
            DataSet datos = new DataSet();
            consulta.SelectCommand = new SqlCommand("SELECT COUNT(IDCOMANDA) AS COMANDAS,SUM(UDSRECIBIDAS) AS MINUTOS FROM (SELECT  Distinct IDCOMANDA ,UDSRECIBIDAS   FROM  dbo.LISTACOCINA where (DATEPART(yy, HORA) = " + DateTime.Now.Year + " AND DATEPART(mm, HORA) = " + DateTime.Now.Month + " AND DATEPART(dd, HORA) = " + DateTime.Now.Day + ") and (UDSRECIBIDAS > 0) ) AS Subtabla", conexion);
            //consulta.SelectCommand = new SqlCommand("select IIF(DATEDIFF(MINUTE, HORA, GETDATE())>"+gMinutos+ ", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')), COUNT(DISTINCT IDCOMANDA) from dbo.LISTACOCINA where (DATEPART(yy, HORA) = '2021' AND DATEPART(mm, HORA) = '12' AND DATEPART(dd, HORA) = '01') GROUP BY IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos+", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')) HAVING IIF(DATEDIFF(MINUTE, HORA, GETDATE())>"+gMinutos+", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')) = 'WORKING'", conexion);

            consulta.Fill(datos);
            conexion.Close();

            conexion.Open();
            SqlDataAdapter consulta2 = new SqlDataAdapter();
            DataSet datos2 = new DataSet();
            consulta2.SelectCommand = new SqlCommand("SELECT COUNT(IDCOMANDA) AS COMANDAS,SUM(UDSRECIBIDAS) AS MINUTOS FROM (SELECT  Distinct IDCOMANDA ,UDSRECIBIDAS   FROM  dbo.LISTACOCINA where (DATEPART(yy, HORA) = " + DateTime.Now.Year + " AND DATEPART(mm, HORA) = " + DateTime.Now.Month + " AND DATEPART(dd, HORA) = " + DateTime.Now.Day + ") and (UDSRECIBIDAS = 0) ) AS Subtabla", conexion);
            //consulta.SelectCommand = new SqlCommand("select IIF(DATEDIFF(MINUTE, HORA, GETDATE())>"+gMinutos+ ", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')), COUNT(DISTINCT IDCOMANDA) from dbo.LISTACOCINA where (DATEPART(yy, HORA) = '2021' AND DATEPART(mm, HORA) = '12' AND DATEPART(dd, HORA) = '01') GROUP BY IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos+", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')) HAVING IIF(DATEDIFF(MINUTE, HORA, GETDATE())>"+gMinutos+", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')) = 'WORKING'", conexion);

            consulta2.Fill(datos2);
            conexion.Close();
            if (int.Parse(datos2.Tables[0].Rows[0][0].ToString()) > 0 && int.Parse(datos.Tables[0].Rows[0][0].ToString()) != 0)
            {
                nComandas = int.Parse(datos.Tables[0].Rows[0][0].ToString());
                tMinutos = int.Parse(datos.Tables[0].Rows[0][1].ToString());
                //pPromedio = tMinutos / nComandas;
                pPromedio = maxMin;

                conexion.Close();
                string StatusF;
                conexion.Open();
                SqlDataAdapter query = new SqlDataAdapter();
                query.UpdateCommand = new SqlCommand("UPDATE dbo.LISTACOCINA SET UDSRECIBIDAS=@Minutos, TEMPORAL=@Status WHERE (DATEDIFF(MINUTE, HORA, GETDATE()) >= @maxMinutos) and (UDSRECIBIDAS = 0)", conexion);
                if (pPromedio < gMinutos)
                {
                    StatusF = "T";
                }
                else
                {
                    StatusF = "F";
                }

                query.UpdateCommand.Parameters.Add("@maxMinutos", SqlDbType.Int).Value = maxMin;
                query.UpdateCommand.Parameters.Add("@Minutos", SqlDbType.Float).Value = pPromedio;
                query.UpdateCommand.Parameters.Add("@Status", SqlDbType.Char).Value = StatusF;


                try
                {

                    query.UpdateCommand.ExecuteNonQuery();
                    //AutoClosingMessageBox.Show("La Orden se da por Terminada", "Caption", 1000);
                    conexion.Close();

                    //MessageBox.Show("opcion 1");

                }
                catch
                {
                    conexion.Close();
                    //MessageBox.Show("error");
                }
            }
            else
            {
                pPromedio = maxMin;
                if (int.Parse(datos2.Tables[0].Rows[0][0].ToString()) > 0 && int.Parse(datos.Tables[0].Rows[0][0].ToString()) == 0)
                {
                    string StatusF;
                    conexion.Open();
                    SqlDataAdapter query = new SqlDataAdapter();
                    //query.UpdateCommand = new SqlCommand("UPDATE dbo.LISTACOCINA SET UDSRECIBIDAS=@Minutos, TEMPORAL=@Status WHERE (DATEDIFF(MINUTE, HORA, GETDATE()) >= @maxMinutos) and (UDSRECIBIDAS = 0) and (DATEPART(yy, HORA) = " + DateTime.Now.Year + " AND DATEPART(mm, HORA) = " + DateTime.Now.Month + " AND DATEPART(dd, HORA) = " + DateTime.Now.Day + ")", conexion);
                    query.UpdateCommand = new SqlCommand("UPDATE dbo.LISTACOCINA SET UDSRECIBIDAS=@Minutos, TEMPORAL=@Status WHERE (DATEDIFF(MINUTE, HORA, GETDATE()) >= @maxMinutos) and (UDSRECIBIDAS = 0)", conexion);
                    if (pPromedio < gMinutos)
                    {
                        StatusF = "T";
                    }
                    else
                    {
                        StatusF = "F";
                    }

                    query.UpdateCommand.Parameters.Add("@maxMinutos", SqlDbType.Int).Value = maxMin;
                    query.UpdateCommand.Parameters.Add("@Minutos", SqlDbType.Float).Value = pPromedio;
                    query.UpdateCommand.Parameters.Add("@Status", SqlDbType.Char).Value = StatusF;


                    try
                    {

                        query.UpdateCommand.ExecuteNonQuery();
                        //AutoClosingMessageBox.Show("La Orden se da por Terminada", "Caption", 1000);
                        conexion.Close();
                        //MessageBox.Show("opcion 2");


                    }
                    catch
                    {
                        conexion.Close();
                        //MessageBox.Show("error");
                    }
                }

            }




        }

        private void buttonIngresa_Click(object sender, EventArgs e)
        {

        }

        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }


        private void MsjLabelComanda(string statusMsj)
        {

            if (statusMsj == "OK")
            {
                labelERROR.Visible = false;
                labelOK.Visible = true;


            }
            else
            {
                labelOK.Visible = false;
                labelERROR.Visible = true;
                labelComanda.Text = "00000";
                labelMesa.Text = "00000";
                
            }

        }    
        private async void MsjLabel( string statusMsj)
        {
           

            if (statusMsj == "OK") {
                textBoxOrden.Enabled = false;
                labelOK.Visible = true;
                al = 0;
                while (true)
                {
                    await Task.Delay(200);
                    labelOK.ForeColor = labelOK.ForeColor == Color.Green ? Color.Lime : Color.Green; 
                    if (al > 10) { labelOK.Visible = false; textBoxOrden.Enabled = true; this.ActiveControl = textBoxOrden; break; }
                    al++;

                }


            }
            else {
                textBoxOrden.Enabled = false;
                labelERROR.Visible = true;
                al = 0;
                while (true)
                {
                    await Task.Delay(200);
                    labelERROR.ForeColor = labelERROR.ForeColor == Color.Red ? Color.Tomato : Color.Red;
                    if (al > 10) { labelERROR.Visible = false; textBoxOrden.Enabled = true; this.ActiveControl = textBoxOrden; break;  }
                    al++;

                }
            }

        }
 

            
        private void TimerAlert_Tick(object sender, EventArgs e)
        {

        }

        private void buttonWorking_Click(object sender, EventArgs e)
        {
            
            
            BDone = 0;
            Status = "SELECT DISTINCT IDCOMANDA, SALA, MESA, DATEDIFF(MINUTE, HORA, GETDATE()) as MINUTOS,IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos + ", 'HOT', 'WORKING') as STATUS  FROM  dbo.LISTACOCINA where (DATEPART(yy, HORA) = " + DateTime.Now.Year + " AND DATEPART(mm, HORA) = " + DateTime.Now.Month + " AND DATEPART(dd, HORA) = " + DateTime.Now.Day + ") and (UDSRECIBIDAS = 0) and (DATEDIFF(MINUTE, HORA, GETDATE())<=" + gMinutos + ") order by IDCOMANDA ";
            //Status = "SELECT DISTINCT IDCOMANDA, SALA, MESA, DATEDIFF(MINUTE, HORA, GETDATE()) as MINUTOS,IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos + ", 'HOT', 'WORKING') as STATUS  FROM  dbo.LISTACOCINA where (DATEPART(yy, HORA) = '2021' AND DATEPART(mm, HORA) = '12' AND DATEPART(dd, HORA) = '01') and (UDSRECIBIDAS = 0) and (DATEDIFF(MINUTE, HORA, GETDATE())<=" + gMinutos + ") order by IDCOMANDA desc";
            mostrarOrdenes();

            textBoxOrden.Enabled = true;
            PRINCIPAL_Click(sender, e);

        }

        private void buttonHot_Click(object sender, EventArgs e)
        {

            
            BDone = 0;
            Status = "SELECT DISTINCT IDCOMANDA, SALA, MESA, DATEDIFF(MINUTE, HORA, GETDATE()) as MINUTOS,IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos + ", 'HOT', 'WORKING') as STATUS  FROM  dbo.LISTACOCINA where (DATEPART(yy, HORA) = " + DateTime.Now.Year + " AND DATEPART(mm, HORA) = " + DateTime.Now.Month + " AND DATEPART(dd, HORA) = " + DateTime.Now.Day + ") and (UDSRECIBIDAS = 0) and (DATEDIFF(MINUTE, HORA, GETDATE())>=" + gMinutos + ") order by IDCOMANDA ";
            //Status = "SELECT DISTINCT IDCOMANDA, SALA, MESA, DATEDIFF(MINUTE, HORA, GETDATE()) as MINUTOS,IIF(DATEDIFF(MINUTE, HORA, GETDATE())>"+gMinutos+", 'HOT', 'WORKING') as STATUS  FROM  dbo.LISTACOCINA where (DATEPART(yy, HORA) = '2021' AND DATEPART(mm, HORA) = '12' AND DATEPART(dd, HORA) = '01') and (UDSRECIBIDAS = 0) and (DATEDIFF(MINUTE, HORA, GETDATE())>="+gMinutos+") order by IDCOMANDA desc";
            mostrarOrdenes();

            textBoxOrden.Enabled = true;
            PRINCIPAL_Click(sender, e);
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            
            BDone = 1;
            Status = "SELECT DISTINCT IDCOMANDA, SALA, MESA, UDSRECIBIDAS AS MINUTOS,IIF(TEMPORAL='F', 'OUT TIME', 'IN TIME') as STATUS  FROM  dbo.LISTACOCINA where (DATEPART(yy, HORA) = " + DateTime.Now.Year + " AND DATEPART(mm, HORA) = " + DateTime.Now.Month + " AND DATEPART(dd, HORA) = " + DateTime.Now.Day + ") and (UDSRECIBIDAS > 0) order by IDCOMANDA ";
            //Status = "SELECT DISTINCT IDCOMANDA, SALA, MESA, UDSRECIBIDAS AS MINUTOS,IIF(TEMPORAL='F', 'OUT TIME', 'IN TIME') as STATUS  FROM  dbo.LISTACOCINA where (DATEPART(yy, HORA) = '2021' AND DATEPART(mm, HORA) = '12' AND DATEPART(dd, HORA) = '01') and (UDSRECIBIDAS > 0) order by IDCOMANDA desc";
            mostrarOrdenes();

            PRINCIPAL_Click(sender, e);

        }



        private void buttonTerminar_Click(object sender, EventArgs e)
        {
            BDone = 0;

            ActualizaStatus(dgComanda, dgMinutos);
            mostrarOrdenes();


        }
        public class DataGridViewSeleccion
        {

            public static string GetValorCelda(DataGridView dgv, int num)
            {

                string valor = "";
                try
                {
                    valor = dgv.Rows[dgv.CurrentRow.Index].Cells[num].Value.ToString();
                    return valor;
                }
                catch { return valor; }

            }

        }

        private void ActualizaStatus(string idComanda, string Minutos)
        {
            string StatusF;
            conexion.Open();
            SqlDataAdapter query = new SqlDataAdapter();
            query.UpdateCommand = new SqlCommand("UPDATE dbo.LISTACOCINA SET UDSRECIBIDAS=@Minutos, TEMPORAL=@Status WHERE (IDCOMANDA = @Comanda)", conexion);
            if (int.Parse(Minutos) < gMinutos)
            {
                StatusF = "T";
            }
            else
            {
                StatusF = "F";
            }
            if (int.Parse(Minutos) > maxMin) {
                Minutos = "" +30;
            }
            if (int.Parse(Minutos) == 0)
            {
                Minutos = "" + 1;
            }
            query.UpdateCommand.Parameters.Add("@Comanda", SqlDbType.Int).Value = idComanda;
            query.UpdateCommand.Parameters.Add("@Minutos", SqlDbType.Float).Value = float.Parse(Minutos);
            query.UpdateCommand.Parameters.Add("@Status", SqlDbType.Char).Value = StatusF;


            try
            {

                query.UpdateCommand.ExecuteNonQuery();
                //AutoClosingMessageBox.Show("La Orden se da por Terminada", "Caption", 1000);
                conexion.Close();



            }
            catch
            {
                conexion.Close();
                //AutoClosingMessageBox.Show("ERROR CONEXION", "Caption", 1000);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["status"] == "True")
            {
                    CambiaFechaSistema();
                    mostrarOrdenes();
                    labelHora.Text = DateTime.Now.ToString("hh:mm tt");
            }
        }


        private void MuestraDatos_SelectionChanged(object sender, EventArgs e)
        {


        }

        private void MuestraDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (BDone == 0)
            {
                
                dgComanda = DataGridViewSeleccion.GetValorCelda(MuestraDatos, 0);
                dgMinutos = DataGridViewSeleccion.GetValorCelda(MuestraDatos, 3);

            }
            
        }
        private void Semaforo()
        {
            string done, working, hot, todos;

            chartSem.Series["Comandas"].Points.Clear();


            conexion.Open();
            SqlDataAdapter consulta = new SqlDataAdapter();
            DataSet datos = new DataSet();
            consulta.SelectCommand = new SqlCommand("select IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos + ", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')), COUNT(DISTINCT IDCOMANDA) from dbo.LISTACOCINA where (DATEPART(yy, HORA) = " + DateTime.Now.Year + " AND DATEPART(mm, HORA) = " + DateTime.Now.Month + " AND DATEPART(dd, HORA) = " + DateTime.Now.Day + ") GROUP BY IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos + ", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')) HAVING IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos + ", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')) = 'DONE'", conexion);
            //consulta.SelectCommand = new SqlCommand("select IIF(DATEDIFF(MINUTE, HORA, GETDATE())>"+gMinutos+ ", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')), COUNT(DISTINCT IDCOMANDA) from dbo.LISTACOCINA where (DATEPART(yy, HORA) = '2021' AND DATEPART(mm, HORA) = '12' AND DATEPART(dd, HORA) = '01') GROUP BY IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos+", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')) HAVING IIF(DATEDIFF(MINUTE, HORA, GETDATE())>"+gMinutos+", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')) = 'DONE'", conexion);

            consulta.Fill(datos);
            if (datos.Tables[0].Rows.Count > 0) { done = datos.Tables[0].Rows[0][1].ToString(); } else done = "0";
            conexion.Close();

            conexion.Open();
            consulta = new SqlDataAdapter();
            datos = new DataSet();
            consulta.SelectCommand = new SqlCommand("select IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos + ", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')), COUNT(DISTINCT IDCOMANDA) from dbo.LISTACOCINA where (DATEPART(yy, HORA) = " + DateTime.Now.Year + " AND DATEPART(mm, HORA) = " + DateTime.Now.Month + " AND DATEPART(dd, HORA) = " + DateTime.Now.Day + ") GROUP BY IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos + ", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')) HAVING IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos + ", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')) = 'WORKING'", conexion);
            //consulta.SelectCommand = new SqlCommand("select IIF(DATEDIFF(MINUTE, HORA, GETDATE())>"+gMinutos+ ", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')), COUNT(DISTINCT IDCOMANDA) from dbo.LISTACOCINA where (DATEPART(yy, HORA) = '2021' AND DATEPART(mm, HORA) = '12' AND DATEPART(dd, HORA) = '01') GROUP BY IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos+", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')) HAVING IIF(DATEDIFF(MINUTE, HORA, GETDATE())>"+gMinutos+", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')) = 'WORKING'", conexion);

            consulta.Fill(datos);
            if (datos.Tables[0].Rows.Count > 0)
            {
                working = datos.Tables[0].Rows[0][1].ToString();

                //chartSem.Series["Comandas"].Color = Color.Gold;

                chartSem.Series["Comandas"].Points.AddXY("", datos.Tables[0].Rows[0][1]);
            }
            else
            {
                chartSem.Series["Comandas"].Points.AddXY("", 0);
                working = "0";
            }
            conexion.Close();

            conexion.Open();
            consulta = new SqlDataAdapter();
            datos = new DataSet();
            consulta.SelectCommand = new SqlCommand("select IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos + ", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')), COUNT(DISTINCT IDCOMANDA) from dbo.LISTACOCINA where (DATEPART(yy, HORA) = " + DateTime.Now.Year + " AND DATEPART(mm, HORA) = " + DateTime.Now.Month + " AND DATEPART(dd, HORA) = " + DateTime.Now.Day + ") GROUP BY IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos + ", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')) HAVING IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos + ", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')) = 'HOT'", conexion);
            //consulta.SelectCommand = new SqlCommand("select IIF(DATEDIFF(MINUTE, HORA, GETDATE())>"+gMinutos+ ", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')), COUNT(DISTINCT IDCOMANDA) from dbo.LISTACOCINA where (DATEPART(yy, HORA) = '2021' AND DATEPART(mm, HORA) = '12' AND DATEPART(dd, HORA) = '01') GROUP BY IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos+", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')) HAVING IIF(DATEDIFF(MINUTE, HORA, GETDATE())>"+gMinutos+", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING')) = 'HOT'", conexion);

            consulta.Fill(datos);
            if (datos.Tables[0].Rows.Count > 0)
            {
                hot = datos.Tables[0].Rows[0][1].ToString();

                //chartSem.PaletteCustomColors. = Color.Red;

                chartSem.Series["Comandas"].Points.AddXY("", datos.Tables[0].Rows[0][1]);
            }
            else
            {
                chartSem.Series["Comandas"].Points.AddXY("", 0);
                hot = "0";
            }
            conexion.Close();

            conexion.Open();
            consulta = new SqlDataAdapter();
            datos = new DataSet();
            consulta.SelectCommand = new SqlCommand("select COUNT(DISTINCT IDCOMANDA)  from dbo.LISTACOCINA where (DATEPART(yy, HORA) = " + DateTime.Now.Year + " AND DATEPART(mm, HORA) = " + DateTime.Now.Month + " AND DATEPART(dd, HORA) = " + DateTime.Now.Day + ") AND (IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos + ", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING'))!='DONE')", conexion);
            //consulta.SelectCommand = new SqlCommand("select COUNT(DISTINCT IDCOMANDA)  from dbo.LISTACOCINA where (DATEPART(yy, HORA) = '2021' AND DATEPART(mm, HORA) = '12' AND DATEPART(dd, HORA) = '01') AND (IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos+", IIF(UDSRECIBIDAS>0, 'DONE', 'HOT'), IIF(UDSRECIBIDAS>0, 'DONE', 'WORKING'))!='DONE')", conexion);

            consulta.Fill(datos);
            if (datos.Tables[0].Rows.Count > 0) { todos = datos.Tables[0].Rows[0][0].ToString(); } else todos = "0";
            conexion.Close();

            buttonDone.Text = done;
            buttonHot.Text = hot;
            buttonWorking.Text = working;
            buttonTodos.Text = todos;
        }
        private void TiempoPromedio()
        {
            string Ptiempo = "00 MIN";

            if (MuestraDatos.Rows.Count != 0 && BDone == 0)
            {
                int suma = 0, count = int.Parse(MuestraDatos.RowCount.ToString());
                foreach (DataGridViewRow row in MuestraDatos.Rows)
                {
                    suma += (int)row.Cells[3].Value;

                }
                suma = suma / count;
                labelTiempo.Text = "" + suma + " MIN";
                labelTiempo.Visible = true;
            }
            else
            {

                labelTiempo.Text = Ptiempo;
                labelTiempo.Visible = false;
            }

        }

        private void textBoxOrden_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (ConfigurationManager.AppSettings["Version"] == "8422")
            {
                timerActualiza.Stop();
                BDone = 0;
                if (e.KeyChar == (char)(Keys.Enter))
                {
                    e.Handled = true;
                    string caracteres = textBoxOrden.Text.Trim();
                    if (string.IsNullOrEmpty(textBoxOrden.Text) || caracteres.ToString().Length < 11 || caracteres.ToString().Length > 14)
                    {

                        //MessageBox.Show("LECTURA ERRONEA INTENTA DE NUEVO " + caracteres.ToString().Length);
                        //AutoClosingMessageBox.Show("ERROR DE LECTURA INTENTA DE NUEVO "+1, "Caption", 1000);
                        labelERROR.Text = "ERROR LECTURA";
                        MsjLabelComanda("ERROR");
                        textBoxOrden.Clear();
                        timerActualiza.Start();

                        return;

                    }
                    else
                    {
                        string phrase = textBoxOrden.Text;

                        string[] words = phrase.Split('X', 'x');
                        string fechaI, Mesa, Fc1, Fc2, idComanda, tMinutos;
                        DateTime date1, date2;

                        Mesa = words[0];



                        try
                        {
                            if (words[2].Substring(6, 1).ToString() == "P" || words[2].Substring(6, 1).ToString() == "p")
                            {
                                string tiempo = words[2].Substring(0, 2).ToString() + ":" + words[2].Substring(2, 2).ToString() + ":" + words[2].Substring(4, 2).ToString() + " pm";
                                DateTime timeValue = Convert.ToDateTime(tiempo);
                                DateTime dateValue;
                                if (ConfigurationManager.AppSettings["region"] == "ENG")
                                {
                                     dateValue = Convert.ToDateTime(DateTime.Now.Month + "/" + words[1].ToString() + "/" + DateTime.Now.Year);
                                }
                                else
                                {
                                     dateValue = Convert.ToDateTime(words[1].ToString() + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                                }
                                
                                
                                fechaI = "" + dateValue.ToString("dd/MM/yyyy") + " " + timeValue.ToString("HH:mm:ss.fff");

                            }
                            else
                            {
                                string tiempo = words[2].Substring(0, 2).ToString() + ":" + words[2].Substring(2, 2).ToString() + ":" + words[2].Substring(4, 2).ToString() + " am";
                                DateTime timeValue = Convert.ToDateTime(tiempo);
                                DateTime dateValue;
                                if (ConfigurationManager.AppSettings["region"] == "ENG")
                                {
                                    dateValue = Convert.ToDateTime(DateTime.Now.Month + "/" + words[1].ToString() + "/" + DateTime.Now.Year);
                                }
                                else
                                {
                                    dateValue = Convert.ToDateTime(words[1].ToString() + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                                }
                                fechaI = "" + dateValue.ToString("dd/MM/yyyy") + " " + timeValue.ToString("HH:mm:ss.fff");


                            }

                            string fecha = DateTime.ParseExact(fechaI, "dd/MM/yyyy HH:mm:ss.fff", null).ToString("yyyy-MM-dd HH:mm:ss.fff");

                            Fc1 = fecha;
                            date1 = Convert.ToDateTime(fecha);
                            date2 = date1.AddSeconds(3);
                            fecha = date2.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            Fc2 = fecha;
                            //MessageBox.Show("Mesa> " + Mesa + "  Fecha1> " + Fc1 + "  fecha2> " + Fc2);


                            conexion.Open();
                            SqlDataAdapter consulta = new SqlDataAdapter();
                            DataSet datos = new DataSet();
                            consulta.SelectCommand = new SqlCommand("SELECT IDCOMANDA, MESA, SALA, HORA, DATEDIFF(MINUTE, HORA, GETDATE()) as MINUTOS, UDSRECIBIDAS FROM  dbo.LISTACOCINA WHERE (HORA BETWEEN CONVERT(DATETIME, '" + Fc1 + "', 102) AND CONVERT(DATETIME, '" + Fc2 + "', 102)) and (MESA = " + Mesa + ")", conexion);

                            consulta.Fill(datos);
                            conexion.Close();
                            //MessageBox.Show("" + datos.Tables[0].Rows.Count);

                            if (datos.Tables[0].Rows.Count > 0)
                            {


                                idComanda = datos.Tables[0].Rows[0][0].ToString();
                                tMinutos = datos.Tables[0].Rows[0][4].ToString();
                                

                                if (int.Parse(datos.Tables[0].Rows[0][5].ToString()) == 0)
                                {
                                    ActualizaStatus(idComanda, tMinutos);
                                    mostrarOrdenes();
                                    textBoxOrden.Clear();
                                    timerActualiza.Start();
                                    labelOK.Text = "OK";
                                    labelMesa.Text = datos.Tables[0].Rows[0][1].ToString();
                                    labelComanda.Text = "" + idComanda;
                                    MsjLabelComanda("OK");
                                }
                                else
                                {

                                    ActualizaStatus(idComanda, tMinutos);
                                    mostrarOrdenes();
                                    textBoxOrden.Clear();
                                    timerActualiza.Start();
                                    labelOK.Text = "COMANDA YA MATADA";
                                    labelMesa.Text = datos.Tables[0].Rows[0][1].ToString();
                                    labelComanda.Text = "" + idComanda;
                                    MsjLabelComanda("OK");

                                }


                            }
                            else
                            {

                                if (string.IsNullOrEmpty(textBoxOrden.Text))
                                {

                                    //AutoClosingMessageBox.Show("ERROR DE LECTURA INTENTA DE NUEVO " + 3, "Caption", 1000);
                                    labelERROR.Text = "ERROR LECTURA 2";
                                    MsjLabelComanda("ERROR");
                                    timerActualiza.Start();
                                    textBoxOrden.Clear();

                                    return;

                                }
                                else
                                {
                                    //guardaOrden(textBoxOrden.Text, DateTime.Now);
                                    //mostrarOrdenes();
                                    //textBoxOrden.Clear();
                                    //Status = "from COCINATIEMPOS where (Status != 'DONE')";

                                    labelERROR.Text = "ERROR HORA";
                                    MsjLabelComanda("ERROR");
                                    mostrarOrdenes();
                                    timerActualiza.Start();
                                    textBoxOrden.Clear();


                                }

                                mostrarOrdenes();
                                timerActualiza.Start();
                                textBoxOrden.Clear();


                            }

                        }
                        catch
                        {
                            textBoxOrden.Clear();
                            //AutoClosingMessageBox.Show("ERROR DE LECTURA INTENTA DE NUEVO "+2, "Caption", 1000);
                            labelERROR.Text = "ERROR REGION";
                            MsjLabelComanda("ERROR");
                            timerActualiza.Start();
                            conexion.Close();
                            return;
                        }


                        
                    }


                }
            }
            if (ConfigurationManager.AppSettings["Version"] == "8426") {
                timerActualiza.Stop();
                BDone = 0;
                if (e.KeyChar == (char)(Keys.Enter))
                {
                    e.Handled = true;
                    string caracteres = textBoxOrden.Text.Trim();
                    //if (string.IsNullOrEmpty(textBoxOrden.Text) || caracteres.ToString().Length < 27 || caracteres.ToString().Length > 30)   ---->>escaner datalogic
                    if (string.IsNullOrEmpty(textBoxOrden.Text) || caracteres.ToString().Length < 25 || caracteres.ToString().Length > 30)    //---->>escaner camara
                    {

                        //MessageBox.Show("LECTURA ERRONEA INTENTA DE NUEVO " + caracteres.ToString().Length);
                        labelERROR.Text = "ERROR LECTURA";
                        MsjLabelComanda("ERROR");
                        textBoxOrden.Clear();
                        timerActualiza.Start();

                    }
                    else
                    {
                        string phrase = textBoxOrden.Text;
                        string[] words = phrase.Split('_', ' ');
                        string fechaI, Mesa, Fc1, Fc2, idComanda, tMinutos;
                        DateTime date1, date2;

                        Mesa = words[0];

                        try
                        {
                            //if (words[3].Equals("p."))    //--->escaner Datalogic
                            if (words[3].Equals("p.m.") || words[3].Equals("p.")) //----->> escaner camara
                            {
                                DateTime timeValue = Convert.ToDateTime("" + words[2] + " PM");
                                fechaI = "" + words[1].ToString() + " " + timeValue.ToString("HH:mm:ss.fff");
                                //MessageBox.Show("PM");

                            }
                            else
                            {
                                DateTime timeValue = Convert.ToDateTime("" + words[2] + " AM");
                                fechaI = "" + words[1].ToString() + " " + timeValue.ToString("HH:mm:ss.fff");


                            }

                            string fecha = DateTime.ParseExact(fechaI, "dd/MM/yyyy HH:mm:ss.fff", null).ToString("yyyy-MM-dd HH:mm:ss.fff");

                            Fc1 = fecha;
                            date1 = Convert.ToDateTime(fecha);
                            date2 = date1.AddSeconds(1);
                            fecha = date2.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            Fc2 = fecha;
                            //MessageBox.Show("Mesa> " + Mesa + " Fecha1> " + Fc1 + " Fecha2> " + Fc2);


                            conexion.Open();
                            SqlDataAdapter consulta = new SqlDataAdapter();
                            DataSet datos = new DataSet();
                            consulta.SelectCommand = new SqlCommand("SELECT IDCOMANDA, MESA, SALA, HORA, DATEDIFF(MINUTE, HORA, GETDATE()) as MINUTOS,UDSRECIBIDAS FROM  dbo.LISTACOCINA WHERE (HORA BETWEEN CONVERT(DATETIME, '" + Fc1 + "', 102) AND CONVERT(DATETIME, '" + Fc2 + "', 102)) and (MESA = " + Mesa + ")", conexion);

                            consulta.Fill(datos);
                            conexion.Close();
                            //MessageBox.Show("" + datos.Tables[0].Rows.Count);

                            if (datos.Tables[0].Rows.Count > 0)
                            {


                                idComanda = datos.Tables[0].Rows[0][0].ToString();
                                tMinutos = datos.Tables[0].Rows[0][4].ToString();

                                if (int.Parse(datos.Tables[0].Rows[0][5].ToString()) == 0)
                                {
                                    ActualizaStatus(idComanda, tMinutos);
                                    mostrarOrdenes();
                                    textBoxOrden.Clear();
                                    timerActualiza.Start();
                                    labelOK.Text = "OK";
                                    labelMesa.Text = datos.Tables[0].Rows[0][1].ToString();
                                    labelComanda.Text = "" + idComanda;
                                    MsjLabelComanda("OK");
                                }
                                else {

                                    ActualizaStatus(idComanda, tMinutos);
                                    mostrarOrdenes();
                                    textBoxOrden.Clear();
                                    timerActualiza.Start();
                                    labelOK.Text = "COMANDA YA MATADA";
                                    labelMesa.Text = datos.Tables[0].Rows[0][1].ToString();
                                    labelComanda.Text = "" + idComanda;
                                    MsjLabelComanda("OK");

                                }

                            }
                            else
                            {

                                if (string.IsNullOrEmpty(textBoxOrden.Text))
                                {

                                    labelERROR.Text = "ERROR LECTURA 2";
                                    MsjLabelComanda("ERROR");
                                    timerActualiza.Start();
                                    textBoxOrden.Clear();

                                    return;
                                }
                                else
                                {
                                    //guardaOrden(textBoxOrden.Text, DateTime.Now);
                                    //mostrarOrdenes();
                                    //textBoxOrden.Clear();
                                    //Status = "from COCINATIEMPOS where (Status != 'DONE')";

                                    

                                    labelERROR.Text = "ERROR HORA";
                                    MsjLabelComanda("ERROR");
                                    mostrarOrdenes();
                                    timerActualiza.Start();
                                    textBoxOrden.Clear();


                                }

                                mostrarOrdenes();
                                timerActualiza.Start();
                                textBoxOrden.Clear();


                            }

                        }
                        catch {
                            textBoxOrden.Clear();
                            //AutoClosingMessageBox.Show("ERROR DE LECTURA INTENTA DE NUEVO "+2, "Caption", 1000);
                            labelERROR.Text = "ERROR REGION";
                            MsjLabelComanda("ERROR");
                            timerActualiza.Start();
                            conexion.Close();
                            return;
                        }

                        
                    }

                }
            } 

        }

        private void buttonTodos_Click(object sender, EventArgs e)
        {
            
            BDone = 0;
            //Status = "SELECT DISTINCT IDCOMANDA, SALA, MESA, DATEDIFF(MINUTE, HORA, GETDATE()) as MINUTOS,IIF(DATEDIFF(MINUTE, HORA, GETDATE())>"+gMinutos+", 'HOT', 'WORKING') as STATUS  FROM  dbo.LISTACOCINA where (DATEPART(yy, HORA) = '2021' AND DATEPART(mm, HORA) = '12' AND DATEPART(dd, HORA) = '01') and (UDSRECIBIDAS = 0) order by IDCOMANDA desc";
            Status = "SELECT DISTINCT IDCOMANDA, SALA, MESA, DATEDIFF(MINUTE, HORA, GETDATE()) as MINUTOS,IIF(DATEDIFF(MINUTE, HORA, GETDATE())>" + gMinutos + ", 'HOT', 'WORKING') as STATUS  FROM  dbo.LISTACOCINA where (DATEPART(yy, HORA) = " + DateTime.Now.Year + " AND DATEPART(mm, HORA) = " + DateTime.Now.Month + " AND DATEPART(dd, HORA) = " + DateTime.Now.Day + ") and (UDSRECIBIDAS = 0) order by IDCOMANDA";
            mostrarOrdenes();
            textBoxOrden.Enabled = true;
            PRINCIPAL_Click(sender,e);
        }

        private void MuestraDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.MuestraDatos.Columns[e.ColumnIndex].Name == "ESTATUS")
            {
                if (e.Value != null)
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {

                        //Stock menor a 20
                        if (e.Value.Equals("WORKING"))
                        {
                            e.CellStyle.BackColor = Color.LimeGreen;
                            e.CellStyle.ForeColor = Color.Black;
                        }
                        //Stock menor a 10
                        if (e.Value.Equals("HOT") || e.Value.Equals("OUT TIME"))
                        {
                            e.CellStyle.BackColor = Color.Red;
                            e.CellStyle.ForeColor = Color.Black;
                        }
                        if (e.Value.Equals("DONE") || e.Value.Equals("IN TIME"))
                        {
                            e.CellStyle.BackColor = Color.LimeGreen;
                            e.CellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        private void PRINCIPAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ActiveControl = textBoxOrden;
        }

        private void PRINCIPAL_Click(object sender, EventArgs e)
        {
            this.ActiveControl = textBoxOrden;
        }



        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {

            Form1_Load(sender, e);
        }

        private void MuestraDatos_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            apl = 1;
            Login frm = new Login();


            frm.Show(this);
            this.Hide();

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TimerReconecta_Tick(object sender, EventArgs e)
        {
            apl = 1;

            Application.Exit();
            Application.ExitThread();
            Application.Restart();
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            apl = 1;
            Application.Exit();
            Application.ExitThread();
        }
        public const int SW_RESTORE = 3;
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern public bool ShowWindow(IntPtr hWnd, int nCmdShow);


        private void Form1_Deactivate(object sender, EventArgs e)
        {






            if (apl == 0)
            {


                Process currentProcess = Process.GetCurrentProcess();
                var process = Process.GetProcessById(currentProcess.Id);
                ShowWindow(process.MainWindowHandle, SW_RESTORE);
                SetForegroundWindow(process.MainWindowHandle);
                this.Focus();
                this.ActiveControl = textBoxOrden;
                Class2.ejecuta();



            }



        }
        private static bool getPrevInstance()
        {
            //get the name of current process, i,e the process 
            //name of this current application

            string currPrsName = Process.GetCurrentProcess().ProcessName;

            //Get the name of all processes having the 
            //same name as this process name 
            Process[] allProcessWithThisName = Process.GetProcessesByName(currPrsName);

            //if more than one process is running return true.
            //which means already previous instance of the application 
            //is running
            if (allProcessWithThisName.Length > 1)
            {
                //MessageBox.Show("Already Running");
                return true; // Yes Previous Instance Exist
            }
            else
            {
                return false; //No Prev Instance Running
            }
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void TextBoxOrden_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBoxOrden.Text == "") {
                textBoxOrden.BackColor = Color.Red;
                
                textBoxOrden.Show();
            }
            else {
                textBoxOrden.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //this.ActiveControl = textBoxOrden;
        }

        private void LabelVersion_Click(object sender, EventArgs e)
        {

        }

        private void MuestraDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(BDone == 0)
            {
                ActualizaStatus(dgComanda, dgMinutos);
                mostrarOrdenes();
            }
        }

        private void Form1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void ButtonIngresa_Click_1(object sender, EventArgs e)
        {

        }

        private void ButtonBuscarR_Click(object sender, EventArgs e)
        {
            Fecha1 = dateTimeFecha1.Value.ToString("yyyy-MM-dd");
            Fecha2 = dateTimeFecha2.Value.ToString("yyyy-MM-dd");
            Form1_Load(sender, e);
            PRINCIPAL_Click(sender, e);
        }

        private void TabControl1_Click(object sender, EventArgs e)
        {
            ButtonBuscarR_Click(sender, e);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetDatos.LISTACOCINA' Puede moverla o quitarla según sea necesario.
            if (ConfigurationManager.AppSettings["status"] == "True")
            {
                try
                {
                    timerActualiza.Start();
                    this.LISTACOCINATableAdapter.Fill(this.DataSetDatos.LISTACOCINA, Fecha1, Fecha2);
                    this.reportViewer1.RefreshReport();
                    Class2.ejecuta();
                }
                catch (SqlException ex) {
                    pictureBoxReconectando.Visible = true;
                    labelReconectando.Visible = true;
                    timerActualiza.Stop();
                    timerReconecta.Start();
                }
            }
            else
            {
                timerActualiza.Stop();
                //MessageBox.Show("Se necesita configuarar el Servidor  ");
            }
        }
    }
}
