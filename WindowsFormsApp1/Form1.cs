using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private string ruta;
        private List<List<string>> datos = new List<List<string>>();
        private List<Tuple<DateTime, string, double, double>> listaDatos = new List<Tuple<DateTime, string, double, double>>();
        private DateTime FechaInicio;
        private DateTime FechaFin;
  


        public Form1()
        {
            InitializeComponent();

            FechaInicio = new DateTime (2000, 1, 1);
            FechaFin = DateTime.Now;


            openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a CSV file",
                Filter = "Csv files (*.csv)|*.CSV",
                Title = "Open .csv file"
            };

            ResetDataGrid();

            txt_inicio.Enabled = false;
            txt_fin.Enabled = false;
            radioButton1.Checked = true;
            radioButton2.Checked = false;
        }

        public void ResetDataGrid()
        {
            dataGridView1.Rows.Clear();
            listaDatos = new List<Tuple<DateTime, string, double, double>>();
            CargarListaDatos(txt_contiene.Text);
            CargarDataGridView();
        }

        private static string[] SmartSplit(string line, char separator = ',')
        {
            var inQuotes = false;
            var token = "";
            var lines = new List<string>();
            for (var i = 0; i < line.Length; i++)
            {
                var ch = line[i];
                if (inQuotes) // process string in quotes, 
                {
                    if (ch == '"')
                    {
                        if (i<line.Length-1 && line[i + 1] == '"')
                        {
                            i++;
                            token += '"';
                        }
                        else inQuotes = false;
                    }
                    else token += ch;
                }
                else
                {
                    if (ch == '"') inQuotes = true;
                    else if (ch == separator)
                    {
                        lines.Add(token);
                        token = "";
                    }
                    else token += ch;
                }
            }
            lines.Add(token);
            return lines.ToArray();
        }

        public static List<List<string>> ObtenerDatos(string ruta)
        {

            string[] lines = System.IO.File.ReadAllLines(ruta);

            List<List<string>> datos = new List<List<string>>();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] fila = SmartSplit(lines[i]);
                datos.Add(fila.ToList());

            }

            return datos;
        }

        public static bool IsNumeric(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c) && c != '.' && c != ',')
                {
                    return false;
                }
            }

            return true;
        }

        DateTime ParsearFecha(string fecha)
        {

            string[] meses = { "ene", "feb", "mar", "abr", "may", "jun", "jul", "ago", "sep", "oct", "nov", "dic" };


            string[] arr = fecha.Split('-');

            if (arr.Length < 3) return DateTime.MinValue;

            int dia = int.Parse(arr[0]);

            string mes_str = arr[1];
            int mes = 0;


            for (int i = 0; i<meses.Length; i++)
            {
                if (meses[i] == mes_str.ToLower())
                {
                    mes = i+1;
                    break;
                }
            }

            int an = int.Parse(arr[2]);


            return new DateTime(an, mes, dia);

        }


        void AgregarALista(string contiene, DateTime FechaDateTime, string descripcion, double importe_double, double saldo_double)
        {

            if (FechaDateTime >= FechaInicio && FechaDateTime <= FechaFin)
            {
                if (!string.IsNullOrEmpty(contiene))
                {
                    if (descripcion.Contains(contiene))
                    {
                        listaDatos.Add(new Tuple<DateTime, string, double, double>(FechaDateTime, descripcion, importe_double, saldo_double));
                    }
                }
                else
                {
                    listaDatos.Add(new Tuple<DateTime, string, double, double>(FechaDateTime, descripcion, importe_double, saldo_double));
                }
            }
        }



        void CargarListaDatos(string contiene)
        {
            foreach (List<string> fila in datos)
            {
                string fecha = fila[0];
                string descripcion = fila[1];
                string importe = fila[2].TrimStart('-');
                string saldo = fila[3].TrimStart('-');

                double importe_double = 0.0;
                double saldo_double = 0.0;

                if (importe.Length > 0  && IsNumeric(importe))
                {
                    importe_double = double.Parse(importe);
                }
                if (saldo.Length > 0 && IsNumeric(saldo))
                {
                    saldo_double = double.Parse(saldo);
                }

                DateTime FechaDateTime = ParsearFecha(fecha);

                if (fecha.Length > 0 && descripcion.Length > 0 && importe_double > 0)
                {
                    AgregarALista(contiene, FechaDateTime, descripcion, importe_double, saldo_double);
                }
            }
        }

        void CargarDataGridView()
        {
            MessageBox.Show("Fecha inicio: " + FechaInicio + " Fecha fin: " + FechaFin);
            foreach (Tuple<DateTime, string, double, double> tuple in listaDatos)
            {
                dataGridView1.Rows.Add(tuple.Item1.ToShortDateString(), tuple.Item2, tuple.Item3, tuple.Item4);
            }
        }




        void BuscarImporte(string contiene)
        {
            double sumatoriaMercado = 0.0;

            foreach (Tuple<DateTime, string, double, double> tuple in listaDatos)
            {
                if (tuple.Item2.Contains(contiene))
                {
                    sumatoriaMercado += tuple.Item3;
                }
            }

            lbl_importe_buscado.Text = sumatoriaMercado.ToString();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //Fecha,Descripción,Importe,Saldo

            ResetDataGrid();


        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btn_sumatoria_Click(object sender, EventArgs e)
        {


            listaDatos = new List<Tuple<DateTime, string, double, double>>();
            CargarListaDatos(txt_contiene.Text);
            BuscarImporte(txt_contiene.Text);
            // CargarDataGridView();
        }

        private void btn_carga_datagrid_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            listaDatos = new List<Tuple<DateTime, string, double, double>>();
            CargarListaDatos(txt_contiene.Text);
            CargarDataGridView();
        }

        private void btn_reset_datagrid_Click(object sender, EventArgs e)
        {
            ResetDataGrid();

        }

        private void btnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    using (Stream str = openFileDialog1.OpenFile())
                    {
                        // Process.Start("notepad.exe", filePath);
                        ruta = filePath;

                        datos = ObtenerDatos(ruta);
                        ResetDataGrid();

                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }



        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (radioButton1.Checked)
            {
                FechaInicio = monthCalendar1.SelectionRange.Start;
                txt_inicio.Text = FechaInicio.ToShortDateString();

            }
            if (radioButton2.Checked)
            {
                FechaFin = monthCalendar1.SelectionRange.Start;
                txt_fin.Text = FechaFin.ToShortDateString();

            }
            if (txt_inicio.Text.Length > 0 && txt_fin.Text.Length > 0 && FechaInicio > FechaFin)
            {
                FechaFin = FechaInicio;
                txt_fin.Text = FechaFin.ToShortDateString();
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final");
            }
        }



    }
}
