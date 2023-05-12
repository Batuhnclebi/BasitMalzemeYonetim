using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;//Veritabanı bağlantısı için
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokKayit_W12
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {//uygulama açıldığında data grid dolması için
            listele();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        //connection string:
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8AT9VP2;Initial Catalog=Stok3;Integrated Security=SSPI;");



        //
        //Butonlar:
        private void button1_Click(object sender, EventArgs e)
        {//ekle
            string t1 = textBox1.Text; //Malzeme kodu
            string t2 = textBox2.Text; //Malzeme Adı
            string t3 = textBox3.Text; //Yıllık Satış
            string t4 = textBox4.Text; //Birim Fiyat
            string t5 = textBox5.Text; //MinStok
            string t6 = textBox6.Text; //T süresi

            baglanti.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Malzemeler WHERE MalzemeKodu = @malzemeKodu", baglanti);
            cmd.Parameters.AddWithValue("@malzemeKodu", t1);
            int existingRows = (int)cmd.ExecuteScalar();
            if (existingRows == 0)
            {
                SqlCommand komut = new SqlCommand("INSERT INTO Malzemeler (MalzemeKodu, MalzemeAdi, YillikSatis, BirimFiyat, MinStok, TSuresi) VALUES (@malzemeKodu, @malzemeAdi, @yillikSatis, @birimFiyat, @minStok, @tSuresi)", baglanti);
                komut.Parameters.AddWithValue("@malzemeKodu", t1);
                komut.Parameters.AddWithValue("@malzemeAdi", t2);
                komut.Parameters.AddWithValue("@yillikSatis", t3);
                komut.Parameters.AddWithValue("@birimFiyat", t4);
                komut.Parameters.AddWithValue("@minStok", t5);
                komut.Parameters.AddWithValue("@tSuresi", t6);
                komut.ExecuteNonQuery();
                baglanti.Close();
                listele();
            }
            else
            {
                MessageBox.Show("Bu Malzeme Kodu zaten mevcut.");
                baglanti.Close();
            }
            // burada malzeme kodu zaten varsa tekrar tabloya eklenmesini sql den alanı uniq olarak ayarlamadan ve try catch kullanmadan yaptık ayrıcaParametreler kullanarak SQL Injectionu önledik!!
        }
        private void button2_Click(object sender, EventArgs e)
        {//sil   
                string t1 = textBox1.Text;
                baglanti.Open();
                SqlCommand komut = new SqlCommand("DELETE FROM Malzemeler WHERE MalzemeKodu=@MalzemeKodu", baglanti);
                komut.Parameters.AddWithValue("@MalzemeKodu", t1);
                komut.ExecuteNonQuery();
                baglanti.Close();
                listele();

            //  güvenli değil!!
            //string t1 = textBox1.Text; //silerken malzeme kodunu where koşuluna yazarak silme yapmak için 1 den aldık.
            //baglanti.Open();
            //SqlCommand komut = new SqlCommand("DELETE FROM Malzemeler WHERE MalzemeKodu=('"+t1+"')", baglanti);
            //komut.ExecuteNonQuery();
            //baglanti.Close();
            //listele();
            //  güvenli değil!!

            //not veri büyüdüğünde Malzemekodu alanı db de index e eklenmeli
            //not2 tabloya görünsünmü alanı eklenir listeleme methodunun where koşuluna gürnsünmü=1 yazılır ve bu sayede görünsünmü 1 olan kayıtlar gelir. bu sayede sil butonuna tıklandığında ilgili malzemenin görünsünmü alanı 0 yapılarak ekrana gelmemesi sağlanabilir ve db den hiçbir kayıt silinmeden sağlıklı süreç yürütülebilir
        }
        private void button3_Click(object sender, EventArgs e)
        {//güncelle

                string t1 = textBox1.Text; //Malzeme kodu
                string t2 = textBox2.Text; //Malzeme Adı
                string t3 = textBox3.Text; //Yıllık Satış
                string t4 = textBox4.Text; //Birim Fiyat
                string t5 = textBox5.Text; //MinStok
                string t6 = textBox6.Text; //T süresi

                baglanti.Open();

                SqlCommand komut = new SqlCommand("UPDATE Malzemeler SET MalzemeKodu=@malzemeKodu, MalzemeAdi=@malzemeAdi, YillikSatis=@yillikSatis, BirimFiyat=@birimFiyat, MinStok=@minStok, TSuresi=@tSuresi WHERE MalzemeKodu=@malzemeKodu", baglanti);

                komut.Parameters.AddWithValue("@malzemeKodu", t1);
                komut.Parameters.AddWithValue("@malzemeAdi", t2);
                komut.Parameters.AddWithValue("@yillikSatis", t3);
                komut.Parameters.AddWithValue("@birimFiyat", t4);
                komut.Parameters.AddWithValue("@minStok", t5);
                komut.Parameters.AddWithValue("@tSuresi", t6);

                komut.ExecuteNonQuery();

                baglanti.Close();

                listele();
    
            //string t1 = textBox1.Text; //Malzeme kodu
            //string t2 = textBox2.Text; //Malzeme Adı
            //string t3 = textBox3.Text; //Yıllık Satış
            //string t4 = textBox4.Text; //Birim Fiyat
            //string t5 = textBox5.Text; //MinStok
            //string t6 = textBox6.Text; //T süresi
            //
            //baglanti.Open();
            //SqlCommand komut = new SqlCommand("UPDATE Malzemeler SET MalzemeKodu='"+t1+ "',MalzemeAdi='" + t2 + "',YillikSatis='" + t3 + "',BirimFiyat='" + t4 + "',MinStok='" + t5 + "',TSuresi='" + t6 + "' WHERE MalzemeKodu='"+t1+"'", baglanti);
            //komut.ExecuteNonQuery();
            //baglanti.Close();
            //listele();
        }



        private void listele()//veritabanındaki kayıtların görüntülenmesi nesnesi
        {
            baglanti.Open();
            //bağlantıyı açtım

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Malzemeler",baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;

            baglanti.Close();
            //bağlantıyı Kapattım
        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {//data grid de seçilen satırın text box lara yazdıracağız bu sayede güncelleme işlemi kolaylaşacak
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
             this.Close();//nav bar dan uygulamayı kapatmak için
        }
    }
}
