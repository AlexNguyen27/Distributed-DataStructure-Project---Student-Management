using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1(string maLop, string maMH, short lan)
        {
            InitializeComponent();
            qldsvroot1.EnforceConstraints = false;
            this.sP_DSThiHetMonTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_DSThiHetMonTableAdapter.Fill(this.qldsvroot1.SP_DSThiHetMon, maLop, maMH, lan);
        }

    }
}
