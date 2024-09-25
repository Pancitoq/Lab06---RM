using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab06_RM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Crear_Click(object sender, RoutedEventArgs e)
        {
            Crear crearWindow = new Crear();
            crearWindow.Show();
        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            Actualizar actualizarWindow = new Actualizar();
            actualizarWindow.Show();
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            Borrar borrarWindow = new Borrar();
            borrarWindow.Show();
        }

        private void Listar_Click(object sender, RoutedEventArgs e)
        {
            Listar listarWindow = new Listar();
            listarWindow.Show();
        }
    }
}