
namespace Sample0603 {
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
            this.btPush = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dmas = new System.Windows.Forms.TextBox();
            this.Sum1 = new System.Windows.Forms.NumericUpDown();
            this.Sum2 = new System.Windows.Forms.NumericUpDown();
            this.ans = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Sum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ans)).BeginInit();
            this.SuspendLayout();
            // 
            // btPush
            // 
            this.btPush.BackColor = System.Drawing.Color.Aqua;
            this.btPush.Font = new System.Drawing.Font("HGS行書体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btPush.Location = new System.Drawing.Point(198, 133);
            this.btPush.Name = "btPush";
            this.btPush.Size = new System.Drawing.Size(227, 112);
            this.btPush.TabIndex = 0;
            this.btPush.Text = "計算";
            this.btPush.UseVisualStyleBackColor = false;
            this.btPush.Click += new System.EventHandler(this.btPush_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(382, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "=";
            // 
            // dmas
            // 
            this.dmas.Font = new System.Drawing.Font("MV Boli", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dmas.Location = new System.Drawing.Point(171, 23);
            this.dmas.Multiline = true;
            this.dmas.Name = "dmas";
            this.dmas.Size = new System.Drawing.Size(39, 37);
            this.dmas.TabIndex = 1;
            this.dmas.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Sum1
            // 
            this.Sum1.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Sum1.Location = new System.Drawing.Point(22, 25);
            this.Sum1.Name = "Sum1";
            this.Sum1.Size = new System.Drawing.Size(120, 39);
            this.Sum1.TabIndex = 3;
            // 
            // Sum2
            // 
            this.Sum2.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Sum2.Location = new System.Drawing.Point(241, 25);
            this.Sum2.Name = "Sum2";
            this.Sum2.Size = new System.Drawing.Size(120, 39);
            this.Sum2.TabIndex = 3;
            // 
            // ans
            // 
            this.ans.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ans.Location = new System.Drawing.Point(449, 27);
            this.ans.Name = "ans";
            this.ans.Size = new System.Drawing.Size(153, 39);
            this.ans.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 266);
            this.Controls.Add(this.ans);
            this.Controls.Add(this.Sum2);
            this.Controls.Add(this.Sum1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dmas);
            this.Controls.Add(this.btPush);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Sum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btPush;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dmas;
        private System.Windows.Forms.NumericUpDown Sum1;
        private System.Windows.Forms.NumericUpDown Sum2;
        private System.Windows.Forms.NumericUpDown ans;
    }
}

