using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Forms
{
    public partial class AddProjectForm : MetroFramework.Forms.MetroForm
    {
        public AddProjectForm()
        {
            InitializeComponent();
        }

        // Burdaki değere göre main form'da ekran yenileme işlemi yapılacak.
        public bool doRefresh { get; set; }
        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            // Eğer text alanı boş gelirse ekleme işlemi yapılmayacak.
            if (String.IsNullOrEmpty(txtBoxProjectName.Text))
                MessageBox.Show("Please enter a project name!", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                ProjectBLL projectBLL = new ProjectBLL();
                projectBLL.AddProject(txtBoxProjectName.Text);

                doRefresh = true;
                this.Close();
            }
        }
    }
}
