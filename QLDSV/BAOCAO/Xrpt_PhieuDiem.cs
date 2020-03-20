using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV.BAOCAO
{
    public partial class Xrpt_PhieuDiem : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_PhieuDiem(string masv)
        {
            InitializeComponent();
            qldsvroot1.EnforceConstraints = false;
            this.sP_PhieuDiemSinhVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_PhieuDiemSinhVienTableAdapter.Fill(this.qldsvroot1.SP_PhieuDiemSinhVien, masv);
        }

    }
}
