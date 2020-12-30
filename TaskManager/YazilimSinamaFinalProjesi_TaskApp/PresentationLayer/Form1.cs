using BusinessLayer;
using Entities;
using MetroFramework.Controls;
using PresentationLayer.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            LoadProjectsToFlowLayout();
        }

        #region Content Menu Strip İşlemleri Buton
        private void btnProjectDeleteMenu_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("This Project Will Delete...", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                ToolStripDropDownItem toolStripDropDownItem = sender as ToolStripDropDownItem;
                ProjectBLL projectBll = new ProjectBLL();

                projectBll.DeleteProject(Convert.ToInt32(toolStripDropDownItem.Name));
                LoadProjectsToFlowLayout();
            }
        }

        private void btnProjectUpdateMenu_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem toolStripDropDownItem = sender as ToolStripDropDownItem;
            projectID = Convert.ToInt32(toolStripDropDownItem.Name);

            UpdateProjectNameForm updateProjectNameForm = new UpdateProjectNameForm(projectID);
            updateProjectNameForm.ShowDialog();

            if (updateProjectNameForm.doRefresh)
                LoadProjectsToFlowLayout();
        }

        private void btnUpdateTaskMenu_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem toolStripDropDownItem = sender as ToolStripDropDownItem;

            AddTaskForm addTaskForm = new AddTaskForm(Convert.ToInt32(toolStripDropDownItem.Name.ToString()), projectID, Convert.ToInt32(toolStripDropDownItem.Tag.ToString()));
            addTaskForm.ShowDialog();

            if (addTaskForm.doRefresh)
                LoadTaskStatusToFlowLayout(projectID);
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            MetroButton btn = sender as MetroButton;

            AddTaskForm addTaskForm = new AddTaskForm(Convert.ToInt32(btn.Tag.ToString()), projectID, Convert.ToInt32(btn.Name));
            addTaskForm.ShowDialog();

            if (addTaskForm.doRefresh)
                LoadTaskStatusToFlowLayout(projectID);
        }

        private void btnTaskStatuDeleteMenu_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("This Task Statu Will Delete...", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                ToolStripDropDownItem toolStripDropDownItem = sender as ToolStripDropDownItem;
                TaskStatuBLL taskStatuBll = new TaskStatuBLL();

                taskStatuBll.DeleteTaskStatu(Convert.ToInt32(toolStripDropDownItem.Name));

                LoadProjectsToFlowLayout();
            }
        }

        private void btnTaskStatuUpdateMenu_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem toolStripDropDownItem = sender as ToolStripDropDownItem;

            UpdateTaskStatuForm updateTaskStatuForm = new UpdateTaskStatuForm(Convert.ToInt32(toolStripDropDownItem.Name));
            updateTaskStatuForm.ShowDialog();

            if (updateTaskStatuForm.doRefresh)
                LoadTaskStatusToFlowLayout(projectID);
        }

        private void btnCreateTaskMenu_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem toolStripDropDownItem = sender as ToolStripDropDownItem;

            AddTaskForm addTaskForm = new AddTaskForm(Convert.ToInt32(toolStripDropDownItem.Name), projectID, 0);
            addTaskForm.ShowDialog();

            if (addTaskForm.doRefresh)
                LoadTaskStatusToFlowLayout(projectID);
        }

        private void btnTaskDeleteMenu_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("This Task Will Delete...", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                ToolStripDropDownItem toolStripDropDownItem = sender as ToolStripDropDownItem;
                TaskBLL taskBll = new TaskBLL();

                taskBll.DeleteTask(Convert.ToInt32(toolStripDropDownItem.Tag));

                LoadProjectsToFlowLayout();
            }
        }
        #endregion

        #region Button Click İşlemleri
        int projectID = 0;
        private void btnProject_Click(object sender, EventArgs e)
        {
            newTaskStatusMenu.Enabled = true;

            // Gösterilen projenin butonuna stil verir.
            MetroButton btn = sender as MetroButton;
            btn.Theme = MetroFramework.MetroThemeStyle.Dark;
            btn.TextAlign = ContentAlignment.MiddleCenter;

            projectID = Convert.ToInt32(btn.Name);
            LoadTaskStatusToFlowLayout(projectID);

            SetSelectedProjectTheme(projectID);
            SetTaskGroupNameFromSelectedProject(projectID);
        }


        #endregion

        #region Görsel Nesnelere Değer Atama İşlemleri
        // Kullanıcının o an hangi projeye baktığını gösteren grup ismi atanır.
        private void SetTaskGroupNameFromSelectedProject(int projectID)
        {
            MetroButton btn = GetSelectedProjectButton(projectID);
            if (btn != null)
            {
                string text = btn.Text.Length > 30 ? btn.Text.Substring(0, 30) + "..." : btn.Text;
                grpBoxTasks.Text = text + " - Tasks";
            }
        }

        private void SetSelectedProjectTheme(int projectID)
        {
            foreach (var item in flProjects.Controls)
            {
                MetroButton btn = item as MetroButton;

                if (btn.Name == projectID.ToString())
                {
                    btn.Theme = MetroFramework.MetroThemeStyle.Dark;
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                }
                else
                {
                    btn.Theme = MetroFramework.MetroThemeStyle.Light;
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                }
            }
        }

        #region Flowlayoutlara Eleman Yükleme İşlemleri
        // Ekrana proje listesini yükler.
        private void LoadProjectsToFlowLayout()
        {
            ClearScreen();

            List<Project> projects = new List<Project>();
            ProjectBLL projectBLL = new ProjectBLL();

            projects = projectBLL.GetProjects();

            // Eğer proje varsa ekrana yüklenir.
            if (projects.Count > 0)
            {
                MetroButton[] btnProject = new MetroButton[projects.Count];
                int myWidth = projects.Count > 14 ? 205 : 225;

                for (int i = 0; i < projects.Count; i++)
                {
                    btnProject[i] = new MetroButton
                    {
                        Text = projects[i].ProjectName,
                        Name = projects[i].ProjectID.ToString(),
                        Width = myWidth,
                        Height = 30,
                        TextAlign = ContentAlignment.MiddleLeft,
                    };

                    btnProject[i].Click += btnProject_Click;

                    btnProject[i].ContextMenuStrip = new ContextMenuStrip();

                    btnProject[i].ContextMenuStrip.Items.Add("Update Project");
                    btnProject[i].ContextMenuStrip.Items[0].Click += btnProjectUpdateMenu_Click;
                    btnProject[i].ContextMenuStrip.Items[0].Name = projects[i].ProjectID.ToString();

                    btnProject[i].ContextMenuStrip.Items.Add("Delete Project");
                    btnProject[i].ContextMenuStrip.Items[1].Click += btnProjectDeleteMenu_Click;
                    btnProject[i].ContextMenuStrip.Items[1].Name = projects[i].ProjectID.ToString();

                    flProjects.Controls.Add(btnProject[i]);
                }
            }
            else
            {
                MetroLabel lblProjectMessage = new MetroLabel
                {
                    Text = "No Any Project.",
                    Name = "lblProjectMessage",
                    Width = 150,
                };

                flProjects.Controls.Add(lblProjectMessage);
            }
        }

        private void LoadTaskStatusToFlowLayout(int projectID)
        {
            ClearTaskStatus();

            TaskStatuBLL taskStatuBLL = new TaskStatuBLL();
            List<TaskStatu> taskStatus = taskStatuBLL.GetTaskStatus(projectID);

            if (taskStatus.Count > 0)
                LoadTaskStatus(projectID, taskStatus);
            else
            {
                MetroLabel lblNoTaskStatuText = new MetroLabel
                {
                    Text = "No Any Task Statu.",
                    Name = "lblNoTaskStatuText",
                    FontSize = MetroFramework.MetroLabelSize.Medium,
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = true,
                };

                flTaskStatus.Controls.Add(lblNoTaskStatuText);
            }
        }
        #endregion
        #endregion

        #region Görsel Nesnelerin Elemanlarına Değer Atama İşlemleri
        List<MetroButton> moveTaskButtons;
        // Görev durumlarını ekrana yükler.
        private void LoadTaskStatus(int projectID, List<TaskStatu> taskStatus)
        {
            moveTaskButtons = new List<MetroButton>();
            for (int i = 0; i < taskStatus.Count; i++)
            {
                string statuTitle = taskStatus[i].TaskStatuTitle;
                statuTitle = statuTitle.Length > 15 ? statuTitle.Substring(0, 15) + "..." : statuTitle;

                TableLayoutPanel tblLayoutTaskStatus = new TableLayoutPanel
                {
                    Name = taskStatus[i].TaskStatuID.ToString(),
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                    AutoSize = true,
                };

                TaskBLL taskBll = new TaskBLL();
                List<Task> tasks = taskBll.GetProjectTasks(projectID, taskStatus[i].TaskStatuID);

                MetroLabel lblStatuName = new MetroLabel
                {
                    Text = statuTitle,
                    Name = taskStatus[i].TaskStatuID.ToString(),
                    FontSize = MetroFramework.MetroLabelSize.Medium,
                    TextAlign = ContentAlignment.MiddleLeft,
                };

                lblStatuName.ContextMenuStrip = new ContextMenuStrip();

                lblStatuName.ContextMenuStrip.Items.Add("Update Statu");
                lblStatuName.ContextMenuStrip.Items[0].Click += btnTaskStatuUpdateMenu_Click;
                lblStatuName.ContextMenuStrip.Items[0].Name = taskStatus[i].TaskStatuID.ToString();

                lblStatuName.ContextMenuStrip.Items.Add("Delete Statu");
                lblStatuName.ContextMenuStrip.Items[1].Click += btnTaskStatuDeleteMenu_Click;
                lblStatuName.ContextMenuStrip.Items[1].Name = taskStatus[i].TaskStatuID.ToString();

                tblLayoutTaskStatus.Controls.Add(lblStatuName);

                if (tasks.Count > 0)
                {
                    for (int j = 0; j < tasks.Count; j++)
                    {
                        lblStatuName.ContextMenuStrip.Items[1].Tag = tasks[j].TaskID.ToString();

                        MetroButton btnTask = new MetroButton
                        {
                            Text = tasks[j].WorkDetail,
                            Name = tasks[j].TaskID.ToString(),
                            Tag = taskStatus[i].TaskStatuID.ToString(),
                            Width = 200,
                            Height = 30,
                            TextAlign = ContentAlignment.MiddleLeft,
                        };

                        btnTask.AllowDrop = true;
                        btnTask.DragDrop += TaskButton_DragDrop;
                        btnTask.DragEnter += TaskButton_DragEnter;
                        btnTask.MouseClick += TaskButton_MouseClick;
                        btnTask.MouseMove += TaskButton_MouseMove;

                        btnTask.Click += btnTask_Click;

                        btnTask.ContextMenuStrip = new ContextMenuStrip();

                        btnTask.ContextMenuStrip.Items.Add("Create New Task");

                        btnTask.ContextMenuStrip.Items[0].Click += btnCreateTaskMenu_Click;
                        btnTask.ContextMenuStrip.Items[0].Name = taskStatus[i].TaskStatuID.ToString();

                        btnTask.ContextMenuStrip.Items.Add("Update Task");

                        btnTask.ContextMenuStrip.Items[1].Click += btnUpdateTaskMenu_Click;
                        btnTask.ContextMenuStrip.Items[1].Name = taskStatus[i].TaskStatuID.ToString();
                        btnTask.ContextMenuStrip.Items[1].Tag = tasks[j].TaskID.ToString();

                        btnTask.ContextMenuStrip.Items.Add("Delete Task");
                        btnTask.ContextMenuStrip.Items[2].Click += btnTaskDeleteMenu_Click;
                        btnTask.ContextMenuStrip.Items[2].Name = taskStatus[i].TaskStatuID.ToString();
                        btnTask.ContextMenuStrip.Items[2].Tag = tasks[j].TaskID.ToString();

                        tblLayoutTaskStatus.Controls.Add(btnTask);
                    }
                }
                else
                {
                    MetroLabel lblNoTaskText = new MetroLabel
                    {
                        Text = "No Any Task.",
                        Name = "lblNoTaskText",
                        FontSize = MetroFramework.MetroLabelSize.Small,
                        TextAlign = ContentAlignment.MiddleLeft,
                    };

                    lblNoTaskText.ContextMenuStrip = new ContextMenuStrip();

                    lblNoTaskText.ContextMenuStrip.Items.Add("Create New Task");

                    lblNoTaskText.ContextMenuStrip.Items[0].Click += btnCreateTaskMenu_Click;
                    lblNoTaskText.ContextMenuStrip.Items[0].Name = taskStatus[i].TaskStatuID.ToString();

                    tblLayoutTaskStatus.Controls.Add(lblNoTaskText);
                }

                MetroButton moveTaskButton = new MetroButton
                {
                    Text = "Move Task Here ( + )",
                    Name = taskStatus[i].TaskStatuID.ToString(),
                    Width = 200,
                    Height = 40,
                    Visible = false,
                };

                moveTaskButton.AllowDrop = true;
                moveTaskButton.DragDrop += TaskButton_DragDrop;
                moveTaskButton.DragEnter += TaskButton_DragEnter;
                moveTaskButton.MouseClick += TaskButton_MouseClick;
                moveTaskButton.MouseMove += TaskButton_MouseMove;

                moveTaskButtons.Add(moveTaskButton);

                tblLayoutTaskStatus.Controls.Add(moveTaskButton);
                flTaskStatus.Controls.Add(tblLayoutTaskStatus);
            }
        }
        #endregion

        #region Görsel Nesneleri Döndüren İşlemleri
        private MetroButton GetSelectedProjectButton(int projectID)
        {
            MetroButton btn = null;

            foreach (var item in flProjects.Controls)
            {
                btn = (MetroButton)item;

                if (btn.Name == projectID.ToString())
                    return btn;
            }

            return null;
        }
        #endregion

        #region Görev Drag Drop İşlemleri
        private void ShowMoveTaskButtons(bool visible)
        {
            foreach (var item in moveTaskButtons)
                item.Visible = visible;
        }

        private void SwapButtons(MetroButton source, MetroButton target)
        {
            if (target.Text == "Move Task Here ( + )" && source.Text != "Move Task Here ( + )")
            {
                TaskBLL taskBll = new TaskBLL();
                taskBll.UpdateTaskForTaskStatu(Convert.ToInt32(source.Name), Convert.ToInt32(target.Name));

                LoadTaskStatusToFlowLayout(projectID);
            }
            else
                ShowMoveTaskButtons(false);
        }

        MetroButton selected;
        private void SelectButton(MetroButton task)
        {
            try
            {
                if (selected != task)
                    selected = task;
                else
                    selected = null;

                foreach (var box in flTaskStatus.Controls)
                {
                    var item = (MetroButton)box;
                    item.Invalidate();
                }
            }
            catch (Exception) { }
        }

        private void TaskButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var btn = (MetroButton)sender;

                if (btn.Text != null)
                {
                    ShowMoveTaskButtons(true);
                    btn.DoDragDrop(btn, DragDropEffects.Move);
                    ShowMoveTaskButtons(false);
                }
            }
        }

        private void TaskButton_MouseClick(object sender, MouseEventArgs e)
        {
            ShowMoveTaskButtons(false);
            SelectButton((MetroButton)sender);
        }

        private void TaskButton_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(MetroButton)))
                e.Effect = DragDropEffects.Move;
        }

        private void TaskButton_DragDrop(object sender, DragEventArgs e)
        {
            var target = (MetroButton)sender;

            if (e.Data.GetDataPresent(typeof(MetroButton)))
            {
                var source = (MetroButton)e.Data.GetData(typeof(MetroButton));
                if (source != target)
                {
                    SwapButtons(source, target);

                    selected = null;
                    SelectButton(target);
                    return;
                }
            }
        }
        #endregion

        #region Ekran Temizleme İşlemleri
        private void ClearScreen()
        {
            ClearTaskStatus();
            ClearProjects();
        }

        private void ClearProjects()
        {
            newTaskStatusMenu.Enabled = false;
            flProjects.Controls.Clear();
        }

        private void ClearTaskStatus()
        {
            grpBoxTasks.Text = "Tasks";
            flTaskStatus.Controls.Clear();
        }
        #endregion

        #region Menu Item İşlemleri
        private void newProjectMenu_Click(object sender, EventArgs e)
        {
            AddProjectForm addProjectForm = new AddProjectForm();
            addProjectForm.ShowDialog();

            if (addProjectForm.doRefresh)
                LoadProjectsToFlowLayout();
        }

        private void newTaskStatusMenu_Click(object sender, EventArgs e)
        {
            AddTaskStatuForm addTaskStatuForm = new AddTaskStatuForm(projectID);
            addTaskStatuForm.ShowDialog();

            if (addTaskStatuForm.doRefresh)
                LoadTaskStatusToFlowLayout(projectID);
        }
        #endregion
    }
}
