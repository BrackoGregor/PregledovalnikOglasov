using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace gregor_bracko_pregledovalnikOglasov
{
    /// <summary>
    /// Interaction logic for nastavitve.xaml
    /// </summary>
    public partial class nastavitve : Window
    {
        public static string shranjevanje;
        public static double interval { get; set; }
        public nastavitve()
        {
            InitializeComponent();
        }

        private void RadioButtonShranjevanje_Checked(object sender, RoutedEventArgs e)
        {
            var rBtnShranjevanje = sender as RadioButton;
            if (rBtnShranjevanje == null)
                return;
            shranjevanje = rBtnShranjevanje.Content.ToString();
        }

        private void RadioButtonInterval_Checked(object sender, RoutedEventArgs e)
        {
            var rBtnInterval = sender as RadioButton;
            if (rBtnInterval == null)
                return;
            string sInterval = rBtnInterval.Content.ToString();
            interval = Double.Parse(sInterval);
        }

        DispatcherTimer autosaveTimer = new DispatcherTimer(TimeSpan.FromMinutes(1), DispatcherPriority.Background, new EventHandler(DoAutoSave), Application.Current.Dispatcher);

        private static void DoAutoSave(object sender, EventArgs e)
        {
            if(shranjevanje == "Vklop")
            {
                MessageBox.Show("dela");
                XmlSerializer mySerializer = new XmlSerializer(typeof(ObservableCollection<Razredi>));
                StreamWriter myWriter = new StreamWriter("oglasi.xml");
                mySerializer.Serialize(myWriter, MainWindow.listOglasov);
                myWriter.Close();
            }
        }
    }
}
