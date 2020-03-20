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
    public partial class formBangDiemMonHoc : DevExpress.XtraEditors.XtraForm
    {
        public formBangDiemMonHoc()
        {
            InitializeComponent();
        }

        private void formBangDiemMonHoc_Load(object sender, EventArgs e)
        {
            this.qLDSVROOT.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'qLDSVROOT.DIEM' table. You can move, or remove it, as needed.
            this.dIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dIEMTableAdapter.Fill(this.qLDSVROOT.DIEM);
            // TODO: This line of code loads data into the 'qLDSVROOT.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.qLDSVROOT.MONHOC);
            // TODO: This line of code loads data into the 'qLDSVROOT.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.qLDSVROOT.LOP);

            this.sP_XuatBangDiemMonHocGridControl.Visible = false;

            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "1");
            dict.Add(2, "2");
            comboLanThi.DataSource = new BindingSource(dict, null);
            comboLanThi.DisplayMember = "Value";
            comboLanThi.ValueMember = "Key";

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
            try
            {
                this.sP_XuatBangDiemMonHocGridControl.Visible = true;
                this.sP_XuatBangDiemMonHocTableAdapter.Fill(this.qLDSVROOT.SP_XuatBangDiemMonHoc, txtTenLop.Text, txtTenMonHoc.Text, new System.Nullable<short>(((short)(System.Convert.ChangeType(comboLanThi.Text, typeof(short))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnMayIn_Click(object sender, EventArgs e)
        {
            BaoCao.xRpt_InBangDiemMonHoc_spXuatBangDiemMonHoc rpt = new BaoCao.xRpt_InBangDiemMonHoc_spXuatBangDiemMonHoc(txtTenLop.Text, txtTenMonHoc.Text, comboLanThi.Text);
            rpt.lbLop.Text = txtTenLop.Text;
            rpt.lbMH.Text = txtTenMonHoc.Text;
            rpt.lbLanThi.Text = comboLanThi.SelectedValue.ToString();
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnThoatMonHoc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboKHOA_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            else
            {
                this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.lOPTableAdapter.Fill(this.qLDSVROOT.LOP);
            }
        }
    }
}