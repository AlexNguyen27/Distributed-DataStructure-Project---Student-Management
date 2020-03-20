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
    public partial class formDanhSachThiHetMon : DevExpress.XtraEditors.XtraForm
    {
        public formDanhSachThiHetMon()
        {
            InitializeComponent();
        }
        public string maLop;
        public string maMH;
        public short lan;
        
        private void FormDanhSachThiHetMon_Load(object sender, EventArgs e)
        {
            dtNgayThi.Properties.MaxValue = DateTime.Today.AddYears(+3);
            dtNgayThi.Properties.MinValue = DateTime.Today.AddYears(-10);
            dtNgayThi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtNgayThi.Properties.Mask.EditMask = "dd/MM/yyyy";
            dtNgayThi.EditValue = "09/09/2019";

            qLDSVROOT.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'qLDSVROOT.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.qLDSVROOT.MONHOC);

            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.qLDSVROOT.LOP);

            // Default value for Lanthi
            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "1");
            dict.Add(2, "2");
            cmbLanThi.DataSource = new BindingSource(dict, null);
            cmbLanThi.DisplayMember = "Value";
            cmbLanThi.ValueMember = "Key";

            gctrl_sP_DSThiHetMon.Enabled = false;

            cmbTenLop.Focus();

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
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            }
            else
            {
                qLDSVROOT.EnforceConstraints = false;
                // TODO: This line of code loads data into the 'qLDSVROOT.MONHOC' table. You can move, or remove it, as needed.
                this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.mONHOCTableAdapter.Fill(this.qLDSVROOT.MONHOC);

                this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.lOPTableAdapter.Fill(this.qLDSVROOT.LOP);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            maLop = txtMalop.Text;
            maMH = txtMaMH.Text;
            lan = short.Parse(cmbLanThi.SelectedValue.ToString());

            if (Program.conn.State == ConnectionState.Closed)
                Program.conn.Open();
            String check = "SP_DSThiHetMon";
            Program.sqlcmd = Program.conn.CreateCommand();
            Program.sqlcmd.CommandType = CommandType.StoredProcedure;
            Program.sqlcmd.CommandText = check;
            Program.sqlcmd.Parameters.Add("@MALOP", SqlDbType.NChar).Value = txtMalop.Text;
            Program.sqlcmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = txtMaMH.Text;
            Program.sqlcmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = short.Parse(cmbLanThi.SelectedValue.ToString());
            Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            Program.sqlcmd.ExecuteNonQuery();
            String ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
            Program.conn.Close();
            if (ret == "1")
            {
                MessageBox.Show("Lớp, môn học, lần thi này đã có điểm!\nVui lòng chọn môn chưa thi!", "Thông báo", MessageBoxButtons.OK);
                cmbTenMH.Focus();
                return;
            }

            XtraReport1 rpt = new XtraReport1(maLop, maMH, lan);
            rpt.lblLop.Text = cmbTenLop.SelectedValue.ToString();
            rpt.lblMonHoc.Text = cmbTenMH.SelectedValue.ToString();
            rpt.lblNgayThi.Text = dtNgayThi.Text;

            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
            
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnScreen_Click(object sender, EventArgs e)
        {
            maLop = txtMalop.Text;
            maMH = txtMaMH.Text;
            lan = short.Parse(cmbLanThi.SelectedValue.ToString());

            if (Program.conn.State == ConnectionState.Closed)
                Program.conn.Open();
            String check = "SP_DSThiHetMon";
            Program.sqlcmd = Program.conn.CreateCommand();
            Program.sqlcmd.CommandType = CommandType.StoredProcedure;
            Program.sqlcmd.CommandText = check;
            Program.sqlcmd.Parameters.Add("@MALOP", SqlDbType.NChar).Value = txtMalop.Text;
            Program.sqlcmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = txtMaMH.Text;
            Program.sqlcmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = short.Parse(cmbLanThi.SelectedValue.ToString());
            Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            Program.sqlcmd.ExecuteNonQuery();
            String ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
            Program.conn.Close();
            if (ret == "1")
            {
                MessageBox.Show("Lớp, môn học, lần thi này đã có điểm!\nVui lòng chọn môn chưa thi!", "Thông báo", MessageBoxButtons.OK);
                cmbTenMH.Focus();
                return;
            }

            gctrl_sP_DSThiHetMon.Enabled = true;
            this.sP_DSThiHetMonTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_DSThiHetMonTableAdapter.Fill(this.qLDSVROOT.SP_DSThiHetMon, maLop, maMH, lan);
        }
    }
}