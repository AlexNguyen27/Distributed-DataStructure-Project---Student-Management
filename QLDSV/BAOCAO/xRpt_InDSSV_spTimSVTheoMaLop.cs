using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV.BaoCao
{
    public partial class xRpt_InDSSV_spTimSVTheoMaLop : DevExpress.XtraReports.UI.XtraReport
    {
        //public xRpt_InDSSV_spTimSVTheoMaLop()
        //{
        //    InitializeComponent();
        //}

        public xRpt_InDSSV_spTimSVTheoMaLop(String maLop)
        {
            InitializeComponent();
            qldsvroot4.EnforceConstraints = false;
            this.sP_XuatSinhVienTheoMaLopTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_XuatSinhVienTheoMaLopTableAdapter.Fill(qldsvroot4.SP_XuatSinhVienTheoMaLop,maLop);
        }

    }
}
