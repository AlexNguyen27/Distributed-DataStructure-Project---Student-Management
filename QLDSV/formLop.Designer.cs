namespace QLDSV
{
    partial class formLop
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
            System.Windows.Forms.Label mALOPLabel;
            System.Windows.Forms.Label tENLOPLabel;
            System.Windows.Forms.Label mAKHLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLop));
            this.frmLop = new DevExpress.XtraGrid.GridControl();
            this.qLDSVROOT = new QLDSV.QLDSVROOT();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMALOP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENLOP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.comboKHOA = new System.Windows.Forms.ComboBox();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLopThem = new System.Windows.Forms.ToolStripButton();
            this.btnLopXoa = new System.Windows.Forms.ToolStripButton();
            this.btnLopSua = new System.Windows.Forms.ToolStripButton();
            this.btnLopPhucHoi = new System.Windows.Forms.ToolStripButton();
            this.btnLopRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnLopThoat = new System.Windows.Forms.ToolStripButton();
            this.btnLopClear = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtMaLop = new DevExpress.XtraEditors.TextEdit();
            this.txtTenLop = new DevExpress.XtraEditors.TextEdit();
            this.txtMaKhoa = new DevExpress.XtraEditors.TextEdit();
            this.tableAdapterManager = new QLDSV.QLDSVROOTTableAdapters.TableAdapterManager();
            this.lOPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lOPTableAdapter = new QLDSV.QLDSVROOTTableAdapters.LOPTableAdapter();
            mALOPLabel = new System.Windows.Forms.Label();
            tENLOPLabel = new System.Windows.Forms.Label();
            mAKHLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.frmLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSVROOT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKhoa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mALOPLabel
            // 
            mALOPLabel.AutoSize = true;
            mALOPLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mALOPLabel.Location = new System.Drawing.Point(52, 20);
            mALOPLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            mALOPLabel.Name = "mALOPLabel";
            mALOPLabel.Size = new System.Drawing.Size(56, 19);
            mALOPLabel.TabIndex = 9;
            mALOPLabel.Text = "Mã lớp:";
            // 
            // tENLOPLabel
            // 
            tENLOPLabel.AutoSize = true;
            tENLOPLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tENLOPLabel.Location = new System.Drawing.Point(50, 65);
            tENLOPLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            tENLOPLabel.Name = "tENLOPLabel";
            tENLOPLabel.Size = new System.Drawing.Size(58, 19);
            tENLOPLabel.TabIndex = 11;
            tENLOPLabel.Text = "Tên lớp:";
            // 
            // mAKHLabel
            // 
            mAKHLabel.AutoSize = true;
            mAKHLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mAKHLabel.Location = new System.Drawing.Point(41, 113);
            mAKHLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            mAKHLabel.Name = "mAKHLabel";
            mAKHLabel.Size = new System.Drawing.Size(67, 19);
            mAKHLabel.TabIndex = 13;
            mAKHLabel.Text = "Mã khoa:";
            // 
            // frmLop
            // 
            this.frmLop.DataSource = this.lOPBindingSource;
            this.frmLop.Dock = System.Windows.Forms.DockStyle.Top;
            this.frmLop.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.frmLop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmLop.Location = new System.Drawing.Point(0, 98);
            this.frmLop.MainView = this.gridView1;
            this.frmLop.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.frmLop.Name = "frmLop";
            this.frmLop.Size = new System.Drawing.Size(811, 262);
            this.frmLop.TabIndex = 4;
            this.frmLop.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // qLDSVROOT
            // 
            this.qLDSVROOT.DataSetName = "QLDSVROOT";
            this.qLDSVROOT.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMALOP,
            this.colTENLOP,
            this.colMAKH});
            this.gridView1.DetailHeight = 459;
            this.gridView1.FixedLineWidth = 3;
            this.gridView1.GridControl = this.frmLop;
            this.gridView1.Name = "gridView1";
            // 
            // colMALOP
            // 
            this.colMALOP.AppearanceCell.Options.UseTextOptions = true;
            this.colMALOP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMALOP.Caption = "Mã lớp";
            this.colMALOP.FieldName = "MALOP";
            this.colMALOP.MinWidth = 35;
            this.colMALOP.Name = "colMALOP";
            this.colMALOP.Visible = true;
            this.colMALOP.VisibleIndex = 0;
            this.colMALOP.Width = 135;
            // 
            // colTENLOP
            // 
            this.colTENLOP.AppearanceCell.Options.UseTextOptions = true;
            this.colTENLOP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTENLOP.Caption = "Tên lớp";
            this.colTENLOP.FieldName = "TENLOP";
            this.colTENLOP.MinWidth = 35;
            this.colTENLOP.Name = "colTENLOP";
            this.colTENLOP.Visible = true;
            this.colTENLOP.VisibleIndex = 1;
            this.colTENLOP.Width = 135;
            // 
            // colMAKH
            // 
            this.colMAKH.AppearanceCell.Options.UseTextOptions = true;
            this.colMAKH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMAKH.Caption = "Mã khoa";
            this.colMAKH.FieldName = "MAKH";
            this.colMAKH.MinWidth = 35;
            this.colMAKH.Name = "colMAKH";
            this.colMAKH.Visible = true;
            this.colMAKH.VisibleIndex = 2;
            this.colMAKH.Width = 135;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "KHOA";
            // 
            // comboKHOA
            // 
            this.comboKHOA.DisplayMember = "TENSERVER";
            this.comboKHOA.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboKHOA.FormattingEnabled = true;
            this.comboKHOA.Location = new System.Drawing.Point(107, 22);
            this.comboKHOA.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.comboKHOA.Name = "comboKHOA";
            this.comboKHOA.Size = new System.Drawing.Size(176, 25);
            this.comboKHOA.TabIndex = 1;
            this.comboKHOA.ValueMember = "TENSERVER";
            this.comboKHOA.SelectedIndexChanged += new System.EventHandler(this.comboKHOA_SelectedIndexChanged);
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(413, 39);
            this.bunifuCards1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(12, 10);
            this.bunifuCards1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panel1.Controls.Add(this.bunifuCards1);
            this.panel1.Controls.Add(this.comboKHOA);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 70);
            this.panel1.TabIndex = 1;
            // 
            // btnLopThem
            // 
            this.btnLopThem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLopThem.Image = ((System.Drawing.Image)(resources.GetObject("btnLopThem.Image")));
            this.btnLopThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLopThem.Name = "btnLopThem";
            this.btnLopThem.Size = new System.Drawing.Size(86, 25);
            this.btnLopThem.Text = "THÊM";
            this.btnLopThem.Click += new System.EventHandler(this.btnLopThem_Click);
            // 
            // btnLopXoa
            // 
            this.btnLopXoa.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLopXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnLopXoa.Image")));
            this.btnLopXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLopXoa.Name = "btnLopXoa";
            this.btnLopXoa.Size = new System.Drawing.Size(74, 25);
            this.btnLopXoa.Text = "XÓA";
            this.btnLopXoa.Click += new System.EventHandler(this.btnLopXoa_Click);
            // 
            // btnLopSua
            // 
            this.btnLopSua.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLopSua.Image = ((System.Drawing.Image)(resources.GetObject("btnLopSua.Image")));
            this.btnLopSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLopSua.Name = "btnLopSua";
            this.btnLopSua.Size = new System.Drawing.Size(73, 25);
            this.btnLopSua.Text = "SỬA";
            this.btnLopSua.Click += new System.EventHandler(this.btnLopSua_Click);
            // 
            // btnLopPhucHoi
            // 
            this.btnLopPhucHoi.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLopPhucHoi.Image = ((System.Drawing.Image)(resources.GetObject("btnLopPhucHoi.Image")));
            this.btnLopPhucHoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLopPhucHoi.Name = "btnLopPhucHoi";
            this.btnLopPhucHoi.Size = new System.Drawing.Size(122, 25);
            this.btnLopPhucHoi.Text = "PHỤC HỒI";
            this.btnLopPhucHoi.Click += new System.EventHandler(this.btnLopPhucHoi_Click);
            // 
            // btnLopRefresh
            // 
            this.btnLopRefresh.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLopRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnLopRefresh.Image")));
            this.btnLopRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLopRefresh.Name = "btnLopRefresh";
            this.btnLopRefresh.Size = new System.Drawing.Size(117, 25);
            this.btnLopRefresh.Text = "REFRESH";
            this.btnLopRefresh.Click += new System.EventHandler(this.btnLopRefresh_Click);
            // 
            // btnLopThoat
            // 
            this.btnLopThoat.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLopThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnLopThoat.Image")));
            this.btnLopThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLopThoat.Name = "btnLopThoat";
            this.btnLopThoat.Size = new System.Drawing.Size(98, 25);
            this.btnLopThoat.Text = "THOÁT";
            this.btnLopThoat.Click += new System.EventHandler(this.BtnLopThoat_Click_1);
            // 
            // btnLopClear
            // 
            this.btnLopClear.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLopClear.Image = ((System.Drawing.Image)(resources.GetObject("btnLopClear.Image")));
            this.btnLopClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLopClear.Name = "btnLopClear";
            this.btnLopClear.Size = new System.Drawing.Size(95, 25);
            this.btnLopClear.Text = "CLEAR";
            this.btnLopClear.Click += new System.EventHandler(this.btnLopClear_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLopThem,
            this.btnLopXoa,
            this.btnLopSua,
            this.btnLopPhucHoi,
            this.btnLopRefresh,
            this.btnLopThoat,
            this.btnLopClear});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(811, 28);
            this.bindingNavigator1.TabIndex = 0;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(mALOPLabel);
            this.panelControl1.Controls.Add(this.txtMaLop);
            this.panelControl1.Controls.Add(tENLOPLabel);
            this.panelControl1.Controls.Add(this.txtTenLop);
            this.panelControl1.Controls.Add(mAKHLabel);
            this.panelControl1.Controls.Add(this.txtMaKhoa);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 360);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(811, 183);
            this.panelControl1.TabIndex = 5;
            // 
            // txtMaLop
            // 
            this.txtMaLop.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lOPBindingSource, "MALOP", true));
            this.txtMaLop.Location = new System.Drawing.Point(116, 17);
            this.txtMaLop.Margin = new System.Windows.Forms.Padding(5);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLop.Properties.Appearance.Options.UseFont = true;
            this.txtMaLop.Size = new System.Drawing.Size(167, 26);
            this.txtMaLop.TabIndex = 10;
            // 
            // txtTenLop
            // 
            this.txtTenLop.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lOPBindingSource, "TENLOP", true));
            this.txtTenLop.Location = new System.Drawing.Point(116, 62);
            this.txtTenLop.Margin = new System.Windows.Forms.Padding(5);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLop.Properties.Appearance.Options.UseFont = true;
            this.txtTenLop.Size = new System.Drawing.Size(333, 26);
            this.txtTenLop.TabIndex = 12;
            // 
            // txtMaKhoa
            // 
            this.txtMaKhoa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lOPBindingSource, "MAKH", true));
            this.txtMaKhoa.Location = new System.Drawing.Point(116, 110);
            this.txtMaKhoa.Margin = new System.Windows.Forms.Padding(5);
            this.txtMaKhoa.Name = "txtMaKhoa";
            this.txtMaKhoa.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKhoa.Properties.Appearance.Options.UseFont = true;
            this.txtMaKhoa.Size = new System.Drawing.Size(167, 26);
            this.txtMaKhoa.TabIndex = 14;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DIEMTableAdapter = null;
            this.tableAdapterManager.GIANGVIENTableAdapter = null;
            this.tableAdapterManager.HOCPHITableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLDSV.QLDSVROOTTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // lOPBindingSource
            // 
            this.lOPBindingSource.DataMember = "LOP";
            this.lOPBindingSource.DataSource = this.qLDSVROOT;
            // 
            // lOPTableAdapter
            // 
            this.lOPTableAdapter.ClearBeforeFill = true;
            // 
            // formLop
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 543);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.frmLop);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bindingNavigator1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "formLop";
            this.Text = "Lớp";
            this.Load += new System.EventHandler(this.formLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.frmLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSVROOT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKhoa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl frmLop;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMALOP;
        private DevExpress.XtraGrid.Columns.GridColumn colTENLOP;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboKHOA;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton btnLopThem;
        private System.Windows.Forms.ToolStripButton btnLopXoa;
        private System.Windows.Forms.ToolStripButton btnLopSua;
        private System.Windows.Forms.ToolStripButton btnLopPhucHoi;
        private System.Windows.Forms.ToolStripButton btnLopRefresh;
        private System.Windows.Forms.ToolStripButton btnLopThoat;
        private System.Windows.Forms.ToolStripButton btnLopClear;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private QLDSVROOT qLDSVROOT;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtMaLop;
        private DevExpress.XtraEditors.TextEdit txtTenLop;
        private DevExpress.XtraEditors.TextEdit txtMaKhoa;
        private QLDSVROOTTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource lOPBindingSource;
        private QLDSVROOTTableAdapters.LOPTableAdapter lOPTableAdapter;
        // private QLDSV.QLDSVTableAdapters.LOPTableAdapter lOPTableAdapter;
        //private QLDSV.QLDSVTableAdapters.TableAdapterManager tableAdapterManager;
        // private QLDSV.QLDSVTableAdapters.LOPTableAdapter lOPTableAdapter;
    }
}