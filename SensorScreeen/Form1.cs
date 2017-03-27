﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace SensorScreeen
{
   
    public partial class Form1 : Form
    {
         
        public Form1()
        {
            InitializeComponent();
			//Just testing for GitHub
        }
        public Prueba CurrProv;
        public SocketClient SC;
        public float incrPB;
        public float AcumPB; 
        private void Form1_Load(object sender, EventArgs e) 
        {
         
            IPStext.Text = Functions.GetLocalIPAddress();
            portSText.Text = "8080";
            IPDtext.Text = "192.168.100.96";
            portDText.Text = "8081";
            TimeVM.Text = "10";
            TimeVE.Text = "10";
            TimeVP.Text = "5";
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.Silver;
            this.tab1cabezal.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tab1cabezal.Style.BackColor2.Color = System.Drawing.Color.Silver;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            ParseCodeBar();
        }
        private void textCodeBar_KeyDown(object sender, KeyEventArgs e)
        {
            ///Aqui se hace el parse principal
            if (e.KeyCode == Keys.Return)
            {
                ParseCodeBar();
            }
        }
        private void ParseCodeBar()
        {     
            try
            {
                string Oper1;
                string aux;
                string Oper2;
                string Oper3;
                string sep = "'";
                if (textCodeBar.Text.Contains("/")) sep = "/";
                if (textCodeBar.Text.Contains("-")) sep = "-";
                //Hacemos el parse del codebar
                Oper1 = textCodeBar.Text.Substring(0, textCodeBar.Text.IndexOf(sep));
                aux = textCodeBar.Text.Substring(textCodeBar.Text.IndexOf(sep) + 1, textCodeBar.Text.Length - (textCodeBar.Text.IndexOf(sep) + 1));
                Oper2 = aux.Substring(0, aux.ToString().IndexOf(sep));
                Oper3 = aux.Substring(aux.ToString().IndexOf(sep) + 1, aux.ToString().Length - (aux.ToString().IndexOf(sep) + 1));
                this.CurrProv = new Prueba();
                if (Functions.IsNumeric(Oper2))
                {
                    //PARSEAMOS COMO NUMERO DE PEDIDO
                    this.lineasPedidoClienteTableAdapter.FillByPedido(this.dataSet1.LineasPedidoCliente, Oper1, Int32.Parse(Oper2), short.Parse(Oper3));
                    if (lineasPedidoClienteBindingSource.Count > 0)
                    {
                        CurrProv.InitVars(((DataRowView)lineasPedidoClienteBindingSource.Current).Row["CodigoArticulo"].ToString());
                        //INTRODUCIMOS NUMERO TRABAJO
                        Functions.GetNumTrabajo(ref CurrProv.EjTra, ref CurrProv.NumTra, Oper1, Int32.Parse(Oper2), short.Parse(Oper3));                            
                        //INTRODUCIMOS NUM.SERIE
                        eADNumerosTableAdapter.FillByPedido(this.dataSet1.EADNumeros, short.Parse(Functions.QuitarR(Oper1)), Oper1, Int32.Parse(Oper2), Int32.Parse(Oper3));
                        for (int i = 0; i < eADNumerosBindingSource.Count; i++)
                        {
                          
                           if (CurrProv.Cabezales == 1) CurrProv.Numeros.Add(((DataRowView)eADNumerosBindingSource.List[i]).Row["numero"].ToString(), new List<ValorsCab> {new ValorsCab() });
                           else if (CurrProv.Cabezales == 2) CurrProv.Numeros.Add(((DataRowView)eADNumerosBindingSource.List[i]).Row["numero"].ToString(), new List<ValorsCab> { new ValorsCab(),new ValorsCab()});


                        }

                    }
                    else  {
                        MessageBox.Show("No se encuentra el Pedido solicitado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textCodeBar.Text = "";
                        return; }
                }
                else {
                    //PARSEAMOS COMO NUMERO TRABAJO
                    ordenesTrabajoTableAdapter.FillByOrdenTrabajo(this.dataSet1.OrdenesTrabajo, short.Parse(Oper1),Int32.Parse(Oper3));
                    
                    if (ordenesTrabajoBindingSource.Count > 0)
                    {
                        CurrProv.InitVars(((DataRowView)ordenesTrabajoBindingSource.Current).Row["CodigoArticulo"].ToString());
                        ordenesFabricacionTableAdapter.FillByFabrica(this.dataSet1.OrdenesFabricacion, short.Parse(Oper1), Oper2,(int)((DataRowView)ordenesTrabajoBindingSource.Current).Row["NumeroFabricacion"]);
                        CurrProv.EjTra = (Int16)((DataRowView)ordenesTrabajoBindingSource.Current).Row["EjercicioTrabajo"];
                        CurrProv.NumTra = (Int32)((DataRowView)ordenesTrabajoBindingSource.Current).Row["NumeroTrabajo"];
                        //INTRODUCIMOS NUM.SERIE
                        estadoPedidosClientesTableAdapter.FillByFabrica(this.dataSet1.EstadoPedidosClientes, Guid.Parse(((DataRowView)ordenesFabricacionBindingSource.Current).Row["Identificador"].ToString()));
                           
                        for (int i = 0; i < estadoPedidosClientesBindingSource.Count; i++)
                        {
                            eADNumerosTableAdapter.FillByPedido(this.dataSet1.EADNumeros, (short)((DataRowView)estadoPedidosClientesBindingSource.List[i]).Row["EjercicioPedido"], ((DataRowView)estadoPedidosClientesBindingSource.List[i]).Row["SeriePedido"].ToString(), (Int32)((DataRowView)estadoPedidosClientesBindingSource.List[i]).Row["NumeroPedido"], (Int32)((DataRowView)estadoPedidosClientesBindingSource.List[i]).Row["OrdenLineas"]);
                            for (int j = 0; j < eADNumerosBindingSource.Count; j++)
                            {
                                if (CurrProv.Cabezales == 1) CurrProv.Numeros.Add(((DataRowView)eADNumerosBindingSource.List[j]).Row["numero"].ToString(), new List<ValorsCab> { new ValorsCab(int.Parse(TimeVM.Text), int.Parse(TimeVE.Text), int.Parse(TimeVP.Text)) });
                                else if (CurrProv.Cabezales == 2) CurrProv.Numeros.Add(((DataRowView)eADNumerosBindingSource.List[j]).Row["numero"].ToString(), new List<ValorsCab> { new ValorsCab(int.Parse(TimeVM.Text), int.Parse(TimeVE.Text), int.Parse(TimeVP.Text)), new ValorsCab(int.Parse(TimeVM.Text), int.Parse(TimeVE.Text), int.Parse(TimeVP.Text)) });
                              
                            }
                        }
                    }
                    else {
                        MessageBox.Show("No se encuentra la Fábrica solicitado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textCodeBar.Text = "";
                        return; }
                }
                //INICIALIZAMOS LOS DETALLES DE LA PRUEBA EN PANTALLA
                CodigoArtText.Text = CurrProv.CodigoArticulo;
                DescArtText.Text = CurrProv.DescripcionArticulo;
                EjTraText.Text = CurrProv.EjTra.ToString();
                NumTraText.Text = CurrProv.NumTra.ToString();
                this.NumerosDataGridView.Rows.Clear();
                foreach (string key in CurrProv.Numeros.Keys)
                {
                    this.NumerosDataGridView.Rows.Add(key);
                }
                if (this.NumerosDataGridView.Rows.Count == 0)
                {
                    textCodeBar.Text = "";
                    groupPanel1.Visible = false;
                    MessageBox.Show("No se encuentran números de serie del código de barras escaneado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else //TODO CORRECTO
                {
                    Connection();
                    groupPanel1.Visible = true;
                    ClearLabels();
                }
            }
                catch (Exception)
            {
                MessageBox.Show("El código de barras no tiene el formato correcto.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                textCodeBar.Text = "";

            }      
        }
        private void Connection()
        {
            try
            {
               SC = new SocketClient(Int32.Parse(portSText.Text), IPDtext.Text, Int32.Parse(portDText.Text));
                if (SC.InitConnection(ref CurrProv) == -1)
                {
                    MessageBox.Show("No se ha podido establecer connexión con el sensor de pruebas.Comprueba que la conexión sea correcta.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pictureConn.Image = global::SensorScreeen.Properties.Resources.UnconnectedRed;
                    butStart.Visible = false;
                }
                else
                {
                    pictureConn.Image = global::SensorScreeen.Properties.Resources.ConnectedGreen;
                    butStart.Visible = true;
                    if (CurrProv.Cabezales == 1)
                    {
                        tabCabezal1.Visible = true;
                        tabGrafica.Visible = false;
                        tab2Cabezales.Visible = false;
                    }
                    else {
                        tabCabezal1.Visible = false;
                        tabGrafica.Visible = false;
                        tab2Cabezales.Visible = true;
                    }
                }
                }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido establecer connexión con el sensor de pruebas.Comprueba que la conexión sea correcta.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            buttonAjustes.Location = new Point(this.Width - 80,30);
            groupPanel1.Location = new Point(this.Width / 2 - groupPanel1.Width / 2, this.Height / 2 - groupPanel1.Height / 2);
            groupAjustes.Location = new Point(buttonAjustes.Location.X - 110, buttonAjustes.Location.Y + 50);
        }
        private void buttonAjustes_Click(object sender, EventArgs e)
        {
            if (groupAjustes.Visible == true) groupAjustes.Visible = false;
            else  groupAjustes.Visible = true;
        }
        private void buttonCloseAjustes_Click(object sender, EventArgs e)
        {
            groupAjustes.Visible = false;
        }
        private void IPtext_Leave(object sender, EventArgs e)
        {
            try
            {
                IPAddress.Parse(IPStext.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("El formato IP no es correcto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IPStext.Focus();
            }
        }
        private void portText_Leave(object sender, EventArgs e)
        {
            if (!Functions.IsNumeric(portSText.Text)){
                MessageBox.Show("El formato puerto no es correcto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                portSText.Focus();
            }
        }
        private void IPDText_Leave(object sender, EventArgs e)
        {
            try
            {
                IPAddress.Parse(IPDtext.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("El formato IP no es correcto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IPDtext.Focus();
            }
        }
        private void PortDText_Leave(object sender, EventArgs e)
        {
            if (!Functions.IsNumeric(portDText.Text))
            {
                MessageBox.Show("El formato puerto no es correcto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                portDText.Focus();
            }
        }
        private void pictureConn_MouseHover(object sender, EventArgs e)
        {       
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureConn,"Clicar para reiniciar connexión!");
        }

        private void pictureConn_Click(object sender, EventArgs e)
        {
            try { SC.StopConnection(); }
            catch (Exception) { }
            Connection();
        }

        private void butStart_Click (object sender, EventArgs e)
        {
            ClearLabels();
           
            int opC = 0;
            long NS=0;
            float value=0;
            List<ValorsCab> CurrPump = null;
            PBRecibiendo.Value = 0;
            this.incrPB  = 100 / ((int.Parse(TimeVM.Text) + int.Parse(TimeVE.Text) + int.Parse(TimeVP.Text)+ 2)/(timerProba.Interval/(float)1000));
            this.AcumPB = 0;
            GPRecibiendo.Visible = true;
            SC.newBomb(ref CurrProv, NumerosDataGridView.CurrentRow.Cells["NUMERO"].Value.ToString());
            timerProba.Start();
            //CurrPump = CurrProv.Nums[i];

            while (opC != 150)
            {
               SC.Listen(ref opC, ref NS, ref value);
               CurrPump = CurrProv.Numeros[Functions.Rellenar0s(NS)];
               switch (opC)
               {
                    case 51://VALOR CAUDAL CABEZAL 1
                        CurrPump[0].Caudal = value;
                        break;
                    case 52://VALOR CAUDAL CABEZAL 2
                        CurrPump[1].Caudal = value;
                        break;
                    case 53://VALOR VACIO MÁXIMO CABEZAL 1
                        CurrPump[0].VacioM = value;
                        break;
                    case 54://VALOR VACIO MÁXIMO CABEZAL 2
                        CurrPump[1].VacioM = value;
                        break;
                    case 55://VALOR VACIO ESTABLE CABEZAL 1
                        CurrPump[0].VacioE1 = value;
                        break;
                    case 56://VALOR VACIO ESTABLE CABEZAL 2
                        CurrPump[1].VacioE1 = value;
                        break;
                    case 57://VALOR VACIO ESTABLE FINAL CABEZAL 1
                        CurrPump[0].VacioE2 = value;
                        break;
                    case 58://VALOR VACIO ESTABLE FINAL CABEZAL 2
                        CurrPump[1].VacioE2 = value;
                        break;
                    case 101://VALOR FINAL CAUDAL CAB1
                        CurrPump[0].Caudal = value;
                        CurrPump[0].EndCaudal = true;
                        break;
                    case 102://VALOR FINAL CAUDAL CAB2
                        CurrPump[1].Caudal = value;
                        CurrPump[1].EndCaudal = true;
                        break;
                    case 103://VALOR FINAL VACIO MAX
                        CurrPump[0].VacioM = value;
                        CurrPump[0].EndVacioM = true;
                        break;
                    case 104://VALOR FINAL VACIO MAX CAB2
                        CurrPump[1].VacioM = value;
                        CurrPump[1].EndVacioM = true;
                        break;
                    case 105://VALOR FINAL VACIO ESTABLE1 CAB1
                        CurrPump[0].VacioE1 = value;
                        CurrPump[0].EndVacioE1 = true;
                        break;
                    case 106://VALOR FINAL VACIO ESTABLE1 CAB2
                        CurrPump[1].VacioE1 = value;
                        CurrPump[1].EndVacioE1 = true;
                        break;
                    case 107://VALOR FINAL VACIO ESTABLE FINAL CAB1
                        CurrPump[0].VacioE2 = value;
                        CurrPump[0].EndVacioE2 = true;
                        CurrPump[0].Perdida = CurrPump[0].VacioE1 - CurrPump[0].VacioE2;
                        break;
                    case 108://VALOR FINAL VACIO ESTABLE FINAL CAB2
                        CurrPump[1].VacioE2 = value;
                        CurrPump[1].EndVacioE2 = true;
                        CurrPump[1].Perdida = CurrPump[1].VacioE1 - CurrPump[1].VacioE2;
                        break;
                    case 148:
                        PresAtmText.Text = Math.Round(value, 2).ToString() + " mbar";
                        break;
                    case 149:
                        PresAtmText.Text = Math.Round(value, 2).ToString() + " mbar";
                        break;
                    default:
                        break;
                    
               }
              
                ActualizarBars(CurrPump);
            }
            NumerosDataGridView.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen;
            timerProba.Stop();
            if (NumerosDataGridView.CurrentRow.Index < NumerosDataGridView.Rows.Count-1)
            {   
                NumerosDataGridView.CurrentCell = NumerosDataGridView[0, NumerosDataGridView.CurrentRow.Index + 1];
            }
            GPRecibiendo.Visible = false;
            //NumerosDataGridView.Cur



        }
        private void ActualizarBars(List<ValorsCab> CurrPump)
        {
            try
            {
                if (CurrProv.Cabezales == 1)
                {
                    if (!CurrPump[0].EndCaudal)
                    {
                        Tab1CaudalValue.Text = Math.Round(CurrPump[0].Caudal, 2).ToString();
                        Tab1pBC1.Value = (int)(CurrPump[0].Caudal / 20 * 100);
                    }
                    else
                    {
                        Tab1Caudal.Text = Tab1CaudalValue.Text  =  Math.Round(CurrPump[0].Caudal, 2).ToString();
                        tab1gPC.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        Tab1pBC1.Value = (int)(CurrPump[0].Caudal / 20 * 100);
                    }
                    if (!CurrPump[0].EndVacioM)
                    {
                        Tab1VacioValue.Text = Math.Round(CurrPump[0].VacioM, 2).ToString();
                        Tab1pBV1.Value = (int)(CurrPump[0].VacioM / 800 * 100);
                    }
                    else
                    {
                        Tab1Vacio1.Text = Tab1VacioValue.Text = Math.Round(CurrPump[0].VacioM, 2).ToString();
                        Tab1gPVM.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        Tab1pBV1.Value = (int)(CurrPump[0].VacioM / 800 * 100);
                    }
                    if (!CurrPump[0].EndVacioE1)
                    {
                        Tab1VE1.Text = Math.Round(CurrPump[0].VacioE1, 2).ToString();
                        Tab1pBE1.Value = (int)(CurrPump[0].VacioE1 / 800 * 100);
                    }
                    else
                    {
                        Tab1VacioE1.Text = Tab1VE1.Text=  Math.Round(CurrPump[0].VacioE1, 2).ToString();
                        Tab1gPVE1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        Tab1pBE1.Value = (int)(CurrPump[0].VacioE1 / 800 * 100);
                    }
                    if (!CurrPump[0].EndVacioE2)
                    {
                        Tab1VE2.Text = Math.Round(CurrPump[0].VacioE2, 2).ToString();
                        Tab1pBE2.Value = (int)(CurrPump[0].VacioE2 / 800 * 100);
                    }
                    else
                    {
                        Tab1VacioE2.Text = Tab1VE2.Text= Math.Round(CurrPump[0].VacioE2, 2).ToString();
                        Tab1Perdida.Text = Math.Round(CurrPump[0].Perdida, 2).ToString();
                        Tab1gpP.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        Tab1gPVE2.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        Tab1pBE2.Value = (int)(CurrPump[0].VacioE2 / 800 * 100);
                    }
                }
                else if (CurrProv.Cabezales == 2)
                {
                    //CAUDAL
                    if (!CurrPump[0].EndCaudal)
                    {
                        Tab2CaudalValue1.Text = Math.Round(CurrPump[0].Caudal, 2).ToString();
                        Tab2pBC1.Value = (int)(CurrPump[0].Caudal / 20 * 100);
                    }
                    else
                    {
                       
                        tab2Caudal.Text = Tab2CaudalValue1.Text = Math.Round(CurrPump[0].Caudal, 2).ToString(); 
                        Tab2gPC1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        Tab2pBC1.Value = (int)(CurrPump[0].Caudal / 20 * 100);
                    }
                    if (!CurrPump[1].EndCaudal)
                    {
                        Tab2CaudalValue2.Text = Math.Round(CurrPump[1].Caudal, 2).ToString();
                        Tab2pBC2.Value = (int)(CurrPump[1].Caudal / 20 * 100);
                    }
                    else
                    {          
                        Tab2Caudal2.Text = Tab2CaudalValue2.Text = Math.Round(CurrPump[1].Caudal, 2).ToString();
                        Tab2gPC2.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        Tab2pBC2.Value = (int)(CurrPump[1].Caudal / 20 * 100);
                    }
                    //VACIO MAX
                    if (!CurrPump[0].EndVacioM)
                    {
                        Tab2VacioValue1.Text = Math.Round(CurrPump[0].VacioM, 2).ToString();
                        Tab2pBV1.Value = (int)(CurrPump[0].VacioM / 800 * 100);
                    }
                    else
                    {                 
                        Tab2VacioM1.Text = Tab2VacioValue1.Text = Math.Round(CurrPump[0].VacioM, 2).ToString();
                        Tab2gPVM1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        Tab2pBV1.Value = (int)(CurrPump[0].VacioM / 800 * 100);
                    }
                    if (!CurrPump[1].EndVacioM)
                    {
                        Tab2VacioValue2.Text = Math.Round(CurrPump[1].VacioM, 2).ToString();
                        Tab2pBV2.Value = (int)(CurrPump[1].VacioM / 800 * 100);
                    }
                    else
                    {
                        Tab2VacioM2.Text = Tab2VacioValue2.Text = Math.Round(CurrPump[1].VacioM, 2).ToString();
                        Tab2gPVM2.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        Tab2pBV2.Value = (int)(CurrPump[1].VacioM / 800 * 100);
                    }
                    //VACIO ESTABLE 1
                    if (!CurrPump[0].EndVacioE1)
                    {
                        Tab2VE1.Text = Math.Round(CurrPump[0].VacioE1, 2).ToString();
                        Tab2pBE1.Value = (int)(CurrPump[0].VacioE1 / 800 * 100);
                    }
                    else
                    {
                        Tab2VacioE1.Text = Tab2VE1.Text = Math.Round(CurrPump[0].VacioE1, 2).ToString();
                        Tab2gPVE1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        Tab2pBE1.Value = (int)(CurrPump[0].VacioE1 / 800 * 100);
                    }
                    if (!CurrPump[1].EndVacioE1)
                    {
                        Tab2VE2.Text = Math.Round(CurrPump[1].VacioE1, 2).ToString();
                        Tab2pBE2.Value = (int)(CurrPump[1].VacioE1 / 800 * 100);
                    }
                    else
                    {
                        Tab2VE2.Text = Tab2VacioE2.Text = Math.Round(CurrPump[1].VacioE1, 2).ToString();
                        Tab2gPVE2.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        Tab2pBE2.Value = (int)(CurrPump[1].VacioE1 / 800 * 100);
                    }
                    //VACIO ESTABLE 2
                    if (!CurrPump[0].EndVacioE2)
                    {
                        Tab2VE11.Text = Math.Round(CurrPump[0].VacioE2, 2).ToString();
                        Tab2pBE11.Value = (int)(CurrPump[0].VacioE2 / 800 * 100);
                    }
                    else
                    {
                        Tab2VacioE11.Text = Tab2VE11.Text = Math.Round(CurrPump[0].VacioE2, 2).ToString();
                        Tab2Perdida1.Text = Math.Round(CurrPump[0].Perdida, 2).ToString();
                        Tab2gPP1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        Tab2gPVE11.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        Tab2pBE11.Value = (int)(CurrPump[0].VacioE2 / 800 * 100);
                    }
                    if (!CurrPump[1].EndVacioE2)
                    {
                        Tab2VE22.Text = Math.Round(CurrPump[1].VacioE2, 2).ToString();
                        Tab2pBE22.Value = (int)(CurrPump[1].VacioE2 / 800 * 100);
                    }
                    else
                    {
                        Tab2VacioE22.Text = Tab2VE22.Text = Math.Round(CurrPump[1].VacioE2, 2).ToString();
                        Tab2Perdida2.Text = Math.Round(CurrPump[1].Perdida, 2).ToString();
                        Tab2gPP2.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        Tab2gPVE22.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        Tab2pBE22.Value = (int)(CurrPump[1].VacioE2 / 800 * 100);
                    }

                }
            }
            catch (Exception)
            {
            }
            Application.DoEvents();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            SC.StopConnection();
        }
        private void ClearLabels()
        {
            Tab1VacioValue.Text = "0" ;
            Tab1VE1.Text = "0";
            Tab1VE2.Text = "0";
            Tab1CaudalValue.Text = "0";
            Tab1Caudal.Text = "0";
            Tab1Vacio1.Text = "0";
            Tab1VacioE1.Text = "0";
            Tab1VacioE2.Text = "0";
            Tab1Perdida.Text = "0";
            Tab2VacioValue1.Text = "0";
            Tab2VacioValue2.Text = "0";
            Tab2CaudalValue1.Text = "0";
            Tab2CaudalValue2.Text = "0";
            Tab2VE1.Text = "0";
            Tab2VE2.Text = "0";
            tab2Caudal.Text = "0";
            Tab2Caudal2.Text = "0";
            Tab2VacioM1.Text = "0";
            Tab2VacioM2.Text = "0";
            Tab2VacioE1.Text = "0";
            Tab2VacioE2.Text = "0";
            Tab2Perdida1.Text = "0";
            Tab2Perdida2.Text = "0";
            tab1gPC.Style.BackColor = System.Drawing.SystemColors.ButtonFace;
            Tab1gpP.Style.BackColor = System.Drawing.SystemColors.ButtonFace;
            Tab1gPVE1.Style.BackColor = System.Drawing.SystemColors.ButtonFace;
            Tab1gPVE2.Style.BackColor = System.Drawing.SystemColors.ButtonFace;
            Tab1gPVM.Style.BackColor = System.Drawing.SystemColors.ButtonFace;
            Tab2gPP2.Style.BackColor = System.Drawing.SystemColors.ButtonFace;
            Tab2gPVE22.Style.BackColor = System.Drawing.SystemColors.ButtonFace;
            Tab2gPVE2.Style.BackColor = System.Drawing.SystemColors.ButtonFace;
            Tab2gPVM2.Style.BackColor = System.Drawing.SystemColors.ButtonFace;
            Tab2gPC2.Style.BackColor = System.Drawing.SystemColors.ButtonFace;
            Tab2gPP1.Style.BackColor = System.Drawing.SystemColors.ButtonFace;
            Tab2gPVE11.Style.BackColor = System.Drawing.SystemColors.ButtonFace;
            Tab2gPVE1.Style.BackColor = System.Drawing.SystemColors.ButtonFace;
            Tab2gPVM1.Style.BackColor = System.Drawing.SystemColors.ButtonFace;
            Tab2gPC1.Style.BackColor = System.Drawing.SystemColors.ButtonFace;
            Application.DoEvents();
        }



        private void TimeVM_Leave(object sender, EventArgs e)
        {
            if (!Functions.IsNumeric(TimeVM.Text))
            {
                MessageBox.Show("El formato tiempo no es correcto (tiene que ser numérico)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TimeVM.Focus();
            }
        }

        private void TimeVE_Leave(object sender, EventArgs e)
        {
            if (!Functions.IsNumeric(TimeVE.Text))
            {
                MessageBox.Show("El formato tiempo no es correctom (tiene que ser numérico)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TimeVE.Focus();
            }
        }

        private void TimeVP_Leave(object sender, EventArgs e)
        {
            if (!Functions.IsNumeric(TimeVP.Text))
            {
                MessageBox.Show("El formato tiempo no es correcto (tiene que ser numérico).", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TimeVP.Focus();
            }
        }

        private void timerProba_Tick(object sender, EventArgs e)
        {
            this.AcumPB += this.incrPB;
            PBRecibiendo.Value = (int)Math.Round(this.AcumPB);
        }











        /*public void ChangeEtiquetasFiles() {
string ruta = @"\\SERVIDORSQL\Datos\Produccion\ETIQUETAS EAD\Codigos\Bombas\NIL\";
string[] files = Directory.GetFiles(ruta);

foreach (string i in files)
{
if (Path.GetFileName(i).StartsWith("NEO"))
{

StreamReader sr = new System.IO.StreamReader(i);   
StreamWriter sw = new System.IO.StreamWriter(i);
string line = null;
while ((line = sr.ReadLine()) != null)
{
if (line.Contains("IP"))
{
sw.WriteLine(line.Replace("IP 65","IP 20"));
}

}
sw.Close();
sr.Close();}}}*/
    }
}
