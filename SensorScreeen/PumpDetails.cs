using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SensorScreeen
{
  
    public partial class PumpDetails : DevComponents.DotNetBar.Metro.MetroForm
    {
        public string CurrPumpStr;
        Prueba CurrProv;
        public PumpDetails(Prueba CurrProv1,string CurrPumpStr1)
        {
            InitializeComponent();
            CurrPumpStr = CurrPumpStr1;
            CurrProv = CurrProv1;

        }

        private void PumpDetails_Load(object sender, EventArgs e)
        {
            if (CurrProv.Cabezales == 1) this.Width = 240;
            else this.Width = 471;
            foreach (string num in CurrProv.Numeros.Keys)
            {
                if (CurrProv.Numeros[num][0].EndCaudal)
                {
                    comboNumerosSerie.Items.Add(num);
                }
            }
            comboNumerosSerie.Text = CurrPumpStr;
            loadNumSerie();
        }
        public void loadNumSerie()
        {
            try
            {
                Cab1Caudal.Text = Math.Round(CurrProv.Numeros[CurrPumpStr][0].Caudal, 2).ToString();
                Cab1VacioMax.Text = Math.Round(CurrProv.Numeros[CurrPumpStr][0].VacioM, 2).ToString();
                Cab1VacioE1.Text = Math.Round(CurrProv.Numeros[CurrPumpStr][0].VacioE1, 2).ToString();
                Cab1VacioE2.Text = Math.Round(CurrProv.Numeros[CurrPumpStr][0].VacioE2, 2).ToString();
                Cab1Perdida.Text = Math.Round(CurrProv.Numeros[CurrPumpStr][0].Perdida, 2).ToString();
                if (CurrProv.Cabezales == 2)
                {
                    Cab2Caudal.Text = Math.Round(CurrProv.Numeros[CurrPumpStr][1].Caudal, 2).ToString();
                    Cab2VacioMax.Text = Math.Round(CurrProv.Numeros[CurrPumpStr][1].VacioM, 2).ToString();
                    Cab2VacioE1.Text = Math.Round(CurrProv.Numeros[CurrPumpStr][1].VacioE1, 2).ToString();
                    Cab2VacioE2.Text = Math.Round(CurrProv.Numeros[CurrPumpStr][1].VacioE2, 2).ToString();
                    Cab2Perdida.Text = Math.Round(CurrProv.Numeros[CurrPumpStr][1].Perdida, 2).ToString();
                }
            }
            catch (Exception) { }
        }

        private void comboNumerosSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrPumpStr = comboNumerosSerie.Text;
            loadNumSerie();
        }
    }
}