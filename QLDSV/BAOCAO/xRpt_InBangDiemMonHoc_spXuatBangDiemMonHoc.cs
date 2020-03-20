using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV.BaoCao
{
    public partial class xRpt_InBangDiemMonHoc_spXuatBangDiemMonHoc : DevExpress.XtraReports.UI.XtraReport
    {
       
        public xRpt_InBangDiemMonHoc_spXuatBangDiemMonHoc(String tenLop,String tenMH,String lan)
        {
            InitializeComponent();
            qldsvroot1.EnforceConstraints = false;
            this.sP_XuatBangDiemMonHocTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_XuatBangDiemMonHocTableAdapter.Fill(qldsvroot1.SP_XuatBangDiemMonHoc, tenLop, tenMH, new System.Nullable<short>(((short)(System.Convert.ChangeType(lan, typeof(short))))));
        }

    }
}
