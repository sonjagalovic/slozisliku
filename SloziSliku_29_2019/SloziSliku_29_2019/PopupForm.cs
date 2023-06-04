using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SloziSliku_29_2019
{
    public partial class PopupForm : Form
    {
        public PopupForm()
        {
            InitializeComponent();
            listView1.Font = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Regular);

            foreach (ListViewItem item in Form1.listViewRezultati.Items)
            {
                this.listView1.Items.Add((ListViewItem)item.Clone());
            }
        }
    }
}
