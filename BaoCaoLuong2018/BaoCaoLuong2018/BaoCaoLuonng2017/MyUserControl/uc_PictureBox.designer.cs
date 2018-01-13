namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl
{
    partial class uc_PictureBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imageBox1 = new ImageGlass.ImageBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btn_xoayphai = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Xoaytrai = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imageBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox1.GridColor = System.Drawing.Color.White;
            this.imageBox1.HorizontalScrollBarStyle = ImageGlass.ImageBoxScrollBarStyle.Hide;
            this.imageBox1.Location = new System.Drawing.Point(2, 2);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(774, 451);
            this.imageBox1.TabIndex = 3;
            this.imageBox1.VerticalScrollBarStyle = ImageGlass.ImageBoxScrollBarStyle.Hide;
            this.imageBox1.MouseLeave += new System.EventHandler(this.imageBox1_MouseLeave);
            this.imageBox1.MouseHover += new System.EventHandler(this.imageBox1_MouseHover);
            this.imageBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageBox1_MouseMove);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn_xoayphai);
            this.panelControl1.Controls.Add(this.btn_Xoaytrai);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 455);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(778, 26);
            this.panelControl1.TabIndex = 4;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.imageBox1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(778, 455);
            this.panelControl2.TabIndex = 5;
            // 
            // btn_xoayphai
            // 
            this.btn_xoayphai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_xoayphai.Location = new System.Drawing.Point(577, 1);
            this.btn_xoayphai.Name = "btn_xoayphai";
            this.btn_xoayphai.Size = new System.Drawing.Size(75, 23);
            this.btn_xoayphai.TabIndex = 16;
            this.btn_xoayphai.Text = "Xoay phải";
            this.btn_xoayphai.Click += new System.EventHandler(this.btn_xoayphai_Click);
            // 
            // btn_Xoaytrai
            // 
            this.btn_Xoaytrai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Xoaytrai.Location = new System.Drawing.Point(496, 1);
            this.btn_Xoaytrai.Name = "btn_Xoaytrai";
            this.btn_Xoaytrai.Size = new System.Drawing.Size(75, 23);
            this.btn_Xoaytrai.TabIndex = 17;
            this.btn_Xoaytrai.Text = "Xoay trái";
            this.btn_Xoaytrai.Click += new System.EventHandler(this.btn_Xoaytrai_Click);
            // 
            // uc_PictureBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "uc_PictureBox";
            this.Size = new System.Drawing.Size(778, 481);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public ImageGlass.ImageBox imageBox1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_xoayphai;
        private DevExpress.XtraEditors.SimpleButton btn_Xoaytrai;
        private DevExpress.XtraEditors.PanelControl panelControl2;
    }
}
