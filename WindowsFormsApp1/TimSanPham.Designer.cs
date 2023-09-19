namespace WindowsFormsApp1
{
    partial class TimSanPham
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
            this.dgvTimHH = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimSP = new System.Windows.Forms.TextBox();
            this.txtMaHH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThemVaoHD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimHH)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTimHH
            // 
            this.dgvTimHH.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvTimHH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimHH.Location = new System.Drawing.Point(59, 58);
            this.dgvTimHH.Name = "dgvTimHH";
            this.dgvTimHH.RowHeadersWidth = 51;
            this.dgvTimHH.RowTemplate.Height = 24;
            this.dgvTimHH.Size = new System.Drawing.Size(1414, 513);
            this.dgvTimHH.TabIndex = 0;
            this.dgvTimHH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimHH_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(56, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tìm sản phẩm";
            // 
            // txtTimSP
            // 
            this.txtTimSP.Location = new System.Drawing.Point(169, 24);
            this.txtTimSP.Name = "txtTimSP";
            this.txtTimSP.Size = new System.Drawing.Size(439, 25);
            this.txtTimSP.TabIndex = 3;
            this.txtTimSP.TextChanged += new System.EventHandler(this.txtTimSP_TextChanged);
            // 
            // txtMaHH
            // 
            this.txtMaHH.Location = new System.Drawing.Point(744, 18);
            this.txtMaHH.Name = "txtMaHH";
            this.txtMaHH.ReadOnly = true;
            this.txtMaHH.Size = new System.Drawing.Size(248, 25);
            this.txtMaHH.TabIndex = 4;
            this.txtMaHH.TextChanged += new System.EventHandler(this.txtMaHH_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(630, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mã hàng hóa";
            // 
            // btnThemVaoHD
            // 
            this.btnThemVaoHD.Location = new System.Drawing.Point(1010, 14);
            this.btnThemVaoHD.Name = "btnThemVaoHD";
            this.btnThemVaoHD.Size = new System.Drawing.Size(190, 33);
            this.btnThemVaoHD.TabIndex = 6;
            this.btnThemVaoHD.Text = "Thêm vào hóa đơn";
            this.btnThemVaoHD.UseVisualStyleBackColor = true;
            this.btnThemVaoHD.Click += new System.EventHandler(this.btnThemVaoHD_Click);
            // 
            // TimSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources._21;
            this.ClientSize = new System.Drawing.Size(1511, 607);
            this.Controls.Add(this.btnThemVaoHD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaHH);
            this.Controls.Add(this.txtTimSP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTimHH);
            this.Font = new System.Drawing.Font("SF Pro Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TimSanPham";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Tìm sản phẩm";
            this.Load += new System.EventHandler(this.TimSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimHH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimHH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimSP;
        private System.Windows.Forms.TextBox txtMaHH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThemVaoHD;
    }
}