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

namespace gregor_bracko_pregledovalnikOglasov
{
    /// <summary>
    /// Interaction logic for pregledOglasa.xaml
    /// </summary>
    public partial class pregledOglasa : Window
    {
        public ObservableCollection<Razredi> oglas = new ObservableCollection<Razredi>();

        Razredi pridobi { get; set; }
        public pregledOglasa(Razredi pridobi)
        {
            InitializeComponent();
            this.pridobi = pridobi;
            oglas.Add(pridobi);
            lstPreglejOglas.ItemsSource = oglas;
            FindImages();
        }

        internal void FindImages()
        {
            string[] slike;
            foreach (var item in oglas)
            {
                
            }
            /*foreach (string filePath in slike)
            {
                if (System.IO.Path.GetFileNameWithoutExtension(filePath).ToLower().Contains("_70x70"))
                {
                    image1.Source = new BitmapImage(new Uri(filePath));
                }
            }*/  
        }
    }
}
