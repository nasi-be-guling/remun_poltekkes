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
using System.Threading;
using System.Globalization;

namespace remun.ENTRY
{
    public partial class fPendidikanPengajaran : Form
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
            private int? id;                         //1
            private int noUrut;                     //2
            private string unsur;                   //3
            private int waktu;                      //4
            private decimal sks;                    //5
            private decimal jam_sks;                //6
            private decimal jam_smt;                //7
            private decimal jam_bln;                //8
            private decimal h1;                     //9
            private decimal h2;                     //10
            private decimal h3;                     //11
            private decimal h4;                     //12
            private decimal h5;                     //13
            private decimal h6;                     //14
            private decimal h7;                     //15
            private decimal h8;                     //16
            private decimal h9;                     //17
            private decimal h10;                    //18
            private decimal h11;                    //19
            private decimal h12;                    //20
            private decimal h13;                    //21
            private decimal h14;                    //22
            private decimal h15;                    //23
            private decimal h16;                    //24
            private decimal h17;                    //25
            private decimal h18;                    //26
            private decimal h19;                    //27
            private decimal h20;                    //28
            private decimal h21;                    //29
            private decimal h22;                    //30
            private int idUser;                     //31
            private string tanggal;                 //32
            private string nama_bulan;              //33
            private string nama_tahun;              //34
            private string statusTP;                //35

            public Pendidikan_Pengajaran(int? id, int noUrut, string unsur, int waktu, decimal sks, decimal jam_sks, decimal jam_smt, decimal jam_bln,
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
        List<Pendidikan_Pengajaran> _Pendidikan_Pengajaran = new List<Pendidikan_Pengajaran>();
        List<Pendidikan_Pengajaran> _Pendidikan_Pengajaran_save = new List<Pendidikan_Pengajaran>();

        #endregion

        public fPendidikanPengajaran()
        {
            InitializeComponent();
        }

        public string ID_USER;
        private void Load_Kegiatan()
        {
            string errMsg = "";
            _connection = _connect.Connect(_configurationManager, ref errMsg, "GhY873LhT");
            if (errMsg != "")
            {
                MessageBox.Show(errMsg);
                return;
            }
            _sqlQuery = "select * from t_pendidikan_pengajaran where idUser = '" + CStringCipher.Decrypt(ID_USER, "hjYir83K") + "'";
            MySqlDataReader reader = _connect.Reading(_sqlQuery, _connection, ref errMsg);
            if (errMsg != "")
            {
                MessageBox.Show(errMsg); lanjut dengan update t_pendidikan_pengajaran jika data ditemukan
                return;
            }
            try
            {
                if (reader.HasRows)
                {
                    int noUrut = 1;
                    while (reader.Read())
                    {
                        _Pendidikan_Pengajaran.Add(new Pendidikan_Pengajaran(Convert.ToInt16(reader[0]), noUrut++, Convert.ToString(reader[2]), Convert.ToInt16(reader[3]),
                            Convert.ToDecimal(reader[4]), Convert.ToDecimal(reader[5]), Convert.ToDecimal(reader[6]), Convert.ToDecimal(reader[7]),
                            Convert.ToDecimal(reader[8]), Convert.ToDecimal(reader[9]), Convert.ToDecimal(reader[10]), Convert.ToDecimal(reader[11]),
                            Convert.ToDecimal(reader[12]), Convert.ToDecimal(reader[13]), Convert.ToDecimal(reader[14]), Convert.ToDecimal(reader[15]),
                            Convert.ToDecimal(reader[16]), Convert.ToDecimal(reader[17]), Convert.ToDecimal(reader[18]), Convert.ToDecimal(reader[19]),
                            Convert.ToDecimal(reader[20]), Convert.ToDecimal(reader[21]), Convert.ToDecimal(reader[22]), Convert.ToDecimal(reader[23]),
                            Convert.ToDecimal(reader[24]), Convert.ToDecimal(reader[25]), Convert.ToDecimal(reader[26]), Convert.ToDecimal(reader[27]),
                            Convert.ToDecimal(reader[28]), Convert.ToDecimal(reader[29]), Convert.ToInt16(reader[30]), Convert.ToString(reader[31]),
                            Convert.ToString(reader[32]), Convert.ToString(reader[33]), Convert.ToString(reader[34])));
                    }
                    reader.Close();
                }
                else
                {
                    Load_Kegiatan_Init();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void Load_Kegiatan_Init()
        {
            string errMsg = "";
            _connection = _connect.Connect(_configurationManager, ref errMsg, "GhY873LhT");
            if (errMsg != "")
            {
                MessageBox.Show(errMsg);
                return;
            }
            _sqlQuery = "select * from t_pendidikan_pengajaran_init where idUser = '" + CStringCipher.Decrypt(ID_USER, "hjYir83K") + "'";
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
                    int noUrut = 1;
                    while (reader.Read())
                    {
                        _Pendidikan_Pengajaran.Add(new Pendidikan_Pengajaran(Convert.ToInt16(reader[0]), noUrut++, Convert.ToString(reader[2]), Convert.ToInt16(reader[3]),
                            Convert.ToDecimal(reader[4]), Convert.ToDecimal(reader[5]), Convert.ToDecimal(reader[6]), Convert.ToDecimal(reader[7]),
                            Convert.ToDecimal(reader[8]), Convert.ToDecimal(reader[9]), Convert.ToDecimal(reader[10]), Convert.ToDecimal(reader[11]),
                            Convert.ToDecimal(reader[12]), Convert.ToDecimal(reader[13]), Convert.ToDecimal(reader[14]), Convert.ToDecimal(reader[15]),
                            Convert.ToDecimal(reader[16]), Convert.ToDecimal(reader[17]), Convert.ToDecimal(reader[18]), Convert.ToDecimal(reader[19]),
                            Convert.ToDecimal(reader[20]), Convert.ToDecimal(reader[21]), Convert.ToDecimal(reader[22]), Convert.ToDecimal(reader[23]),
                            Convert.ToDecimal(reader[24]), Convert.ToDecimal(reader[25]), Convert.ToDecimal(reader[26]), Convert.ToDecimal(reader[27]),
                            Convert.ToDecimal(reader[28]), Convert.ToDecimal(reader[29]), Convert.ToInt16(reader[30]), Convert.ToString(reader[31]),
                            Convert.ToString(reader[32]), Convert.ToString(reader[33]), Convert.ToString(reader[34])));
                    }
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("ANDA BELUM MENENTUKAN TARGET", "ERROR");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void fPendidikanPengajaran_Load(object sender, EventArgs e)
        {
            //dataGridView1.Width = Width;
            //dataGridView1.Height = Height - 300;
            //dataGridView1.Dock = DockStyle.Bottom;
            Load_Kegiatan();
            var query = (from pendidikan_pengajaran in _Pendidikan_Pengajaran select pendidikan_pengajaran);
            dataGridView1.DataSource = query.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            //| System.Windows.Forms.AnchorStyles.Right)));
            //var height = 40;
            //foreach (DataGridViewRow dr in dataGridView1.Rows)
            //{
            //    height += dr.Height;
            //}

            //dataGridView1.Height = Height - 300;
            //dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 30;
            for (int i = dataGridView1.Columns.Count - 5; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Visible = false;
            }
            for (int i = 1; i < 8; i++)
            {
                dataGridView1.Columns[i].ReadOnly = true;
                dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.DarkGray;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("HARAP MASUKKAN DATA YG SESUAI", "ERROR FORMAT");
        }

        private void fill_LinqGroup()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            foreach (DataGridViewRow dgROW in dataGridView1.Rows)
            {
                //MessageBox.Show(dgROW.Cells[1].Value.ToString() + " | " + dgROW.Cells[2].Value.ToString() + " | " + " | " + dgROW.Cells[3].Value.ToString() +
                //    " | " + " | " + dgROW.Cells[4].Value.ToString() + " | " + " | " + dgROW.Cells[5].Value.ToString() + " | " + dgROW.Cells[6].Value.ToString());
                _Pendidikan_Pengajaran_save.Add(new Pendidikan_Pengajaran(null, //1
                    Convert.ToInt16(dgROW.Cells[1].Value),                      //2
                    dgROW.Cells[2].Value.ToString(),                            //3
                    Convert.ToInt16(dgROW.Cells[3].Value),                      //4
                    Convert.ToDecimal(dgROW.Cells[4].Value),                    //5
                    Convert.ToDecimal(dgROW.Cells[5].Value),                    //6
                    Convert.ToDecimal(dgROW.Cells[6].Value),                    //7
                    Convert.ToDecimal(dgROW.Cells[7].Value),                    //8
                    Convert.ToDecimal(dgROW.Cells[8].Value),                    //9
                    Convert.ToDecimal(dgROW.Cells[9].Value),                    //10
                    Convert.ToDecimal(dgROW.Cells[10].Value),                   //11
                    Convert.ToDecimal(dgROW.Cells[11].Value),                   //12
                    Convert.ToDecimal(dgROW.Cells[12].Value),                   //13
                    Convert.ToDecimal(dgROW.Cells[13].Value),                   //14
                    Convert.ToDecimal(dgROW.Cells[14].Value),                   //15
                    Convert.ToDecimal(dgROW.Cells[15].Value),                   //16
                    Convert.ToDecimal(dgROW.Cells[16].Value),                   //17
                    Convert.ToDecimal(dgROW.Cells[17].Value),                   //18
                    Convert.ToDecimal(dgROW.Cells[18].Value),                   //19
                    Convert.ToDecimal(dgROW.Cells[19].Value),                   //20
                    Convert.ToDecimal(dgROW.Cells[20].Value),                   //21
                    Convert.ToDecimal(dgROW.Cells[21].Value),                   //22
                    Convert.ToDecimal(dgROW.Cells[22].Value),                   //23
                    Convert.ToDecimal(dgROW.Cells[23].Value),                   //24
                    Convert.ToDecimal(dgROW.Cells[24].Value),                   //25
                    Convert.ToDecimal(dgROW.Cells[25].Value),                   //26
                    Convert.ToDecimal(dgROW.Cells[26].Value),                   //27
                    Convert.ToDecimal(dgROW.Cells[27].Value),                   //28
                    Convert.ToDecimal(dgROW.Cells[28].Value),                   //29
                    Convert.ToDecimal(dgROW.Cells[29].Value),                   //30
                    Convert.ToInt16(CStringCipher.Decrypt(ID_USER, "hjYir83K")),//31
                    String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now),     //32
                    DateTime.Now.Month.ToString(),                              //33
                    DateTime.Now.Year.ToString(),                               //34
                    "1"                                                         //35
                    ));
            }
        }

        private void CommitLinqtoDb(List<Pendidikan_Pengajaran> VarPenelitianPengajaran)
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
                _sqlQuery = "insert into t_pendidikan_pengajaran values (null, " +
                    things.NoUrut + ",'" + 
                    things.Unsur + "','" + 
                    things.Waktu + "','" + 
                    things.Sks + "','" + 
                    things.Jam_sks + "','" + 
                    things.Jam_smt + "','" + 
                    things.Jam_bln + "','" +
                    things.H1 + "','" +
                    things.H2 + "','" +
                    things.H3 + "','" +
                    things.H4 + "','" +
                    things.H5 + "','" +
                    things.H6 + "','" +
                    things.H7 + "','" +
                    things.H8 + "','" +
                    things.H9 + "','" +
                    things.H10 + "','" +
                    things.H11 + "','" +
                    things.H12 + "','" +
                    things.H13 + "','" +
                    things.H14 + "','" +
                    things.H15 + "','" +
                    things.H16 + "','" +
                    things.H17 + "','" +
                    things.H18 + "','" +
                    things.H19 + "','" +
                    things.H20 + "','" +
                    things.H21 + "','" +
                    things.H22 + "','" +
                    things.IdUser + "','" + 
                    things.Tanggal + "', '" + 
                    things.Nama_bulan + "','" + 
                    things.Nama_tahun + "', " + 
                    things.StatusTP + ");";
                Clipboard.SetText(_sqlQuery);

                _connect.Insertion(_sqlQuery, _connection, _mysqlTrans, ref errMsg);               
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

        private void bSimpan_Click(object sender, EventArgs e)
        {
            if (bSimpan.Text == "Save")
            {
                if (MessageBox.Show("Apakah sudah fix?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bSimpan.Text = "FIX?";
                    bSimpan.BackColor = Color.Red;
                    fill_LinqGroup();
                    _Pendidikan_Pengajaran.Clear();
                }
            }
            else if (bSimpan.Text == "FIX?")
            {
                if (MessageBox.Show("Dengan menekan tombol ini maka anda setuju sudah FIX",
                    "Confirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bSimpan.Text = "Save";
                    bSimpan.BackColor = Color.LightGray;
                    CommitLinqtoDb(_Pendidikan_Pengajaran_save);
                    _Pendidikan_Pengajaran_save.Clear();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var query = (from pendidikan_pengajaran in _Pendidikan_Pengajaran_save select pendidikan_pengajaran);
            foreach (var items in query)
            {
                MessageBox.Show(items.Id.ToString() + " | " + //1
                    items.NoUrut.ToString() + " | " +         //2
                    items.Unsur.ToString() + " | " +         //3
                    items.Waktu.ToString() + " | " +          //4
                    items.Sks.ToString() + " | " +          //5
                    items.Jam_sks.ToString() + " | " +         //6
                    items.Jam_smt.ToString() + " | " +          //7
                    items.Jam_bln.ToString() + " | " +          //8
                    items.H1.ToString() + " | " +         //9
                    items.H2.ToString() + " | " +          //10
                    items.H3.ToString() + " | " +          //11
                    items.H4.ToString() + " | " +         //12
                    items.H5.ToString() + " | " +          //13
                    items.H6.ToString() + " | " +          //14
                    items.H7.ToString() + " | " +         //15
                    items.H8.ToString() + " | " +          //16
                    items.H9.ToString() + " | " +          //17
                    items.H10.ToString() + " | " +         //18
                    items.H11.ToString() + " | " +          //19
                    items.H12.ToString() + " | " +          //20
                    items.H13.ToString() + " | " +         //21
                    items.H14.ToString() + " | " +          //22
                    items.H15.ToString() + " | " +          //23
                    items.H16.ToString() + " | " +         //24
                    items.H17.ToString() + " | " +          //25
                    items.H18.ToString() + " | " +          //26
                    items.H19.ToString() + " | " +         //27
                    items.H20.ToString() + " | " +          //28
                    items.H21.ToString() + " | " +          //29
                    items.H22.ToString() + " | " +         //30
                    items.IdUser.ToString() + " | " +          //31
                    items.Tanggal.ToString() + " | " +          //32
                    items.Nama_bulan.ToString() + " | " +         //33
                    items.Nama_tahun.ToString() + " | " +          //34
                    items.StatusTP.ToString());         //35
            }
        }
    }
}
