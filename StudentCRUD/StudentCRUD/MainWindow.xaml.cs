using System.Windows;
using System.Data;
using System.Windows.Controls;
using ParcialFinalProgramacion;

namespace StudentCRUD
{
    public partial class MainWindow : Window
    {
        private DatabaseHelper dbHelper;

        public MainWindow()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = dbHelper.GetAllStudents();
            if (dt != null)
            {
                dataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            dbHelper.AddStudent(txtCarnet.Text, txtNombre.Text, txtTelefono.Text, txtGrado.Text, cbUsuario.Text);
            LoadData();
        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            dbHelper.UpdateStudent(txtCarnet.Text, txtNombre.Text, txtTelefono.Text, txtGrado.Text, cbUsuario.Text);
            LoadData();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            dbHelper.DeleteStudent(txtCarnet.Text);
            LoadData();
        }

        private void Recuperar_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
