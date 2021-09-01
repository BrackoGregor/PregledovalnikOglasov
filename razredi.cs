using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace gregor_bracko_pregledovalnikOglasov
{
    public class Razredi : INotifyPropertyChanged
    {
        public DateTime cas { get; set; }
        public Avtomobil avtomobil { get; set; }
        public Prodajalec prodajalec { get; set; }

        public Razredi() { }
        public Razredi(DateTime cas, Avtomobil avtomobil, Prodajalec prodajalec)
        {
            this.cas = cas;
            this.avtomobil = avtomobil;
            this.prodajalec = prodajalec;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        public class Avtomobil:Razredi
        {
            public List<string> slike = new List<string>();

            private string _znamka;
            public string znamka
            {
                get { return _znamka; }
                set { _znamka = value; OnPropertyChanged(new PropertyChangedEventArgs("")); }
            }

            private string _model;
            public string model
            {
                get { return _model; }
                set { _model = value; OnPropertyChanged(new PropertyChangedEventArgs("")); }
            }

            private int _letnik;
            public int letnik
            {
                get { return _letnik; }
                set { _letnik = value; OnPropertyChanged(new PropertyChangedEventArgs("")); }
            }

            private int _cena;
            public int cena
            {
                get { return _cena; }
                set { _cena = value; OnPropertyChanged(new PropertyChangedEventArgs("")); }
            }

            private string _tip;
            public string tip
            {
                get { return _tip; }
                set { _tip = value; OnPropertyChanged(new PropertyChangedEventArgs("")); }
            }

            private string _menjalnik;
            public string menjalnik
            {
                get { return _menjalnik; }
                set { _menjalnik = value; OnPropertyChanged(new PropertyChangedEventArgs("")); }
            }

            private string _gorivo;
            public string gorivo
            {
                get { return _gorivo; }
                set { _gorivo = value; OnPropertyChanged(new PropertyChangedEventArgs("")); }
            }

            private string _slika;
            public string slika
            {
                get { return _slika; }
                set { _slika = value; OnPropertyChanged(new PropertyChangedEventArgs("")); }
            }

            /*private string[] _slike;
            public string[] slike
            {
                get { return _slike; }
                set { _slike = value; OnPropertyChanged(new PropertyChangedEventArgs("")); }
            }*/

            public Avtomobil() { }

            public string preveriSliko()
            {
                if(slika == null)
                {
                    if(tip == "Avtomobil")
                    {
                        return "Avtomobil";
                    }
                    else
                    {
                        return "Motorno kolo";
                    }
                }
                return "slika";
            }
        }

        public class Prodajalec:Razredi
        {
            private string _ime;
            public string ime
            {
                get { return _ime; }
                set { _ime = value; OnPropertyChanged(new PropertyChangedEventArgs("")); }
            }

            private string _priimek;
            public string priimek
            {
                get { return _priimek; }
                set { _priimek = value; OnPropertyChanged(new PropertyChangedEventArgs("")); }
            }

            private string _naslov;
            public string naslov
            {
                get { return _naslov; }
                set { _naslov = value; OnPropertyChanged(new PropertyChangedEventArgs("")); }
            }

            private int _postna;
            public int postna
            {
                get { return _postna; }
                set { _postna = value; OnPropertyChanged(new PropertyChangedEventArgs("")); }
            }

            private string _kraj;
            public string kraj
            {
                get { return _kraj; }
                set { _kraj = value; OnPropertyChanged(new PropertyChangedEventArgs("")); }
            }

            private int _telefon;
            public int telefon
            {
                get { return _telefon; }
                set { _telefon = value; OnPropertyChanged(new PropertyChangedEventArgs("")); }
            }

            public Prodajalec() { }

        }
    }
}
