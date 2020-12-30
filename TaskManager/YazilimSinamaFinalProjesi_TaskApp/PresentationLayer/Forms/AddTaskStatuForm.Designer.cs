
namespace PresentationLayer.Forms
{
    partial class AddTaskStatuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTaskStatuForm));
            this.grpBoxTaskStatuDetail = new System.Windows.Forms.GroupBox();
            this.btnCreateTaskStatu = new MetroFramework.Controls.MetroButton();
            this.txtBoxTaskStatuName = new MetroFramework.Controls.MetroTextBox();
            this.lblTaskStatuName = new MetroFramework.Controls.MetroLabel();
            this.grpBoxTaskStatuDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxTaskStatuDetail
            // 
            this.grpBoxTaskStatuDetail.Controls.Add(this.btnCreateTaskStatu);
            this.grpBoxTaskStatuDetail.Controls.Add(this.txtBoxTaskStatuName);
            this.grpBoxTaskStatuDetail.Controls.Add(this.lblTaskStatuName);
            this.grpBoxTaskStatuDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpBoxTaskStatuDetail.Location = new System.Drawing.Point(23, 37);
            this.grpBoxTaskStatuDetail.Name = "grpBoxTaskStatuDetail";
            this.grpBoxTaskStatuDetail.Size = new System.Drawing.Size(251, 132);
            this.grpBoxTaskStatuDetail.TabIndex = 1;
            this.grpBoxTaskStatuDetail.TabStop = false;
            this.grpBoxTaskStatuDetail.Text = "Enter A Task Statu";
            // 
            // btnCreateTaskStatu
            // 
            this.btnCreateTaskStatu.Location = new System.Drawing.Point(132, 95);
            this.btnCreateTaskStatu.Name = "btnCreateTaskStatu";
            this.btnCreateTaskStatu.Size = new System.Drawing.Size(112, 23);
            this.btnCreateTaskStatu.TabIndex = 2;
            this.btnCreateTaskStatu.Text = "Create Task Statu";
            this.btnCreateTaskStatu.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnCreateTaskStatu.Click += new System.EventHandler(this.btnCreateTaskStatu_Click);
            // 
            // txtBoxTaskStatuName
            // 
            this.txtBoxTaskStatuName.Location = new System.Drawing.Point(6, 57);
            this.txtBoxTaskStatuName.Name = "txtBoxTaskStatuName";
            this.txtBoxTaskStatuName.Size = new System.Drawing.Size(238, 23);
            this.txtBoxTaskStatuName.TabIndex = 1;
            // 
            // lblTaskStatuName
            // 
            this.lblTaskStatuName.AutoSize = true;
            this.lblTaskStatuName.Location = new System.Drawing.Point(6, 35);
            this.lblTaskStatuName.Name = "lblTaskStatuName";
            this.lblTaskStatuName.Size = new System.Drawing.Size(108, 19);
            this.lblTaskStatuName.TabIndex = 0;
            this.lblTaskStatuName.Text = "Task Statu Name:";
            // 
            // AddTaskStatuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(301, 192);
            this.Controls.Add(this.grpBoxTaskStatuDetail);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Movable = false;
            this.Name = "AddTaskStatuForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "Add Task Statu";
            this.grpBoxTaskStatuDetail.ResumeLayout(false);
            this.grpBoxTaskStatuDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxTaskStatuDetail;
        private MetroFramework.Controls.MetroButton btnCreateTaskStatu;
        private MetroFramework.Controls.MetroTextBox txtBoxTaskStatuName;
        private MetroFramework.Controls.MetroLabel lblTaskStatuName;
    }
}