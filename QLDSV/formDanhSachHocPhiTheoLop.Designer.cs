namespace QLDSV
{
    partial class formDanhSachHocPhiTheoLop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDanhSachHocPhiTheoLop));
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnManHinh = new System.Windows.Forms.ToolStripButton();
            this.btnMayIn = new System.Windows.Forms.ToolStripButton();
            this.btnThoatMonHoc = new System.Windows.Forms.ToolStripButton();
            this.v_DS_PHANMANHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLDSVPMMaster = new QLDSV.QLDSVPMMaster();
            this.v_DS_PHANMANHTableAdapter = new QLDSV.QLDSVPMMasterTableAdapters.V_DS_PHANMANHTableAdapter();
            this.tableAdapterManager = new QLDSV.QLDSVPMMasterTableAdapters.TableAdapterManager();
            this.qLDSVROOT = new QLDSV.QLDSVROOT();
            this.tableAdapterManager1 = new QLDSV.QLDSVROOTTableAdapters.TableAdapterManager();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboNienKhoa = new System.Windows.Forms.ComboBox();
            this.comboHocKy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboMaLop = new System.Windows.Forms.ComboBox();
            this.getAllMaLopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sP_DanhSachHocPhiLopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sP_DanhSachHocPhiLopTableAdapter = new QLDSV.QLDSVROOTTableAdapters.SP_DanhSachHocPhiLopTableAdapter();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOCPHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tdSoTienDaDong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sP_DanhSachHocPhiLopGridControl = new DevExpress.XtraGrid.GridControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.getAllMaLopTableAdapter = new QLDSV.QLDSVROOTTableAdapters.GetAllMaLopTableAdapter();
            this.hOCPHIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hOCPHITableAdapter = new QLDSV.QLDSVROOTTableAdapters.HOCPHITableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v_DS_PHANMANHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSVPMMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSVROOT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getAllMaLopBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sP_DanhSachHocPhiLopBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sP_DanhSachHocPhiLopGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hOCPHIBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnManHinh,
            this.btnMayIn,
            this.btnThoatMonHoc});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(761, 27);
            this.bindingNavigator1.TabIndex = 3;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // btnManHinh
            // 
            this.btnManHinh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManHinh.Image = ((System.Drawing.Image)(resources.GetObject("btnManHinh.Image")));
            this.btnManHinh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnManHinh.Name = "btnManHinh";
            this.btnManHinh.Size = new System.Drawing.Size(113, 24);
            this.btnManHinh.Text = "MÀN HÌNH";
            this.btnManHinh.Click += new System.EventHandler(this.btnManHinh_Click);
            // 
            // btnMayIn
            // 
            this.btnMayIn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMayIn.Image = ((System.Drawing.Image)(resources.GetObject("btnMayIn.Image")));
            this.btnMayIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMayIn.Name = "btnMayIn";
            this.btnMayIn.Size = new System.Drawing.Size(89, 24);
            this.btnMayIn.Text = "MÁY IN";
            this.btnMayIn.Click += new System.EventHandler(this.btnMayIn_Click);
            // 
            // btnThoatMonHoc
            // 
            this.btnThoatMonHoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoatMonHoc.Image = ((System.Drawing.Image)(resources.GetObject("btnThoatMonHoc.Image")));
            this.btnThoatMonHoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoatMonHoc.Name = "btnThoatMonHoc";
            this.btnThoatMonHoc.Size = new System.Drawing.Size(85, 24);
            this.btnThoatMonHoc.Text = "THOÁT";
            this.btnThoatMonHoc.Click += new System.EventHandler(this.btnThoatMonHoc_Click);
            // 
            // v_DS_PHANMANHBindingSource
            // 
            this.v_DS_PHANMANHBindingSource.DataMember = "V_DS_PHANMANH";
            this.v_DS_PHANMANHBindingSource.DataSource = this.qLDSVPMMaster;
            // 
            // qLDSVPMMaster
            // 
            this.qLDSVPMMaster.DataSetName = "QLDSVPMMaster";
            this.qLDSVPMMaster.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_DS_PHANMANHTableAdapter
            // 
            this.v_DS_PHANMANHTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = QLDSV.QLDSVPMMasterTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // qLDSVROOT
            // 
            this.qLDSVROOT.DataSetName = "QLDSVROOT";
            this.qLDSVROOT.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.DIEMTableAdapter = null;
            this.tableAdapterManager1.GIANGVIENTableAdapter = null;
            this.tableAdapterManager1.HOCPHITableAdapter = null;
            this.tableAdapterManager1.KHOATableAdapter = null;
            this.tableAdapterManager1.LOPTableAdapter = null;
            this.tableAdapterManager1.MONHOCTableAdapter = null;
            this.tableAdapterManager1.SINHVIENTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = QLDSV.QLDSVROOTTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Niên Khóa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "Học Kỳ:";
            // 
            // comboNienKhoa
            // 
            this.comboNienKhoa.DataSource = this.hOCPHIBindingSource;
            this.comboNienKhoa.DisplayMember = "NIENKHOA";
            this.comboNienKhoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboNienKhoa.FormattingEnabled = true;
            this.comboNienKhoa.Location = new System.Drawing.Point(110, 54);
            this.comboNienKhoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboNienKhoa.Name = "comboNienKhoa";
            this.comboNienKhoa.Size = new System.Drawing.Size(132, 27);
            this.comboNienKhoa.TabIndex = 13;
            this.comboNienKhoa.ValueMember = "NIENKHOA";
            // 
            // comboHocKy
            // 
            this.comboHocKy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboHocKy.FormattingEnabled = true;
            this.comboHocKy.Location = new System.Drawing.Point(110, 91);
            this.comboHocKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboHocKy.Name = "comboHocKy";
            this.comboHocKy.Size = new System.Drawing.Size(97, 27);
            this.comboHocKy.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mã Lớp:";
            // 
            // comboMaLop
            // 
            this.comboMaLop.DataSource = this.getAllMaLopBindingSource;
            this.comboMaLop.DisplayMember = "MALOP";
            this.comboMaLop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMaLop.FormattingEnabled = true;
            this.comboMaLop.Location = new System.Drawing.Point(110, 14);
            this.comboMaLop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboMaLop.Name = "comboMaLop";
            this.comboMaLop.Size = new System.Drawing.Size(163, 27);
            this.comboMaLop.TabIndex = 8;
            this.comboMaLop.ValueMember = "MALOP";
            // 
            // getAllMaLopBindingSource
            // 
            this.getAllMaLopBindingSource.DataMember = "GetAllMaLop";
            this.getAllMaLopBindingSource.DataSource = this.qLDSVROOT;
            // 
            // sP_DanhSachHocPhiLopBindingSource
            // 
            this.sP_DanhSachHocPhiLopBindingSource.DataMember = "SP_DanhSachHocPhiLop";
            this.sP_DanhSachHocPhiLopBindingSource.DataSource = this.qLDSVROOT;
            // 
            // sP_DanhSachHocPhiLopTableAdapter
            // 
            this.sP_DanhSachHocPhiLopTableAdapter.ClearBeforeFill = true;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colHOTEN,
            this.colHOCPHI,
            this.tdSoTienDaDong});
            this.gridView1.DetailHeight = 284;
            this.gridView1.GridControl = this.sP_DanhSachHocPhiLopGridControl;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Discontinued", null, "(Discontinued products count={0})", 2)});
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "#";
            this.gridColumn1.MinWidth = 21;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 81;
            // 
            // colHOTEN
            // 
            this.colHOTEN.Caption = "Họ và Tên";
            this.colHOTEN.FieldName = "HOTEN";
            this.colHOTEN.MinWidth = 21;
            this.colHOTEN.Name = "colHOTEN";
            this.colHOTEN.Visible = true;
            this.colHOTEN.VisibleIndex = 0;
            this.colHOTEN.Width = 81;
            // 
            // colHOCPHI
            // 
            this.colHOCPHI.AppearanceHeader.Options.UseTextOptions = true;
            this.colHOCPHI.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHOCPHI.Caption = "Học Phí(VND)";
            this.colHOCPHI.FieldName = "HOCPHI";
            this.colHOCPHI.MinWidth = 21;
            this.colHOCPHI.Name = "colHOCPHI";
            this.colHOCPHI.Visible = true;
            this.colHOCPHI.VisibleIndex = 1;
            this.colHOCPHI.Width = 81;
            // 
            // tdSoTienDaDong
            // 
            this.tdSoTienDaDong.AppearanceHeader.Options.UseTextOptions = true;
            this.tdSoTienDaDong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tdSoTienDaDong.Caption = "Số Tiền Đã Đóng(VND)";
            this.tdSoTienDaDong.FieldName = "SOTIENDADONG";
            this.tdSoTienDaDong.MinWidth = 21;
            this.tdSoTienDaDong.Name = "tdSoTienDaDong";
            this.tdSoTienDaDong.Visible = true;
            this.tdSoTienDaDong.VisibleIndex = 2;
            this.tdSoTienDaDong.Width = 81;
            // 
            // sP_DanhSachHocPhiLopGridControl
            // 
            this.sP_DanhSachHocPhiLopGridControl.DataSource = this.sP_DanhSachHocPhiLopBindingSource;
            this.sP_DanhSachHocPhiLopGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sP_DanhSachHocPhiLopGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sP_DanhSachHocPhiLopGridControl.Location = new System.Drawing.Point(2, 2);
            this.sP_DanhSachHocPhiLopGridControl.MainView = this.gridView1;
            this.sP_DanhSachHocPhiLopGridControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sP_DanhSachHocPhiLopGridControl.Name = "sP_DanhSachHocPhiLopGridControl";
            this.sP_DanhSachHocPhiLopGridControl.Size = new System.Drawing.Size(757, 187);
            this.sP_DanhSachHocPhiLopGridControl.TabIndex = 15;
            this.sP_DanhSachHocPhiLopGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.comboMaLop);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.comboHocKy);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.comboNienKhoa);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 27);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(761, 157);
            this.panelControl1.TabIndex = 16;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sP_DanhSachHocPhiLopGridControl);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 184);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(761, 191);
            this.panelControl2.TabIndex = 15;
            // 
            // getAllMaLopTableAdapter
            // 
            this.getAllMaLopTableAdapter.ClearBeforeFill = true;
            // 
            // hOCPHIBindingSource
            // 
            this.hOCPHIBindingSource.DataMember = "HOCPHI";
            this.hOCPHIBindingSource.DataSource = this.qLDSVROOT;
            // 
            // hOCPHITableAdapter
            // 
            this.hOCPHITableAdapter.ClearBeforeFill = true;
            // 
            // formDanhSachHocPhiTheoLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 375);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.bindingNavigator1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "formDanhSachHocPhiTheoLop";
            this.Text = "In danh sách học phí";
            this.Load += new System.EventHandler(this.formDanhSachHocPhiTheoLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v_DS_PHANMANHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSVPMMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSVROOT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getAllMaLopBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sP_DanhSachHocPhiLopBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sP_DanhSachHocPhiLopGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hOCPHIBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton btnManHinh;
        private System.Windows.Forms.ToolStripButton btnMayIn;
        private System.Windows.Forms.ToolStripButton btnThoatMonHoc;
        private QLDSVPMMaster qLDSVPMMaster;
        private System.Windows.Forms.BindingSource v_DS_PHANMANHBindingSource;
        private QLDSVPMMasterTableAdapters.V_DS_PHANMANHTableAdapter v_DS_PHANMANHTableAdapter;
        private QLDSVPMMasterTableAdapters.TableAdapterManager tableAdapterManager;
        private QLDSVROOT qLDSVROOT;
        private QLDSVROOTTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboNienKhoa;
        private System.Windows.Forms.ComboBox comboHocKy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboMaLop;
        private System.Windows.Forms.BindingSource sP_DanhSachHocPhiLopBindingSource;
        private QLDSVROOTTableAdapters.SP_DanhSachHocPhiLopTableAdapter sP_DanhSachHocPhiLopTableAdapter;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEN;
        private DevExpress.XtraGrid.Columns.GridColumn colHOCPHI;
        private DevExpress.XtraGrid.Columns.GridColumn tdSoTienDaDong;
        private DevExpress.XtraGrid.GridControl sP_DanhSachHocPhiLopGridControl;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.BindingSource getAllMaLopBindingSource;
        private QLDSVROOTTableAdapters.GetAllMaLopTableAdapter getAllMaLopTableAdapter;
        private System.Windows.Forms.BindingSource hOCPHIBindingSource;
        private QLDSVROOTTableAdapters.HOCPHITableAdapter hOCPHITableAdapter;
    }
}