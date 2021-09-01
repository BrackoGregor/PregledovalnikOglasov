using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace gregor_bracko_pregledovalnikOglasov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Razredi> listOglasov = new ObservableCollection<Razredi>();
        string gorivo;
        string menjalnik;

        public MainWindow()
        {
            InitializeComponent();
            naloziObZagonu();
        }

        private void naloziObZagonu()
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(ObservableCollection<Razredi>)); 
            StreamReader myReader = new StreamReader(@"C:\Users\Gregor\Desktop\2.letnik\UV\gregor_bracko_pregledovalnikOglasov\gregor_bracko_pregledovalnikOglasov\bin\Debug\oglasi.xml");
            listOglasov = (ObservableCollection<Razredi>)mySerializer.Deserialize(myReader);
            myReader.Close();
            lstOglasi.ItemsSource = listOglasov;
        }

        private void izhod_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            dodajOglas dodajOglas = new dodajOglas();
            dodajOglas.Show();
        }

        private void izvozi_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(ObservableCollection<Razredi>));
                // To write to a file, create a StreamWriter object.  
                StreamWriter myWriter = new StreamWriter(saveFileDialog.FileName);
                mySerializer.Serialize(myWriter, listOglasov);
                myWriter.Close();
            }
        }

        private void nalozi_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Izberite datoteko";
            op.Filter = "XML Files (*.xml)|*.xml";
            op.ShowDialog();

            XmlSerializer mySerializer = new XmlSerializer(typeof(ObservableCollection<Razredi>));
            // To write to a file, create a StreamWriter object.  
            StreamReader myReader = new StreamReader(op.FileName);
            listOglasov =  (ObservableCollection<Razredi>)mySerializer.Deserialize(myReader);
            myReader.Close();
            lstOglasi.ItemsSource = listOglasov;
        }

        private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
        {
            Razredi pridobi = (Razredi)lstOglasi.SelectedItem;

            if(pridobi == null)
            {
                MessageBox.Show("Niste izbrali oglasa!");
            }
            else
            {
                listOglasov.Remove(pridobi);
            }            
        }

        private void lstOglasi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Razredi pridobi = (Razredi)lstOglasi.SelectedItem;

            foreach (var item in listOglasov)
            {
                if(pridobi.avtomobil.model == item.avtomobil.model)
                {
                    pregledOglasa pregledOglasa = new pregledOglasa(pridobi);
                    pregledOglasa.ShowDialog();
                }
            }
        }        

        private void nastavitve_Click(object sender, RoutedEventArgs e)
        {
            nastavitve nastavitveOkno = new nastavitve();
            nastavitveOkno.ShowDialog();
        }

        private void RadioButtonGorivo_Checked(object sender, RoutedEventArgs e)
        {
            var rbtnGorivo = sender as RadioButton;
            if (rbtnGorivo == null)
                return;
            gorivo = rbtnGorivo.Content.ToString();
            //MessageBox.Show(gorivo.ToString(CultureInfo.InvariantCulture));
        }

        private void RadioButtonMenjalnik_Checked(object sender, RoutedEventArgs e)
        {
            var rbtnMenjalnik = sender as RadioButton;
            if (rbtnMenjalnik == null)
                return;
            menjalnik = rbtnMenjalnik.Content.ToString();
            //MessageBox.Show(gorivo.ToString(CultureInfo.InvariantCulture));
        }

        private void btnIsci_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Razredi> oglasi = new ObservableCollection<Razredi>();
            if (txtBoxIsci.Text != "")
            {
                Razredi oglas = listOglasov.Where(x => x.avtomobil.znamka == txtBoxIsci.Text).First();
                oglasi.Add(oglas);

                lstOglasi.ItemsSource = null;
                lstOglasi.ItemsSource = oglasi;
            }
            else
            {
                Razredi oglas1 = listOglasov.Where(x => x.avtomobil.gorivo == gorivo).First();
                Razredi oglas2 = listOglasov.Where(x => x.avtomobil.menjalnik == menjalnik).First();
                oglasi.Add(oglas1);
                oglasi.Add(oglas2);

                lstOglasi.ItemsSource = null;
                lstOglasi.ItemsSource = oglasi;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtBoxIsci.Clear();
            lstOglasi.ItemsSource = null;
            lstOglasi.ItemsSource = listOglasov;
        }

        private void pogled1_Click(object sender, RoutedEventArgs e)
        {
            pogled1.SetValue(Grid.ColumnProperty, 0);
            pogled2.SetValue(Grid.ColumnProperty, 1);
        }

        private void pogled2_Click(object sender, RoutedEventArgs e)
        {
            pogled1.SetValue(Grid.ColumnProperty, 1);
            pogled2.SetValue(Grid.ColumnProperty, 0);
        }
    }
}

