using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SensorScreeen
{
    public struct SensType {
        public int index;
        public string name;
    }

    public class ValorsCab {
        public float Caudal =0;
        public float VacioM =0;
        public float VacioE1=0;
        public float VacioE2=0;    
        public float Perdida=0;
        public bool EndCaudal = false;
        public bool EndVacioM = false;
        public bool EndVacioE1 = false;
        public bool EndVacioE2 = false;

        public int TimeVacMax;
        public int TimeEst;
        public int TimePerdida;
        public ValorsCab(int TiempoVacioMaximo = 10, int TiempoEstabilizado=10, int TiempoPerdida= 5)
        {
            TimeVacMax = TiempoVacioMaximo;
            TimeEst = TiempoEstabilizado;
            TimePerdida = TiempoPerdida;
        }
        public void SetTime(int TiempoVacioMaximo, int TiempoEstabilizado, int TiempoPerdida)
        {
            TimeVacMax = TiempoVacioMaximo;
            TimeEst = TiempoEstabilizado;
            TimePerdida = TiempoPerdida;
        }
    }
    public class Prueba
    {
        //ELEMENTOS PUBLICOS DE LA CLASSE

        public Dictionary<string, float> ValoresTotal = new Dictionary<string, float>() { { "CaudalMax", 0 }, { "CaudalMin", 0 }, { "VacioMax",0}, { "VacioMin", 0 }, { "VacioEstMax", 0 }, { "VacioEstMin", 0 }, { "VacioPerMax", 0 }, { "VacioPerMin", 0 } };
        public Dictionary<string,List<ValorsCab>> Numeros = new Dictionary<string,List<ValorsCab>>();
        public List<SensType > Sensors = new List<SensType>();
        public string CodigoArticulo;
        public string DescripcionArticulo;
        public int EjTra;
        public int NumTra;
        public int VoltageType; //0 para AC y 1 para DC
        public int Voltage;
        public int Cabezales;
        //ELEMENTOS DE CONTROL
        private System.ComponentModel.IContainer components = null;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource articulosBindingSource;
        private DataSet1TableAdapters.ArticulosTableAdapter articulosTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        
        public Prueba()
        {
            CargarTable();
           
        }
        public void InitVars(string CodArt)
        {
            //Aqui parseamos

            this.CodigoArticulo = CodArt;
            articulosTableAdapter.FillByCodArt(this.dataSet1.Articulos, CodArt);
            this.DescripcionArticulo  = ((DataRowView)articulosBindingSource.Current).Row["DescripcionArticulo"].ToString();
           

            int i = 0;
            while (i < this.DescripcionArticulo.Length )
            {
                try
                {
                    if (this.DescripcionArticulo[i].ToString() == "V")
                    {
                        if (Functions.IsNumeric(this.DescripcionArticulo[i - 1].ToString()))
                        {
                            if (Functions.IsNumeric(this.DescripcionArticulo[i - 2].ToString()))
                            {
                                if (Functions.IsNumeric(this.DescripcionArticulo[i - 3].ToString())) this.Voltage = Int32.Parse(this.DescripcionArticulo.Substring(i - 3, 3));
                                else this.Voltage = Int32.Parse(this.DescripcionArticulo.Substring(i - 2, 2));
                                break;
                            }
                        }
                    }
                    i ++;
                }
                catch (Exception) {
                    i++;
                }
            }
            //BUSCAMOS SI ES AC/DC
            if (this.DescripcionArticulo.Substring(i).Contains("dc") || this.DescripcionArticulo.Substring(i).Contains("DC") || this.DescripcionArticulo.Substring(i).Contains("Dc"))
            {
                this.VoltageType = 1;
            }
            if (this.DescripcionArticulo.Substring(i).Contains("Hz") || this.DescripcionArticulo.Substring(i).Contains("HZ") || this.DescripcionArticulo.Substring(i).Contains("hz"))
            {
                this.VoltageType = 0;
            }
            //BUSCAMOS SI ES 1 CABEZAL O 2
            this.Cabezales = GetCabezal(this.DescripcionArticulo);

          
            //INICIALIZAMOS LOS SENSORES
            if (this.Cabezales == 1)
            {
                //Sensor 1 vacio
                SensType PS1 = new SensType();
                PS1.index = 0;
                PS1.name = "PSMC01";
                //Sensor 1 caudal
                SensType Ca1 = new SensType();
                Ca1.index = 0;
                Ca1.name = "FWTA20";
                this.Sensors.Add(PS1);
                this.Sensors.Add(Ca1);
            }
            else if(this.Cabezales == 2)
            {
                //Sensor 1 vacio
                SensType PS1 = new SensType();
                PS1.index = 0;
                PS1.name = "PSMC01";
                //Sensor 2 vacio
                SensType PS2 = new SensType();
                PS2.index = 1;
                PS2.name = "PSMC01";
                //Sensor 1 caudal
                SensType Ca1 = new SensType();
                Ca1.index = 0;
                Ca1.name = "FWTA20";
                //Sensor 2 caudal
                SensType Ca2 = new SensType();
                Ca2.index = 0;
                Ca2.name = "FWTA50";
                this.Sensors.Add(PS1);
                this.Sensors.Add(PS2);
                this.Sensors.Add(Ca1);
                this.Sensors.Add(Ca2);

            }
        }
        public void ClearValues() {
            if (this.Cabezales == 2)
            {
            //    this.ValuesCab[1].Caudal = 0;
            //    this.ValuesCab[1].VacioM = 0;
            //    this.ValuesCab[1].VacioE1 = 0;
            //    this.ValuesCab[1].VacioE2 = 0;
            //    this.ValuesCab[1].Perdida = 0;
            //    this.ValuesCab[1].EndCaudal = false;
            //    this.ValuesCab[1].EndVacioM = false;
            //    this.ValuesCab[1].EndVacioE1 = false;
            //    this.ValuesCab[1].EndVacioE2 = false;

            }        
            //    this.ValuesCab[0].Caudal = 0;
            //    this.ValuesCab[0].VacioM = 0;
            //    this.ValuesCab[0].VacioE1 = 0;
            //    this.ValuesCab[0].VacioE2 = 0;
            //    this.ValuesCab[0].Perdida = 0;
            //    this.ValuesCab[0].EndCaudal = false;
            //    this.ValuesCab[0].EndVacioM = false;
            //    this.ValuesCab[0].EndVacioE1 = false;
            //    this.ValuesCab[0].EndVacioE2 = false;    
        }
        private void CargarTable()
        {
            this.components = new System.ComponentModel.Container();
            this.dataSet1 = new SensorScreeen.DataSet1();
            this.articulosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.articulosTableAdapter = new SensorScreeen.DataSet1TableAdapters.ArticulosTableAdapter();
            this.tableAdapterManager = new SensorScreeen.DataSet1TableAdapters.TableAdapterManager();
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // articulosBindingSource
            // 
            this.articulosBindingSource.DataMember = "Articulos";
            this.articulosBindingSource.DataSource = this.dataSet1;
            // 
            // articulosTableAdapter
            // 
            this.articulosTableAdapter.ClearBeforeFill = true;

        }
        public void RefreshTotal()
        {
            foreach(String e in this.Numeros.Keys)
            {
                if (this.Numeros[e][0].Caudal > this.ValoresTotal["CaudalMax"]) this.ValoresTotal["CaudalMax"] = this.Numeros[e][0].Caudal;
                {

                }
            }
        }
        public void RefreshTotal(string Option, float value)
        {
            switch(Option)
            { 
                case "caudal":
                    if (ValoresTotal["CaudalMax"] < value) ValoresTotal["CaudalMax"] = value;
                    if ((ValoresTotal["CaudalMin"] <= 0 || ValoresTotal["CaudalMin"] > value) && value > 0) ValoresTotal["CaudalMin"] = value;
                    break;
                case "vacio":
                    if (ValoresTotal["VacioMax"] < value) ValoresTotal["VacioMax"] = value;
                    if ((ValoresTotal["VacioMin"] <= 0 || ValoresTotal["VacioMin"] > value) && value > 0 ) ValoresTotal["VacioMin"] = value;
                    break;
                case "vacioE":
                    if (ValoresTotal["VacioEstMax"] < value) ValoresTotal["VacioEstMax"] = value;
                    if ((ValoresTotal["VacioEstMin"] <= 0 || ValoresTotal["VacioEstMin"] > value) && value > 0) ValoresTotal["VacioEstMin"] = value;
                    break;
                case "vacioP":
                    if (ValoresTotal["VacioPerMax"] < value) ValoresTotal["VacioPerMax"] = value;
                    if ((ValoresTotal["VacioPerMin"] <= 0 || ValoresTotal["VacioPerMin"] > value) && value > 0) ValoresTotal["VacioPerMin"] = value;
                    break;
            }
        }
       
        private int GetCabezal(string DescArt)
        {
            int numCab = 0;
            string IniDesc = DescArt.Substring(0, DescArt.IndexOf(" "));
            if (IniDesc.Contains("P3")) numCab = 2;
            else if (IniDesc.Contains("EVO")) numCab = 2;
            else if (IniDesc.Contains("NEO-I")) numCab = 2;
            else if (IniDesc.Contains("DEO-I")) numCab = 2;
            else numCab = 1;
            return numCab;
        }
    }
}
