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
using DevExpress.XtraGrid.Columns;

namespace QLDSV
{
    public partial class formDiem : DevExpress.XtraEditors.XtraForm
    {
        public formDiem()
        {
            InitializeComponent();
        }

        public int prevSelectedMaLop = -1;
        public int prevSelectedMonHoc = -1;
        public int prevSelectedLanThi = 0;

        private void FormDiem_Load(object sender, EventArgs e)
        {
            qLDSVROOT.EnforceConstraints = false;
            // Stop checking the constraints
            // Run on the newest connection
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.qLDSVROOT.MONHOC);

            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.qLDSVROOT.LOP);

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
                comboKHOA.DataSource = Program.bds_khoa.DataSource;
                comboKHOA.DisplayMember = "TENCN";
                comboKHOA.ValueMember = "TENSERVER";
                comboKHOA.SelectedIndex = Program.mChinhanh;
            }

            // Default value for Lanthi
            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "1");
            dict.Add(2, "2");
            cmbLanThi.DataSource = new BindingSource(dict, null);
            cmbLanThi.DisplayMember = "Value";
            cmbLanThi.ValueMember = "Key";

            // Disabled gridview sinhvien
            gridControlFillDiem.Enabled = false;
            gridControlFillDiem.Visible = false;

            // Diabled button Ghi Diem
            this.btnGhiDiem.Enabled = false;
        }

        private void ComboKHOA_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBatDau.Enabled = true;
            // For close form
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
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            }
            else
            {
                this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.lOPTableAdapter.Fill(this.qLDSVROOT.LOP);

                this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.mONHOCTableAdapter.Fill(this.qLDSVROOT.MONHOC);
            }

        }


        private void BtnGhiDiem_Click(object sender, EventArgs e)
        {
            int dem = sPNhapDiemMonHocBindingSource.Count;
            for (int i = 0; i < dem; i++)
            {
                if (((DataRowView)sPNhapDiemMonHocBindingSource[i])["DIEM"].ToString() == "")
                {
                    MessageBox.Show("Bạn chưa nhập điểm cho sinh viên này!\n" + "Mã SV: " + ((DataRowView)sPNhapDiemMonHocBindingSource[i])["MASV"].ToString());
                    gridView1.FocusedRowHandle = i;
                    return;
                }
                if (float.Parse(((DataRowView)sPNhapDiemMonHocBindingSource[i])["DIEM"].ToString()) > 10)
                {
                    MessageBox.Show("Điểm không được lớn hơn 10!\n" + "Mã SV: " + ((DataRowView)sPNhapDiemMonHocBindingSource[i])["MASV"].ToString());
                    gridView1.FocusedRowHandle = i;
                    return;
                }
                if (float.Parse(((DataRowView)sPNhapDiemMonHocBindingSource[i])["DIEM"].ToString()) < 0)
                {
                    MessageBox.Show("Điểm phải lớn hơn hoặc bằng 0!\n" + "Mã SV: " + ((DataRowView)sPNhapDiemMonHocBindingSource[i])["MASV"].ToString());
                    gridView1.FocusedRowHandle = i;
                    return;
                }
            }
            // for show error message
            Boolean hasError = false;
            string strLenh = "";
            for (int i = 0; i < dem; i++)
            {
                // Check if SinhVien did not have diem yet 
                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();
                String check = "SP_KiemTraSinhVienCoDiem";
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = check;
                Program.sqlcmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = gridView1.GetRowCellValue(i, "MASV").ToString().Trim();
                Program.sqlcmd.Parameters.Add("@MAMH", SqlDbType.NVarChar).Value = cmbMaMH.SelectedValue.ToString();
                Program.sqlcmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = short.Parse(cmbLanThi.SelectedValue.ToString());
                Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.sqlcmd.ExecuteNonQuery();
                String ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
                // dont have Diem before, insert into table DIEM
                if (ret == "1")
                {
                    try
                    {
                        if (Program.conn.State == ConnectionState.Closed)
                            Program.conn.Open();
                        strLenh = "SP_UpdateDiem";
                        Program.sqlcmd = Program.conn.CreateCommand();
                        Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                        Program.sqlcmd.CommandText = strLenh;
                        Program.sqlcmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = gridView1.GetRowCellValue(i, "MASV").ToString().Trim();
                        Program.sqlcmd.Parameters.Add("@MAMH", SqlDbType.NVarChar).Value = cmbMaMH.SelectedValue.ToString();
                        Program.sqlcmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = short.Parse(cmbLanThi.SelectedValue.ToString());
                        Program.sqlcmd.Parameters.Add("@DIEM", SqlDbType.Float).Value = Math.Round(float.Parse(gridView1.GetRowCellValue(i, "DIEM").ToString().Trim()), 2, MidpointRounding.AwayFromZero);
                        Program.sqlcmd.ExecuteNonQuery();
                        Program.conn.Close();

                    }
                    catch (Exception ex)
                    {
                        hasError = true;
                        MessageBox.Show("Lỗi ghi điểm! " + ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        strLenh = "SP_InsertDiem";
                        Program.sqlcmd = Program.conn.CreateCommand();
                        Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                        Program.sqlcmd.CommandText = strLenh;
                        Program.sqlcmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = gridView1.GetRowCellValue(i, "MASV").ToString().Trim();
                        Program.sqlcmd.Parameters.Add("@MAMH", SqlDbType.NVarChar).Value = cmbMaMH.SelectedValue.ToString();
                        Program.sqlcmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = short.Parse(cmbLanThi.SelectedValue.ToString());
                        Program.sqlcmd.Parameters.Add("@DIEM", SqlDbType.Float).Value = Math.Round(float.Parse(gridView1.GetRowCellValue(i, "DIEM").ToString().Trim()), 2, MidpointRounding.AwayFromZero);
                        Program.sqlcmd.ExecuteNonQuery();
                        Program.conn.Close();

                    }
                    catch (Exception ex)
                    {
                        hasError = true;
                        MessageBox.Show("Lỗi ghi điểm! " + ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }
                }

            }
            if (!hasError)
            {
                MessageBox.Show("Ghi điểm thành công!", "", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Ghi điểm thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
            //sPNhapDiemMonHocBindingSource.EndEdit();
        }

        private void BtnBatDau_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if SinhVien did not have diem yet 
                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();
                String check = "SP_KiemTraDieuKienNhapDiem";
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = check;
                Program.sqlcmd.Parameters.Add("@MALOP", SqlDbType.NChar).Value = cmbMaLop.SelectedValue.ToString();
                Program.sqlcmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = cmbMaMH.SelectedValue.ToString();
                Program.sqlcmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = short.Parse(cmbLanThi.SelectedValue.ToString());
                Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.sqlcmd.ExecuteNonQuery();
                String ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
               
                // Did not have Diem lan 1, Dont allow to see LAN 2
                if (ret == "2")
                {
                    MessageBox.Show("Chưa nhập điểm lần một\nVui lòng nhập lần 1 trước!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                try
                {
                    // Fill the data
                    this.sP_NhapDiemMonHocTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.sP_NhapDiemMonHocTableAdapter.Fill(this.qLDSVROOT.SP_NhapDiemMonHoc, cmbMaLop.SelectedValue.ToString(), cmbMaMH.SelectedValue.ToString(), short.Parse(cmbLanThi.SelectedValue.ToString()));
                    Program.conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi \n" + ex.Message);
                   
                    return;
                }

                if (sPNhapDiemMonHocBindingSource.Count == 0)
                {
                    MessageBox.Show("Lớp chưa có sinh viên!","Thông báo", MessageBoxButtons.OK);
                    return;
                }else
                {
                    gridControlFillDiem.Enabled = true;
                    gridControlFillDiem.Visible = true;
                    prevSelectedMaLop = cmbMaLop.SelectedIndex;
                    prevSelectedMonHoc = cmbMaMH.SelectedIndex;
                    prevSelectedLanThi = cmbLanThi.SelectedIndex;
                }

                // Allow to edit and fill
                if (ret == "1")
                {
                    // this.btnBatDau.Enabled = false;
                     this.btnGhiDiem.Enabled = true;
                    gridView1.OptionsBehavior.Editable = true;
                }
                // Dont allow to edit LAN 1 cuz had LAN 2 already
                if (ret == "0")
                {
                    gridView1.OptionsBehavior.Editable = false;
                    this.btnBatDau.Enabled = true;
                    this.btnGhiDiem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra điều kiện nhập điểm!\n" + ex.Message);
            }
        }


        private void CmbMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaLop.SelectedIndex != prevSelectedMaLop && cmbMaLop.SelectedIndex != -1 && gridControlFillDiem.Enabled == true)
            {
                // prevSelectedIndex = cmbMaLop.SelectedIndex;
                if (MessageBox.Show("Bạn muốn nhập điểm lớp khác?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.btnBatDau.Enabled = true;
                    this.btnGhiDiem.Enabled = false;

                    gridControlFillDiem.Enabled = false;
                    gridControlFillDiem.Visible = false;
                }
                else
                {
                    cmbMaLop.SelectedIndex = prevSelectedMaLop;
                }
            }

        }

        private void CmbMaMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaMH.SelectedIndex != prevSelectedMonHoc && cmbMaMH.SelectedIndex != -1 && gridControlFillDiem.Enabled == true)
            {
                // prevSelectedIndex = cmbMaLop.SelectedIndex;
                if (MessageBox.Show("Bạn muốn nhập điểm môn học khác?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.btnBatDau.Enabled = true;
                    this.btnGhiDiem.Enabled = false;

                    gridControlFillDiem.Enabled = false;
                    gridControlFillDiem.Visible = false;
                }
                else
                {
                    cmbMaMH.SelectedIndex = prevSelectedMonHoc;
                }
            }
        }

        private void CmbLanThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLanThi.SelectedIndex != prevSelectedLanThi && gridControlFillDiem.Enabled == true)
            {
                // prevSelectedIndex = cmbMaLop.SelectedIndex;
                if (MessageBox.Show("Bạn muốn nhập điểm lần khác?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.btnBatDau.Enabled = true;
                    this.btnGhiDiem.Enabled = false;

                    gridControlFillDiem.Enabled = false;
                    gridControlFillDiem.Visible = false;
                }
                else
                {
                    cmbLanThi.SelectedIndex = prevSelectedLanThi;
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}