
namespace АРМ
{
    partial class autentForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.userBD = new System.Windows.Forms.Button();
            this.providerBd = new System.Windows.Forms.Button();
            this.productBd = new System.Windows.Forms.Button();
            this.DelaysBd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(186, 78);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(125, 27);
            this.tbLogin.TabIndex = 0;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(186, 152);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(125, 27);
            this.tbPassword.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(186, 331);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(347, 29);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Выполнить";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Взаимодействие";
            // 
            // cbState
            // 
            this.cbState.FormattingEnabled = true;
            this.cbState.Items.AddRange(new object[] {
            "Войти(пользователь)",
            "Войти(гость)",
            "Зарегестрироваться"});
            this.cbState.Location = new System.Drawing.Point(186, 227);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(332, 28);
            this.cbState.TabIndex = 6;
            this.cbState.SelectedIndexChanged += new System.EventHandler(this.cbState_SelectedIndexChanged);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(186, 288);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(50, 20);
            this.lblState.TabIndex = 7;
            this.lblState.Text = "label4";
            // 
            // userBD
            // 
            this.userBD.Location = new System.Drawing.Point(13, 374);
            this.userBD.Name = "userBD";
            this.userBD.Size = new System.Drawing.Size(176, 29);
            this.userBD.TabIndex = 8;
            this.userBD.Text = "Пользователи АРМ";
            this.userBD.UseVisualStyleBackColor = true;
            this.userBD.Click += new System.EventHandler(this.userBD_Click);
            // 
            // providerBd
            // 
            this.providerBd.Location = new System.Drawing.Point(195, 374);
            this.providerBd.Name = "providerBd";
            this.providerBd.Size = new System.Drawing.Size(172, 29);
            this.providerBd.TabIndex = 9;
            this.providerBd.Text = "Поставщики/банки";
            this.providerBd.UseVisualStyleBackColor = true;
            this.providerBd.Click += new System.EventHandler(this.providerBd_Click);
            // 
            // productBd
            // 
            this.productBd.Location = new System.Drawing.Point(373, 374);
            this.productBd.Name = "productBd";
            this.productBd.Size = new System.Drawing.Size(160, 29);
            this.productBd.TabIndex = 10;
            this.productBd.Text = "Продукты";
            this.productBd.UseVisualStyleBackColor = true;
            this.productBd.Click += new System.EventHandler(this.productBd_Click);
            // 
            // DelaysBd
            // 
            this.DelaysBd.Location = new System.Drawing.Point(539, 374);
            this.DelaysBd.Name = "DelaysBd";
            this.DelaysBd.Size = new System.Drawing.Size(141, 29);
            this.DelaysBd.TabIndex = 11;
            this.DelaysBd.Text = "Поставки";
            this.DelaysBd.UseVisualStyleBackColor = true;
            this.DelaysBd.Click += new System.EventHandler(this.DelaysBd_Click);
            // 
            // autentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 422);
            this.Controls.Add(this.DelaysBd);
            this.Controls.Add(this.productBd);
            this.Controls.Add(this.providerBd);
            this.Controls.Add(this.userBD);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbLogin);
            this.Name = "autentForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.autentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button userBD;
        private System.Windows.Forms.Button providerBd;
        private System.Windows.Forms.Button productBd;
        private System.Windows.Forms.Button DelaysBd;
    }
}

