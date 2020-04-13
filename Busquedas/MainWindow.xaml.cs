using System;
using System.Collections.Generic;
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

namespace Busquedas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<City> totalCities;
        private CitiesDb cities = new CitiesDb();
        public String text;
        public MainWindow()
        {
            totalCities = cities.getCitiesList();
            InitializeComponent();
            cbStart.ItemsSource = totalCities;
            cbDestiny.ItemsSource = totalCities;
            cbStart.DisplayMemberPath = "CityName";
            cbDestiny.DisplayMemberPath = "CityName";
            cities.tbResult = tbResult;
            cities.tbOrder = tbOrder;
        }

        private void btDFS_Click(object sender, RoutedEventArgs e)
        {
            if (cbStart.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una ciudad de inicio");
            }else if (cbDestiny.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una ciudad de destino");
            }
            else
            { 
                cities.DFSSearchInterface((City)cbStart.SelectedValue, (City)cbDestiny.SelectedValue);
            }
        }

        private void btTraverseDFS_Click(object sender, RoutedEventArgs e)
        {
            if (cbStart.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una ciudad de inicio");
            }
            else
            {
                cities.DFSTraverseInterface((City)cbStart.SelectedValue);
            }
        }

        private void bt_Click(object sender, RoutedEventArgs e)
        {
            if (cbStart.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una ciudad de inicio");
            }
            else if (cbDestiny.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una ciudad de destino");
            }
            else
            {
                cities.UCSInterface((City)cbStart.SelectedValue, (City)cbDestiny.SelectedValue);
            }
        }
    }
}
