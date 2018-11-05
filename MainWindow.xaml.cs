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

namespace SolarSystem
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private dataAccess database = new dataAccess();

        public MainWindow()
        {
            InitializeComponent();
            fill_combo();
        }

        private void fill_combo()
        {
            List<Planet> planets = database.GetAllPlanets();

            foreach (Planet planet in planets)
            {
                planetListingComboBox.Items.Add(planet);
            }
        }

        private void planetListingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // planetListing.Text = database.GetIndividualPlanet().ToString();
        }
    }
}
