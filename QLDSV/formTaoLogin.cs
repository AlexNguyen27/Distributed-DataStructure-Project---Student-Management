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

namespace QLDSV
{
    public partial class formTaoLogin : DevExpress.XtraEditors.XtraForm
    {
        public static String quyen = "";
        public static String username = "";
        public static String pass = "";
        public static String loginName = "";

        public const String variablePGV = "PGV";
        public const String variableKHOA = "KHOA";
        public const String variableKETOAN = "KETOAN";

        public formTaoLogin()
        {
            InitializeComponent();
        }

        private void gIANGVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gIANGVIENBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLDSVROOT);

        }

        private void setRoleUser()
        {
            IDictionary<String, String> dict = new Dictionary<String, String>();
            if (Program.mGroup == variablePGV)
            {
                dict.Add(variablePGV, variablePGV);
                dict.Add(variableKHOA, variableKHOA);
            }else if(Program.mGroup == variableKHOA)
            {
                comboBoxQuyen.Enabled = false;
                dict.Add(variableKHOA, variableKHOA);
            }
            else
            {
                comboBoxQuyen.Enabled = false;
                dict.Add(variableKETOAN, variableKETOAN);
            }
            comboBoxQuyen.DataSource = new BindingSource(dict, null);
            comboBoxQuyen.DisplayMember = "Value";
            comboBoxQuyen.ValueMember = "Key";
        }

        private void formTaoLogin_Load(object sender, EventArgs e)
        {
            this.qLDSVROOT.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'qLDSVROOT.GIANGVIEN' table. You can move, or remove it, as needed.
            this.gIANGVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIANGVIENTableAdapter.Fill(this.qLDSVROOT.GIANGVIEN);
            setRoleUser();
        }


        public Boolean checkInfoGV()
        {
            if (this.cmbMaGV.Text.Trim() == "")
            {
                MessageBox.Show("Mã giảng viên không được thiếu.\n", "", MessageBoxButtons.OK);
                cmbMaGV.Focus();
                return false;
            }
            if (this.txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Mật khẩu giảng viên không được thiếu.\n", "", MessageBoxButtons.OK);
                txtMatKhau.Focus();
                return false;
            }
            if (comboBoxQuyen.Text.Trim() == "")
            {
                MessageBox.Show("Quyền giảng viên không được thiếu.\n", "", MessageBoxButtons.OK);
                comboBoxQuyen.Focus();
                return false;
            }


            if (textBoxtenDangNhap.Text.Trim() == "")
            {
                MessageBox.Show("Tên đăng nhập không được thiếu.\n", "", MessageBoxButtons.OK);
                textBoxtenDangNhap.Focus();
                return false;
            }
            return true;
        }

        public void acceptInfo()
        {
            loginName = textBoxtenDangNhap.Text.Trim();
            username = cmbMaGV.Text.Trim();
            pass = txtMatKhau.Text.Trim();
            quyen = comboBoxQuyen.Text.Trim();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Boolean checkEmpty = checkInfoGV();
            //ring s = comboBoxQuyen.Items[2].ToString();
            if (checkEmpty)
            {
                try
                {
                    if (Program.conn.State == ConnectionState.Closed)
                        Program.conn.Open();
                    acceptInfo();
                    String strLenh = "sp_TaoTaiKhoan";
                    Program.sqlcmd = Program.conn.CreateCommand();
                    Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                    Program.sqlcmd.CommandText = strLenh;
                    Program.sqlcmd.Parameters.Add("@LGNAME", SqlDbType.VarChar).Value = loginName;
                    Program.sqlcmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = pass;
                    Program.sqlcmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = username;
                    Program.sqlcmd.Parameters.Add("@ROLE ", SqlDbType.VarChar).Value = quyen;
                    Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    Program.sqlcmd.ExecuteNonQuery();
                    Program.conn.Close();
                    MessageBox.Show("Thêm thành công", "Thông Báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tạo tài khoản.\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Không được để trống thông tin", "", MessageBoxButtons.OK);
                return;
            }

        }

        private void comboBoxQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.maCN = comboBoxQuyen.Items[comboBoxQuyen.SelectedIndex].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn quyền.\n" + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            try
            {
                this.gIANGVIENTableAdapter.Fill(this.qLDSVROOT.GIANGVIEN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload :" + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}