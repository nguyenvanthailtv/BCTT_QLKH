
namespace BCTT_QLKH.Module1_form
{
    partial class frm_PhieuThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuThu));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvPhieuThu = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Reset = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbTenKhach = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbPT = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpNgayThu = new System.Windows.Forms.DateTimePicker();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenQuanLy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoPT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.DanhMuc1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.khoHàngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hàngTồnKhoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nhàCungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hàngHóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.đơnMuaHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuNhậpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuChiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đơnĐặtHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuGiaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hàngNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hàngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hàngTồnKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoTồnKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoDoanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QL = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuThu)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(523, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 34);
            this.label1.TabIndex = 34;
            this.label1.Text = "Phiếu Giao";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.dgvPhieuThu);
            this.groupBox3.Location = new System.Drawing.Point(56, 541);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1087, 248);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách Phiếu Thu:";
            // 
            // dgvPhieuThu
            // 
            this.dgvPhieuThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuThu.Location = new System.Drawing.Point(83, 56);
            this.dgvPhieuThu.Name = "dgvPhieuThu";
            this.dgvPhieuThu.RowHeadersWidth = 51;
            this.dgvPhieuThu.RowTemplate.Height = 24;
            this.dgvPhieuThu.Size = new System.Drawing.Size(932, 186);
            this.dgvPhieuThu.TabIndex = 0;
            this.dgvPhieuThu.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuChi_RowEnter);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.Reset);
            this.groupBox2.Controls.Add(this.btnIn);
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Location = new System.Drawing.Point(56, 430);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1087, 105);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng :";
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(668, 32);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(145, 47);
            this.Reset.TabIndex = 4;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(870, 32);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(145, 47);
            this.btnIn.TabIndex = 3;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(473, 32);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(145, 47);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(277, 32);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(145, 47);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(83, 32);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(145, 47);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.cbbTenKhach);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbbPT);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpNgayThu);
            this.groupBox1.Controls.Add(this.txtTongTien);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTenQuanLy);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSoPT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(56, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1087, 318);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin Phiếu Giao:";
            // 
            // cbbTenKhach
            // 
            this.cbbTenKhach.FormattingEnabled = true;
            this.cbbTenKhach.Location = new System.Drawing.Point(443, 187);
            this.cbbTenKhach.Name = "cbbTenKhach";
            this.cbbTenKhach.Size = new System.Drawing.Size(463, 33);
            this.cbbTenKhach.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tên Khách:";
            // 
            // cbbPT
            // 
            this.cbbPT.FormattingEnabled = true;
            this.cbbPT.Location = new System.Drawing.Point(446, 99);
            this.cbbPT.Name = "cbbPT";
            this.cbbPT.Size = new System.Drawing.Size(463, 33);
            this.cbbPT.TabIndex = 11;
            this.cbbPT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbbPN_MouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(207, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "Số Phiếu Giao:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(207, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Ngày Thu:";
            // 
            // dtpNgayThu
            // 
            this.dtpNgayThu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayThu.Location = new System.Drawing.Point(446, 139);
            this.dtpNgayThu.Name = "dtpNgayThu";
            this.dtpNgayThu.Size = new System.Drawing.Size(463, 33);
            this.dtpNgayThu.TabIndex = 8;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(443, 265);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(463, 33);
            this.txtTongTien.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tổng Tiền Thu : ";
            // 
            // txtTenQuanLy
            // 
            this.txtTenQuanLy.Location = new System.Drawing.Point(443, 226);
            this.txtTenQuanLy.Name = "txtTenQuanLy";
            this.txtTenQuanLy.Size = new System.Drawing.Size(463, 33);
            this.txtTenQuanLy.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên Quản Lý :";
            // 
            // txtSoPT
            // 
            this.txtSoPT.Location = new System.Drawing.Point(446, 55);
            this.txtSoPT.Name = "txtSoPT";
            this.txtSoPT.Size = new System.Drawing.Size(463, 33);
            this.txtSoPT.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số Phiếu Thu:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DanhMuc1,
            this.cậpNhậpToolStripMenuItem,
            this.tìmKiếmToolStripMenuItem,
            this.báoCáoToolStripMenuItem,
            this.QL});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1200, 35);
            this.menuStrip1.TabIndex = 35;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // DanhMuc1
            // 
            this.DanhMuc1.Name = "DanhMuc1";
            this.DanhMuc1.Size = new System.Drawing.Size(121, 31);
            this.DanhMuc1.Text = "Hệ Thống";
            this.DanhMuc1.Click += new System.EventHandler(this.DanhMuc1_Click);
            // 
            // cậpNhậpToolStripMenuItem
            // 
            this.cậpNhậpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.nhàCungCấpToolStripMenuItem,
            this.hàngHóaToolStripMenuItem,
            this.kháchHàngToolStripMenuItem,
            this.toolStripMenuItem2,
            this.nhậpHàngToolStripMenuItem});
            this.cậpNhậpToolStripMenuItem.Name = "cậpNhậpToolStripMenuItem";
            this.cậpNhậpToolStripMenuItem.Size = new System.Drawing.Size(128, 31);
            this.cậpNhậpToolStripMenuItem.Text = "Danh Mục";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.khoHàngToolStripMenuItem1,
            this.hàngTồnKhoToolStripMenuItem1});
            this.toolStripMenuItem1.Image = global::BCTT_QLKH.Properties.Resources.warehouse__1_;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(230, 32);
            this.toolStripMenuItem1.Text = "Kho hàng";
            // 
            // khoHàngToolStripMenuItem1
            // 
            this.khoHàngToolStripMenuItem1.Image = global::BCTT_QLKH.Properties.Resources.warehouse__1_;
            this.khoHàngToolStripMenuItem1.Name = "khoHàngToolStripMenuItem1";
            this.khoHàngToolStripMenuItem1.Size = new System.Drawing.Size(228, 32);
            this.khoHàngToolStripMenuItem1.Text = "Kho hàng";
            this.khoHàngToolStripMenuItem1.Click += new System.EventHandler(this.khoHàngToolStripMenuItem1_Click);
            // 
            // hàngTồnKhoToolStripMenuItem1
            // 
            this.hàngTồnKhoToolStripMenuItem1.Image = global::BCTT_QLKH.Properties.Resources.inventory;
            this.hàngTồnKhoToolStripMenuItem1.Name = "hàngTồnKhoToolStripMenuItem1";
            this.hàngTồnKhoToolStripMenuItem1.Size = new System.Drawing.Size(228, 32);
            this.hàngTồnKhoToolStripMenuItem1.Text = "Hàng tồn kho";
            this.hàngTồnKhoToolStripMenuItem1.Click += new System.EventHandler(this.hàngTồnKhoToolStripMenuItem1_Click);
            // 
            // nhàCungCấpToolStripMenuItem
            // 
            this.nhàCungCấpToolStripMenuItem.Image = global::BCTT_QLKH.Properties.Resources.supplier;
            this.nhàCungCấpToolStripMenuItem.Name = "nhàCungCấpToolStripMenuItem";
            this.nhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(230, 32);
            this.nhàCungCấpToolStripMenuItem.Text = "Nhà cung cấp";
            this.nhàCungCấpToolStripMenuItem.Click += new System.EventHandler(this.nhàCungCấpToolStripMenuItem_Click);
            // 
            // hàngHóaToolStripMenuItem
            // 
            this.hàngHóaToolStripMenuItem.Image = global::BCTT_QLKH.Properties.Resources.boxes;
            this.hàngHóaToolStripMenuItem.Name = "hàngHóaToolStripMenuItem";
            this.hàngHóaToolStripMenuItem.Size = new System.Drawing.Size(230, 32);
            this.hàngHóaToolStripMenuItem.Text = "Hàng Hóa";
            this.hàngHóaToolStripMenuItem.Click += new System.EventHandler(this.hàngHóaToolStripMenuItem_Click);
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Image = global::BCTT_QLKH.Properties.Resources.customer;
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(230, 32);
            this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đơnMuaHàngToolStripMenuItem,
            this.phiếuNhậpToolStripMenuItem1,
            this.phiếuChiToolStripMenuItem1});
            this.toolStripMenuItem2.Image = global::BCTT_QLKH.Properties.Resources.import;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(230, 32);
            this.toolStripMenuItem2.Text = "Nhập hàng";
            // 
            // đơnMuaHàngToolStripMenuItem
            // 
            this.đơnMuaHàngToolStripMenuItem.Image = global::BCTT_QLKH.Properties.Resources.order_delivery;
            this.đơnMuaHàngToolStripMenuItem.Name = "đơnMuaHàngToolStripMenuItem";
            this.đơnMuaHàngToolStripMenuItem.Size = new System.Drawing.Size(247, 32);
            this.đơnMuaHàngToolStripMenuItem.Text = "Đơn Mua Hàng";
            this.đơnMuaHàngToolStripMenuItem.Click += new System.EventHandler(this.đơnMuaHàngToolStripMenuItem_Click);
            // 
            // phiếuNhậpToolStripMenuItem1
            // 
            this.phiếuNhậpToolStripMenuItem1.Image = global::BCTT_QLKH.Properties.Resources.order_delivery__1_;
            this.phiếuNhậpToolStripMenuItem1.Name = "phiếuNhậpToolStripMenuItem1";
            this.phiếuNhậpToolStripMenuItem1.Size = new System.Drawing.Size(247, 32);
            this.phiếuNhậpToolStripMenuItem1.Text = "Phiếu Nhập";
            this.phiếuNhậpToolStripMenuItem1.Click += new System.EventHandler(this.phiếuNhậpToolStripMenuItem1_Click);
            // 
            // phiếuChiToolStripMenuItem1
            // 
            this.phiếuChiToolStripMenuItem1.Image = global::BCTT_QLKH.Properties.Resources.bill;
            this.phiếuChiToolStripMenuItem1.Name = "phiếuChiToolStripMenuItem1";
            this.phiếuChiToolStripMenuItem1.Size = new System.Drawing.Size(247, 32);
            this.phiếuChiToolStripMenuItem1.Text = "Phiếu Chi";
            this.phiếuChiToolStripMenuItem1.Click += new System.EventHandler(this.phiếuChiToolStripMenuItem1_Click);
            // 
            // nhậpHàngToolStripMenuItem
            // 
            this.nhậpHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đơnĐặtHàngToolStripMenuItem,
            this.phiếuGiaoToolStripMenuItem,
            this.phiếuThuToolStripMenuItem});
            this.nhậpHàngToolStripMenuItem.Image = global::BCTT_QLKH.Properties.Resources.import__1_;
            this.nhậpHàngToolStripMenuItem.Name = "nhậpHàngToolStripMenuItem";
            this.nhậpHàngToolStripMenuItem.Size = new System.Drawing.Size(230, 32);
            this.nhậpHàngToolStripMenuItem.Text = "Xuất hàng";
            // 
            // đơnĐặtHàngToolStripMenuItem
            // 
            this.đơnĐặtHàngToolStripMenuItem.Image = global::BCTT_QLKH.Properties.Resources.order_delivery;
            this.đơnĐặtHàngToolStripMenuItem.Name = "đơnĐặtHàngToolStripMenuItem";
            this.đơnĐặtHàngToolStripMenuItem.Size = new System.Drawing.Size(228, 32);
            this.đơnĐặtHàngToolStripMenuItem.Text = "Đơn đặt hàng";
            this.đơnĐặtHàngToolStripMenuItem.Click += new System.EventHandler(this.đơnĐặtHàngToolStripMenuItem_Click);
            // 
            // phiếuGiaoToolStripMenuItem
            // 
            this.phiếuGiaoToolStripMenuItem.Image = global::BCTT_QLKH.Properties.Resources.order_delivery__1_;
            this.phiếuGiaoToolStripMenuItem.Name = "phiếuGiaoToolStripMenuItem";
            this.phiếuGiaoToolStripMenuItem.Size = new System.Drawing.Size(228, 32);
            this.phiếuGiaoToolStripMenuItem.Text = "Phiếu giao";
            this.phiếuGiaoToolStripMenuItem.Click += new System.EventHandler(this.phiếuGiaoToolStripMenuItem_Click);
            // 
            // phiếuThuToolStripMenuItem
            // 
            this.phiếuThuToolStripMenuItem.Image = global::BCTT_QLKH.Properties.Resources.bill;
            this.phiếuThuToolStripMenuItem.Name = "phiếuThuToolStripMenuItem";
            this.phiếuThuToolStripMenuItem.Size = new System.Drawing.Size(228, 32);
            this.phiếuThuToolStripMenuItem.Text = "Phiếu thu";
            this.phiếuThuToolStripMenuItem.Click += new System.EventHandler(this.phiếuThuToolStripMenuItem_Click);
            // 
            // tìmKiếmToolStripMenuItem
            // 
            this.tìmKiếmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hàngNhậpToolStripMenuItem,
            this.hàngXuấtToolStripMenuItem,
            this.hàngTồnKhoToolStripMenuItem});
            this.tìmKiếmToolStripMenuItem.Name = "tìmKiếmToolStripMenuItem";
            this.tìmKiếmToolStripMenuItem.Size = new System.Drawing.Size(122, 31);
            this.tìmKiếmToolStripMenuItem.Text = "Tìm Kiếm";
            // 
            // hàngNhậpToolStripMenuItem
            // 
            this.hàngNhậpToolStripMenuItem.Image = global::BCTT_QLKH.Properties.Resources.loupe;
            this.hàngNhậpToolStripMenuItem.Name = "hàngNhậpToolStripMenuItem";
            this.hàngNhậpToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.hàngNhậpToolStripMenuItem.Text = "Hàng Nhập";
            this.hàngNhậpToolStripMenuItem.Click += new System.EventHandler(this.hàngNhậpToolStripMenuItem_Click);
            // 
            // hàngXuấtToolStripMenuItem
            // 
            this.hàngXuấtToolStripMenuItem.Image = global::BCTT_QLKH.Properties.Resources.loupe__1_;
            this.hàngXuấtToolStripMenuItem.Name = "hàngXuấtToolStripMenuItem";
            this.hàngXuấtToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.hàngXuấtToolStripMenuItem.Text = "Hàng Xuất";
            this.hàngXuấtToolStripMenuItem.Click += new System.EventHandler(this.hàngXuấtToolStripMenuItem_Click);
            // 
            // hàngTồnKhoToolStripMenuItem
            // 
            this.hàngTồnKhoToolStripMenuItem.Image = global::BCTT_QLKH.Properties.Resources.loupe__2_;
            this.hàngTồnKhoToolStripMenuItem.Name = "hàngTồnKhoToolStripMenuItem";
            this.hàngTồnKhoToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.hàngTồnKhoToolStripMenuItem.Text = "Hàng Tồn Kho";
            this.hàngTồnKhoToolStripMenuItem.Click += new System.EventHandler(this.hàngTồnKhoToolStripMenuItem_Click);
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoTồnKhoToolStripMenuItem,
            this.báoCáoDoanhThuToolStripMenuItem});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(110, 31);
            this.báoCáoToolStripMenuItem.Text = "Báo Cáo";
            // 
            // báoCáoTồnKhoToolStripMenuItem
            // 
            this.báoCáoTồnKhoToolStripMenuItem.Image = global::BCTT_QLKH.Properties.Resources.report__2_;
            this.báoCáoTồnKhoToolStripMenuItem.Name = "báoCáoTồnKhoToolStripMenuItem";
            this.báoCáoTồnKhoToolStripMenuItem.Size = new System.Drawing.Size(279, 32);
            this.báoCáoTồnKhoToolStripMenuItem.Text = "Báo cáo tồn kho";
            this.báoCáoTồnKhoToolStripMenuItem.Click += new System.EventHandler(this.báoCáoTồnKhoToolStripMenuItem_Click);
            // 
            // báoCáoDoanhThuToolStripMenuItem
            // 
            this.báoCáoDoanhThuToolStripMenuItem.Image = global::BCTT_QLKH.Properties.Resources.turnover;
            this.báoCáoDoanhThuToolStripMenuItem.Name = "báoCáoDoanhThuToolStripMenuItem";
            this.báoCáoDoanhThuToolStripMenuItem.Size = new System.Drawing.Size(279, 32);
            this.báoCáoDoanhThuToolStripMenuItem.Text = "Báo cáo doanh thu";
            this.báoCáoDoanhThuToolStripMenuItem.Click += new System.EventHandler(this.báoCáoDoanhThuToolStripMenuItem_Click);
            // 
            // QL
            // 
            this.QL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.QL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem});
            this.QL.Image = global::BCTT_QLKH.Properties.Resources.user;
            this.QL.Name = "QL";
            this.QL.Size = new System.Drawing.Size(149, 31);
            this.QL.Text = "Quản Lý : ";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Image = global::BCTT_QLKH.Properties.Resources.power_off__1_;
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(304, 32);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất                 ";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // frm_PhieuThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1200, 851);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frm_PhieuThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu Thu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_PhieuThu_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuThu)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvPhieuThu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbTenKhach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbPT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpNgayThu;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenQuanLy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoPT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DanhMuc1;
        private System.Windows.Forms.ToolStripMenuItem cậpNhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem khoHàngToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hàngTồnKhoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nhàCungCấpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hàngHóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem đơnMuaHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuNhậpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem phiếuChiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nhậpHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đơnĐặtHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuGiaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hàngNhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hàngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hàngTồnKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoTồnKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoDoanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QL;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
    }
}