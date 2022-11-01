using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        string ruta = "C:\\Users\\nacho\\OneDrive\\Desktop\\Banco provincia csv meses\\unidos.csv";
        static List<List<string>> datos = new List<List<string>>();
        static List<Tuple<string, string, double, double>> listaDatos = new List<Tuple<string, string, double, double>>();

        public Form1()
        {
            InitializeComponent();

            datos = ObtenerDatos(ruta);
            CargarListaDatos();
            CargarDataGridView();
        }

        public void ResetDataGrid()
        {
            dataGridView1.Rows.Clear();
            listaDatos = new List<Tuple<string, string, double, double>>();
            CargarListaDatos();
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

            for(int i = 0; i < lines.Length; i++)
            {
                string[] fila = SmartSplit(lines[i]);
                datos.Add(fila.ToList());

            }

            return datos;
        }

        public static bool IsNumeric( string s)
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

        void CargarListaDatos()
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

                if (fecha.Length > 0 && descripcion.Length > 0 && importe_double > 0)
                {
                    listaDatos.Add(new Tuple<string, string, double, double>(fecha, descripcion, importe_double, saldo_double));
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

                //dataGridView1.Rows.Add(fecha, descripcion, importe_double, saldo_double);
                if (fecha.Length > 0 && descripcion.Length > 0 && importe_double > 0)
                {
                    if (descripcion.Contains(contiene))
                    {
                        listaDatos.Add(new Tuple<string, string, double, double>(fecha, descripcion, importe_double, saldo_double));
                    }
                }
            }
        }

        void CargarDataGridView()
        {

            foreach (Tuple<string, string, double, double> tuple in listaDatos)
            {
                dataGridView1.Rows.Add(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
            }
        }




        void BuscarImporte(string contiene)
        {
            double sumatoriaMercado = 0.0;

            foreach (Tuple<string, string, double, double> tuple in listaDatos)
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


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btn_sumatoria_Click(object sender, EventArgs e)
        {
            

            listaDatos = new List<Tuple<string, string, double, double>>();
            CargarListaDatos();
            BuscarImporte(txt_contiene.Text);

        }

        private void btn_carga_datagrid_Click(object sender, EventArgs e)
        {
           
            dataGridView1.Rows.Clear(); 

            listaDatos = new List<Tuple<string, string, double, double>>();
            CargarListaDatos(txt_contiene.Text);
            CargarDataGridView();

        }

        private void btn_reset_datagrid_Click(object sender, EventArgs e)
        {
            ResetDataGrid();
        }
    }
}
