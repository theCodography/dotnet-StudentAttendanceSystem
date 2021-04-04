
namespace AdminAttendanceSystem
{
    partial class AddStudentToClass
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
            this.tbClass = new System.Windows.Forms.TextBox();
            this.dvStudentNoClass = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvStudentNoClass)).BeginInit();
            this.SuspendLayout();
            // 
            // tbClass
            // 
            this.tbClass.Enabled = false;
            this.tbClass.Location = new System.Drawing.Point(12, 82);
            this.tbClass.Name = "tbClass";
            this.tbClass.Size = new System.Drawing.Size(121, 20);
            this.tbClass.TabIndex = 0;
            // 
            // dvStudentNoClass
            // 
            this.dvStudentNoClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvStudentNoClass.Location = new System.Drawing.Point(177, 82);
            this.dvStudentNoClass.Name = "dvStudentNoClass";
            this.dvStudentNoClass.Size = new System.Drawing.Size(435, 273);
            this.dvStudentNoClass.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(13, 134);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 37);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add Student";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AddStudentToClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 385);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dvStudentNoClass);
            this.Controls.Add(this.tbClass);
            this.Name = "AddStudentToClass";
            this.Text = "AddStudentToClass";
            this.Load += new System.EventHandler(this.AddStudentToClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvStudentNoClass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbClass;
        private System.Windows.Forms.DataGridView dvStudentNoClass;
        private System.Windows.Forms.Button btnAdd;
    }
}