
namespace WeatherApp {
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
            this.tbWeatherInfo = new System.Windows.Forms.TextBox();
            this.btWeatherGet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPref = new System.Windows.Forms.ComboBox();
            this.cbRegion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbWeatherInfo
            // 
            this.tbWeatherInfo.Location = new System.Drawing.Point(56, 231);
            this.tbWeatherInfo.Multiline = true;
            this.tbWeatherInfo.Name = "tbWeatherInfo";
            this.tbWeatherInfo.Size = new System.Drawing.Size(742, 216);
            this.tbWeatherInfo.TabIndex = 0;
            // 
            // btWeatherGet
            // 
            this.btWeatherGet.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btWeatherGet.Location = new System.Drawing.Point(647, 176);
            this.btWeatherGet.Name = "btWeatherGet";
            this.btWeatherGet.Size = new System.Drawing.Size(141, 40);
            this.btWeatherGet.TabIndex = 1;
            this.btWeatherGet.Text = "取得";
            this.btWeatherGet.UseVisualStyleBackColor = true;
            this.btWeatherGet.Click += new System.EventHandler(this.btWeatherGet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(6, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 132);
            this.label1.TabIndex = 2;
            this.label1.Text = "天\r\n気\r\n概\r\n況";
            // 
            // cbPref
            // 
            this.cbPref.FormattingEnabled = true;
            this.cbPref.Items.AddRange(new object[] {
            "関東"});
            this.cbPref.Location = new System.Drawing.Point(95, 176);
            this.cbPref.Name = "cbPref";
            this.cbPref.Size = new System.Drawing.Size(191, 20);
            this.cbPref.TabIndex = 3;
            // 
            // cbRegion
            // 
            this.cbRegion.FormattingEnabled = true;
            this.cbRegion.Items.AddRange(new object[] {
            "北海道地方",
            "東北地方",
            "関東甲信地方",
            "東海地方",
            "北陸地方",
            "近畿地方",
            "中国地方（山口県を除く）",
            "四国地方",
            "九州北部地方（山口県を含む）",
            "九州南部・奄美地方",
            "沖縄地方"});
            this.cbRegion.Location = new System.Drawing.Point(95, 100);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(191, 20);
            this.cbRegion.TabIndex = 3;
            this.cbRegion.SelectedIndexChanged += new System.EventHandler(this.cbRegion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(7, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "地方";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(7, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 27);
            this.label4.TabIndex = 4;
            this.label4.Text = "地域";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbRegion);
            this.Controls.Add(this.cbPref);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btWeatherGet);
            this.Controls.Add(this.tbWeatherInfo);
            this.Name = "Form1";
            this.Text = "天気予報";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbWeatherInfo;
        private System.Windows.Forms.Button btWeatherGet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPref;
        private System.Windows.Forms.ComboBox cbRegion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

