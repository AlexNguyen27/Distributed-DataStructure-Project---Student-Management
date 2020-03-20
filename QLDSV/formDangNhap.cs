using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace QLDSV
{
    public partial class formDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public formDangNhap()
        {
            InitializeComponent();
        }

        private void formDangNhap_Load(object sender, EventArgs e)
        {
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLDSVROOT.V_DS_PHANMANH);

            string chuoiketnoi = "Data Source=THANH\\SERVER1;Initial Catalog=QLDSV;Integrated Security=True;";
            Program.conn.ConnectionString = chuoiketnoi;
            Program.conn.Open();
            DataTable dt = new DataTable();
            dt = Program.ExecSqlDataTable("SELECT * FROM V_DS_PHANMANH");
            Program.bds_dspm.DataSource = dt;
            comboBoxChiNhanh.DataSource = dt;
            comboBoxChiNhanh.DisplayMember = "TENCN";
            comboBoxChiNhanh.ValueMember = "TENSERVER";
            comboBoxChiNhanh.SelectedIndex = 1;
            comboBoxChiNhanh.SelectedIndex = 0;
            txtUsername.Focus();
        }

        private void txtUsernameEnter(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals(@"Username"))
            {
                txtUsername.Text = "";
            }
        }

        private void txtUsernameLeave(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals(""))
            {
                txtUsername.Text = @"Username";
            }
        }

        private void txtPasswordEnter(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(@"Password"))
            {
                txtPassword.Text = "";
            }
        }

        private void txtPasswordLeave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(""))
            {
                txtPassword.Text = @"Password";
            }
        }

        public Form isActive(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //txtUsername.Text = "SON";
            //txtPassword.Text = "1234";
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Tên tài khoản không được để trống", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Program.mlogin = txtUsername.Text.Trim();
            Program.password = txtPassword.Text.Trim();
            if (Program.KetNoi() == 0)
            {
                return;
            }
            Program.mChinhanh = comboBoxChiNhanh.SelectedIndex;//xác định chi nhánh
            Program.tenChiNhanh = comboBoxChiNhanh.Text;
            if (Program.tenChiNhanh == "QLDSV_CNTT")
            {
                Program.maCN = "CNTT";
            }
            else if (Program.tenChiNhanh == "QLDSV_VT")
            {
                Program.maCN = "VT";
            }
            else if (Program.tenChiNhanh == "QLDSV_KETOAN")
            {
                Program.maCN = "KETOAN";
            }
            else
            {
                return;
            }
            SqlDataReader myReader;
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;
            String strLenh = "exec SP_DANGNHAP '" + Program.mlogin + "'";
            myReader = Program.ExecSqlDataReader(strLenh);
            if (myReader == null) return;
            myReader.Read();
            Program.username = myReader.GetString(0);
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username của cơ sở dữ liệu", "", MessageBoxButtons.OK);
                return;
            }
            Program.mHoten = myReader.GetString(1);
            Program.mGroup = myReader.GetString(2);
            if(Program.mGroup == "PGV")
            {
                if (Program.conn.State == ConnectionState.Open)
                    Program.conn.Close();
                DataTable dt = new DataTable();
                dt = Program.ExecSqlDataTable("SELECT * FROM V_DS_PHANMANH WHERE TENCN <> 'QLDSV_KETOAN'");
                Program.bds_khoa.DataSource = dt;
                // set cmb start with value of index 0
                Program.mChinhanh = 0;
            }
            myReader.Close();
            Program.conn.Close();

            MessageBox.Show("Đăng Nhập Thành Công", "", MessageBoxButtons.OK);
            
            this.Hide();

            formMain f = new formMain();
            f.HienThiMenu();
            f.ShowDialog();

            this.Close();
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = comboBoxChiNhanh.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                Program.servername = "";
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}