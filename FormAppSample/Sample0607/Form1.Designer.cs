
namespace Sample0607 {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ndCalc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ndNum1 = new System.Windows.Forms.NumericUpDown();
            this.ndNum2 = new System.Windows.Forms.NumericUpDown();
            this.ndAns = new System.Windows.Forms.NumericUpDown();
            this.ndMod = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ndNum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndNum2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndAns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndMod)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(151, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "÷";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(360, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(348, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 37);
            this.label3.TabIndex = 1;
            this.label3.Text = "=";
            // 
            // ndCalc
            // 
            this.ndCalc.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ndCalc.Location = new System.Drawing.Point(402, 101);
            this.ndCalc.Name = "ndCalc";
            this.ndCalc.Size = new System.Drawing.Size(124, 51);
            this.ndCalc.TabIndex = 2;
            this.ndCalc.Text = "計算";
            this.ndCalc.UseVisualStyleBackColor = true;
            this.ndCalc.Click += new System.EventHandler(this.tbCalc_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(541, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 37);
            this.label4.TabIndex = 1;
            this.label4.Text = "あまり";
            // 
            // ndNum1
            // 
            this.ndNum1.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ndNum1.Location = new System.Drawing.Point(25, 26);
            this.ndNum1.Name = "ndNum1";
            this.ndNum1.Size = new System.Drawing.Size(120, 39);
            this.ndNum1.TabIndex = 3;
            // 
            // ndNum2
            // 
            this.ndNum2.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ndNum2.Location = new System.Drawing.Point(211, 26);
            this.ndNum2.Name = "ndNum2";
            this.ndNum2.Size = new System.Drawing.Size(120, 39);
            this.ndNum2.TabIndex = 3;
            // 
            // ndAns
            // 
            this.ndAns.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ndAns.Location = new System.Drawing.Point(402, 26);
            this.ndAns.Name = "ndAns";
            this.ndAns.Size = new System.Drawing.Size(120, 39);
            this.ndAns.TabIndex = 3;
            // 
            // ndMod
            // 
            this.ndMod.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ndMod.Location = new System.Drawing.Point(645, 25);
            this.ndMod.Name = "ndMod";
            this.ndMod.Size = new System.Drawing.Size(120, 39);
            this.ndMod.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(779, 371);
            this.Controls.Add(this.ndMod);
            this.Controls.Add(this.ndAns);
            this.Controls.Add(this.ndNum2);
            this.Controls.Add(this.ndNum1);
            this.Controls.Add(this.ndCalc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "割り算";
            ((System.ComponentModel.ISupportInitialize)(this.ndNum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndNum2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndAns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndMod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ndCalc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ndNum1;
        private System.Windows.Forms.NumericUpDown ndNum2;
        private System.Windows.Forms.NumericUpDown ndAns;
        private System.Windows.Forms.NumericUpDown ndMod;
    }
}

