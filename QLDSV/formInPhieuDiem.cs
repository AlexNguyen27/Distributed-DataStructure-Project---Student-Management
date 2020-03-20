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
using DevExpress.XtraReports.UI;

namespace QLDSV
{
    public partial class formInPhieuDiem : DevExpress.XtraEditors.XtraForm
    {
        public formInPhieuDiem()
        {
            InitializeComponent();
        }

        public string maSV;

        private void FormPhieuDiem_Load(object sender, EventArgs e)
        {
            qLDSVROOT.EnforceConstraints = false;

            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.qLDSVROOT.SINHVIEN);

            gctrl_sP_PhieuDiemSinhVien.Enabled = false;
            gridView1.OptionsBehavior.Editable = false;

            if (Program.mGroup == "KHOA")
            {
                cmbKhoa.DataSource = Program.bds_dspm.DataSource;
                cmbKhoa.DisplayMember = "TENCN";
                cmbKhoa.ValueMember = "TENSERVER";
                // We set mChinhanh when Login 
                cmbKhoa.SelectedIndex = Program.mChinhanh;
                cmbKhoa.Enabled = false;
            }
            if (Program.mGroup == "PGV")
            {
                cmbKhoa.DataSource = Program.bds_khoa.DataSource;
                cmbKhoa.DisplayMember = "TENCN";
                cmbKhoa.ValueMember = "TENSERVER";
                cmbKhoa.SelectedIndex = Program.mChinhanh;
            }
        }

        private void BtnManHinh_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "", MessageBoxButtons.OK);
                txtMaSV.Focus();
                return;
            }
            maSV = txtMaSV.Text;
            // check if maSV is exists
            formSinhVien formSV = new formSinhVien();
            int checkMasvIsExist = formSV.kiemTraSinhVienTonTai(maSV); 
            if(checkMasvIsExist == 1)
            {
                gctrl_sP_PhieuDiemSinhVien.Enabled = true;
                
                sP_PhieuDiemSinhVienTableAdapter.Connection.ConnectionString = Program.connstr;
                sP_PhieuDiemSinhVienTableAdapter.Fill(this.qLDSVROOT.SP_PhieuDiemSinhVien, maSV);
            }else
            {
                MessageBox.Show("Mã sinh viên không tồn tại!\nVui lòng nhập lại.", "", MessageBoxButtons.OK);
                txtMaSV.Focus();
                return;
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 
        private void BtnMayIn_Click(object sender, EventArgs e)
        {
            maSV = txtMaSV.Text;

            BAOCAO.Xrpt_PhieuDiem rpt = new BAOCAO.Xrpt_PhieuDiem(maSV);
            rpt.lblHoTen.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HO").ToString().Trim() + " " + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN").ToString().Trim();
            rpt.lblMaSV.Text = maSV;

            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void CmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // For close form
            if (cmbKhoa.SelectedValue == null) return;

            Program.servername = cmbKhoa.SelectedValue.ToString();
            if (cmbKhoa.SelectedIndex != Program.mChinhanh)
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
                this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.sINHVIENTableAdapter.Fill(this.qLDSVROOT.SINHVIEN);
            }
        }
    }
}