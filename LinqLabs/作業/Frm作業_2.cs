using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();
            this.productPhotoTableAdapter1.Fill(this.awDataSet1.ProductPhoto);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = this.awDataSet1.ProductPhoto;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Columns.Clear();


            var q =  from pp in this.awDataSet1.ProductPhoto
                      where pp.ModifiedDate.Year == int.Parse(comboBox3.Text)
                      select pp;


            this.dataGridView1.DataSource = q.ToList();

        }
    }
}
