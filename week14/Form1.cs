using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace week14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textboxtan xml'e

            XmlDocument dosya = new XmlDocument();
            dosya.Load(Application.StartupPath + "\\isim.xml");

            XmlElement ogrenci = dosya.CreateElement("ogrenci");
            ogrenci.SetAttribute("kimlik", textBox1.Text);

            XmlNode tc_kimlik = dosya.CreateNode(XmlNodeType.Element, "tc_kimlik", "");
            tc_kimlik.InnerText = textBox2.Text;
            ogrenci.AppendChild(tc_kimlik);

            XmlNode adi = dosya.CreateNode(XmlNodeType.Element, "adi", "");
            adi.InnerText = textBox3.Text;
            ogrenci.AppendChild(adi);

            XmlNode soyadi = dosya.CreateNode(XmlNodeType.Element, "soyadi", "");
            soyadi.InnerText = textBox4.Text;
            ogrenci.AppendChild(soyadi);

            XmlNode adresi = dosya.CreateNode(XmlNodeType.Element, "adresi", "");
            adresi.InnerText = textBox5.Text;
            ogrenci.AppendChild(adresi);

            XmlNode ders_adi = dosya.CreateNode(XmlNodeType.Element, "ders_adi", "");
            ders_adi.InnerText = textBox6.Text;
            ogrenci.AppendChild(ders_adi);

            XmlNode vize1 = dosya.CreateNode(XmlNodeType.Element, "vize", "");
            vize1.InnerText = textBox7.Text;
            ogrenci.AppendChild(vize1);

            XmlNode final = dosya.CreateNode(XmlNodeType.Element, "final", "");
            final.InnerText = textBox8.Text;
            ogrenci.AppendChild(final);

            XmlNode sonuc = dosya.CreateNode(XmlNodeType.Element, "sonuc", "");
            sonuc.InnerText = textBox9.Text;
            ogrenci.AppendChild(sonuc);

            dosya.DocumentElement.AppendChild(ogrenci);
            dosya.Save(Application.StartupPath + "\\isim.xml");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //xmlden textboxa

            XmlDocument dosya = new XmlDocument();
            dosya.Load(Application.StartupPath + "\\isim.xml");
            XmlNodeList liste = dosya.GetElementsByTagName("ogrenci");

            foreach (XmlNode ogr_liste in liste)
            {
                string kimlik = ogr_liste.Attributes["kimlik"].Value;
                string tc_kimlik = ogr_liste["tc_kimlik"].FirstChild.Value;
                string adi = ogr_liste["adi"].FirstChild.Value;
                string soyadi = ogr_liste["soyadi"].FirstChild.Value;
                string adresi = ogr_liste["adresi"].FirstChild.Value;
                string ders_adi = ogr_liste["ders_adi"].FirstChild.Value;
                string vize = ogr_liste["vize"].FirstChild.Value;
                string final = ogr_liste["final"].FirstChild.Value;
                string sonuc = ogr_liste["sonuc"].FirstChild.Value;

                textBox1.Text = kimlik;
                textBox2.Text = tc_kimlik;
                textBox3.Text = adi;
                textBox4.Text = soyadi;
                textBox5.Text = adresi;
                textBox6.Text = ders_adi;
                textBox7.Text = vize;
                textBox8.Text = final;
                textBox9.Text = sonuc;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //xmlden listboxa

            XmlDocument dosya = new XmlDocument();
            dosya.Load(Application.StartupPath + "\\isim.xml");
            XmlNodeList liste = dosya.GetElementsByTagName("ogrenci");

            foreach (XmlNode ogr_liste in liste)
            {
                string kimlik = ogr_liste.Attributes["kimlik"].Value;
                string tc_kimlik = ogr_liste["tc_kimlik"].FirstChild.Value;
                string adi = ogr_liste["adi"].FirstChild.Value;
                string soyadi = ogr_liste["soyadi"].FirstChild.Value;
                string adresi = ogr_liste["adresi"].FirstChild.Value;
                string ders_adi = ogr_liste["ders_adi"].FirstChild.Value;
                string vize = ogr_liste["vize"].FirstChild.Value;
                string final = ogr_liste["final"].FirstChild.Value;
                string sonuc = ogr_liste["sonuc"].FirstChild.Value;

                listBox1.Items.Add("kimlik="+kimlik);
                listBox1.Items.Add("tc="+tc_kimlik);
                listBox1.Items.Add("adi="+adi);
                listBox1.Items.Add("soyadi="+soyadi);
                listBox1.Items.Add("adres="+adresi);
                listBox1.Items.Add("dersin adi="+ders_adi);
                listBox1.Items.Add("vize="+vize);
                listBox1.Items.Add("final="+final);
                listBox1.Items.Add("sonuc="+sonuc);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //xml'den listview'a

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "\\isim.xml");

                XmlNodeList studentNodes = xmlDoc.SelectNodes("/Basarı_notu/ogrenci");
                listView1.View = View.Details;
                foreach (XmlNode studentNode in studentNodes)
                {
                    string kimlik = studentNode.Attributes["kimlik"].Value;

                    string tc_kimlik = studentNode["tc_kimlik"].InnerText;
                    string adi = studentNode["adi"].InnerText;
                    string soyadi = studentNode["soyadi"].InnerText;
                    string adresi = studentNode["adresi"].InnerText;
                    string ders_adi = studentNode["ders_adi"].InnerText;
                    string vize = studentNode["vize"].InnerText;
                    string final = studentNode["final"].InnerText;
                    string sonuc = studentNode["sonuc"].InnerText;
                    ListViewItem item = new ListViewItem(kimlik);
                    item.SubItems.Add(tc_kimlik);
                    item.SubItems.Add(adi);
                    item.SubItems.Add(soyadi);
                    item.SubItems.Add(adresi);
                    item.SubItems.Add(ders_adi);
                    item.SubItems.Add(vize);
                    item.SubItems.Add(final);
                    item.SubItems.Add(sonuc);
                    listView1.Items.Add(item);
                }
                //try ve catch mutlaka unutma kullan
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //listview'ın çalışması için gereken kolon başlıkları bu olmadan listview çalışmaz

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("kimlik", 50);
            listView1.Columns.Add("tc_kimlik", 50);
            listView1.Columns.Add("adi", 50);
            listView1.Columns.Add("soyadi", 50);
            listView1.Columns.Add("adresi", 50);
            listView1.Columns.Add("ders_adi", 50);
            listView1.Columns.Add("vize", 50);
            listView1.Columns.Add("final", 50);
            listView1.Columns.Add("sonuc", 50);

        }

    }
}
