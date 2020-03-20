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
    public partial class formHocPhi : DevExpress.XtraEditors.XtraForm
    {
        public Boolean isAddNew = false;
        public Boolean isChonMaSV = false;
        public formHocPhi()
        {
            InitializeComponent();
        }
        private void setComboboxKHOAbyDefault()
        {

            comboKHOA.DataSource = Program.bds_dspm;
            comboKHOA.DisplayMember = "TENCN";
            comboKHOA.ValueMember = "TENSERVER";
            // We already set mChinhanh when Login 
            comboKHOA.SelectedIndex = Program.mChinhanh;
            comboKHOA.Enabled = false;
        }
        private void FormHocPhi_Load(object sender, EventArgs e)
        {
            qLDSVROOT.EnforceConstraints = false;
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.qLDSVROOT.SINHVIEN);
           
            setComboboxKHOAbyDefault();

            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "1");
            dict.Add(2, "2");
            dict.Add(3, "3");
            cmbHocKy.DataSource = new BindingSource(dict, null);
            cmbHocKy.DisplayMember = "Value";
            cmbHocKy.ValueMember = "Key";

            hOCPHIGridControl.Enabled = false;
            sINHVIENGridControl.Enabled = false;

            btnGhi.Enabled = false;
            pnclHocPhi.Visible = false;
            cmbHocKy.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (isChonMaSV)
            {
                txtMASV.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MASV").ToString().Trim();
                isChonMaSV = false;
            }
            if (txtMASV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã SV!");
                txtMASV.Focus();
                return;
            }
            try
            {
                if (Program.conn.State == ConnectionState.Open) Program.conn.Close();
                SqlDataReader myReader;
                string strLenh = " exec SP_GetThongTinSinhVien '" + txtMASV.Text.Trim() + "'";
                myReader = Program.ExecSqlDataReader(strLenh);

                if (!myReader.HasRows)
                {
                    MessageBox.Show("Sinh viên không tồn tại hoặc đã NGHỈ HỌC!", "", MessageBoxButtons.OK);
                    myReader.Close();
                    if (!isChonMaSV) isChonMaSV = true;
                    txtMASV.Focus();
                    return;
                }
                if (myReader.Read())
                {
                    lbHOTEN.Text = myReader.GetString(0);
                    lbMALOP.Text = myReader.GetString(1);

                    this.sP_DongHocPhiSinhVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.sP_DongHocPhiSinhVienTableAdapter.Fill(this.qLDSVROOT.SP_DongHocPhiSinhVien, txtMASV.Text.Trim());

                    txtNienKhoa.ReadOnly = true;
                  
                    txtMASV.Enabled = false;
                    btnLoad.Enabled = true;

                    btnGhi.Enabled = true;
                    hOCPHIGridControl.Enabled = true;
                    pnclHocPhi.Visible = true;

                    sINHVIENGridControl.Enabled = false;

                    int dem = sPDongHocPhiSinhVienBindingSource.Count;
                    if (dem <= 0)
                    {
                        btnClear.Enabled = false;
                        txtNienKhoa.Focus();
                        txtNienKhoa.ReadOnly = false;
                        cmbHocKy.Enabled = true;
                        // Create new row in grid control
                        this.sPDongHocPhiSinhVienBindingSource.AddNew();
                        isAddNew = true;
                    }
                    else
                    {
                        cmbHocKy.Enabled = false;
                        btnClear.Enabled = true;
                    }
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load học phí:\n" + ex.Message, "", MessageBoxButtons.OK);
                Program.conn.Close();
                return;
            }
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            if (txtNienKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Niên khóa không được để trống!", "Lỗi", MessageBoxButtons.OK);
                txtNienKhoa.Focus();
                return;
            }
            if (txtHocPhi.Text.Trim() == "")
            {
                MessageBox.Show("Học phí không được để trống!", "Lỗi", MessageBoxButtons.OK);
                txtHocPhi.Focus();
                return;
            }
            else if (int.Parse(txtHocPhi.Text) < 0)
            {
                MessageBox.Show("Học phí không được âm!", "Lỗi", MessageBoxButtons.OK);
                txtHocPhi.Focus();
                return;
            }

            if (txtSoTien.Text.Trim() == "")
            {
                MessageBox.Show("Số tiền đã đóng không được để trống!", "Lỗi", MessageBoxButtons.OK);
                txtSoTien.Focus();
                return;
            }
            else if (int.Parse(txtSoTien.Text) < 0)
            {
                MessageBox.Show("Số tiền không được âm!", "Lỗi", MessageBoxButtons.OK);
                txtSoTien.Focus();
                return;
            }

            if (int.Parse(txtSoTien.Text) > int.Parse(txtHocPhi.Text))
            {
                MessageBox.Show("Số tiền đã đóng <= học phí!", "Lỗi", MessageBoxButtons.OK);
                txtSoTien.Focus();
                return;
            }
            if (cmbHocKy.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn học kỳ!", "Lỗi", MessageBoxButtons.OK);
                cmbHocKy.Focus();
                return;
            }
            // FOR HOCPHI ALREDY EXIST
            Boolean isUpdate = false;
            if (isAddNew)
            {
                try
                {
                    SqlDataReader myReader;
                    string strLenh = "SELECT * FROM DBO.HOCPHI WHERE MASV='" + txtMASV.Text.Trim() + "' and NIENKHOA='" + txtNienKhoa.Text.Trim() + "' AND HOCKY='" + cmbHocKy.SelectedValue.ToString() + "' ";
                    myReader = Program.ExecSqlDataReader(strLenh);
                    if (myReader.HasRows)
                    {
                        DialogResult result = MessageBox.Show("Mã SV, niên khóa, học kỳ đã có trong database!\n Bạn có muốn cập nhật lại không?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            isAddNew = false;
                        }
                        else
                        {
                            // remove addnew when click clear button
                            this.sPDongHocPhiSinhVienBindingSource.RemoveCurrent();
                            this.sPDongHocPhiSinhVienBindingSource.EndEdit();
                            isUpdate = true;
                        }
                        myReader.Close();
                    }
                    Program.conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kiểm tra MASV, NIENKHOA, HOCKY: " + ex.Message, "THÔNG BÁO", MessageBoxButtons.OK);
                    Program.conn.Close();
                    return;
                }
            }

            if (!isUpdate)
            {
                if (isAddNew)
                {
                    isAddNew = false;
                    try
                    {
                        string strLenh = "dbo.SP_InsertHocPhiChoSinhVien";
                        if (Program.conn.State == ConnectionState.Closed)
                            Program.conn.Open();
                        Program.sqlcmd = Program.conn.CreateCommand();
                        Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                        Program.sqlcmd.CommandText = strLenh;
                        Program.sqlcmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = txtMASV.Text.Trim();
                        Program.sqlcmd.Parameters.Add("@NIENKHOA", SqlDbType.NVarChar).Value = txtNienKhoa.Text.Trim();
                        Program.sqlcmd.Parameters.Add("@HOCKY", SqlDbType.Int).Value = int.Parse(cmbHocKy.SelectedValue.ToString());
                        Program.sqlcmd.Parameters.Add("@HOCPHI", SqlDbType.Int).Value = int.Parse(txtHocPhi.Text.Trim());
                        Program.sqlcmd.Parameters.Add("@SOTIENDADONG", SqlDbType.Int).Value = int.Parse(txtSoTien.Text.Trim());
                        Program.sqlcmd.ExecuteNonQuery();
                        Program.conn.Close();

                        MessageBox.Show("Đã thêm vào danh sách học phí", "", MessageBoxButtons.OK);
                        this.sPDongHocPhiSinhVienBindingSource.EndEdit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "THÔNG BÁO", MessageBoxButtons.OK);
                        Program.conn.Close();
                        return;
                    }
                }
                else
                {
                    try
                    {
                        string strLenh = "dbo.SP_UpdateHocPhiChoSinhVien";
                        if (Program.conn.State == ConnectionState.Closed)
                            Program.conn.Open();
                        Program.sqlcmd = Program.conn.CreateCommand();
                        Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                        Program.sqlcmd.CommandText = strLenh;
                        Program.sqlcmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = txtMASV.Text.Trim();
                        Program.sqlcmd.Parameters.Add("@NIENKHOA", SqlDbType.NVarChar).Value = txtNienKhoa.Text.Trim();
                        Program.sqlcmd.Parameters.Add("@HOCKY", SqlDbType.Int).Value = int.Parse(cmbHocKy.SelectedValue.ToString());
                        Program.sqlcmd.Parameters.Add("@HOCPHI", SqlDbType.Int).Value = int.Parse(txtHocPhi.Text.Trim());
                        Program.sqlcmd.Parameters.Add("@SOTIENDADONG", SqlDbType.Int).Value = int.Parse(txtSoTien.Text.Trim());
                        Program.sqlcmd.ExecuteNonQuery();
                        Program.conn.Close();
                        MessageBox.Show("Đã cập nhật học phí", "", MessageBoxButtons.OK);
                        //this.sPDongHocPhiSinhVienBindingSource.EndEdit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "THÔNG BÁO", MessageBoxButtons.OK);
                        Program.conn.Close();
                        return;
                    }
                }
            }
            btnClear.Enabled = true;
            txtNienKhoa.ReadOnly = true;
            cmbHocKy.Enabled = false;
            this.sP_DongHocPhiSinhVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_DongHocPhiSinhVienTableAdapter.Fill(this.qLDSVROOT.SP_DongHocPhiSinhVien, txtMASV.Text.Trim());
        }

        private void BtnNhapSV_Click(object sender, EventArgs e)
        {
            txtMASV.Enabled = true;
            txtMASV.Focus();

            btnLoad.Enabled = true;
            hOCPHIGridControl.Enabled = false;
            sINHVIENGridControl.Enabled = false;
            pnclHocPhi.Visible = false;

            // Clear fields
            txtMASV.ReadOnly = false;
            lbHOTEN.Text = "";
            lbMALOP.Text = "";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtNienKhoa.Focus();
            // Create new row in grid control
            this.sPDongHocPhiSinhVienBindingSource.AddNew();
            isAddNew = true;
            btnClear.Enabled = false;
            txtNienKhoa.ReadOnly = false;
            cmbHocKy.Enabled = true;
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            if (Program.conn.State == ConnectionState.Open) Program.conn.Close();
            if(isAddNew)
            {
                this.sPDongHocPhiSinhVienBindingSource.RemoveCurrent();
            }
            this.Close();
        }

        private void BtnChonSV_Click(object sender, EventArgs e)
        {
            hOCPHIGridControl.Enabled = false;
            pnclHocPhi.Visible = false;

            sINHVIENGridControl.Enabled = true;
            gridView1.OptionsBehavior.Editable = false;

            txtMASV.ReadOnly = true;
            isChonMaSV = true;

        }
    }
}