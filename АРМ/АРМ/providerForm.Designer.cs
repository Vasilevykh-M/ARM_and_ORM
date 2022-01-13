
namespace АРМ
{
    partial class providerForm
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
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.lbBank = new System.Windows.Forms.ListBox();
            this.btbChange = new System.Windows.Forms.Button();
            this.btnProv = new System.Windows.Forms.Button();
            this.btnBank = new System.Windows.Forms.Button();
            this.btDefault = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(13, 13);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersWidth = 51;
            this.dgv1.RowTemplate.Height = 29;
            this.dgv1.Size = new System.Drawing.Size(550, 425);
            this.dgv1.TabIndex = 0;
            this.dgv1.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv1_RowValidating);
            this.dgv1.SelectionChanged += new System.EventHandler(this.dgv1_SelectionChanged);
            this.dgv1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgv1_UserDeletingRow);
            this.dgv1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgv1_PreviewKeyDown);
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(608, 12);
            this.dgv2.Name = "dgv2";
            this.dgv2.RowHeadersWidth = 51;
            this.dgv2.RowTemplate.Height = 29;
            this.dgv2.Size = new System.Drawing.Size(536, 254);
            this.dgv2.TabIndex = 1;
            this.dgv2.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv2_RowValidating);
            this.dgv2.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgv2_UserDeletingRow);
            this.dgv2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgv2_PreviewKeyDown);
            // 
            // lbBank
            // 
            this.lbBank.FormattingEnabled = true;
            this.lbBank.ItemHeight = 20;
            this.lbBank.Location = new System.Drawing.Point(608, 318);
            this.lbBank.Name = "lbBank";
            this.lbBank.Size = new System.Drawing.Size(536, 44);
            this.lbBank.TabIndex = 2;
            // 
            // btbChange
            // 
            this.btbChange.Location = new System.Drawing.Point(608, 399);
            this.btbChange.Name = "btbChange";
            this.btbChange.Size = new System.Drawing.Size(536, 29);
            this.btbChange.TabIndex = 3;
            this.btbChange.Text = "Сменить банк у поставщика";
            this.btbChange.UseVisualStyleBackColor = true;
            this.btbChange.Click += new System.EventHandler(this.btbChange_Click);
            // 
            // btnProv
            // 
            this.btnProv.Location = new System.Drawing.Point(569, 364);
            this.btnProv.Name = "btnProv";
            this.btnProv.Size = new System.Drawing.Size(180, 29);
            this.btnProv.TabIndex = 4;
            this.btnProv.Text = "Поставщики без банка";
            this.btnProv.UseVisualStyleBackColor = true;
            this.btnProv.Click += new System.EventHandler(this.btnProv_Click);
            // 
            // btnBank
            // 
            this.btnBank.Location = new System.Drawing.Point(755, 364);
            this.btnBank.Name = "btnBank";
            this.btnBank.Size = new System.Drawing.Size(205, 29);
            this.btnBank.TabIndex = 5;
            this.btnBank.Text = "Банк без поставщиков";
            this.btnBank.UseVisualStyleBackColor = true;
            this.btnBank.Click += new System.EventHandler(this.btnBank_Click);
            // 
            // btDefault
            // 
            this.btDefault.Location = new System.Drawing.Point(966, 364);
            this.btDefault.Name = "btDefault";
            this.btDefault.Size = new System.Drawing.Size(189, 29);
            this.btDefault.TabIndex = 6;
            this.btDefault.Text = "Стоковое отображение";
            this.btDefault.UseVisualStyleBackColor = true;
            this.btDefault.Click += new System.EventHandler(this.btDefault_Click);
            // 
            // providerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 448);
            this.Controls.Add(this.btDefault);
            this.Controls.Add(this.btnBank);
            this.Controls.Add(this.btnProv);
            this.Controls.Add(this.btbChange);
            this.Controls.Add(this.lbBank);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.dgv1);
            this.Name = "providerForm";
            this.Text = "providerForm";
            this.Load += new System.EventHandler(this.providerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.ListBox lbBank;
        private System.Windows.Forms.Button btbChange;
        private System.Windows.Forms.Button btnProv;
        private System.Windows.Forms.Button btnBank;
        private System.Windows.Forms.Button btDefault;
    }
}