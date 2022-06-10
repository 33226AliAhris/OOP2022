
namespace NumberGame {
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
            this.nudNum = new System.Windows.Forms.NumericUpDown();
            this.btEnter = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.tbAns = new System.Windows.Forms.TextBox();
            this.test = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.test)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(174, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "1～50の中から数字を一つ選択";
            // 
            // nudNum
            // 
            this.nudNum.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nudNum.Location = new System.Drawing.Point(99, 146);
            this.nudNum.Name = "nudNum";
            this.nudNum.Size = new System.Drawing.Size(190, 71);
            this.nudNum.TabIndex = 1;
            // 
            // btEnter
            // 
            this.btEnter.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btEnter.Location = new System.Drawing.Point(365, 146);
            this.btEnter.Name = "btEnter";
            this.btEnter.Size = new System.Drawing.Size(176, 71);
            this.btEnter.TabIndex = 2;
            this.btEnter.Text = "入力";
            this.btEnter.UseVisualStyleBackColor = true;
            this.btEnter.Click += new System.EventHandler(this.btEnter_Click);
            // 
            // btReset
            // 
            this.btReset.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btReset.Location = new System.Drawing.Point(575, 146);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(176, 71);
            this.btReset.TabIndex = 2;
            this.btReset.Text = "リセット";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btEnter_Click);
            // 
            // tbAns
            // 
            this.tbAns.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbAns.ForeColor = System.Drawing.Color.Black;
            this.tbAns.Location = new System.Drawing.Point(402, 251);
            this.tbAns.Name = "tbAns";
            this.tbAns.Size = new System.Drawing.Size(107, 44);
            this.tbAns.TabIndex = 3;
            this.tbAns.Text = "正解！";
            // 
            // test
            // 
            this.test.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.test.Location = new System.Drawing.Point(575, 251);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(190, 71);
            this.test.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(845, 450);
            this.Controls.Add(this.tbAns);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.btEnter);
            this.Controls.Add(this.test);
            this.Controls.Add(this.nudNum);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "数当てゲーム";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.test)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudNum;
        private System.Windows.Forms.Button btEnter;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.TextBox tbAns;
        private System.Windows.Forms.NumericUpDown test;
    }
}

