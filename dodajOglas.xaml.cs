using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Xml.Serialization;
using static gregor_bracko_pregledovalnikOglasov.Razredi;

namespace gregor_bracko_pregledovalnikOglasov
{
    /// <summary>
    /// Interaction logic for dodajOglas.xaml
    /// </summary>
    public partial class dodajOglas : Window
    {
        public string tip;
        public string menjalnik;
        public string gorivo;
        string slika1;
        List<string> slike1 = new List<string>();

        public dodajOglas()
        {
            InitializeComponent();
        }

        private void RadioButtonTip_Checked(object sender, RoutedEventArgs e)
        {
            var rBtnTip = sender as RadioButton;
            if (rBtnTip == null)
                return;
            tip = rBtnTip.Content.ToString();
            //MessageBox.Show(stanje.ToString(CultureInfo.InvariantCulture));
        }

        private void RadioButtonMenjalnik_Checked(object sender, RoutedEventArgs e)
        {
            var rbtnMenjalnik = sender as RadioButton;
            if (rbtnMenjalnik == null)
                return;
            menjalnik = rbtnMenjalnik.Content.ToString();
            //MessageBox.Show(menjalnik.ToString(CultureInfo.InvariantCulture));
        }

        private void RadioButtonGorivo_Checked(object sender, RoutedEventArgs e)
        {
            var rbtnGorivo = sender as RadioButton;
            if (rbtnGorivo == null)
                return;
            gorivo = rbtnGorivo.Content.ToString();
            //MessageBox.Show(gorivo.ToString(CultureInfo.InvariantCulture));
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            //prodajalec
            string ime = txtBoxIme.Text;
            string priimek = txtBoxPriimek.Text;
            string naslov = txtBoxNaslov.Text;
            string zPostna = txtBoxPosta.Text;
            int postna = Int32.Parse(zPostna);
            string kraj = txtBoxKraj.Text;
            string zTelefon = txtBoxTelefon.Text;
            int telefon = Int32.Parse(zTelefon);

            //prevozno sredstvo
            string znamka = txtBoxZnamka.Text;
            string model = txtBoxModel.Text;
            string zLetnik = txtBoxLetnik.Text;
            int letnik = Int32.Parse(zLetnik);
            string zCena = txtBoxCena.Text;
            int cena = Int32.Parse(zCena);

            if (ime == "" || priimek == "" || naslov == "" || postna == 0 || kraj == "" || telefon == 0)
            {
                MessageBox.Show("Podatki o prodajalcu niso izpolnjeni!");
            }
            else if(znamka == "" || model == "" || letnik == 0 || cena == 0)
            {
                MessageBox.Show("Podatki o vozilu niso izpolnjeni!");
            }
            else
            {
                Prodajalec prodajalec = new Prodajalec() { ime=ime, priimek= priimek, naslov= naslov, postna=postna, kraj= kraj, telefon= telefon };
                Avtomobil avtomobil = new Avtomobil() { znamka= znamka, model= model, letnik= letnik, cena= cena, tip= tip, menjalnik= menjalnik, gorivo= gorivo, slika = slika1, slike = slike1 };
                Razredi skupaj = new Razredi(DateTime.Now, avtomobil, prodajalec);
                MainWindow.listOglasov.Add(skupaj);

                this.Close();
            }
        }

        private void slika_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Izberite naslovno sliko";
            op.Filter = "Formati slik|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                var pot = op.FileName;
                slika1 = pot.ToString();
            }
        }

        private void imgPhoto_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Izberite slike";
            op.Filter = "Formati slik|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            op.Multiselect = true;

            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                slike1.Add(op.FileNames.ToString());
            }
        }
    }
}
