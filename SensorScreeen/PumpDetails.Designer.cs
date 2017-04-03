namespace SensorScreeen
{
    partial class PumpDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.comboNumerosSerie = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Cab1Perdida = new DevComponents.DotNetBar.LabelX();
            this.Cab1VacioE2 = new DevComponents.DotNetBar.LabelX();
            this.Cab1VacioE1 = new DevComponents.DotNetBar.LabelX();
            this.Cab1VacioMax = new DevComponents.DotNetBar.LabelX();
            this.Cab1Caudal = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Cab2Perdida = new DevComponents.DotNetBar.LabelX();
            this.Cab2VacioE2 = new DevComponents.DotNetBar.LabelX();
            this.Cab2VacioE1 = new DevComponents.DotNetBar.LabelX();
            this.Cab2VacioMax = new DevComponents.DotNetBar.LabelX();
            this.Cab2Caudal = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // comboNumerosSerie
            // 
            this.comboNumerosSerie.DisplayMember = "Text";
            this.comboNumerosSerie.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboNumerosSerie.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboNumerosSerie.ForeColor = System.Drawing.Color.Black;
            this.comboNumerosSerie.FormattingEnabled = true;
            this.comboNumerosSerie.ItemHeight = 19;
            this.comboNumerosSerie.Location = new System.Drawing.Point(126, 21);
            this.comboNumerosSerie.Name = "comboNumerosSerie";
            this.comboNumerosSerie.Size = new System.Drawing.Size(108, 25);
            this.comboNumerosSerie.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboNumerosSerie.TabIndex = 0;
            this.comboNumerosSerie.SelectedIndexChanged += new System.EventHandler(this.comboNumerosSerie_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(12, 21);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(108, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Número de serie:";
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.White;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.Cab1Perdida);
            this.groupPanel1.Controls.Add(this.Cab1VacioE2);
            this.groupPanel1.Controls.Add(this.Cab1VacioE1);
            this.groupPanel1.Controls.Add(this.Cab1VacioMax);
            this.groupPanel1.Controls.Add(this.Cab1Caudal);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(13, 63);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(221, 147);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 2;
            this.groupPanel1.Text = "Cabezal 1";
            // 
            // Cab1Perdida
            // 
            this.Cab1Perdida.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.Cab1Perdida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Cab1Perdida.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cab1Perdida.ForeColor = System.Drawing.Color.Black;
            this.Cab1Perdida.Location = new System.Drawing.Point(131, 95);
            this.Cab1Perdida.Name = "Cab1Perdida";
            this.Cab1Perdida.Size = new System.Drawing.Size(79, 23);
            this.Cab1Perdida.TabIndex = 11;
            this.Cab1Perdida.Text = "0";
            // 
            // Cab1VacioE2
            // 
            this.Cab1VacioE2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.Cab1VacioE2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Cab1VacioE2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cab1VacioE2.ForeColor = System.Drawing.Color.Black;
            this.Cab1VacioE2.Location = new System.Drawing.Point(131, 71);
            this.Cab1VacioE2.Name = "Cab1VacioE2";
            this.Cab1VacioE2.Size = new System.Drawing.Size(79, 23);
            this.Cab1VacioE2.TabIndex = 10;
            this.Cab1VacioE2.Text = "0";
            // 
            // Cab1VacioE1
            // 
            this.Cab1VacioE1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.Cab1VacioE1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Cab1VacioE1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cab1VacioE1.ForeColor = System.Drawing.Color.Black;
            this.Cab1VacioE1.Location = new System.Drawing.Point(131, 48);
            this.Cab1VacioE1.Name = "Cab1VacioE1";
            this.Cab1VacioE1.Size = new System.Drawing.Size(79, 23);
            this.Cab1VacioE1.TabIndex = 9;
            this.Cab1VacioE1.Text = "0";
            // 
            // Cab1VacioMax
            // 
            this.Cab1VacioMax.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.Cab1VacioMax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Cab1VacioMax.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cab1VacioMax.ForeColor = System.Drawing.Color.Black;
            this.Cab1VacioMax.Location = new System.Drawing.Point(131, 26);
            this.Cab1VacioMax.Name = "Cab1VacioMax";
            this.Cab1VacioMax.Size = new System.Drawing.Size(79, 23);
            this.Cab1VacioMax.TabIndex = 8;
            this.Cab1VacioMax.Text = "0";
            // 
            // Cab1Caudal
            // 
            this.Cab1Caudal.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.Cab1Caudal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Cab1Caudal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cab1Caudal.ForeColor = System.Drawing.Color.Black;
            this.Cab1Caudal.Location = new System.Drawing.Point(131, 3);
            this.Cab1Caudal.Name = "Cab1Caudal";
            this.Cab1Caudal.Size = new System.Drawing.Size(79, 23);
            this.Cab1Caudal.TabIndex = 7;
            this.Cab1Caudal.Text = "0";
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(3, 95);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(122, 23);
            this.labelX6.TabIndex = 6;
            this.labelX6.Text = "Perdida(mmHg):";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(3, 71);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(122, 23);
            this.labelX5.TabIndex = 5;
            this.labelX5.Text = "Vacio Est2(mmHg):";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(3, 48);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(122, 23);
            this.labelX4.TabIndex = 4;
            this.labelX4.Text = "Vacio Est1(mmHg):";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(3, 26);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(122, 23);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "Vacio Max(mmHg):";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(3, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(108, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Caudal (LPM):";
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.White;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.Cab2Perdida);
            this.groupPanel2.Controls.Add(this.Cab2VacioE2);
            this.groupPanel2.Controls.Add(this.Cab2VacioE1);
            this.groupPanel2.Controls.Add(this.Cab2VacioMax);
            this.groupPanel2.Controls.Add(this.Cab2Caudal);
            this.groupPanel2.Controls.Add(this.labelX12);
            this.groupPanel2.Controls.Add(this.labelX13);
            this.groupPanel2.Controls.Add(this.labelX14);
            this.groupPanel2.Controls.Add(this.labelX15);
            this.groupPanel2.Controls.Add(this.labelX16);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(240, 63);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(221, 147);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 3;
            this.groupPanel2.Text = "Cabezal 2";
            // 
            // Cab2Perdida
            // 
            this.Cab2Perdida.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.Cab2Perdida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Cab2Perdida.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cab2Perdida.ForeColor = System.Drawing.Color.Black;
            this.Cab2Perdida.Location = new System.Drawing.Point(131, 95);
            this.Cab2Perdida.Name = "Cab2Perdida";
            this.Cab2Perdida.Size = new System.Drawing.Size(79, 23);
            this.Cab2Perdida.TabIndex = 11;
            this.Cab2Perdida.Text = "0";
            // 
            // Cab2VacioE2
            // 
            this.Cab2VacioE2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.Cab2VacioE2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Cab2VacioE2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cab2VacioE2.ForeColor = System.Drawing.Color.Black;
            this.Cab2VacioE2.Location = new System.Drawing.Point(131, 71);
            this.Cab2VacioE2.Name = "Cab2VacioE2";
            this.Cab2VacioE2.Size = new System.Drawing.Size(79, 23);
            this.Cab2VacioE2.TabIndex = 10;
            this.Cab2VacioE2.Text = "0";
            // 
            // Cab2VacioE1
            // 
            this.Cab2VacioE1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.Cab2VacioE1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Cab2VacioE1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cab2VacioE1.ForeColor = System.Drawing.Color.Black;
            this.Cab2VacioE1.Location = new System.Drawing.Point(131, 48);
            this.Cab2VacioE1.Name = "Cab2VacioE1";
            this.Cab2VacioE1.Size = new System.Drawing.Size(79, 23);
            this.Cab2VacioE1.TabIndex = 9;
            this.Cab2VacioE1.Text = "0";
            // 
            // Cab2VacioMax
            // 
            this.Cab2VacioMax.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.Cab2VacioMax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Cab2VacioMax.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cab2VacioMax.ForeColor = System.Drawing.Color.Black;
            this.Cab2VacioMax.Location = new System.Drawing.Point(131, 26);
            this.Cab2VacioMax.Name = "Cab2VacioMax";
            this.Cab2VacioMax.Size = new System.Drawing.Size(79, 23);
            this.Cab2VacioMax.TabIndex = 8;
            this.Cab2VacioMax.Text = "0";
            // 
            // Cab2Caudal
            // 
            this.Cab2Caudal.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.Cab2Caudal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Cab2Caudal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cab2Caudal.ForeColor = System.Drawing.Color.Black;
            this.Cab2Caudal.Location = new System.Drawing.Point(131, 3);
            this.Cab2Caudal.Name = "Cab2Caudal";
            this.Cab2Caudal.Size = new System.Drawing.Size(79, 23);
            this.Cab2Caudal.TabIndex = 7;
            this.Cab2Caudal.Text = "0";
            // 
            // labelX12
            // 
            this.labelX12.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX12.ForeColor = System.Drawing.Color.Black;
            this.labelX12.Location = new System.Drawing.Point(3, 95);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(122, 23);
            this.labelX12.TabIndex = 6;
            this.labelX12.Text = "Perdida(mmHg):";
            // 
            // labelX13
            // 
            this.labelX13.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX13.ForeColor = System.Drawing.Color.Black;
            this.labelX13.Location = new System.Drawing.Point(3, 71);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(122, 23);
            this.labelX13.TabIndex = 5;
            this.labelX13.Text = "Vacio Est2(mmHg):";
            // 
            // labelX14
            // 
            this.labelX14.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX14.ForeColor = System.Drawing.Color.Black;
            this.labelX14.Location = new System.Drawing.Point(3, 48);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(122, 23);
            this.labelX14.TabIndex = 4;
            this.labelX14.Text = "Vacio Est1(mmHg):";
            // 
            // labelX15
            // 
            this.labelX15.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX15.ForeColor = System.Drawing.Color.Black;
            this.labelX15.Location = new System.Drawing.Point(3, 26);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(122, 23);
            this.labelX15.TabIndex = 3;
            this.labelX15.Text = "Vacio Max(mmHg):";
            // 
            // labelX16
            // 
            this.labelX16.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX16.ForeColor = System.Drawing.Color.Black;
            this.labelX16.Location = new System.Drawing.Point(3, 3);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(108, 23);
            this.labelX16.TabIndex = 2;
            this.labelX16.Text = "Caudal (LPM):";
            // 
            // PumpDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 221);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.comboNumerosSerie);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "PumpDetails";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DETALLES BOMBA";
            this.Load += new System.EventHandler(this.PumpDetails_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboNumerosSerie;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.LabelX Cab1Perdida;
        private DevComponents.DotNetBar.LabelX Cab1VacioE2;
        private DevComponents.DotNetBar.LabelX Cab1VacioE1;
        private DevComponents.DotNetBar.LabelX Cab1VacioMax;
        private DevComponents.DotNetBar.LabelX Cab1Caudal;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.LabelX Cab2Perdida;
        private DevComponents.DotNetBar.LabelX Cab2VacioE2;
        private DevComponents.DotNetBar.LabelX Cab2VacioE1;
        private DevComponents.DotNetBar.LabelX Cab2VacioMax;
        private DevComponents.DotNetBar.LabelX Cab2Caudal;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.LabelX labelX15;
        private DevComponents.DotNetBar.LabelX labelX16;
    }
}

