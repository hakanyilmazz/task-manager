using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Forms
{
    public partial class AddTaskStatuForm : MetroFramework.Forms.MetroForm
    {
        // Hangi projede olduğumuzu bilmek için gereklidir.
        private int projectID;
        public AddTaskStatuForm(int projectID)
        {
            InitializeComponent();
            this.projectID = projectID;
        }

        // Burdaki değere göre main form'da ekran yenileme işlemi yapılacak.
        public bool doRefresh { get; set; }
        private void btnCreateTaskStatu_Click(object sender, EventArgs e)
        {
            // Eğer text alanı boş gelirse ekleme işlemi yapılmayacak.
            if (String.IsNullOrEmpty(txtBoxTaskStatuName.Text))
                MessageBox.Show("Please enter a task statu name!", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                TaskStatuBLL taskStatuBll = new TaskStatuBLL();
                taskStatuBll.AddTaskStatu(projectID, txtBoxTaskStatuName.Text);

                doRefresh = true;
                this.Close();
            }
        }
    }
}
