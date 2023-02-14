namespace osiguranje;
using osiguranje.models;

public partial class MainPage : ContentPage
{
	public List<VrstaOsiguranja> listVrstaOsiguranja { get; set; }
	public List<KlasaOsiguranja> listKlasaOsiguranja { get; set; }


	public MainPage()
	{
		InitializeComponent();
		uneseniDatum.Date = DateTime.Today;

		listVrstaOsiguranja = new List<VrstaOsiguranja>
		{
            new VrstaOsiguranja {id=1, Naziv="PUTNO OSIGURANJE", OsiguranaSumaPoUsluzi=2000, Cijena=2.0f},
            new VrstaOsiguranja {id=2, Naziv="OSIGURANJE STANA", OsiguranaSumaPoUsluzi=4000, Cijena=4.0f},
            new VrstaOsiguranja {id=3, Naziv="ZDRAVSTVENO \n OSIGURANJE", OsiguranaSumaPoUsluzi=5000, Cijena=5.0f},
            new VrstaOsiguranja {id=4, Naziv="ASISTENCIJA NA PUTU", OsiguranaSumaPoUsluzi=1000, Cijena=50.0f},
            new VrstaOsiguranja {id=5, Naziv="MALI \n KASKO", OsiguranaSumaPoUsluzi=1000, Cijena=500.0f},
            new VrstaOsiguranja {id=6, Naziv="OSIGURANJE MOBITELA", OsiguranaSumaPoUsluzi=2000, Cijena=50.0f}


        };

		listKlasaOsiguranja = new List<KlasaOsiguranja>
		{
            new KlasaOsiguranja {id=1, NazivKlase="Osnovna", FaktorOsiguraneSume=1, FaktorCijene=1},
            new KlasaOsiguranja {id=2, NazivKlase="Plus", FaktorOsiguraneSume=2, FaktorCijene=3},
            new KlasaOsiguranja {id=3, NazivKlase="Premium", FaktorOsiguraneSume=3, FaktorCijene=5}


        };

        BindingContext = this;

        osiguranje1.Text = listVrstaOsiguranja[0].Naziv;

        osiguranje2.Text = listVrstaOsiguranja[1].Naziv;

        osiguranje3.Text = listVrstaOsiguranja[2].Naziv;

        osiguranje4.Text = listVrstaOsiguranja[3].Naziv;

        osiguranje5.Text = listVrstaOsiguranja[4].Naziv;

        osiguranje6.Text = listVrstaOsiguranja[5].Naziv;

        klasa.ItemsSource = listKlasaOsiguranja;


    }

    private void Button_Clicked(object sender, EventArgs e)
    {

        KlasaOsiguranja klasaOsiguranja = (KlasaOsiguranja)klasa.SelectedItem;


        if ((check1.IsChecked == true && KilometriEntry.Text is null) || (check1.IsChecked == false && KilometriEntry.Text is not null))
        {
            DisplayAlert("GREŠKA", "Provjerite podatke.", "OK");
        }
        else if ((check2.IsChecked == true && KvadrataEntry.Text is null) || (check2.IsChecked == false && KvadrataEntry.Text is not null))
        {
            DisplayAlert("GREŠKA", "Provjerite podatke.", "OK");
        }
        else if ((check3.IsChecked == true && OsobaEntry.Text is null) || (check3.IsChecked == false && OsobaEntry.Text is not null))
        {
            DisplayAlert("GREŠKA", "Provjerite podatke.", "OK");
        }
        else if ((check4.IsChecked == true && AutomobilaEntry.Text is null) || (check4.IsChecked == false && AutomobilaEntry.Text is not null))
        {
            DisplayAlert("GREŠKA", "Provjerite podatke.", "OK");
        }
        else if ((check5.IsChecked == true && AutomobilaKaskoEntry.Text is null) || (check4.IsChecked == false && AutomobilaKaskoEntry.Text is not null))
        {
            DisplayAlert("GREŠKA", "Provjerite podatke.", "OK");
        }
        else if ((check6.IsChecked == true && MobitelaEntry.Text is null) || (check4.IsChecked == false && MobitelaEntry.Text is not null))
        {
            DisplayAlert("GREŠKA", "Provjerite podatke.", "OK");
        }
        else if (klasa.SelectedItem is null)
        {
            DisplayAlert("GRESKA", "Nije odabrana klasa osiguranja", "OK");
        }

        else 
        {

            int trajanje = int.Parse(MjeseciEntry.Text);
            
            int br = 0;

            int kol1 = 0;
            int kol2 = 0;
            int kol3 = 0;
            int kol4 = 0;
            int kol5 = 0;
            int kol6 = 0;

            float cijena = 0;
            float porodicnaCijena = 0;

            float baznaosiguranasuma = 0;

            float baznaosiguranasuma1 = 0;
            float baznaosiguranasuma2 = 0;
            float baznaosiguranasuma3 = 0;
            float baznaosiguranasuma4 = 0;
            float baznaosiguranasuma5 = 0;
            float baznaosiguranasuma6 = 0;

            float cijena1 = 0;
            float cijena2 = 0;
            float cijena3 = 0;
            float cijena4 = 0;
            float cijena5 = 0;
            float cijena6 = 0;

            float cijena1m = listVrstaOsiguranja[0].Cijena / 12;
            float cijena2m = listVrstaOsiguranja[1].Cijena / 12;
            float cijena3m = listVrstaOsiguranja[2].Cijena / 12;
            float cijena4m = listVrstaOsiguranja[3].Cijena / 12;
            float cijena5m = listVrstaOsiguranja[4].Cijena / 12;
            float cijena6m = listVrstaOsiguranja[5].Cijena / 12;



            if (check1.IsChecked)
            {
                kol1=int.Parse(KilometriEntry.Text);
                br++;
            }

            if (check2.IsChecked)
            {
                kol2 = int.Parse(KvadrataEntry.Text);
                br++;
            }
            if (check3.IsChecked)
            {
                kol3 = int.Parse(OsobaEntry.Text);
                br++;
            }
            if (check4.IsChecked)
            {
                kol4 = int.Parse(AutomobilaEntry.Text);
                br++;
            }
            if (check5.IsChecked)
            {
                kol5 = int.Parse(AutomobilaKaskoEntry.Text);
                br++;
            }
            if (check6.IsChecked)
            {
                kol6 = int.Parse(MobitelaEntry.Text);
                br++;

            }


            if (kol1 > 0)
            {

                cijena1 = cijena1 + (cijena1m * trajanje) * kol1;
                baznaosiguranasuma1 = baznaosiguranasuma1 + (cijena1m * listVrstaOsiguranja[0].OsiguranaSumaPoUsluzi);

            }
            else
            {
                cijena1 = 0;
            }


            if (kol2 > 0)
            {

                cijena2 = cijena2 + (cijena2m * trajanje) * kol2;
                baznaosiguranasuma2 = baznaosiguranasuma2 + (cijena2m * listVrstaOsiguranja[1].OsiguranaSumaPoUsluzi);
            }
            else
            {
                cijena2 = 0;
            }


            if (kol3 > 0)
            {

                cijena3 = cijena3 + (cijena3m * trajanje) * kol3;
                baznaosiguranasuma3 = baznaosiguranasuma3 + (cijena3m * listVrstaOsiguranja[2].OsiguranaSumaPoUsluzi);
            }
            else
            {
                cijena3 = 0;
            }

            if (kol4 > 0)
            {

                cijena4 = cijena4 + (cijena4m * trajanje) * kol4;
                baznaosiguranasuma4 = baznaosiguranasuma4 + (cijena4m * listVrstaOsiguranja[3].OsiguranaSumaPoUsluzi);
            }
            else
            {
                cijena4 = 0;
            }

            if (kol5 > 0)
            {

                cijena5 = cijena5 + (cijena5m * trajanje) * kol5;
                baznaosiguranasuma5 = baznaosiguranasuma5 + (cijena5m * listVrstaOsiguranja[4].OsiguranaSumaPoUsluzi);
            }
            else
            {
                cijena5 = 0;
            }

            if (kol6 > 0)
            {

                cijena6 = cijena6 + (cijena6m * trajanje) * kol6;
                baznaosiguranasuma6 = baznaosiguranasuma6 + (cijena6m * listVrstaOsiguranja[5].OsiguranaSumaPoUsluzi);
            }
            else
            {
                cijena6 = 0;
            }


            cijena = cijena1 + cijena2 + cijena3 + cijena4 + cijena5 + cijena6;
            baznaosiguranasuma = baznaosiguranasuma1 + baznaosiguranasuma2 + baznaosiguranasuma3 + baznaosiguranasuma4 + baznaosiguranasuma5 + baznaosiguranasuma6;


            if (klasaOsiguranja.NazivKlase == listKlasaOsiguranja[0].NazivKlase)
            {
                cijena = cijena * listKlasaOsiguranja[0].FaktorCijene;
            }
            else if (klasaOsiguranja.NazivKlase == listKlasaOsiguranja[1].NazivKlase)
            {
                cijena = cijena * listKlasaOsiguranja[1].FaktorCijene;
            }
            else
            {
                cijena = cijena * listKlasaOsiguranja[2].FaktorCijene;
            }


            if (OsiguranjeSwitch.IsToggled)
            {
                porodicnaCijena = cijena + (cijena - (cijena * 0.7f));
            }


            String ispis;

            if (OsiguranjeSwitch.IsToggled)
            {
                ispis = "Ukljuceno";
            }
            else
            {
                ispis = "Nije ukljuceno";
            }

            string poruka = "POLICA OSIGURANJA" +
                            "\r\nUkupna vrijednost osiguranja: " + cijena.ToString() + " KM" +
                            "\r\nBroj odabranih vrsta osiguranja: " + br +
                            "\r\nPorodicni paket:" + ispis +
                            "\r\nOsigurana suma: " + baznaosiguranasuma +
                            "\r\nBroj mjeseci osiguranja: " + trajanje;

            DisplayAlert("Kalkulacija usluge", poruka, "OK");

            //+ "\r\nBroj mjeseci " + mjeseci + "\r\n Datum od "+ uneseniDatum.Date.ToShortDateString() + "do "+uneseniDatum.Date.AddMonths(mjeseci).ToShortDateString();










        }



    }
}

