namespace My.Tools.InstallDB
{
    partial class FrmLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDBName = new System.Windows.Forms.ComboBox();
            this.cboDBAudit = new System.Windows.Forms.ComboBox();
            this.txtDBUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDBPassWord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDBServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpgrade = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDBName);
            this.groupBox1.Controls.Add(this.cboDBAudit);
            this.groupBox1.Controls.Add(this.txtDBUser);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtDBPassWord);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDBServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 160);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库服务器";
            // 
            // txtDBName
            // 
            this.txtDBName.FormattingEnabled = true;
            this.txtDBName.Items.AddRange(new object[] {
            "SQL Server 身份验证",
            "Windows 身份验证"});
            this.txtDBName.Location = new System.Drawing.Point(116, 46);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(186, 20);
            this.txtDBName.TabIndex = 3;
            this.txtDBName.SelectedIndexChanged += new System.EventHandler(this.cboDBAudit_SelectedIndexChanged);
            // 
            // cboDBAudit
            // 
            this.cboDBAudit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDBAudit.FormattingEnabled = true;
            this.cboDBAudit.Items.AddRange(new object[] {
            "SQL Server 身份验证",
            "Windows 身份验证"});
            this.cboDBAudit.Location = new System.Drawing.Point(116, 74);
            this.cboDBAudit.Name = "cboDBAudit";
            this.cboDBAudit.Size = new System.Drawing.Size(186, 20);
            this.cboDBAudit.TabIndex = 3;
            this.cboDBAudit.SelectedIndexChanged += new System.EventHandler(this.cboDBAudit_SelectedIndexChanged);
            // 
            // txtDBUser
            // 
            this.txtDBUser.Location = new System.Drawing.Point(116, 100);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(186, 21);
            this.txtDBUser.TabIndex = 4;
            this.txtDBUser.Text = "sa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "登录名：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "目标数据库：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDBPassWord
            // 
            this.txtDBPassWord.Location = new System.Drawing.Point(116, 127);
            this.txtDBPassWord.Name = "txtDBPassWord";
            this.txtDBPassWord.PasswordChar = '*';
            this.txtDBPassWord.Size = new System.Drawing.Size(186, 21);
            this.txtDBPassWord.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "密码：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "身份验证：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDBServer
            // 
            this.txtDBServer.Location = new System.Drawing.Point(116, 18);
            this.txtDBServer.Name = "txtDBServer";
            this.txtDBServer.Size = new System.Drawing.Size(186, 21);
            this.txtDBServer.TabIndex = 1;
            this.txtDBServer.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnUpgrade
            // 
            this.btnUpgrade.Location = new System.Drawing.Point(47, 191);
            this.btnUpgrade.Name = "btnUpgrade";
            this.btnUpgrade.Size = new System.Drawing.Size(86, 30);
            this.btnUpgrade.TabIndex = 4;
            this.btnUpgrade.Text = "确定";
            this.btnUpgrade.UseVisualStyleBackColor = true;
            this.btnUpgrade.Click += new System.EventHandler(this.btnUpgrade_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(188, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 233);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUpgrade);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SqlServer数据库安装工具 v2.1.2012.03.20";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboDBAudit;
        private System.Windows.Forms.TextBox txtDBUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDBPassWord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDBServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpgrade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox txtDBName;

    }
}

