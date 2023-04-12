using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlUsuarios
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //lista todos los usuarios
            listDatos();

        }
        //lista todos los usuarios
        private void listDatos()
        {
            try
            {
                SqlConnection thisConnection = new SqlConnection(@"Server=DESKTOP-DOLID7H\MSSQLSERVER01;Database=DatosPersonales;Trusted_Connection=True;Encrypt=False");
                thisConnection.Open();
                //realiza la consulta de los datos
                string Get_Data = "SELECT Id_Usuario #, Nombre, Apellido  FROM Usuarios";

                SqlCommand cmd = thisConnection.CreateCommand();
                cmd.CommandText = Get_Data;

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Usuarios");
                sda.Fill(dt);
               
                DGDatosPersonales.ItemsSource = dt.DefaultView;

               
               
            }
            catch
            {
                MessageBox.Show("error al conectar a la bd ");
            }
        }
        
    }
}
