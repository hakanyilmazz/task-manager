using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Forms
{
    public partial class UpdateTaskStatuForm : MetroFramework.Forms.MetroForm
    {
        // Hangi görev durumunda olduğumuzu bilmek için gereklidir.
        private int taskStatuID;
        public UpdateTaskStatuForm(int taskStatuID)
        {
            InitializeComponent();
            this.taskStatuID = taskStatuID;
        }

        // Burdaki değere göre main form'da ekran yenileme işlemi yapılacak.
        public bool doRefresh { get; set; }
        private void btnUpdateTaskStatu_Click(object sender, EventArgs e)
        {
            // Eğer text alanı boş gelirse ekleme işlemi yapılmayacak.
            if (String.IsNullOrEmpty(txtBoxTaskStatuName.Text))
                MessageBox.Show("Please enter new task statu name or just close the form!", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                TaskStatuBLL taskStatuBll = new TaskStatuBLL();
                taskStatuBll.UpdateTaskStatu(taskStatuID, txtBoxTaskStatuName.Text);

                doRefresh = true;
                this.Close();
            }
        }
    }
}
