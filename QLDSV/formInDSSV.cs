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
    public partial class formInDSSV : DevExpress.XtraEditors.XtraForm
    {
        public formInDSSV()
        {
            InitializeComponent();
        }

        private void formInDSSV_Load(object sender, EventArgs e)
        {
            qLDSVROOT.EnforceConstraints = false;

            //this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            //this.sINHVIENTableAdapter.Fill(this.qLDSVROOT.SINHVIEN);

            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.qLDSVROOT.LOP);

            this.sINHVIENGridControl.Visible = false;

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
        }

        private void btnManHinh_Click(object sender, EventArgs e)
        {
            this.sINHVIENGridControl.Visible = true;
            this.sP_XuatSinhVienTheoMaLopTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_XuatSinhVienTheoMaLopTableAdapter.Fill(qLDSVROOT.SP_XuatSinhVienTheoMaLop, txtML.Text.Trim());
        }

        private void btnMayIn_Click(object sender, EventArgs e)
        {
            BaoCao.xRpt_InDSSV_spTimSVTheoMaLop rpt = new BaoCao.xRpt_InDSSV_spTimSVTheoMaLop(txtML.Text);
            rpt.lbML.Text = comboBox1.SelectedValue.ToString();
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnThoatMonHoc_Click(object sender, EventArgs e)
        {
            this.Close();
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
                qLDSVROOT.EnforceConstraints = false;
                // TODO: This line of code loads data into the 'qLDSVROOT.LOP' table. You can move, or remove it, as needed.
                this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.lOPTableAdapter.Fill(this.qLDSVROOT.LOP);
                //this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                //this.sINHVIENTableAdapter.Fill(this.qLDSVROOT.SINHVIEN);

            }
        }
    }
}