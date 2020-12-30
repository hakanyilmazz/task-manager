
namespace PresentationLayer.Forms
{
    partial class UpdateTaskStatuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateTaskStatuForm));
            this.grpBoxTaskStatuDetail = new System.Windows.Forms.GroupBox();
            this.btnUpdateTaskStatu = new MetroFramework.Controls.MetroButton();
            this.txtBoxTaskStatuName = new MetroFramework.Controls.MetroTextBox();
            this.lblNewTaskStatuName = new MetroFramework.Controls.MetroLabel();
            this.grpBoxTaskStatuDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxTaskStatuDetail
            // 
            this.grpBoxTaskStatuDetail.Controls.Add(this.btnUpdateTaskStatu);
            this.grpBoxTaskStatuDetail.Controls.Add(this.txtBoxTaskStatuName);
            this.grpBoxTaskStatuDetail.Controls.Add(this.lblNewTaskStatuName);
            this.grpBoxTaskStatuDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpBoxTaskStatuDetail.Location = new System.Drawing.Point(19, 33);
            this.grpBoxTaskStatuDetail.Name = "grpBoxTaskStatuDetail";
            this.grpBoxTaskStatuDetail.Size = new System.Drawing.Size(251, 132);
            this.grpBoxTaskStatuDetail.TabIndex = 2;
            this.grpBoxTaskStatuDetail.TabStop = false;
            this.grpBoxTaskStatuDetail.Text = "Enter New Task Statu";
            // 
            // btnUpdateTaskStatu
            // 
            this.btnUpdateTaskStatu.Location = new System.Drawing.Point(132, 95);
            this.btnUpdateTaskStatu.Name = "btnUpdateTaskStatu";
            this.btnUpdateTaskStatu.Size = new System.Drawing.Size(112, 23);
            this.btnUpdateTaskStatu.TabIndex = 2;
            this.btnUpdateTaskStatu.Text = "Update Task Statu";
            this.btnUpdateTaskStatu.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnUpdateTaskStatu.Click += new System.EventHandler(this.btnUpdateTaskStatu_Click);
            // 
            // txtBoxTaskStatuName
            // 
            this.txtBoxTaskStatuName.Location = new System.Drawing.Point(6, 57);
            this.txtBoxTaskStatuName.Name = "txtBoxTaskStatuName";
            this.txtBoxTaskStatuName.Size = new System.Drawing.Size(238, 23);
            this.txtBoxTaskStatuName.TabIndex = 1;
            // 
            // lblNewTaskStatuName
            // 
            this.lblNewTaskStatuName.AutoSize = true;
            this.lblNewTaskStatuName.Location = new System.Drawing.Point(6, 35);
            this.lblNewTaskStatuName.Name = "lblNewTaskStatuName";
            this.lblNewTaskStatuName.Size = new System.Drawing.Size(138, 19);
            this.lblNewTaskStatuName.TabIndex = 0;
            this.lblNewTaskStatuName.Text = "New Task Statu Name:";
            // 
            // UpdateTaskStatuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(293, 184);
            this.Controls.Add(this.grpBoxTaskStatuDetail);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Movable = false;
            this.Name = "UpdateTaskStatuForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "Update Task Statu";
            this.grpBoxTaskStatuDetail.ResumeLayout(false);
            this.grpBoxTaskStatuDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxTaskStatuDetail;
        private MetroFramework.Controls.MetroButton btnUpdateTaskStatu;
        private MetroFramework.Controls.MetroTextBox txtBoxTaskStatuName;
        private MetroFramework.Controls.MetroLabel lblNewTaskStatuName;
    }
}