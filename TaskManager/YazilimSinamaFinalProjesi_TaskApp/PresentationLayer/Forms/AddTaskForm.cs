using BusinessLayer;
using Entities;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer.Forms
{
    public partial class AddTaskForm : MetroFramework.Forms.MetroForm
    {
        // Hangi görev durumu, proje ve görevde olduğumuzu bilmemiz gerekir.
        private int taskStatuID;
        private int projectID;
        private int taskID;
        private int predictTime;
        private string projectName = "";

        public AddTaskForm(int taskStatuID, int projectID, int taskID)
        {
            InitializeComponent();

            this.taskStatuID = taskStatuID;
            this.projectID = projectID;
            this.taskID = taskID;

            SetDateTimePickers();
            SetJobTrackingWorkToDos();
            SetJobTrackingStatus();
            SetJobTrackingWorkDetails();

            TaskBLL taskBll = new TaskBLL();
            predictTime = taskBll.GetPredictTime();

            ProjectBLL projectBll = new ProjectBLL();
            Project project = projectBll.GetProject(projectID);
            projectName = project.ProjectName;

            if (project != null)
                txtBoxProjectNoAndName.Text = project.ProjectID.ToString() + " / " + project.ProjectName;
            if (taskID != 0)
                LoadTextBoxesValues();
        }

        // Burdaki değere göre main form'da ekran yenileme işlemi yapılacak.
        public bool doRefresh { get; set; }
        private void btnSaveTask_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBoxTechnicalExpert.Text) && !String.IsNullOrEmpty(txtBoxActualTime.Text) &&
                    !String.IsNullOrEmpty(txtBoxWorkDetail.Text) && !String.IsNullOrEmpty(txtBoxNots.Text))
            {
                TaskBLL taskBll = new TaskBLL();

                try
                {
                    int actualTime = Convert.ToInt32(txtBoxActualTime.Text);

                    if (taskID == 0)
                    {
                        txtBoxDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
                        txtBoxCardNo.Text = "-";

                        taskBll.AddTask(projectID, taskStatuID, projectName, txtBoxTechnicalExpert.Text, predictTime,
                       actualTime, txtBoxWorkDetail.Text, txtBoxNots.Text, GetWorkListFromTextBoxes());
                    }
                    else
                    {
                        Task task = taskBll.GetTask(taskID);
                        txtBoxDate.Text = task.Date.ToString("dd/MM/yyyy");

                        taskBll.UpdateTask(taskID, projectID, txtBoxTechnicalExpert.Text, DateTime.Now, predictTime, Convert.ToInt32(txtBoxActualTime.Text),
                            txtBoxWorkDetail.Text, txtBoxNots.Text, GetWorkListFromTextBoxes());
                    }

                    doRefresh = true;
                    this.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Actual time must be number!", "Type Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Please fill the empty areas!", "Empty Area Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region İş Bilgilerini Arayüzden Toplama Kısmı
        private List<Work> GetWorkListFromTextBoxes()
        {
            List<Work> works = new List<Work>();
            bool[] jobIsEmptyInformations = GetJobEmptyInformation();

            for (int i = 1; i < jobIsEmptyInformations.Length; i++)
            {
                if (!jobIsEmptyInformations[i])
                {
                    DateTime confirmDate = dates[i - 1].Value >= DateTime.Today ? dates[i - 1].Value : DateTime.Today;

                    Work work = new Work
                    {
                        JobTrackingStatus = jobTrackingStatus[i - 1].Text,
                        JobTrackingDetail = jobTrackingWorkDetails[i - 1].Text,
                        JobTrackingWorkToDo = jobTrackingWorkToDos[i - 1].Text,
                        Date = confirmDate,
                    };

                    works.Add(work);
                }
            }

            return works;
        }

        // İş bölümünde boş text box var mı onu kontrol eder.
        public bool[] GetJobEmptyInformation()
        {
            bool[] controls = new bool[7];

            for (int i = 1; i < controls.Length; i++)
                if (String.IsNullOrEmpty(jobTrackingStatus[i - 1].Text) || String.IsNullOrEmpty(jobTrackingWorkDetails[i - 1].Text) ||
                    String.IsNullOrEmpty(jobTrackingWorkToDos[i - 1].Text))
                    controls[i] = true;

            return controls;
        }
        #endregion

        #region Görsel Nesneleri Değişkenlere Aktardığımız Kısım
        DateTimePicker[] dates;
        private void SetDateTimePickers()
        {
            dates = new DateTimePicker[]
            {
                dateTimePicker1,
                dateTimePicker2,
                dateTimePicker3,
                dateTimePicker4,
                dateTimePicker5,
                dateTimePicker6,
            };
        }

        MetroTextBox[] jobTrackingWorkToDos;
        private void SetJobTrackingWorkToDos()
        {
            jobTrackingWorkToDos = new MetroTextBox[]
            {
                txtBoxJobTrackingWorkToDo1,
                txtBoxJobTrackingWorkToDo2,
                txtBoxJobTrackingWorkToDo3,
                txtBoxJobTrackingWorkToDo4,
                txtBoxJobTrackingWorkToDo5,
                txtBoxJobTrackingWorkToDo6,
            };
        }

        MetroTextBox[] jobTrackingStatus;
        private void SetJobTrackingStatus()
        {
            jobTrackingStatus = new MetroTextBox[]
            {
                txtBoxJobTrackingStatu1,
                txtBoxJobTrackingStatu2,
                txtBoxJobTrackingStatu3,
                txtBoxJobTrackingStatu4,
                txtBoxJobTrackingStatu5,
                txtBoxJobTrackingStatu6,
            };
        }

        MetroTextBox[] jobTrackingWorkDetails;
        private void SetJobTrackingWorkDetails()
        {
            jobTrackingWorkDetails = new MetroTextBox[]
            {
                txtBoxJobTrackingWorkDetail1,
                txtBoxJobTrackingWorkDetail2,
                txtBoxJobTrackingWorkDetail3,
                txtBoxJobTrackingWorkDetail4,
                txtBoxJobTrackingWorkDetail5,
                txtBoxJobTrackingWorkDetail6,
            };
        }
        #endregion

        // Textbox'lara veritabanındaki değerleri yükler.
        private void LoadTextBoxesValues()
        {
            TaskBLL taskBll = new TaskBLL();
            Task task = taskBll.GetTask(taskID);

            if (task != null)
            {
                txtBoxDate.Text = task.Date.ToString("dd.MM.yyyy");
                txtBoxCardNo.Text = task.TaskID.ToString();
                txtBoxActualTime.Text = task.ActualTime.ToString();
                txtBoxTechnicalExpert.Text = task.TechnicalExpert.ToString();
                txtBoxWorkDetail.Text = task.WorkDetail.ToString();
                txtBoxNots.Text = task.Nots.ToString();
                txtBoxPredictTime.Text = predictTime.ToString();

                WorkBLL workBll = new WorkBLL();
                List<Work> works = workBll.GetTaskWorks(task.TaskID);

                for (int i = 0; i < works.Count; i++)
                {
                    dates[i].Value = works[i].Date;
                    jobTrackingWorkToDos[i].Text = works[i].JobTrackingWorkToDo;
                    jobTrackingStatus[i].Text = works[i].JobTrackingStatus;
                    jobTrackingWorkDetails[i].Text = works[i].JobTrackingDetail;
                }
            }
            else
                this.Close();
        }
    }
}
