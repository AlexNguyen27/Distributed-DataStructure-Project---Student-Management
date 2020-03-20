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
using DevExpress.XtraReports.UI;

namespace QLDSV
{
    public partial class formInBangDiemMonHoc : DevExpress.XtraEditors.XtraForm
    {
        public formInBangDiemMonHoc()
        {
            InitializeComponent();
        }

        public Boolean isNhap = false;
        private void FormInBangDiemMonHoc_Load(object sender, EventArgs e)
        {
            qLDSVROOT.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'qLDSVROOT.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.qLDSVROOT.LOP);

            BangDiemTongKetGridControl.Enabled = false;
            BangDiemTongKetGridControl.Visible = false;

            gridView1.OptionsBehavior.ReadOnly = true;

            txtTenLop.ReadOnly = true;


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
        private void BtnManHinh_Click(object sender, EventArgs e)
        {
            if (txtTenLop.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã SV!");
                txtTenLop.Focus();
                return;
            }
            try
            {
                if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                String check = "SP_KiemTraTenLopTonTaiSinhVien";
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = check;
                Program.sqlcmd.Parameters.Add("@TENLOP", SqlDbType.NVarChar).Value = txtTenLop.Text.Trim();
                Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.sqlcmd.ExecuteNonQuery();
                String ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
                Program.conn.Close();
                if (ret == "2")
                {
                    MessageBox.Show("Tên lớp không tồn tại!", "Thông báo", MessageBoxButtons.OK);
                    txtTenLop.Focus();
                    return;
                }
                if (ret == "1")
                {
                    MessageBox.Show("Lớp chưa có sinh viên!", "Thông báo", MessageBoxButtons.OK);
                    txtTenLop.Focus();
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra tên lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK);
                return;
            }

            if (isNhap)
            {
                txtTenLop.ReadOnly = true;
                lOPGridControl.Enabled = true;
                isNhap = false;
            }

            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            string strLenh = " exec SP_InBangDiemTongKet N'" + txtTenLop.Text.Trim() + "'";
      
            SqlDataAdapter dataadapter = new SqlDataAdapter(strLenh, Program.connstr);
            DataSet ds = new DataSet();
            dataadapter.Fill(ds, "SP_InBangDiemTongKet");

            BangDiemTongKetGridControl.Enabled = true;
            BangDiemTongKetGridControl.Visible = true;
            BangDiemTongKetGridControl.DataSource = ds;
            try
            {
                BangDiemTongKetGridControl.DataMember = "SP_InBangDiemTongKet";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lớp chưa có sinh viên hoặc chưa có điểm!", "THÔNG BÁO", MessageBoxButtons.OK);
                Program.conn.Close();
                return;
            }
           
            gridView2.Columns[0].Caption = "Mã sinh viên";
            gridView2.Columns[1].Caption = "Họ và tên";

            Program.conn.Close();
        }

        private void BtnMayIn_Click(object sender, EventArgs e)
        {
            if (txtTenLop.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã SV!");
                txtTenLop.Focus();
                return;
            }
            try
            {
                if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                String check = "SP_KiemTraTenLopTonTaiSinhVien";
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = check;
                Program.sqlcmd.Parameters.Add("@TENLOP", SqlDbType.NVarChar).Value = txtTenLop.Text.Trim();
                Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.sqlcmd.ExecuteNonQuery();
                String ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
                Program.conn.Close();
                if (ret == "2")
                {
                    MessageBox.Show("Tên lớp không tồn tại!", "Thông báo", MessageBoxButtons.OK);
                    txtTenLop.Focus();
                    return;
                }
                if (ret == "1")
                {
                    MessageBox.Show("Lớp chưa có sinh viên hoặc chưa có điểm!", "Thông báo", MessageBoxButtons.OK);
                    txtTenLop.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra tên lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (isNhap)
            {
                txtTenLop.ReadOnly = true;
                lOPGridControl.Enabled = true;
                isNhap = false;
            }

            // Create XtraReport instance
            XtraReport rep = new XtraReport();

            // Set the XtraReport.DataSource
            rep.DataSource = FillDataset();
            rep.DataMember = ((DataSet)rep.DataSource).Tables[0].TableName;

            // Add required bands to the Xtrareport.Bands collection
            InitBands(rep);

            // Add requited styles to the XtraReport.StyleSheet collection
            InitStyles(rep);
         
            // Use XRTable to display data
            InitDetailsBasedonXRTable(rep);

            if (Program.conn.State == ConnectionState.Open) Program.conn.Close();

            // Display the result
            rep.ShowPreviewDialog();
        }


         public DataSet FillDataset() {
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            string strLenh = " exec SP_InBangDiemTongKet N'" + txtTenLop.Text.Trim() + "'";
            SqlDataAdapter dataadapter = new SqlDataAdapter(strLenh, Program.connstr);
            DataSet dataSet1 = new DataSet();
            dataSet1.DataSetName = "SP_InBangDiemTongKet";
            DataTable dataTable1 = new DataTable();
            dataadapter.Fill(dataTable1);
            dataSet1.Tables.Add(dataTable1);

            return dataSet1;

        }
        public void InitBands(XtraReport rep) {
            // Create bands
            DetailBand detail = new DetailBand();
            PageHeaderBand pageHeader = new PageHeaderBand();
            ReportFooterBand reportFooter = new ReportFooterBand();
            
            detail.Height = 20;
            reportFooter.Height = 380;
            pageHeader.Height = 20;

            var reportHeaderBand = CreateReportHeader("BẢNG ĐIỂM TỔNG KẾT ", "Lớp: " + txtTenLop.Text.Trim(), 15.75f, 12f);

            // Place the bands onto a report
            rep.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { detail, pageHeader, reportFooter, reportHeaderBand});
        }
        public void InitStyles(XtraReport rep) {
            // Create different odd and even styles
            XRControlStyle Style = new XRControlStyle();
            Style.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            Style.BackColor = Color.White;
            Style.BorderColor = Color.Black;
            Style.ForeColor = Color.Black;

            // Add styles to report's style sheet
            rep.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {Style});
        }
        static ReportHeaderBand CreateReportHeader(String mainTitle,String subTitle, float mainSize, float subSize)
        {
            ReportHeaderBand reportHeaderBand = new ReportHeaderBand()
            {
                HeightF = 50
            };
            XRLabel titleLabel = new XRLabel()
            {
                Text = mainTitle,
                Font = new Font("Times New Roman", mainSize, FontStyle.Bold),
                BoundsF = new RectangleF(230, 0, 800, 60),
                StyleName = "Title"
                
            };
            XRLabel titleLabel1 = new XRLabel()
            {
                Text = subTitle,
                Font = new Font("Times New Roman", subSize, FontStyle.Regular),
                BoundsF = new RectangleF(255, 25, 800, 60),
                StyleName = "Title"

            };
            reportHeaderBand.Controls.Add(titleLabel);
            reportHeaderBand.Controls.Add(titleLabel1);
            return reportHeaderBand;
        }

        public void InitDetailsBasedonXRTable(XtraReport rep) {
            DataSet ds = ((DataSet)rep.DataSource);
            
            try
            {
                int colCount = ds.Tables[0].Columns.Count;
                int colWidth = (rep.PageWidth - (rep.Margins.Left + rep.Margins.Right)) / colCount;

                // Create a table to represent headers
                XRTable tableHeader = new XRTable();
                tableHeader.Height = 20;
                tableHeader.Width = (rep.PageWidth - (rep.Margins.Left + rep.Margins.Right));
                tableHeader.Font = new Font("Times New Roman", 10f, FontStyle.Bold);
                tableHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                tableHeader.Borders = DevExpress.XtraPrinting.BorderSide.All;
                XRTableRow headerRow = new XRTableRow();
                headerRow.Width = tableHeader.Width;
                tableHeader.Rows.Add(headerRow);

                tableHeader.BeginInit();

                // Create a table to display data
                XRTable tableDetail = new XRTable();
                tableDetail.Height = 20;
                tableDetail.Width = (rep.PageWidth - (rep.Margins.Left + rep.Margins.Right));
                tableDetail.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;
                tableDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                XRTableRow detailRow = new XRTableRow();
                detailRow.Width = tableDetail.Width;
                tableDetail.Rows.Add(detailRow);

                tableDetail.BeginInit();

                // Create table cells, fill the header cells with text, bind the cells to data
                for (int i = 0; i < colCount; i++)
                {
                    XRTableCell headerCell = new XRTableCell();
                    headerCell.Width = colWidth;

                    //headerCell.Font = new Font("Arial", FontStyle.Bold);
                    if (ds.Tables[0].Columns[i].Caption == "MASV")
                    {
                        headerCell.Text = "Mã sinh viên";
                    }
                    else if (ds.Tables[0].Columns[i].Caption == "HOTEN")
                    {
                        headerCell.Text = "Họ và tên";
                    }
                    else
                    {
                        headerCell.Text = ds.Tables[0].Columns[i].Caption;
                    }


                    XRTableCell detailCell = new XRTableCell();
                    detailCell.Width = colWidth;
                    detailCell.DataBindings.Add("Text", null, ds.Tables[0].Columns[i].Caption);

                    // Place the cells into the corresponding tables
                    headerRow.Cells.Add(headerCell);
                    detailRow.Cells.Add(detailCell);
                }
                tableHeader.EndInit();
                tableDetail.EndInit();
                // Place the table onto a report's Detail band
                rep.Bands[BandKind.PageHeader].Controls.Add(tableHeader);
                rep.Bands[BandKind.Detail].Controls.Add(tableDetail);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lớp chưa có sinh viên!", "Thông báo", MessageBoxButtons.OK);
                txtTenLop.Focus();
                return;
            }
          
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void BtnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}