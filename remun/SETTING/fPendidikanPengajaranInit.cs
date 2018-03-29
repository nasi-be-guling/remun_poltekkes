using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using _encryption;
using _connectMySQL;
using System.Globalization;
using System.Threading;

namespace remun.SETTING
{
    public partial class fPendidikanPengajaranInit : Form
    {
        #region KOMPONEN WAJIB
        private readonly CConnection _connect = new CConnection();
        private MySqlConnection _connection;
        private string _sqlQuery;
        private readonly string _configurationManager = Properties.Settings.Default.Setting;

        /*
         * contoh class
        private class Pegawai
        {
            private string id;
            private string nama;

            public Pegawai(string id, string nama)
            {
                this.id = id;
                this.nama = nama;
            }

            public string Id
            {
                get { return id; }
                set { id = value; }
            }
            public string Nama
            {
                get { return nama; }
                set { nama = value; }
            }
        }
          
         */
        #endregion

        #region CLASS

        private class Pegawai
        {
            private string id;
            private string nama;
            private string nip;
            private string statusDosen;
            private string pangkatGolongan;
            private string jabatan;
            private string unitKerja;
            private string namaAtasan;
            private string nipAtasan;
            private string isDosen;
            private string passwd;


            public Pegawai(string id, string nama, string nip, string statusDosen, string pangkatGolongan, string jabatan,
                string unitKerja, string namaAtasan, string nipAtasan, string isDosen, string passwd)
            {
                this.id = id;
                this.nama = nama;
                this.nip = nip;
                this.statusDosen = statusDosen;
                this.pangkatGolongan = pangkatGolongan;
                this.jabatan = jabatan;
                this.unitKerja = unitKerja;
                this.namaAtasan = namaAtasan;
                this.nipAtasan = nipAtasan;
                this.isDosen = isDosen;
                this.passwd = passwd;
            }

            public string Id
            {
                get { return id; }
                set { id = value; }
            }
            public string Nama
            {
                get { return nama; }
                set { nama = value; }
            }
            public string Nip
            {
                get { return nip; }
                set { nip = value; }
            }
            public string StatusDosen
            {
                get { return statusDosen; }
                set { statusDosen = value; }
            }
            public string PangkatGolongan
            {
                get { return pangkatGolongan; }
                set { pangkatGolongan = value; }
            }
            public string Jabatan
            {
                get { return jabatan; }
                set { jabatan = value; }
            }
            public string UnitKerja
            {
                get { return unitKerja; }
                set { unitKerja = value; }
            }
            public string NamaAtasan
            {
                get { return namaAtasan; }
                set { namaAtasan = value; }
            }
            public string NipAtasan
            {
                get { return nipAtasan; }
                set { nipAtasan = value; }
            }
            public string IsDosen
            {
                get { return isDosen; }
                set { isDosen = value; }
            }
            public string Passwd
            {
                get { return passwd; }
                set { passwd = value; }
            }

        }

        private class Menu_Pegawai
        {
            private string id;
            private string nama;
            private string text;
            private string namaForm;
            private string isDosen;
            private string parentMenu;

            public Menu_Pegawai(string id, string nama, string text, string namaForm, string isDosen, string parentMenu)
            {
                this.id = id;
                this.nama = nama;
                this.text = text;
                this.namaForm = namaForm;
                this.isDosen = isDosen;
                this.parentMenu = parentMenu;
            }

            public string Id
            {
                get { return id; }
                set { id = value; }
            }
            public string Nama
            {
                get { return nama; }
                set { nama = value; }
            }
            public string Text
            {
                get { return text; }
                set { text = value; }
            }
            public string NamaForm
            {
                get { return namaForm; }
                set { namaForm = value; }
            }
            public string IsDosen
            {
                get { return isDosen; }
                set { isDosen = value; }
            }
            public string ParentMenu
            {
                get { return parentMenu; }
                set { parentMenu = value; }
            }
        }

        private class Pendidikan_Pengajaran
        {
            private int id;
            private int noUrut;
            private string unsur;
            private int waktu;
            private decimal sks;
            private decimal jam_sks;
            private decimal jam_smt;
            private decimal jam_bln;
            private decimal h1;
            private decimal h2;
            private decimal h3;
            private decimal h4;
            private decimal h5;
            private decimal h6;
            private decimal h7;
            private decimal h8;
            private decimal h9;
            private decimal h10;
            private decimal h11;
            private decimal h12;
            private decimal h13;
            private decimal h14;
            private decimal h15;
            private decimal h16;
            private decimal h17;
            private decimal h18;
            private decimal h19;
            private decimal h20;
            private decimal h21;
            private decimal h22;
            private int idUser;
            private string tanggal;
            private string nama_bulan;
            private string nama_tahun;

            public Pendidikan_Pengajaran(int id, int noUrut, string unsur, int waktu, decimal sks, decimal jam_sks, decimal jam_smt, decimal jam_bln,
                decimal h1, decimal h2, decimal h3, decimal h4, decimal h5, decimal h6, decimal h7, decimal h8, decimal h9, decimal h10, decimal h11,
                decimal h12, decimal h13, decimal h14, decimal h15, decimal h16, decimal h17, decimal h18, decimal h19, decimal h20, decimal h21, decimal h22,
                int idUser, string tanggal, string nama_bulan, string nama_tahun)
            {
                this.id = id;
                this.noUrut = noUrut;
                this.unsur = unsur;
                this.waktu = waktu;
                this.sks = sks;
                this.jam_sks = jam_sks;
                this.jam_smt = jam_smt;
                this.jam_bln = jam_bln;
                this.h1 = h1;
                this.h2 = h2;
                this.h3 = h3;
                this.h4 = h4;
                this.h5 = h5;
                this.h6 = h6;
                this.h7 = h7;
                this.h8 = h8;
                this.h9 = h9;
                this.h10 = h10;
                this.h11 = h11;
                this.h12 = h12;
                this.h13 = h13;
                this.h14 = h14;
                this.h15 = h15;
                this.h16 = h16;
                this.h17 = h17;
                this.h18 = h18;
                this.h19 = h19;
                this.h20 = h20;
                this.h21 = h21;
                this.h22 = h22;
                this.idUser = idUser;
                this.tanggal = tanggal;
                this.nama_bulan = nama_bulan;
                this.nama_tahun = nama_tahun;
            }

            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            public int NoUrut
            {
                get { return noUrut; }
                set { noUrut = value; }
            }
            public string Unsur
            {
                get { return unsur; }
                set { unsur = value; }
            }
            public int Waktu
            {
                get { return waktu; }
                set { waktu = value; }
            }
            public decimal Sks
            {
                get { return sks; }
                set { sks = value; }
            }
            public decimal Jam_sks
            {
                get { return jam_sks; }
                set { jam_sks = value; }
            }
            public decimal Jam_smt
            {
                get { return jam_smt; }
                set { jam_smt = value; }
            }
            public decimal Jam_bln
            {
                get { return jam_bln; }
                set { jam_bln = value; }
            }
            public decimal H1
            {
                get { return h1; }
                set { h1 = value; }
            }
            public decimal H2
            {
                get { return h2; }
                set { h2 = value; }
            }
            public decimal H3
            {
                get { return h3; }
                set { h3 = value; }
            }
            public decimal H4
            {
                get { return h4; }
                set { h4 = value; }
            }
            public decimal H5
            {
                get { return h5; }
                set { h5 = value; }
            }
            public decimal H6
            {
                get { return h6; }
                set { h6 = value; }
            }
            public decimal H7
            {
                get { return h7; }
                set { h7 = value; }
            }
            public decimal H8
            {
                get { return h8; }
                set { h8 = value; }
            }
            public decimal H9
            {
                get { return h9; }
                set { h9 = value; }
            }
            public decimal H10
            {
                get { return h10; }
                set { h10 = value; }
            }
            public decimal H11
            {
                get { return h11; }
                set { h11 = value; }
            }
            public decimal H12
            {
                get { return h12; }
                set { h12 = value; }
            }
            public decimal H13
            {
                get { return h13; }
                set { h13 = value; }
            }
            public decimal H14
            {
                get { return h14; }
                set { h14 = value; }
            }
            public decimal H15
            {
                get { return h15; }
                set { h15 = value; }
            }
            public decimal H16
            {
                get { return h16; }
                set { h16 = value; }
            }
            public decimal H17
            {
                get { return h17; }
                set { h17 = value; }
            }
            public decimal H18
            {
                get { return h18; }
                set { h18 = value; }
            }
            public decimal H19
            {
                get { return h19; }
                set { h19 = value; }
            }
            public decimal H20
            {
                get { return h20; }
                set { h20 = value; }
            }
            public decimal H21
            {
                get { return h21; }
                set { h21 = value; }
            }
            public decimal H22
            {
                get { return h22; }
                set { h22 = value; }
            }
            public int IdUser
            {
                get { return idUser; }
                set { idUser = value; }
            }
            public string Tanggal
            {
                get { return tanggal; }
                set { tanggal = value; }
            }
            public string Nama_bulan
            {
                get { return nama_bulan; }
                set { nama_bulan = value; }
            }
            public string Nama_tahun
            {
                get { return nama_tahun; }
                set { nama_tahun = value; }
            }
        }

        private class Pendidikan_Pengajaran_Init
        {
            private int? id;
            private int noUrut;
            private string unsur;
            private int waktu;
            private decimal sks;
            private decimal jam_sks;
            private decimal jam_smt;
            private decimal jam_bln;
            private decimal h1;
            private decimal h2;
            private decimal h3;
            private decimal h4;
            private decimal h5;
            private decimal h6;
            private decimal h7;
            private decimal h8;
            private decimal h9;
            private decimal h10;
            private decimal h11;
            private decimal h12;
            private decimal h13;
            private decimal h14;
            private decimal h15;
            private decimal h16;
            private decimal h17;
            private decimal h18;
            private decimal h19;
            private decimal h20;
            private decimal h21;
            private decimal h22;
            private int idUser;
            private string tanggal;
            private string nama_bulan;
            private string nama_tahun;
            private string statusTP;

            public Pendidikan_Pengajaran_Init(int? id, int noUrut, string unsur, int waktu, decimal sks, decimal jam_sks, decimal jam_smt, decimal jam_bln,
                decimal h1, decimal h2, decimal h3, decimal h4, decimal h5, decimal h6, decimal h7, decimal h8, decimal h9, decimal h10, decimal h11,
                decimal h12, decimal h13, decimal h14, decimal h15, decimal h16, decimal h17, decimal h18, decimal h19, decimal h20, decimal h21, decimal h22,
                int idUser, string tanggal, string nama_bulan, string nama_tahun, string statusTP)
            {
                this.id = id;
                this.noUrut = noUrut;
                this.unsur = unsur;
                this.waktu = waktu;
                this.sks = sks;
                this.jam_sks = jam_sks;
                this.jam_smt = jam_smt;
                this.jam_bln = jam_bln;
                this.h1 = h1;
                this.h2 = h2;
                this.h3 = h3;
                this.h4 = h4;
                this.h5 = h5;
                this.h6 = h6;
                this.h7 = h7;
                this.h8 = h8;
                this.h9 = h9;
                this.h10 = h10;
                this.h11 = h11;
                this.h12 = h12;
                this.h13 = h13;
                this.h14 = h14;
                this.h15 = h15;
                this.h16 = h16;
                this.h17 = h17;
                this.h18 = h18;
                this.h19 = h19;
                this.h20 = h20;
                this.h21 = h21;
                this.h22 = h22;
                this.idUser = idUser;
                this.tanggal = tanggal;
                this.nama_bulan = nama_bulan;
                this.nama_tahun = nama_tahun;
                this.statusTP = statusTP;
            }

            public int? Id
            {
                get { return id; }
                set { id = value; }
            }
            public int NoUrut
            {
                get { return noUrut; }
                set { noUrut = value; }
            }
            public string Unsur
            {
                get { return unsur; }
                set { unsur = value; }
            }
            public int Waktu
            {
                get { return waktu; }
                set { waktu = value; }
            }
            public decimal Sks
            {
                get { return sks; }
                set { sks = value; }
            }
            public decimal Jam_sks
            {
                get { return jam_sks; }
                set { jam_sks = value; }
            }
            public decimal Jam_smt
            {
                get { return jam_smt; }
                set { jam_smt = value; }
            }
            public decimal Jam_bln
            {
                get { return jam_bln; }
                set { jam_bln = value; }
            }
            public decimal H1
            {
                get { return h1; }
                set { h1 = value; }
            }
            public decimal H2
            {
                get { return h2; }
                set { h2 = value; }
            }
            public decimal H3
            {
                get { return h3; }
                set { h3 = value; }
            }
            public decimal H4
            {
                get { return h4; }
                set { h4 = value; }
            }
            public decimal H5
            {
                get { return h5; }
                set { h5 = value; }
            }
            public decimal H6
            {
                get { return h6; }
                set { h6 = value; }
            }
            public decimal H7
            {
                get { return h7; }
                set { h7 = value; }
            }
            public decimal H8
            {
                get { return h8; }
                set { h8 = value; }
            }
            public decimal H9
            {
                get { return h9; }
                set { h9 = value; }
            }
            public decimal H10
            {
                get { return h10; }
                set { h10 = value; }
            }
            public decimal H11
            {
                get { return h11; }
                set { h11 = value; }
            }
            public decimal H12
            {
                get { return h12; }
                set { h12 = value; }
            }
            public decimal H13
            {
                get { return h13; }
                set { h13 = value; }
            }
            public decimal H14
            {
                get { return h14; }
                set { h14 = value; }
            }
            public decimal H15
            {
                get { return h15; }
                set { h15 = value; }
            }
            public decimal H16
            {
                get { return h16; }
                set { h16 = value; }
            }
            public decimal H17
            {
                get { return h17; }
                set { h17 = value; }
            }
            public decimal H18
            {
                get { return h18; }
                set { h18 = value; }
            }
            public decimal H19
            {
                get { return h19; }
                set { h19 = value; }
            }
            public decimal H20
            {
                get { return h20; }
                set { h20 = value; }
            }
            public decimal H21
            {
                get { return h21; }
                set { h21 = value; }
            }
            public decimal H22
            {
                get { return h22; }
                set { h22 = value; }
            }
            public int IdUser
            {
                get { return idUser; }
                set { idUser = value; }
            }
            public string Tanggal
            {
                get { return tanggal; }
                set { tanggal = value; }
            }
            public string Nama_bulan
            {
                get { return nama_bulan; }
                set { nama_bulan = value; }
            }
            public string Nama_tahun
            {
                get { return nama_tahun; }
                set { nama_tahun = value; }
            }
            public string StatusTP
            {
                get { return statusTP; }
                set { statusTP = value; }
            }
        }

        #region CONTOH CLASS
        /*
         * select 't_pendidikan_pengajaran' into @table; #table name
        select 'remun' into @schema; #database name
        select concat('public class ',@table,'{') union
        select concat('public ',tps.dest,' ',column_name,'{get;set;}') from  information_schema.columns c
        join( #datatypes mapping
        select 'char' as orign ,'string' as dest union all
        select 'varchar' ,'string' union all
        select 'longtext' ,'string' union all
        select 'datetime' ,'DateTime?' union all
        select 'text' ,'string' union all
        select 'bit' ,'int?' union all
        select 'bigint' ,'int?' union all
        select 'int' ,'int?' union all
        select 'double' ,'double?' union all
        select 'decimal' ,'double?' union all
        select 'date' ,'DateTime?' union all
        select 'tinyint' ,'bool?'
        ) tps on c.data_type like tps.orign
        where table_schema=@schema and table_name=@table union
        select '}';
        */
        #endregion

        List<Pegawai> _Pegawai = new List<Pegawai>();
        List<Menu_Pegawai> _Menu_pegawai = new List<Menu_Pegawai>();
        //List<Pendidikan_Pengajaran> _Pendidikan_Pengajaran = new List<Pendidikan_Pengajaran>();
        List<Pendidikan_Pengajaran_Init> _Pendidikan_Pengajaran_Init = new List<Pendidikan_Pengajaran_Init>();
        List<Pendidikan_Pengajaran_Init> _Pendidikan_Pengajaran_Init_temp = new List<Pendidikan_Pengajaran_Init>();

        #endregion

        public fPendidikanPengajaranInit()
        {
            InitializeComponent();
        }

        public string ID_USER;       
        private void fPendidikanPengajaranInit_Load(object sender, EventArgs e)
        {
            _Pendidikan_Pengajaran_Init.Clear();
            lvTampil.Items.Clear();
            Bersih2();
            LoadInitTahun(0);
        }

        private void LoadInitTahun(int loadMode)
        {
            string errMsg = string.Empty;
            _sqlQuery = "";
            _connection = _connect.Connect(_configurationManager, ref errMsg, "GhY873LhT");
            if (errMsg != "")
            {
                MessageBox.Show(errMsg);
                return;
            }
            if (loadMode == 0)
                _sqlQuery = "select * from t_pendidikan_pengajaran_init where idUser = " + CStringCipher.Decrypt(ID_USER, "hjYir83K") +
                    " and nama_bulan = '" + DateTime.Now.Month + "' and nama_tahun = '" + DateTime.Now.Year + "' and status = 1";
            else if (loadMode == 1)
                _sqlQuery = "select * from t_pendidikan_pengajaran_init where idUser = " + CStringCipher.Decrypt(ID_USER, "hjYir83K") +
                    " and nama_bulan = '" + cbBulan.Text + "' and nama_tahun = '" + cbTahun.Text + "' and status = 1";
            MySqlDataReader reader = _connect.Reading(_sqlQuery, _connection, ref errMsg);
            if (errMsg != "")
            {
                MessageBox.Show(errMsg);
                return;
            }
            try
            {
                if (reader.HasRows)
                {
                    int nomorUrut = 1;
                    while (reader.Read())
                    {
                        ListViewItem items = new ListViewItem(Convert.ToString(nomorUrut++.ToString()));
                        items.SubItems.Add(Convert.ToString(reader[2]));
                        items.SubItems.Add(Convert.ToString(reader[3]));
                        items.SubItems.Add(Convert.ToString(reader[4]));
                        items.SubItems.Add(Convert.ToString(reader[5]));
                        items.SubItems.Add(Convert.ToString(reader[6]));
                        items.SubItems.Add(Convert.ToString(reader[7]));
                        items.SubItems.Add("1");
                        items.SubItems.Add(Convert.ToString(reader[0]));
                        lvTampil.Items.Add(items);
                    }
                    lvTampil.Columns[7].Width = 0;
                    lvTampil.Columns[8].Width = 0;
                    lvTampil.Columns[9].Width = 0;
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            _connection.Close();
        }

        private void cbTahun_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtWaktu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == ','
                && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtSKS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == ','
                && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtJamSKS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == ','
                && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtJamSMT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == ','
                && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtJamBLN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == ','
                && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Load Data pada bulan: " + cbBulan.Text + " tahun: " + cbTahun.Text + "?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _Pendidikan_Pengajaran_Init.Clear();
                _Pendidikan_Pengajaran_Init_temp.Clear();
                lvTampil.Items.Clear();
                Bersih2();
                LoadInitTahun(1);
            }
        }

        private void Bersih2()
        {
            foreach (Control tb in Controls)
            {
                if (tb is TextBox)
                {
                    tb.Text = "";
                }
            }
        }

        private bool CekTeksBoxKosong()
        {
            foreach (Control tb in Controls)
            {
                if (tb is TextBox)
                {
                    if (string.IsNullOrEmpty(tb.Text) || string.IsNullOrWhiteSpace(tb.Text))
                        return false;
                }
            }
            return true;
        }
                
        private void bTambah_Click(object sender, EventArgs e)
        {
            if (bTambah.Text == "Tambah")
            {
                if (CekTeksBoxKosong())
                {
                    int noUrut = 1;
                    if (lvTampil.Items.Count > 0)
                        noUrut = lvTampil.Items.Count + 1;
                    ListViewItem items = new ListViewItem(noUrut++.ToString());
                    items.SubItems.Add(txtUnsur.Text);
                    items.SubItems.Add(txtWaktu.Text);
                    items.SubItems.Add(txtSKS.Text);
                    items.SubItems.Add(txtJamSKS.Text);
                    items.SubItems.Add(txtJamSMT.Text);
                    items.SubItems.Add(txtJamBLN.Text);
                    items.SubItems.Add("0");
                    lvTampil.Items.Add(items);
                    lvTampil.Columns[7].Width = 0;
                    lvTampil.Columns[8].Width = 0;
                    lvTampil.Columns[9].Width = 0;
                    Bersih2();
                }
                else
                {
                    MessageBox.Show("Mohon isi data dengan lengkap", "ERROR");
                }
            }
            else
            {
                lvTampil.Items[lvSelectedItemsIndex].SubItems[1].Text = txtUnsur.Text;
                lvTampil.Items[lvSelectedItemsIndex].SubItems[2].Text = txtWaktu.Text;
                lvTampil.Items[lvSelectedItemsIndex].SubItems[3].Text = txtSKS.Text;
                lvTampil.Items[lvSelectedItemsIndex].SubItems[4].Text = txtJamSKS.Text;
                lvTampil.Items[lvSelectedItemsIndex].SubItems[5].Text = txtJamSMT.Text;
                lvTampil.Items[lvSelectedItemsIndex].SubItems[6].Text = txtJamBLN.Text;
                lvTampil.Items[lvSelectedItemsIndex].SubItems[7].Text = "3";
                Bersih2();
                bTambah.Text = "Tambah";
            }
        }

        int lvSelectedItemsIndex;
        private void lvTampil_DoubleClick(object sender, EventArgs e)
        {
            if (lvTampil.SelectedIndices[0] < lvTampil.Items.Count)
            {
                txtUnsur.Text = lvTampil.SelectedItems[0].SubItems[1].Text;
                txtWaktu.Text = lvTampil.SelectedItems[0].SubItems[2].Text;
                txtSKS.Text = lvTampil.SelectedItems[0].SubItems[3].Text;
                txtJamSKS.Text = lvTampil.SelectedItems[0].SubItems[4].Text;
                txtJamSMT.Text = lvTampil.SelectedItems[0].SubItems[5].Text;
                txtJamBLN.Text = lvTampil.SelectedItems[0].SubItems[6].Text;
                lvSelectedItemsIndex = lvTampil.SelectedIndices[0];
                bTambah.Text = "Update";
            }
        }

        private void bSimpan_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            if (bSimpan.Text == "Save")
            {
                if (MessageBox.Show("Apakah sudah fix?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bSimpan.Text = "FIX?";
                    bSimpan.BackColor = Color.Red;
                    int noUrut = 1;
                    if (lvTampil.Items.Count > 0)
                        noUrut = lvTampil.Items.Count + 1;            

                    foreach (ListViewItem items in lvTampil.Items)
                    {
                        if (items.SubItems[7].Text == "0" || items.SubItems[7].Text == "3")
                            _Pendidikan_Pengajaran_Init.Add(new Pendidikan_Pengajaran_Init(null, noUrut++, items.SubItems[1].Text,
                                Convert.ToInt16(items.SubItems[2].Text.Replace(",", ".")), Convert.ToDecimal(items.SubItems[3].Text.Replace(",", ".")), 
                                Convert.ToDecimal(items.SubItems[4].Text.Replace(",", ".")), Convert.ToDecimal(items.SubItems[5].Text.Replace(",", ".")), 
                                Convert.ToDecimal(items.SubItems[6].Text.Replace(",", ".")), 0, 0, 0, 0, 0,
                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt16(CStringCipher.Decrypt(ID_USER, "hjYir83K")),
                                String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), "1"));
                        if (items.SubItems[7].Text == "3")
                            _Pendidikan_Pengajaran_Init_temp.Add(new Pendidikan_Pengajaran_Init(Convert.ToInt16(items.SubItems[8].Text), noUrut++, items.SubItems[1].Text,
                            Convert.ToInt16(items.SubItems[2].Text), Convert.ToDecimal(items.SubItems[3].Text), Convert.ToDecimal(items.SubItems[4].Text),
                            Convert.ToDecimal(items.SubItems[5].Text), Convert.ToDecimal(items.SubItems[6].Text), 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt16(CStringCipher.Decrypt(ID_USER, "hjYir83K")),
                            String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), "1"));
                    }
                }
            }
            else if (bSimpan.Text == "FIX?")
            {
                if (MessageBox.Show("Dengan menekan tombol ini maka anda setuju sudah FIX", 
                    "Confirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {                    
                    bSimpan.Text = "Save";
                    bSimpan.BackColor = Color.LightGray;
                    Bersih2();
                    lvTampil.Items.Clear();                    
                    CommitLinqtoDb(_Pendidikan_Pengajaran_Init);
                    UpdateCommitLinqtoDb(_Pendidikan_Pengajaran_Init_temp);
                    _Pendidikan_Pengajaran_Init.Clear();
                }
            }
        }
        
        private void CommitLinqtoDb(List<Pendidikan_Pengajaran_Init> VarPenelitianPengajaran)
        {
            string errMsg = "";
            _connection = _connect.Connect(_configurationManager, ref errMsg, "GhY873LhT");
            if (errMsg != "")
            {
                MessageBox.Show(errMsg);
                return;
            }            
            var query = (from theThings in VarPenelitianPengajaran select theThings);
            MySqlTransaction _mysqlTrans = _connection.BeginTransaction();
            int noUrut = lvTampil.Items.Count + 1;
            foreach (var things in query)
            {
                _sqlQuery = "insert into t_pendidikan_pengajaran_init (noUrut, unsur, waktu, sks, jam_sks, jam_smt, jam_bln, idUser, tanggal, nama_bulan, nama_tahun, status) " +
                    "values (" + noUrut++ + ",'" + things.Unsur + "','" + things.Waktu + "','" + things.Sks + "','" + things.Jam_sks + "','" + things.Jam_smt +
                    "','" + things.Jam_bln + "','" + things.IdUser + "','" + things.Tanggal + "', '" + things.Nama_bulan + "','" + things.Nama_tahun + "', " + things.StatusTP + ");";
                //Clipboard.SetText(_sqlQuery);

                _connect.Insertion(_sqlQuery, _connection, _mysqlTrans, ref errMsg);

                //_sqlQuery = "insert into t_pendidikan_pengajaran_init (noUrut, unsur, waktu, sks, jam_sks, jam_smt, jam_bln, idUser, tanggal, nama_bulan, nama_tahun, status) " +
                //    "values (@noUrut, @unsur, @waktu, @sks, @jam_sks, @jam_smt, @jam_bln, @idUser, @tanggal, @nama_bulan, @nama_tahun, @status);";

                //MySqlCommand insertCommand = new MySqlCommand(_sqlQuery, _connection, _mysqlTrans);
                //MySqlParameter param1 = new MySqlParameter("@noUrut", MySqlDbType.Int16);
                //param1.Value = noUrut++;
                //insertCommand.Parameters.Add(param1);

                //MySqlParameter param2 = new MySqlParameter("@unsur", MySqlDbType.VarChar);
                //param1.Value = things.Unsur;
                //insertCommand.Parameters.Add(param2);

                //MySqlParameter param3 = new MySqlParameter("@waktu", MySqlDbType.Int16);
                //param1.Value = things.Waktu;
                //insertCommand.Parameters.Add(param3);

                //MySqlParameter param4 = new MySqlParameter("@sks", MySqlDbType.Decimal);
                //param1.Value = things.Sks;
                //insertCommand.Parameters.Add(param4);

                //MySqlParameter param5 = new MySqlParameter("@jam_sks", MySqlDbType.Decimal);
                //param1.Value = things.Jam_sks;
                //insertCommand.Parameters.Add(param5);

                //MySqlParameter param6 = new MySqlParameter("@jam_smt", MySqlDbType.Decimal);
                //param1.Value = things.Jam_smt;
                //insertCommand.Parameters.Add(param6);

                //MySqlParameter param7 = new MySqlParameter("@jam_bln", MySqlDbType.Decimal);
                //param1.Value = things.Jam_bln;
                //insertCommand.Parameters.Add(param7);

                //MySqlParameter param8 = new MySqlParameter("@idUser", MySqlDbType.Int16);
                //param1.Value = things.IdUser;
                //insertCommand.Parameters.Add(param8);

                //MySqlParameter param9 = new MySqlParameter("@tanggal", MySqlDbType.DateTime);
                //param1.Value = things.Tanggal;
                //insertCommand.Parameters.Add(param9);

                //MySqlParameter param10 = new MySqlParameter("@nama_bulan", MySqlDbType.VarChar);
                //param1.Value = things.Nama_bulan;
                //insertCommand.Parameters.Add(param10);

                //MySqlParameter param11 = new MySqlParameter("@nama_tahun", MySqlDbType.VarChar);
                //param1.Value = things.Nama_tahun;
                //insertCommand.Parameters.Add(param11);

                //MySqlParameter param12 = new MySqlParameter("@status", MySqlDbType.Int16);
                //param1.Value = things.StatusTP;
                //insertCommand.Parameters.Add(param12);

                //insertCommand.ExecuteNonQuery();
            }

            if (errMsg != "")
            {
                _mysqlTrans.Rollback();
                MessageBox.Show(errMsg);
                return;
            }
            _mysqlTrans.Commit();
            MessageBox.Show("Data Tersimpan");
            _connection.Close();
        }

        private void UpdateCommitLinqtoDb(List<Pendidikan_Pengajaran_Init> VarPenelitianPengajaran)
        {
            string errMsg = "";
            _connection = _connect.Connect(_configurationManager, ref errMsg, "GhY873LhT");
            if (errMsg != "")
            {
                MessageBox.Show(errMsg);
                return;
            }
            var query = (from theThings in VarPenelitianPengajaran select theThings);
            MySqlTransaction _mysqlTrans = _connection.BeginTransaction();
            foreach (var things in query)
            {
                _sqlQuery = "update t_pendidikan_pengajaran_init set status = 0 where id = '"+ things.Id +"';";
                //Clipboard.SetText(_sqlQuery);
                _connect.Insertion(_sqlQuery, _connection, _mysqlTrans, ref errMsg);
            }

            if (errMsg != "")
            {
                _mysqlTrans.Rollback();
                MessageBox.Show(errMsg);
                return;
            }
            _mysqlTrans.Commit();
            _connection.Close();
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            var query = (from theThings in _Pendidikan_Pengajaran_Init select theThings);
            foreach (var things in query)
            {
                MessageBox.Show(things.Unsur.ToString());
                MessageBox.Show(things.Sks.ToString());
                MessageBox.Show(things.Jam_sks.ToString());
                MessageBox.Show(things.Jam_smt.ToString());
                MessageBox.Show(things.Jam_bln.ToString());                
            }
        }

        private void lvTampil_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvTampil.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            _Pendidikan_Pengajaran_Init_temp.Add(new Pendidikan_Pengajaran_Init(Convert.ToInt16(lvTampil.SelectedItems[0].SubItems[8].Text), 0, "0",
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                            Convert.ToInt16(CStringCipher.Decrypt(ID_USER, "hjYir83K")),
                            String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), "1"));
            lvTampil.SelectedItems[0].Remove();
        }

        private void lvTampil_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex == 7 || e.ColumnIndex == 8 || e.ColumnIndex == 9)
            {
                e.Cancel = true;
                e.NewWidth = 0;
            }
        }
    }
}
