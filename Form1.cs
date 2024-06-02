using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gunes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Çıkış butonu
            //this.Close(); Programı kapatmaya yarıyor
            this.Close();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            // try catch komutuyla gün/hafta kısmındaki textBox ın 0 ve 7 arası değer girmemesi durumunda hata vermesini sağlıyor
            try
            {
                if (Convert.ToInt32(textBox3.Text) < 0 || Convert.ToInt32(textBox3.Text) > 7)
                {
                    MessageBox.Show("0-7 arası değer giriniz"); // hata verdiği zaman yazı çıkmasına yarıyor
                    textBox3.Text = ""; // textbox ın temizlenmesini sağlıyor
                    textBox3.Focus(); // aynı textbox a odaklanmasını sağlıyor
                }
            }
            catch
            {
                MessageBox.Show("Sayısal değer giriniz");
                textBox3.Text = "";
                textBox3.Focus();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            // try catch komutuyla saat/gün kısmındaki textBox ın 0 ve 24 arası değer girmemesi durumunda hata vermesini sağlıyor
            try
            {
                if (Convert.ToInt32(textBox2.Text) < 0 || Convert.ToInt32(textBox2.Text) > 24)
                {
                    MessageBox.Show("0-24 arası değer giriniz");
                    textBox2.Text = "";
                    textBox2.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Sayısal değer giriniz");
                textBox2.Text = "";
                textBox2.Focus();
            }
        }
        double bV,aHg,sK,etSaat,aHd,etAkm,bS,pS,cvG;

        double gli ;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // radiobutton 12 V sçildiğinde değerinin 12 olması için
            if (radioButton1.Checked == true)
                bV = 12;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // radiobutton 24 V sçildiğinde değerinin 24 olması için
            if (radioButton2.Checked == true)
                bV = 24;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hesapla butonu
            float tB4 = Convert.ToInt32(textBox4.Text);
            float gzlC = Convert.ToInt32(gizliC.Text); // visible false yani program çalıştırılınca görülmeyen textbox
            float drAc = Convert.ToInt32(dgrAc.Text);
            float dc = Convert.ToInt32(ddC.Text);
            

            aHg = ((1.2 * (drAc + gli))+dc) / bV / 7;
            
            if (comboBox1.SelectedIndex == 0)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    sK = 1; // Aydın ilinin yazın sıcaklık katsayısı
                    etSaat = 11.89; // Aydın ilinin yazın etkin saat değeri
                }
                if (comboBox2.SelectedIndex == 1)
                {
                    sK = 1.08375; // Aydın ilinin yıllık sıcaklık katsayısı
                    etSaat = 8.294; // Aydın ilinin yıllık etkin saat değeri
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    sK = 1.03; // Erzincan ilinin yazlık sıcaklık katsayısı
                    etSaat = 10.32; // Erzincan ilinin yazlık etkin saat değeri
                }
                if (comboBox2.SelectedIndex == 1)
                {
                    sK = 1.177; // Erzincan ilinin yıllık sıcaklık katsayısı
                    etSaat = 7.029;// Erzincan ilinin yıllık etkin saat değeri
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    sK = 1.027418182; // İstanbul ilinin yazlık sıcaklık katsayısı
                    etSaat = 10.607; // İstanbul ilinin yazlık etkin saat değeri
                }
                if (comboBox2.SelectedIndex == 1)
                {
                    sK = 1.128571429; // İstanbul ilinin yıllık sıcaklık katsayısı
                    etSaat = 6.6958; // İstanbul ilinin yıllık etkin saat değeri
                }
            }

            if (comboBox4.SelectedIndex == 0)
            {
                aHd = 30;
            }
            if (comboBox4.SelectedIndex == 1)
            {
                aHd = 50;
            }
            if (comboBox4.SelectedIndex == 2)
            {
                aHd = 100;
            }
            if (comboBox5.SelectedIndex == 0)
            {
                etAkm = 3;
            }
            if (comboBox5.SelectedIndex == 1)
            {
                etAkm = 5;
            }
            bS = aHg * tB4 * 0.5 * sK / aHd; // Batarya sayısı
            btryS.Text = (bS).ToString();
            pS = 1.2 * aHg / etAkm / etSaat; // Panel sayısı
            pnlS.Text = (pS).ToString();
            cvG =  (gzlC+drAc)* 1.2; // Çevirici gücü
            cevG.Text = (cvG).ToString();
        }
        double fL, cM, dB, yzc, bD, eS, mF, trs, mB, teV;

        private void button3_Click(object sender, EventArgs e)
        {
            // Cihaz ekle butonu
            float t1 = Convert.ToInt32(textBox1.Text); // Adet textbox
            float t2 = Convert.ToInt32(textBox2.Text); // Saat/gün textbox
            float t3 = Convert.ToInt32(textBox3.Text); // Gün/hafta textbox
            float gzli = Convert.ToInt32(gizli.Text);  // Visible false t1*t2*t3*(cihaz güç tüketimi) yazılan textbox
            float gzliC = Convert.ToInt32(gizliC.Text);// Visible false cihaz güç tüketimi yazılan textbox
            float tTV = Convert.ToInt32(txTV.Text);    // 
            float tFL = Convert.ToInt32(txFL.Text);
            float tCM = Convert.ToInt32(txCM.Text);
            float tDB = Convert.ToInt32(txDB.Text);
            float tYZC = Convert.ToInt32(txYZC.Text);// Buradaki textbox lar Visible false dur. Amacı ise cihaz ekle butonuna
            float tBD = Convert.ToInt32(txBD.Text);  // basıldığında değerler arka planda buraya yazılır ve buradanda cihazların
            float tES = Convert.ToInt32(txES.Text);  // sol tarafında sayı yazılmasını sağlamak için kullanılır.
            float tMF = Convert.ToInt32(txMF.Text);
            float tTRS = Convert.ToInt32(txTRS.Text);
            float tMB = Convert.ToInt32(txMB.Text);     //

            if (comboBox3.SelectedIndex == 0)
            {
                teV = 45; // Televizyon un güç tüketimi
                gizliC.Text = (teV + gzliC).ToString(); // Cihazların güç tüketimini toplayan Visible false textbox
                gli = (45 * t1 * t2 * t3) + gzli; 
                gizli.Text = (gli).ToString(); // Cihazların adet*saat*gün*güçtüketimi yazılan visible false textbox

                textBox1.Text = ""; // textbox ın temizlenmesini sağlıyor
                textBox2.Text = "";
                textBox3.Text = "";
                
                txTV.Text = (tTV + 1).ToString(); // Visible false kaç tane televizyon eklendiğini sayıyor ve labell3 e aktarıyor
                labell3.Text = (txTV).Text; // kaç tane televizyon seçildiğini gösteren televizyonun sol kısmındaki label.

            }
            if (comboBox3.SelectedIndex == 1)
            {
                //Florasan lamba
                fL = 10;
                gizliC.Text = (fL + gzliC).ToString();
                gli = (10 * t1 * t2 * t3) + gzli;
                gizli.Text = (gli).ToString();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                txFL.Text = (tFL + 1).ToString();
                label3.Text = (txFL).Text;
            }
            if (comboBox3.SelectedIndex == 2)
            {
                // Çamaşır makinesi
                cM = 425;
                gizliC.Text = (cM + gzliC).ToString();
                gli = (425 * t1 * t2 * t3) + gzli;
                gizli.Text = (gli).ToString();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                txCM.Text = (tCM + 1).ToString();
                label19.Text = (txCM).Text;
            }
            if (comboBox3.SelectedIndex == 3)
            {
                // dizüstü bilgisayar
                dB = 40;
                gizliC.Text = (dB + gzliC).ToString();
                gli = (40 * t1 * t2 * t3) + gzli;
                gizli.Text = (gli).ToString();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                txDB.Text = (tDB + 1).ToString();
                label20.Text = (txDB).Text;
            }
            if (comboBox3.SelectedIndex == 4)
            {
                //yazıcı
                yzc = 100;
                gizliC.Text = (yzc + gzliC).ToString();
                gli = (100 * t1 * t2 * t3) + gzli;
                gizli.Text = (gli).ToString();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                txYZC.Text = (tYZC + 1).ToString();
                label21.Text = (txYZC).Text;
            }
            if (comboBox3.SelectedIndex == 5)
            {
                //buzdolabı
                bD = 120;
                gizliC.Text = (bD + gzliC).ToString();
                gli = (120 * t1 * t2 * t3) + gzli;
                gizli.Text = (gli).ToString();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                txBD.Text = (tBD + 1).ToString();
                label22.Text = (txBD).Text;
            }
            if (comboBox3.SelectedIndex == 6)
            {
                //elektirikli saat
                eS = 3;
                gizliC.Text = (eS + gzliC).ToString();
                gli = (3 * t1 * t2 * t3) + gzli;
                gizli.Text = (gli).ToString();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                txES.Text = (tES + 1).ToString();
                label23.Text = (txES).Text;
            }
            if (comboBox3.SelectedIndex == 7)
            {
                //mikrodalga fırın
                mF = 900;
                gizliC.Text = (mF + gzliC).ToString();
                gli = (900 * t1 * t2 * t3) + gzli;
                gizli.Text = (gli).ToString();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                txMF.Text = (tMF + 1).ToString();
                label24.Text = (txMF).Text;
            }
            if (comboBox3.SelectedIndex == 8)
            {
                //traş makinesi
                trs = 15;
                gizliC.Text = (trs + gzliC).ToString();
                gli = (15 * t1 * t2 * t3) + gzli;
                gizli.Text = (gli).ToString();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                txTRS.Text = (tTRS + 1).ToString();
                label25.Text = (txTRS).Text;
            }
            if (comboBox3.SelectedIndex == 9)
            {
                // masaüstü bilgisayar
                mB = 120;
                gizliC.Text = (mB + gzliC).ToString();
                gli = (120 * t1 * t2 * t3) + gzli;
                gizli.Text = (gli).ToString();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                txMB.Text = (tMB + 1).ToString();
                label26.Text = (txMB).Text;
            }
        }
    }
}
