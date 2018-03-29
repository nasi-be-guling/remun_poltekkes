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

namespace remun.ENTRY
{
    public partial class fMainMenu : Form
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
            private int id;
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


            public Pegawai(int id, string nama, string nip, string statusDosen, string pangkatGolongan, string jabatan,
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

            public int Id
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
            private int id;
            private string nama;
            private string text;
            private string namaForm;
            private string isDosen;
            private string parentMenu;

            public Menu_Pegawai(int id, string nama, string text, string namaForm, string isDosen, string parentMenu)
            {
                this.id = id;
                this.nama = nama;
                this.text = text;
                this.namaForm = namaForm;
                this.isDosen = isDosen;
                this.parentMenu = parentMenu;
            }

            public int Id
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
        
        List<Pegawai> _Pegawai = new List<Pegawai>();
        List<Menu_Pegawai> _Menu_pegawai = new List<Menu_Pegawai>();

        #endregion

        public fMainMenu()
        {
            InitializeComponent();
        }

        public string ID_USER;

        public void Load_Pegawai()
        {
            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel2.Text = "";
            string errMsg = "";
            _connection = _connect.Connect(_configurationManager, ref errMsg, "GhY873LhT");
            if (errMsg != "")
            {
                MessageBox.Show(errMsg);
                return;
            }
            _sqlQuery = "select * from t_user where id = '" + CStringCipher.Decrypt(ID_USER, "hjYir83K") + "'";
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
                    while (reader.Read())
                    {
                        _Pegawai.Add(new Pegawai(Convert.ToInt16(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]),
                            Convert.ToString(reader[3]), Convert.ToString(reader[4]), Convert.ToString(reader[5]), Convert.ToString(reader[6]),
                            Convert.ToString(reader[7]), Convert.ToString(reader[8]), Convert.ToString(reader[9]), Convert.ToString(reader[10])));
                    }
                    reader.Close();
                    var query = (from i in _Pegawai select i);
                    foreach (var item in query)
                    {
                        toolStripStatusLabel1.Text = "Nama: " + item.Nama;
                        toolStripStatusLabel2.Text = " | NIP: " + item.Nip;
                        statusPegawai = Convert.ToInt16(item.IsDosen);
                    }
                }
                else
                {
                    MessageBox.Show("User atau password salah", "ERROR");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Load_Menu();
        }
                
        private bool CekInitTahun(string SqlQueryCek)
        {
            string errMsg = string.Empty;
            bool status = false;
            _sqlQuery = "";
            _connection = _connect.Connect(_configurationManager, ref errMsg, "GhY873LhT");
            if (errMsg != "")
            {
                MessageBox.Show(errMsg);
                return false;
            }
            //_sqlQuery = "select id from t_pendidikan_pengajaran_init where idUser = " + CStringCipher.Decrypt(ID_USER, "hjYir83K") +
            //    " and nama_bulan = " + DateTime.Now.Month + "";
            MySqlDataReader reader = _connect.Reading(SqlQueryCek, _connection, ref errMsg);
            if (errMsg != "")
            {
                MessageBox.Show(errMsg);
                return false;
            }
            try
            {
                if (reader.HasRows)
                    status = true;
                else
                    status = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            _connection.Close();
            return status;
        }

        private int statusPegawai = 0;
        private void Load_Menu()
        {
            string errMsg = "";
            _connection = _connect.Connect(_configurationManager, ref errMsg, "GhY873LhT");
            if (errMsg != "")
            {
                MessageBox.Show(errMsg);
                return;
            }
            if (statusPegawai == 1)
                _sqlQuery = "select * from t_menu where isDosen = 1";
            else
                _sqlQuery = "select * from t_menu where isDosen = 0";
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
                    while (reader.Read())
                    {
                        _Menu_pegawai.Add(new Menu_Pegawai(Convert.ToInt16(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), 
                            Convert.ToString(reader[3]), Convert.ToString(reader[4]), Convert.ToString(reader[5])));
                    }
                    reader.Close();
                    var query = (from i in _Menu_pegawai select i);
                    foreach (var item in query)
                    {
                        if (item.ParentMenu == "entry")
                        {
                            ToolStripMenuItem SSMenu = new ToolStripMenuItem(item.Text, null, new EventHandler(ChildClick), item.Nama);
                            entryToolStripMenuItem.DropDownItems.Add(SSMenu);
                        }
                        if (item.ParentMenu == "report")
                        {
                            ToolStripMenuItem SSMenu = new ToolStripMenuItem(item.Text, null, new EventHandler(ChildClick), item.Nama);
                            laporanToolStripMenuItem.DropDownItems.Add(SSMenu);
                        }
                        if (item.ParentMenu == "setting")
                        {
                            ToolStripMenuItem SSMenu = new ToolStripMenuItem(item.Text, null, new EventHandler(ChildClick), item.Nama);
                            settingToolStripMenuItem.DropDownItems.Add(SSMenu);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("User atau password salah", "ERROR");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void ChildClick(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem.Name == "mPendidikanPengajaran")
            {
                if (!CekInitTahun("select id from t_pendidikan_pengajaran_init where idUser = " + CStringCipher.Decrypt(ID_USER, "hjYir83K") +
                " and nama_bulan = " + DateTime.Now.Month + " and nama_tahun = " + DateTime.Now.Year + ""))
                {
                    MessageBox.Show("Anda Belum Menentukan Target\nSilahkan Klik Setting > Inisiasi");
                    return;
                }
                if (CekInitTahun("select id from t_pendidikan_pengajaran where idUser = " + CStringCipher.Decrypt(ID_USER, "hjYir83K") +
                " and nama_bulan = " + DateTime.Now.Month + " and nama_tahun = " + DateTime.Now.Year + ""))
                {
                    if (MessageBox.Show("Anda sudah Mengisi Remun Bulan ini\nLanjut load data?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
                ENTRY.fPendidikanPengajaran _fPendidikanPengajaran;
                if ((_fPendidikanPengajaran = (ENTRY.fPendidikanPengajaran)FormSudahDibuat(typeof(ENTRY.fPendidikanPengajaran))) == null)
                {
                    _fPendidikanPengajaran = new ENTRY.fPendidikanPengajaran();
                    _fPendidikanPengajaran.ID_USER = ID_USER;
                    _fPendidikanPengajaran.MdiParent = this;
                    _fPendidikanPengajaran.WindowState = FormWindowState.Maximized;
                    _fPendidikanPengajaran.Show();
                }
                else
                {
                    //_fPendidikanPengajaran.ID_USER = CStringCipher.Encrypt(idUser, "hjYir83K");
                    //_fPendidikanPengajaran.Load_Pegawai();
                    //_fPendidikanPengajaran.Location = new Point(200, 200);
                    _fPendidikanPengajaran.WindowState = FormWindowState.Maximized;
                    _fPendidikanPengajaran.Select();
                }
            }
            if (menuItem.Name == "mPenelitian")
            {
                ENTRY.fPenelitian _fPenelitian;
                if ((_fPenelitian = (ENTRY.fPenelitian)FormSudahDibuat(typeof(ENTRY.fPenelitian))) == null)
                {
                    _fPenelitian = new ENTRY.fPenelitian();
                    _fPenelitian.MdiParent = this;
                    _fPenelitian.WindowState = FormWindowState.Maximized;
                    _fPenelitian.Show();
                }
                else
                {
                    _fPenelitian.WindowState = FormWindowState.Maximized;
                    _fPenelitian.Select();
                }
            }
            if (menuItem.Name == "mPendidikanPengajaran_init")
            {
                if (CekInitTahun("select id from t_pendidikan_pengajaran_init where idUser = " + CStringCipher.Decrypt(ID_USER, "hjYir83K") +
                " and nama_bulan = " + DateTime.Now.Month + ""))
                {
                    if (MessageBox.Show("Anda sudah menentukan target bulan ini, load data?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
                {
                    SETTING.fPendidikanPengajaranInit _fPendidikanPengajaran_init;
                    if ((_fPendidikanPengajaran_init = (SETTING.fPendidikanPengajaranInit)FormSudahDibuat(typeof(SETTING.fPendidikanPengajaranInit))) == null)
                    {
                        _fPendidikanPengajaran_init = new SETTING.fPendidikanPengajaranInit();
                        _fPendidikanPengajaran_init.ID_USER = ID_USER;
                        _fPendidikanPengajaran_init.MdiParent = this;
                        _fPendidikanPengajaran_init.WindowState = FormWindowState.Maximized;
                        _fPendidikanPengajaran_init.Show();
                    }
                    else
                    {
                        //_fPendidikanPengajaran.ID_USER = CStringCipher.Encrypt(idUser, "hjYir83K");
                        //_fPendidikanPengajaran.Load_Pegawai();
                        //_fPendidikanPengajaran.Location = new Point(200, 200);
                        _fPendidikanPengajaran_init.WindowState = FormWindowState.Maximized;
                        _fPendidikanPengajaran_init.Select();
                    }
                }
            }
            else
                return;
        }

        private void fMainMenu_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel2.Text = "";
            LOGIN.fLogin _fLogin = new LOGIN.fLogin();
            _fLogin.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public Form FormSudahDibuat(Type tipeForm)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(formTerbuat => formTerbuat.GetType() == tipeForm);
        }
    }
}
