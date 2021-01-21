namespace RedisTest
{
    partial class FrmRedis
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
            this.btnSaveData = new System.Windows.Forms.Button();
            this.tbxKeyData = new System.Windows.Forms.TextBox();
            this.tbxValueData = new System.Windows.Forms.TextBox();
            this.btnFetchData = new System.Windows.Forms.Button();
            this.btnDeleteData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSaveData
            // 
            this.btnSaveData.Location = new System.Drawing.Point(417, 214);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(117, 33);
            this.btnSaveData.TabIndex = 0;
            this.btnSaveData.Text = "Kaydet";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // tbxKeyData
            // 
            this.tbxKeyData.Location = new System.Drawing.Point(109, 15);
            this.tbxKeyData.Name = "tbxKeyData";
            this.tbxKeyData.Size = new System.Drawing.Size(287, 22);
            this.tbxKeyData.TabIndex = 1;
            // 
            // tbxValueData
            // 
            this.tbxValueData.Location = new System.Drawing.Point(109, 43);
            this.tbxValueData.Multiline = true;
            this.tbxValueData.Name = "tbxValueData";
            this.tbxValueData.Size = new System.Drawing.Size(287, 243);
            this.tbxValueData.TabIndex = 2;
            // 
            // btnFetchData
            // 
            this.btnFetchData.Location = new System.Drawing.Point(417, 43);
            this.btnFetchData.Name = "btnFetchData";
            this.btnFetchData.Size = new System.Drawing.Size(117, 34);
            this.btnFetchData.TabIndex = 3;
            this.btnFetchData.Text = "Getir";
            this.btnFetchData.UseVisualStyleBackColor = true;
            this.btnFetchData.Click += new System.EventHandler(this.btnFetchData_Click);
            // 
            // btnDeleteData
            // 
            this.btnDeleteData.Location = new System.Drawing.Point(417, 253);
            this.btnDeleteData.Name = "btnDeleteData";
            this.btnDeleteData.Size = new System.Drawing.Size(117, 33);
            this.btnDeleteData.TabIndex = 4;
            this.btnDeleteData.Text = "Sil";
            this.btnDeleteData.UseVisualStyleBackColor = true;
            this.btnDeleteData.Click += new System.EventHandler(this.btnDeleteData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Anahtar :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Değer :";
            // 
            // FrmRedis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 308);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteData);
            this.Controls.Add(this.btnFetchData);
            this.Controls.Add(this.tbxValueData);
            this.Controls.Add(this.tbxKeyData);
            this.Controls.Add(this.btnSaveData);
            this.Name = "FrmRedis";
            this.Text = "Redis Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.TextBox tbxKeyData;
        private System.Windows.Forms.TextBox tbxValueData;
        private System.Windows.Forms.Button btnFetchData;
        private System.Windows.Forms.Button btnDeleteData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

