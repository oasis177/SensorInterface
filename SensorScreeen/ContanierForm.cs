using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SensorScreeen
{
    public partial class ContanierForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ContanierForm()
        {
            InitializeComponent();
        }

        private void ContanierForm_Load(object sender, EventArgs e)
        {
            Form1 thisForm = new Form1();
            thisForm.MdiParent = this;
            thisForm.Show();
        }
    }
}