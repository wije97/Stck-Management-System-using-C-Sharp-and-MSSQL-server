namespace Stock_Management_System
{
    partial class ViewOrderSP
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearchOID = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchOID = new System.Windows.Forms.TextBox();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.btnSearchCID = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchCID = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblSPNIC = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 29);
            this.label1.TabIndex = 23;
            this.label1.Text = "View Order";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSearchOID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtSearchOID);
            this.panel1.Controls.Add(this.dgvView);
            this.panel1.Controls.Add(this.btnSearchCID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSearchCID);
            this.panel1.Location = new System.Drawing.Point(22, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 368);
            this.panel1.TabIndex = 24;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(898, 319);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(106, 36);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearchOID
            // 
            this.btnSearchOID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchOID.Location = new System.Drawing.Point(390, 61);
            this.btnSearchOID.Name = "btnSearchOID";
            this.btnSearchOID.Size = new System.Drawing.Size(206, 34);
            this.btnSearchOID.TabIndex = 23;
            this.btnSearchOID.Text = "Search";
            this.btnSearchOID.UseVisualStyleBackColor = true;
            this.btnSearchOID.Click += new System.EventHandler(this.btnSearchOID_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Order ID:";
            // 
            // txtSearchOID
            // 
            this.txtSearchOID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchOID.Location = new System.Drawing.Point(163, 65);
            this.txtSearchOID.Name = "txtSearchOID";
            this.txtSearchOID.Size = new System.Drawing.Size(206, 26);
            this.txtSearchOID.TabIndex = 22;
            // 
            // dgvView
            // 
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Location = new System.Drawing.Point(29, 115);
            this.dgvView.Name = "dgvView";
            this.dgvView.RowHeadersWidth = 51;
            this.dgvView.RowTemplate.Height = 24;
            this.dgvView.Size = new System.Drawing.Size(975, 193);
            this.dgvView.TabIndex = 20;
            // 
            // btnSearchCID
            // 
            this.btnSearchCID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCID.Location = new System.Drawing.Point(390, 21);
            this.btnSearchCID.Name = "btnSearchCID";
            this.btnSearchCID.Size = new System.Drawing.Size(206, 34);
            this.btnSearchCID.TabIndex = 19;
            this.btnSearchCID.Text = "Search";
            this.btnSearchCID.UseVisualStyleBackColor = true;
            this.btnSearchCID.Click += new System.EventHandler(this.btnSearchCID_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Customer ID:";
            // 
            // txtSearchCID
            // 
            this.txtSearchCID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCID.Location = new System.Drawing.Point(163, 25);
            this.txtSearchCID.Name = "txtSearchCID";
            this.txtSearchCID.Size = new System.Drawing.Size(206, 26);
            this.txtSearchCID.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(22, 451);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(106, 36);
            this.btnBack.TabIndex = 24;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblSPNIC
            // 
            this.lblSPNIC.AutoSize = true;
            this.lblSPNIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSPNIC.Location = new System.Drawing.Point(962, 25);
            this.lblSPNIC.Name = "lblSPNIC";
            this.lblSPNIC.Size = new System.Drawing.Size(90, 20);
            this.lblSPNIC.TabIndex = 40;
            this.lblSPNIC.Text = "000000000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(798, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Sales Person NIC:";
            // 
            // ViewOrderSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 501);
            this.Controls.Add(this.lblSPNIC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "ViewOrderSP";
            this.Text = "ViewOrderSP";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearchOID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchOID;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.Button btnSearchCID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchCID;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Label lblSPNIC;
        private System.Windows.Forms.Label label4;
    }
}