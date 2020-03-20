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
    public partial class formChuyenLop : DevExpress.XtraEditors.XtraForm
    {
        public formChuyenLop()
        {
            InitializeComponent();
        }
        public void enableInput()
        {
            txtMaSV.Enabled = false;
            txtHo.Enabled = false;
            txtTen.Enabled = false;
            txtMaLop.Enabled = false;
            comboNgaySinh.Enabled = false;
            txtNoiSinh.Enabled = false;
            txtDiaChi.Enabled = false;
            cbPhai.Enabled = false;
            cbNghiHoc.Enabled = false;
            txtTL.Enabled = false;
        }
        public void info()
        {
            txtMaSV.Text = formSinhVien.saveInfo.maSV;
            txtHo.Text = formSinhVien.saveInfo.ho;
            txtTen.Text = formSinhVien.saveInfo.ten;
            txtMaLop.Text = formSinhVien.saveInfo.maLop;
            comboNgaySinh.Text = formSinhVien.saveInfo.ngaySinh;
            txtNoiSinh.Text = formSinhVien.saveInfo.noiSinh;
            txtDiaChi.Text = formSinhVien.saveInfo.diaChi;
            cbPhai.Checked = formSinhVien.saveInfo.phai;
            cbNghiHoc.Checked = formSinhVien.saveInfo.nghiHoc;
            txtTL.Text = txtMaLop.Text;
            txtML.Text = txtMaLop.Text;
        }
        public void cmdSinhVien(String maSV, String ho, String ten, String maLop,
                               Boolean checkBoxPhai, String comboNgaySinh, String noiSinh,
                               String diaChi, Boolean checkboxNghiHoc)
        {
            if (Program.conn.State == ConnectionState.Closed)
                Program.conn.Open();
            try
            {
                Program.sqlcmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = maSV;
                Program.sqlcmd.Parameters.Add("@HO", SqlDbType.NVarChar).Value = ho;
                Program.sqlcmd.Parameters.Add("@TEN", SqlDbType.NVarChar).Value = ten;
                Program.sqlcmd.Parameters.Add("@MALOP", SqlDbType.NChar).Value = maLop;
                Program.sqlcmd.Parameters.Add("@PHAI", SqlDbType.Bit).Value = checkBoxPhai ? 1 : 0;
                Program.sqlcmd.Parameters.Add("@NGAYSINH", SqlDbType.NVarChar).Value = comboNgaySinh;
                Program.sqlcmd.Parameters.Add("@NOISINH", SqlDbType.NVarChar).Value = noiSinh;
                Program.sqlcmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = diaChi;
                Program.sqlcmd.Parameters.Add("@NGHIHOC", SqlDbType.Bit).Value = checkboxNghiHoc ? 1 : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi sinh viên.\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void formChuyenLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSVROOT.SP_ThongTinMaLopSiteKhac1' table. You can move, or remove it, as needed.

            this.qLDSVROOT.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'qLDSVROOT.SP_ThongTinMaLopSiteKhac' table. You can move, or remove it, as needed.
            this.sP_ThongTinMaLopSiteKhacTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_ThongTinMaLopSiteKhacTableAdapter.Fill(this.qLDSVROOT.SP_ThongTinMaLopSiteKhac);
            // TODO: This line of code loads data into the 'qLDSVPMMaster.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLDSVPMMaster.V_DS_PHANMANH);
            // TODO: This line of code loads data into the 'qLDSVPMMaster.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLDSVPMMaster.V_DS_PHANMANH);
            // TODO: This line of code loads data into the 'qLDSVROOT.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.qLDSVROOT.LOP);
            enableInput();
            info();
            toolStripStatusMaSV.Text = "MaSV: " + txtMaSV.Text;
            toolStripStatusHoTen.Text = "Họ Tên: " + txtHo.Text + " " + txtTen.Text;
            tooltipMaSV.Text = "MaSV: " + txtMaSV.Text;
            tooltipHoTen.Text = "Họ Tên: " + txtHo.Text + " " + txtTen.Text;

            if (Program.mGroup == "KHOA")
            {
                comboKHOA.DataSource = Program.bds_dspm.DataSource;
                comboKHOA.DisplayMember = "TENCN";
                comboKHOA.ValueMember = "TENSERVER";
                // We set mChinhanh when Login 
                comboKHOA.SelectedIndex = Program.mChinhanh;
                comboKHOA.Enabled = false;
            }
            if (Program.mGroup == "PGV")
            {
                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();
                DataTable dt = new DataTable();
                dt = Program.ExecSqlDataTable("SELECT * FROM V_DS_PHANMANH WHERE TENCN <> 'QLDSV_KETOAN'");

                comboKHOA.DataSource = dt;
                comboKHOA.DisplayMember = "TENCN";
                comboKHOA.ValueMember = "TENSERVER";
                comboKHOA.SelectedIndex = Program.mChinhanh;
            }
        }

        public int checkSVCoDiemTonTai(String maSV)
        {
            try
            {
                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();
                String strLenh = "SP_KiemTraDiemTonTaiSinhVien";
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = strLenh;
                Program.sqlcmd.Parameters.Add("@MaSV", SqlDbType.NChar).Value = maSV;
                Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.sqlcmd.ExecuteNonQuery();
                String ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
                if (ret == "1")
                {

                    return 1;
                }
                if (ret == "2")
                {
                    return 2;
                }
                if (ret == "0")
                {
                    return 0;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi .\n" + ex.Message, "", MessageBoxButtons.OK);
            }
            return 0;
        }

        private int kiemTraServer()
        {
            if (comboKHOA.Text == Program.servername)
            {
                return 1;
            }
            else
            {
                return 2;
            }
            return 0;
        }

        private void btnChuyenLop_Click(object sender, EventArgs e)
        {
            try
            {
                int check = checkSVCoDiemTonTai(txtMaSV.Text);
                if (check == 1)
                {
                    MessageBox.Show("Sinh viên đã có điểm! Không được chuyển lớp.\n", "", MessageBoxButtons.OK);
                }
                else if (check == 2)
                {
                    MessageBox.Show("Sinh viên đã nghĩ học không được chuyển lớp.\n", "", MessageBoxButtons.OK);
                }
                else
                {
                    if (Program.conn.State == ConnectionState.Closed)
                        Program.conn.Open();
                    String maLop = comboMaLop.SelectedValue.ToString();
                    String updateSinhVien = "SP_UpdateSinhVien";
                    Program.sqlcmd = Program.conn.CreateCommand();
                    Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                    Program.sqlcmd.CommandText = updateSinhVien;
                    cmdSinhVien(txtMaSV.Text, txtHo.Text, txtTen.Text, maLop, cbPhai.Checked,
                           comboNgaySinh.Text, txtNoiSinh.Text, txtDiaChi.Text, cbNghiHoc.Checked);
                    Program.sqlcmd.ExecuteNonQuery();
                    Program.conn.Close();
                    MessageBox.Show("Chuyển lớp thành công!", "", MessageBoxButtons.OK);
                    this.Hide();
                    this.Close();
                    formSinhVien frm = new formSinhVien();
                    frm.formSinhVien_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi.\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void v_DS_PHANMANHComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboKHOA.SelectedValue == null) return;

            Program.servername = comboKHOA.SelectedValue.ToString();
            if (comboKHOA.SelectedIndex != Program.mChinhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0)
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            else
            {
                this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.lOPTableAdapter.Fill(this.qLDSVROOT.LOP);

            }
        }

        private void BtnCL_Click_2(object sender, EventArgs e)
        {
            try
            {
                int check = checkSVCoDiemTonTai(txtMaSV.Text);
                if (check == 1)
                {
                    MessageBox.Show("Sinh viên đã có điểm! Không được chuyển lớp.\n", "", MessageBoxButtons.OK);
                }
                else if (check == 2)
                {
                    MessageBox.Show("Sinh viên đã nghĩ học không được chuyển lớp.\n", "", MessageBoxButtons.OK);
                }
                else
                {
                    if (Program.conn.State == ConnectionState.Closed)
                        Program.conn.Open();
                    String maLop = comboKhacKhoaLop.SelectedValue.ToString();
                    String updateSinhVien = "SP_UpdateSinhVienSiteKhac";
                    Program.sqlcmd = Program.conn.CreateCommand();
                    Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                    Program.sqlcmd.CommandText = updateSinhVien;
                    cmdSinhVien(txtMaSV.Text, txtHo.Text, txtTen.Text, maLop, cbPhai.Checked,
                           comboNgaySinh.Text, txtNoiSinh.Text, txtDiaChi.Text, cbNghiHoc.Checked);
                    Program.sqlcmd.ExecuteNonQuery();
                    Program.conn.Close();
                    MessageBox.Show("Chuyển lớp thành công!", "", MessageBoxButtons.OK);
                    this.Hide();
                    this.Close();
                    formSinhVien frm = new formSinhVien();
                    frm.formSinhVien_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi.\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

    }
}