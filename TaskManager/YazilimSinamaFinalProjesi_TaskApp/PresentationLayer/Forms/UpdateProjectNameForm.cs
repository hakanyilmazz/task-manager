using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Forms
{
    public partial class UpdateProjectNameForm : MetroFramework.Forms.MetroForm
    {
        // Hangi projede olduğumuzu bilmek için gereklidir.
        private int projectID;
        public UpdateProjectNameForm(int projectID)
        {
            InitializeComponent();
            this.projectID = projectID;
        }

        // Burdaki değere göre main form'da ekran yenileme işlemi yapılacak.
        public bool doRefresh { get; set; }
        private void btnUpdateProject_Click(object sender, EventArgs e)
        {
            // Eğer text alanı boş gelirse ekleme işlemi yapılmayacak.
            if (String.IsNullOrEmpty(txtBoxProjectName.Text))
                MessageBox.Show("Please enter new project name or just close the form!", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                ProjectBLL projectBLL = new ProjectBLL();
                projectBLL.UpdateProjectName(projectID, txtBoxProjectName.Text);

                doRefresh = true;
                this.Close();
            }
        }
    }
}
