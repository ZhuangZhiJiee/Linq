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
    public partial class Frm作業_3 : Form
    {
        public Frm作業_3()
        {
            InitializeComponent();
            students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },

                                          };
        }
        List<Student> students_scores;

        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Chi { get; set; }
            public int Eng { get; internal set; }
            public int Math { get; set; }
            public string Gender { get; set; }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            // split=> 數學成績 分成 三群 '待加強'(60~69) '佳'(70~89) '優良'(90~100) 
            var q = from s in students_scores
                    group s by MathScore(s.Math) into g
                    select new { g.Key, count = g.Count() };
            this.dataGridView1.DataSource = q.ToList();
        }

        private object MathScore(int n)
        {
            if (n >= 90)
                return "優良";
            else if (n >= 70)
                return "佳";
            else 
;               return "待加強";
        }

        private void button36_Click(object sender, EventArgs e)
        {
            // 
            // 共幾個 學員成績 ?						
            var q = from s in students_scores

                    select s;

            this.dataGridView1.DataSource = q.ToList();
        }
        

        private void button37_Click(object sender, EventArgs e)
        {
            //new {.....  Min=33, Max=34.}
            // 找出 'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績  |		
            var q = from s in students_scores
                    where s.Name == "aaa" || s.Name == "bbb" || s.Name == "ccc"
                    select new {s.Name,s.Chi,s.Math };
            this.dataGridView1.DataSource = q.ToList();
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 找出 前面三個 的學員所有科目成績
            var q = (from s in students_scores
                     orderby s.Name
                     select s).Take(3);
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 找出 後面兩個 的學員所有科目成績	
            var q = (from s in students_scores
                     orderby s.Name descending
                     select s).Take(2);
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 找出 Name 'aaa','bbb','ccc' 的學成績	
            var q = from s in students_scores
                    where s.Name == "aaa" || s.Name == "bbb" || s.Name == "ccc"
                    orderby s.Name
                    select s;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 找出學員 'bbb' 的成績
            var q = from s in students_scores
                    where s.Name == "bbb"
                    select s;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	
            var q = from s in students_scores
                    where s.Name != "bbb"
                    select s;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var q = from s in students_scores
                    where s.Math <60
                    select s;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //個人 所有科的  sum, min, max, avg
            //var q = from s in students_scores

            //        select new
            //this.dataGridView1.DataSource = q.ToList();
        }


    }
}
