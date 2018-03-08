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

namespace remun.LOGIN
{
    public partial class fLogin : Form
    {
        #region KOMPONEN WAJIB
        private readonly CConnection _connect = new CConnection();
        private MySqlConnection _connection;
        private string _sqlQuery;
        private readonly string _configurationManager = Properties.Settings.Default.Setting;
        #endregion

        ENTRY.fMainMenu _fMainMenu;

        public fLogin()
        {
            InitializeComponent();
        }

        private void CekLogin()
        {
            string idUser = "";
            string password = "";
            string errMsg = "";
            _sqlQuery = "";
            _connection = _connect.Connect(_configurationManager, ref errMsg, "GhY873LhT");
            if (errMsg != "")
            {
                MessageBox.Show(errMsg);
                return;
            }
            _sqlQuery = "select id, passwd from t_user where nip = '" + txtNIP.Text + "'";
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
                    reader.Read();
                    idUser = reader[0].ToString();
                    password = reader[1].ToString();
                    reader.Close();
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

            if (CStringCipher.Decrypt(password, "hjsu939LpTie") == txtPasswd.Text)
            {              
                if ((_fMainMenu = (ENTRY.fMainMenu)FormSudahDibuat(typeof(ENTRY.fMainMenu))) == null)
                {
                    _fMainMenu = new ENTRY.fMainMenu();
                    _fMainMenu.ID_USER = CStringCipher.Encrypt(idUser, "hjYir83K");
                    _fMainMenu.Show();
                }
                else
                {
                    _fMainMenu.ID_USER = CStringCipher.Encrypt(idUser, "hjYir83K");
                    _fMainMenu.Load_Pegawai();
                    _fMainMenu.Select();
                }
                Close();
            }
            else
                MessageBox.Show("User atau password salah", "ERROR");

            _connection.Close();
        }

        public Form FormSudahDibuat(Type tipeForm)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(formTerbuat => formTerbuat.GetType() == tipeForm);
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            CekLogin();
        }
    }
}
