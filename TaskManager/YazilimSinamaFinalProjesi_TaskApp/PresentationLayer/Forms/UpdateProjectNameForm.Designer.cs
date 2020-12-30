
namespace PresentationLayer.Forms
{
    partial class UpdateProjectNameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateProjectNameForm));
            this.grpBoxProjectDetail = new System.Windows.Forms.GroupBox();
            this.btnUpdateProject = new MetroFramework.Controls.MetroButton();
            this.txtBoxProjectName = new MetroFramework.Controls.MetroTextBox();
            this.lblProjectName = new MetroFramework.Controls.MetroLabel();
            this.grpBoxProjectDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxProjectDetail
            // 
            this.grpBoxProjectDetail.Controls.Add(this.btnUpdateProject);
            this.grpBoxProjectDetail.Controls.Add(this.txtBoxProjectName);
            this.grpBoxProjectDetail.Controls.Add(this.lblProjectName);
            this.grpBoxProjectDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpBoxProjectDetail.Location = new System.Drawing.Point(21, 38);
            this.grpBoxProjectDetail.Name = "grpBoxProjectDetail";
            this.grpBoxProjectDetail.Size = new System.Drawing.Size(251, 132);
            this.grpBoxProjectDetail.TabIndex = 1;
            this.grpBoxProjectDetail.TabStop = false;
            this.grpBoxProjectDetail.Text = "Enter New Project Name";
            // 
            // btnUpdateProject
            // 
            this.btnUpdateProject.Location = new System.Drawing.Point(145, 95);
            this.btnUpdateProject.Name = "btnUpdateProject";
            this.btnUpdateProject.Size = new System.Drawing.Size(99, 23);
            this.btnUpdateProject.TabIndex = 2;
            this.btnUpdateProject.Text = "Update Project";
            this.btnUpdateProject.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnUpdateProject.Click += new System.EventHandler(this.btnUpdateProject_Click);
            // 
            // txtBoxProjectName
            // 
            this.txtBoxProjectName.Location = new System.Drawing.Point(6, 57);
            this.txtBoxProjectName.Name = "txtBoxProjectName";
            this.txtBoxProjectName.Size = new System.Drawing.Size(238, 23);
            this.txtBoxProjectName.TabIndex = 1;
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(6, 35);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(123, 19);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "New Project Name:";
            // 
            // UpdateProjectNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(293, 186);
            this.Controls.Add(this.grpBoxProjectDetail);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Movable = false;
            this.Name = "UpdateProjectNameForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "Update Project Name";
            this.grpBoxProjectDetail.ResumeLayout(false);
            this.grpBoxProjectDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxProjectDetail;
        private MetroFramework.Controls.MetroButton btnUpdateProject;
        private MetroFramework.Controls.MetroTextBox txtBoxProjectName;
        private MetroFramework.Controls.MetroLabel lblProjectName;
    }
}