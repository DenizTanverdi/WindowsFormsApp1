using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var kisiler = from k in db.KisilerLangirts select k;
            foreach (var item in kisiler)
            {
                if (item.Cinsiyet == 1)
                {
                    listBox1.Items.Add(item.KisilerName);
                    listBox1.ValueMember = "KisilerId";
                    listBox1.DisplayMember = "KisilerName";
                }
                else
                {
                    listBox2.Items.Add(item.KisilerName);
                    listBox2.ValueMember = "KisilerId";
                    listBox2.DisplayMember = "KisilerName";
                }

            }

            listBox4.Items.Add("A");
            listBox4.Items.Add("B");
            listBox4.Items.Add("C");
            listBox4.Items.Add("D");
            listBox4.Items.Add("E");
            listBox4.Items.Add("F");
            listBox4.Items.Add("X");
            listBox4.Items.Add("Y");
            button2.Visible = false;
         
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Random rastgele = new Random();

            int sayi = rastgele.Next(1,16);
            var kisiler = from k in db.KisilerLangirts where k.KisilerID==sayi && k.Cinsiyet==1 && k.Aktif==0 select k;
            
            foreach (var item in kisiler)
            {
                listBox3.Items.Add(item.KisilerName);
                listBox3.ValueMember = "KisilerId";
                listBox3.DisplayMember = "KisilerName";
                var sql = db.KisilerLangirts.FirstOrDefault(I => I.KisilerID == sayi && I.Cinsiyet == 1); sql.Aktif=1;
                db.SubmitChanges();
                button1.Visible = false;
                button2.Visible = true;

            }

                       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();

            int sayi = rastgele.Next(1, 16);
       
            var kisiler = from k in db.KisilerLangirts where k.KisilerID == sayi && k.Cinsiyet == 0 && k.Aktif == 0 select k;
            foreach (var item in kisiler)
            {
                if (listBox3.Items.Count < 2) {
                    listBox3.Items.Add(item.KisilerName);
                    listBox3.ValueMember = "KisilerId";
                    listBox3.DisplayMember = "KisilerName";
                    var sql = db.KisilerLangirts.FirstOrDefault(I => I.KisilerID == sayi && I.Cinsiyet == 0); sql.Aktif = 1;
                    db.SubmitChanges();
                    button1.Visible = true;
                    button2.Visible = false;
                }
                
                


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var Sonuc = from k in db.KisilerLangirts
                        where k.Aktif==1
                        select k;
            foreach (var item in Sonuc)
            {
                item.Aktif = 0;
            }
            db.SubmitChanges();
        }
    }
}
