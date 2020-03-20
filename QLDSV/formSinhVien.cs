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
using System.Collections;

namespace QLDSV
{
    public partial class formSinhVien : DevExpress.XtraEditors.XtraForm
    {

        public String maSV;
        public String ho;
        public String ten;
        public String maLop;
        public String nghiHoc;
        public String phai;
        public String ngaySinh;
        public String noiSinh;
        public String diaChi;

        public class saveInfo
        {
            static public String maSV;
            static public String ho;
            static public String ten;
            static public String maLop;
            static public Boolean nghiHoc;
            static public Boolean phai;
            static public String ngaySinh;
            static public String noiSinh;
            static public String diaChi;
        }

        public Stack st = new Stack();
        public class ObjectUndo
        {
            int type;//thêm = 1, xóa =2 , sửa =3
            String lenh;//lệnh SP

            public ObjectUndo(int t, String l)
            {
                this.type = t;
                this.lenh = l;
            }

            public int getType()
            {
                return type;
            }
            public String getLenh()
            {
                return lenh;
            }
        }


        public formSinhVien()
        {
            InitializeComponent();
        }

        private void validation()
        {
            if (Program.mGroup == "KHOA")
            {
                this.btnSVThem.Visible = false;
                this.btnSuaSV.Visible = false;
                this.btnXoaSV.Visible = false;
                this.btnPhucHoiSV.Visible = false;
                this.btnClearSV.Visible = false;
                this.btnRefresh.Visible = false;
                this.btnChuyenLop.Visible = false;
                this.btnThoatSV.Visible = false;
                gridView1.OptionsBehavior.ReadOnly = true;
                gridView2.OptionsBehavior.ReadOnly = true;
            }
        }

        public void formSinhVien_Load(object sender, EventArgs e)
        {
            qLDSVROOT.EnforceConstraints = false;

            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.qLDSVROOT.SINHVIEN);

            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.qLDSVROOT.LOP);

            maLop = ((DataRowView)lOPBindingSource[0])["MALOP"].ToString();
            txtMaLop.Text = maLop;
            txtMaLop.Enabled = false;

            this.validation();
            if (Program.mGroup == "KHOA")
            {
                comboKHOA.DataSource = Program.bds_dspm.DataSource;
                comboKHOA.DisplayMember = "TENCN";
                comboKHOA.ValueMember = "TENSERVER";
                comboKHOA.SelectedIndex = Program.mChinhanh;
                comboKHOA.Enabled = false;
            }
            if (Program.mGroup == "PGV")
            {
                comboKHOA.DataSource = Program.bds_khoa.DataSource;
                comboKHOA.DisplayMember = "TENCN";
                comboKHOA.ValueMember = "TENSERVER";
                comboKHOA.SelectedIndex = Program.mChinhanh;
            }
        }

        private void comboKHOA_SelectedIndexChanged(object sender, EventArgs e)
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

                this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.sINHVIENTableAdapter.Fill(this.qLDSVROOT.SINHVIEN);
            }
        }

        private void btnClearSV_Click(object sender, EventArgs e)
        {
            txtMaSV.Focus();
            this.btnSuaSV.Enabled = true;
            this.sINHVIENBindingSource.AddNew();
            maLop = ((DataRowView)sINHVIENBindingSource[0])["MALOP"].ToString();
            txtMaLop.Text = maLop;
            txtMaLop.Enabled = false;
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

        public int kiemTraSinhVienTonTai(String maSV)
        {
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            if (Program.conn.State == ConnectionState.Closed)
                Program.conn.Open();
            try
            {
                String strLenh = "SP_KiemTraTonTaiSinhVien";
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = strLenh;
                Program.sqlcmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = maSV;
                Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.sqlcmd.ExecuteNonQuery();
                String ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
                Program.conn.Close();
                if (ret == "1")
                {
                    return 1;
                }
                if (ret == "2")
                {
                    return 2;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiem tra sinh viên tồn tại.\n" + ex.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        public Boolean validationSinhVien()
        {
            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Mã sinh viên không được thiếu.\n", "", MessageBoxButtons.OK);
                txtMaSV.Focus();
                return false;
            }
            if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ sinh viên không được thiếu.\n", "", MessageBoxButtons.OK);
                txtHo.Focus();
                return false;
            }
            if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên sinh viên không được thiếu.\n", "", MessageBoxButtons.OK);
                txtTen.Focus();
                return false;
            }
            if (txtMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp sinh viên không được thiếu.\n", "", MessageBoxButtons.OK);
                txtMaLop.Focus();
                return false;
            }
            if (comboNgaySinh.Text.Trim() == "")
            {
                MessageBox.Show("Ngày sinh sinh viên không được thiếu.\n", "", MessageBoxButtons.OK);
                comboNgaySinh.Focus();
                return false;
            }

            if (txtNoiSinh.Text.Trim() == "")
            {
                MessageBox.Show("Nơi sinh sinh viên không được thiếu.\n", "", MessageBoxButtons.OK);
                txtNoiSinh.Focus();
                return false;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ sinh viên không được thiếu.\n", "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }
            return true;
        }

        private void btnThemSV2_Click(object sender, EventArgs e)
        {

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
                if (ret == "0")
                {
                    return 0;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "", MessageBoxButtons.OK);
            }
            return 0;
        }

        public int xoaSinhVien(String maSV)
        {
            if (Program.conn.State == ConnectionState.Closed)
                Program.conn.Open();
            try
            {
                int type = 2;//XÓA
                int checkPhai = checkboxPhai.Checked ? 1 : 0;
                int checkNghi = checkboxNghiHoc.Checked ? 1 : 0;
                String strSP = "SP_DeleteSinhVien";
                String lenh = "exec SP_UndoDeleteSinhVien '" + txtMaSV.Text.Trim() + "', N'" + txtHo.Text.Trim()
                              + "', N'" + txtTen.Text.Trim() + "', '" + txtMaLop.Text.Trim() + "', '" + checkPhai +
                              "', '" + comboNgaySinh.Text.Trim() + "', N'" + txtNoiSinh.Text.Trim() + "', N'" + txtDiaChi.Text.Trim()
                              + "', '" + checkNghi + "'";
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = strSP;
                Program.sqlcmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = maSV;
                Program.sqlcmd.ExecuteNonQuery();
                this.sINHVIENBindingSource.RemoveCurrent();
                this.sINHVIENBindingSource.EndEdit();
                Program.conn.Close();
                ObjectUndo ob = new ObjectUndo(type, lenh);
                st.Push(ob);
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa sinh viên thất bai." + ex.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa nó không?", "Xóa sinh viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int checkSinhVienCoDiem = checkSVCoDiemTonTai(txtMaSV.Text);
                if (checkSinhVienCoDiem == 1)
                {
                    MessageBox.Show("Sinh viên đã có điểm. Không được xóa", "", MessageBoxButtons.OK);
                }
                else
                {
                    int result = xoaSinhVien(txtMaSV.Text);
                    if (result == 1)
                    {
                        MessageBox.Show("Xóa sinh viên thành công.", "", MessageBoxButtons.OK);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public void handleSinhVienTable()
        {
            maSV = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MASV").ToString().Trim();
            ho = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "HO").ToString().Trim();
            ten = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "TEN").ToString().Trim();
            maLop = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MALOP").ToString().Trim();
            ngaySinh = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "NGAYSINH").ToString().Trim();
            noiSinh = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "NOISINH").ToString().Trim();
            diaChi = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "DIACHI").ToString().Trim();
            phai = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "PHAI").ToString().Trim();
            nghiHoc = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "NGHIHOC").ToString().Trim();
        }

        private void btnSuaSV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn sửa nó không?", "Sửa sinh viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Boolean checkValidation = validationSinhVien();
                if (!checkValidation)
                {
                    return;
                }
                int checkMaSV = kiemTraSinhVienTonTai(txtMaSV.Text);
                if (checkMaSV == 0)
                {
                    MessageBox.Show("Sinh viên không tồn tại.\n", "", MessageBoxButtons.OK);
                }
                else if (checkMaSV == 2)
                {
                    MessageBox.Show("Đã tồn tại mã sinh viên trong site khác.\n", "", MessageBoxButtons.OK);
                }
                else
                {
                    if (Program.conn.State == ConnectionState.Closed)
                        Program.conn.Open();
                    try
                    {
                        handleSinhVienTable();
                        String lenh = "exec SP_UndoUpdateSinhVien N'" + ho
                              + "', N'" + ten + "', '" + maLop + "', '" + phai +
                              "', '" + ngaySinh + "', N'" + noiSinh + "', N'" + diaChi
                              + "', '" + nghiHoc + "', '" + maSV + "'";
                        String updateSinhVien = "SP_UpdateSinhVien";
                        Program.sqlcmd = Program.conn.CreateCommand();
                        Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                        Program.sqlcmd.CommandText = updateSinhVien;
                        cmdSinhVien(txtMaSV.Text, txtHo.Text, txtTen.Text, txtMaLop.Text, checkboxPhai.Checked,
                               comboNgaySinh.Text, txtNoiSinh.Text, txtDiaChi.Text, checkboxNghiHoc.Checked);
                        Program.sqlcmd.ExecuteNonQuery();
                        Program.conn.Close();
                        MessageBox.Show("Sửa sinh viên thành công!", "", MessageBoxButtons.OK);
                        this.sINHVIENBindingSource.EndEdit();
                        //    this.refresh();
                        int type = 3;//chỉnh sửa
                        ObjectUndo ob = new ObjectUndo(type, lenh);
                        st.Push(ob);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sửa sinh viên thất bại.\n" + ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.lOPTableAdapter.Fill(this.qLDSVROOT.LOP);
                this.sINHVIENTableAdapter.Fill(this.qLDSVROOT.SINHVIEN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThoatSV_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPhucHoiSV_Click(object sender, EventArgs e)
        {
            try
            {
                ObjectUndo ob = (ObjectUndo)st.Pop();
                if (ob.getType() == 1)
                {
                    if (Program.conn.State == ConnectionState.Closed)
                        Program.conn.Open();
                    MessageBox.Show("Khôi phục sau khi thêm " + ob.getLenh());
                    Program.ExecSqlDataReader(ob.getLenh());
                    this.sINHVIENTableAdapter.Fill(this.qLDSVROOT.SINHVIEN);
                    Program.conn.Close();
                }
                if (ob.getType() == 2)
                {
                    if (Program.conn.State == ConnectionState.Closed)
                        Program.conn.Open();
                    MessageBox.Show("Khôi phục sau khi xóa " + ob.getLenh());
                    Program.ExecSqlDataReader(ob.getLenh());
                    this.sINHVIENTableAdapter.Fill(this.qLDSVROOT.SINHVIEN);
                    Program.conn.Close();
                }
                if (ob.getType() == 3)
                {
                    if (Program.conn.State == ConnectionState.Closed)
                        Program.conn.Open();
                    MessageBox.Show("Khôi phục sau khi sữa " + ob.getLenh());
                    Program.ExecSqlDataReader(ob.getLenh());
                    this.sINHVIENTableAdapter.Fill(this.qLDSVROOT.SINHVIEN);
                    Program.conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không có gì để Undo", "THÔNG BÁO", MessageBoxButtons.OK);
            }
        }

        private void btnChuyenLop_Click(object sender, EventArgs e)
        {
            saveInfo.maSV = txtMaSV.Text.Trim();
            saveInfo.ten = txtTen.Text.Trim();
            saveInfo.ho = txtHo.Text.Trim();
            saveInfo.maLop = txtMaLop.Text.Trim();
            saveInfo.phai = checkboxPhai.Checked;
            saveInfo.ngaySinh = comboNgaySinh.Text.Trim();
            saveInfo.noiSinh = txtNoiSinh.Text.Trim();
            saveInfo.diaChi = txtDiaChi.Text.Trim();
            saveInfo.nghiHoc = checkboxNghiHoc.Checked;
            var frm = new formChuyenLop();
            frm.ShowDialog(this);

            btnRefresh.PerformClick();
        }

        private void btnSVThem_Click(object sender, EventArgs e)
        {
            if (Program.conn.State == ConnectionState.Closed)
                Program.conn.Open();
            Boolean checkValidation = validationSinhVien();
            if (!checkValidation)
            {
                return;
            }
            int checkMaSV = kiemTraSinhVienTonTai(txtMaSV.Text);
            if (checkMaSV == 1)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại.\n", "", MessageBoxButtons.OK);
            }
            else if (checkMaSV == 2)
            {
                MessageBox.Show("Tồn tại mã sinh viên trong site khác.\n", "", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    String strLenh = "dbo.SP_InsertSinhVien";
                    Program.sqlcmd = Program.conn.CreateCommand();
                    Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                    Program.sqlcmd.CommandText = strLenh;
                    cmdSinhVien(txtMaSV.Text, txtHo.Text, txtTen.Text, txtMaLop.Text, checkboxPhai.Checked,
                                comboNgaySinh.Text, txtNoiSinh.Text, txtDiaChi.Text, checkboxNghiHoc.Checked);
                    Program.sqlcmd.ExecuteNonQuery();
                    Program.conn.Close();
                    this.sINHVIENBindingSource.EndEdit();
                    sINHVIENBindingSource.ResetAllowNew();
                    Program.conn.Close();
                    MessageBox.Show("Thêm sinh viên thành công", "THÔNG BÁO", MessageBoxButtons.OK);
                    int type = 1;//Thêm
                    String lenh = "exec SP_UndoThemSinhVien '" + txtMaSV.Text + "'";
                    ObjectUndo ob = new ObjectUndo(type, lenh);
                    st.Push(ob);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi sinh viên.\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
        }

    }
}