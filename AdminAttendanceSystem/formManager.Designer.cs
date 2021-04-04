
namespace AdminAttendanceSystem
{
    partial class formManager
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
            this.btnCreateClass = new System.Windows.Forms.Button();
            this.dvClass = new System.Windows.Forms.DataGridView();
            this.dvStudent = new System.Windows.Forms.DataGridView();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpClass = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dvAccount = new System.Windows.Forms.DataGridView();
            this.cbbRole = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvStudent)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpClass.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(531, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Manager System";
            // 
            // btnCreateClass
            // 
            this.btnCreateClass.Location = new System.Drawing.Point(6, 20);
            this.btnCreateClass.Name = "btnCreateClass";
            this.btnCreateClass.Size = new System.Drawing.Size(94, 37);
            this.btnCreateClass.TabIndex = 1;
            this.btnCreateClass.Text = "Create Class";
            this.btnCreateClass.UseVisualStyleBackColor = true;
            this.btnCreateClass.Click += new System.EventHandler(this.btnCreateClass_Click);
            // 
            // dvClass
            // 
            this.dvClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvClass.Location = new System.Drawing.Point(6, 81);
            this.dvClass.Name = "dvClass";
            this.dvClass.Size = new System.Drawing.Size(351, 273);
            this.dvClass.TabIndex = 4;
            this.dvClass.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvClass_CellContentClick);
            // 
            // dvStudent
            // 
            this.dvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvStudent.Location = new System.Drawing.Point(373, 81);
            this.dvStudent.Name = "dvStudent";
            this.dvStudent.Size = new System.Drawing.Size(351, 273);
            this.dvStudent.TabIndex = 5;
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Location = new System.Drawing.Point(6, 15);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(94, 37);
            this.btnCreateAccount.TabIndex = 6;
            this.btnCreateAccount.Text = "Create Account";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpClass);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(739, 403);
            this.tabControl1.TabIndex = 7;
            // 
            // tpClass
            // 
            this.tpClass.Controls.Add(this.dvClass);
            this.tpClass.Controls.Add(this.dvStudent);
            this.tpClass.Controls.Add(this.btnCreateClass);
            this.tpClass.Location = new System.Drawing.Point(4, 22);
            this.tpClass.Name = "tpClass";
            this.tpClass.Padding = new System.Windows.Forms.Padding(3);
            this.tpClass.Size = new System.Drawing.Size(731, 377);
            this.tpClass.TabIndex = 0;
            this.tpClass.Text = "Class";
            this.tpClass.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbbRole);
            this.tabPage2.Controls.Add(this.dvAccount);
            this.tabPage2.Controls.Add(this.btnCreateAccount);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(731, 377);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Account";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dvAccount
            // 
            this.dvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvAccount.Location = new System.Drawing.Point(6, 70);
            this.dvAccount.Name = "dvAccount";
            this.dvAccount.Size = new System.Drawing.Size(370, 301);
            this.dvAccount.TabIndex = 7;
            // 
            // cbbRole
            // 
            this.cbbRole.FormattingEnabled = true;
            this.cbbRole.Location = new System.Drawing.Point(108, 30);
            this.cbbRole.Name = "cbbRole";
            this.cbbRole.Size = new System.Drawing.Size(268, 21);
            this.cbbRole.TabIndex = 8;
            this.cbbRole.SelectedIndexChanged += new System.EventHandler(this.cbbRole_SelectedIndexChanged);
            // 
            // formManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 478);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "formManager";
            this.Text = "formManager";
            this.Load += new System.EventHandler(this.formManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvStudent)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpClass.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateClass;
        private System.Windows.Forms.DataGridView dvClass;
        private System.Windows.Forms.DataGridView dvStudent;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpClass;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dvAccount;
        private System.Windows.Forms.ComboBox cbbRole;
    }
}