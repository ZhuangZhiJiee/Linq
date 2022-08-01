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
    public partial class Frm作業_4 : Form
    {
        public Frm作業_4()
        {
            InitializeComponent();
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            this.ordersTableAdapter1.Fill(this.nwDataSet1.Orders);
            this.order_DetailsTableAdapter1.Fill(this.nwDataSet1.Order_Details);
            this.categoriesTableAdapter1.Fill(this.nwDataSet1.Categories);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from f in files
                    group f by lenth(f.Length) into g
                    orderby g.Key
                    select new { g.Key, MyCount = g.Count() };

            this.dataGridView1.DataSource = q.ToList();


        }

        private string lenth(long n)
        {
            if (n <= 1000) 
                return "small";
            else if (n <= 100000) 
                return "medium";
            else 
                return "large";
        }


        private void button2_Click(object sender, EventArgs e) //總金額
        {
            var q = this.nwDataSet1.Order_Details.AsEnumerable().Sum(od => Convert.ToDouble(od.UnitPrice) * od.Quantity * (1 - Convert.ToDouble(od.Discount)));
            MessageBox.Show("總金額:" + q);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            var q = from n in nums
    
                    group n by MyKey(n) into g
                    select new { MyKey = g.Key, MyCount = g.Count(), MyAvg = g.Average(), MyGroup = g };

            this.dataGridView1.DataSource = q.ToList();
            //==================================

            this.treeView1.Nodes.Clear();
            foreach (var group in q)
            {
                string s = $"{group.MyKey} ( {group.MyCount} )";
                TreeNode x = this.treeView1.Nodes.Add(s);

                foreach (var item in group.MyGroup)
                {
                    x.Nodes.Add(item.ToString());
                }
            }
        }

        private string MyKey(int n)
        {
            if (n <= 5)
                return "小";
            else if (n <= 10)
                return "中";
            else
                return "大";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from f in files
                    group f by f.CreationTime.Year into g
                    orderby g.Key descending
                    select new { g.Key, MyCount = g.Count() };

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var q = from p in this.nwDataSet1.Products
                    group p by unitprice(p.UnitPrice) into g
                   
                    select new { g.Key, MyCount = g.Count() };
            this.dataGridView1.DataSource = q.ToList();
        }

        private object unitprice(decimal n)
        {
            if (n >= 100)
                return "高價";
            else if (n >= 20)
                return "中價";
            else
                return "低價";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var q = from o in this.nwDataSet1.Orders
                    group o by o.OrderDate.Year into g
                    orderby g.Key
                    select new { g.Key, MyCount = g.Count() };
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //double totalprice=0;
            //var q = from od in this.nwDataSet1.Order_Details
            //        join o in this.nwDataSet1.Orders
            //        on od.OrderID equals o.OrderID
            //        group o by o.EmployeeID into g
            //        orderby totalprice = g.Sum(od => Convert.ToDouble(od.UnitPrice) * od.Quantity * (1 - Convert.ToDouble(od.Discount))) descending
            //        select new { EmployeeID = g.Key, totalprice };

            //this.dataGridView1.DataSource = q.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var q = (from c in this.nwDataSet1.Categories
                    join p in this.nwDataSet1.Products
                    on c.CategoryID equals p.CategoryID
                    orderby p.UnitPrice descending
                    select new { c.CategoryName, p.UnitPrice }).Take(5);

            this.dataGridView2.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var q = from p in this.nwDataSet1.Products
                    where p.UnitPrice >=300
                    select p;

            this.dataGridView2.DataSource = q.ToList();
            if (q.Count() == 0)
            {
               MessageBox.Show("沒有產品單價大於300");
            }
            
        }
    }
}
