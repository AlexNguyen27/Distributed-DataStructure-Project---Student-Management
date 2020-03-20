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
using DevExpress.XtraGrid.Columns;

namespace QLDSV
{
    public partial class formDanhSachHocPhiTheoLop : DevExpress.XtraEditors.XtraForm
    {
        public formDanhSachHocPhiTheoLop()
        {
            InitializeComponent();
        }
        public decimal sendTongDaDong = 0;

        private void formDanhSachHocPhiTheoLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSVROOT.HOCPHI' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'qLDSVROOT.GetAllMaLop' table. You can move, or remove it, as needed.
            this.getAllMaLopTableAdapter.Connection.ConnectionString = Program.connstr;
            this.getAllMaLopTableAdapter.Fill(this.qLDSVROOT.GetAllMaLop);
            // TODO: This line of code loads data into the 'qLDSVROOT.SINHVIEN' table. You can move, or remove it, as needed.
            this.qLDSVROOT.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'qLDSVROOT.HOCPHI' table. You can move, or remove it, as needed.
            this.hOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.hOCPHITableAdapter.FillBy(this.qLDSVROOT.HOCPHI);
            // TODO: This line of code loads data into the 'qLDSVPMMaster.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLDSVPMMaster.V_DS_PHANMANH);

            //handle comboHocKy
            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "1");
            dict.Add(2, "2");
            dict.Add(3, "3");
            comboHocKy.DataSource = new BindingSource(dict, null);
            comboHocKy.DisplayMember = "Value";
            comboHocKy.ValueMember = "Key";

            this.sP_DanhSachHocPhiLopGridControl.Visible = false;

        }

        private decimal handleHocPhi()
        {
            int dem = 0;
            decimal sum = 0;
            dem = sP_DanhSachHocPhiLopBindingSource.Count;
            for (int i = 0; i < dem; i++)
            {
                sum += decimal.Parse(((DataRowView)sP_DanhSachHocPhiLopBindingSource[i])["SOTIENDADONG"].ToString());
            }
            return sum;
        }

        private void btnManHinh_Click(object sender, EventArgs e)
        {
            try
            {
                this.sP_DanhSachHocPhiLopGridControl.Visible = true;
                this.sP_DanhSachHocPhiLopTableAdapter.Connection.ConnectionString = Program.connstr;
                this.sP_DanhSachHocPhiLopTableAdapter.Fill(this.qLDSVROOT.SP_DanhSachHocPhiLop, comboMaLop.Text, comboNienKhoa.Text, new System.Nullable<int>(((int)(System.Convert.ChangeType(comboHocKy.Text, typeof(int))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnThoatMonHoc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMayIn_Click(object sender, EventArgs e)
        {
            this.sP_DanhSachHocPhiLopTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_DanhSachHocPhiLopTableAdapter.Fill(this.qLDSVROOT.SP_DanhSachHocPhiLop, comboMaLop.Text, comboNienKhoa.Text, new System.Nullable<int>(((int)(System.Convert.ChangeType(comboHocKy.Text, typeof(int))))));
            sendTongDaDong = handleHocPhi();
            BaoCao.xRpt_InDanhSachHocPhiLop_spDanhSachHocPhiLop rpt = new BaoCao.xRpt_InDanhSachHocPhiLop_spDanhSachHocPhiLop(comboMaLop.Text, comboNienKhoa.Text, comboHocKy.Text, sendTongDaDong);
            rpt.lbML.Text = comboMaLop.Text;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
}