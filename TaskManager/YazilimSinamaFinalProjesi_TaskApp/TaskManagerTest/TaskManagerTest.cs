using BusinessLayer;
using Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace TaskManagerTest
{
    public class TaskManagerTest
    {
        [Test]
        public void GetProjects()
        {
            ProjectBLL projectBll = new ProjectBLL();
            List<Project> projects = projectBll.GetProjects();
            int projectCount = -1;
            
            if (projects.Count > 0)
                projectCount = projects.Count;

            Assert.AreEqual(projects.Count, projectCount);
        }

        [Test]
        public void GetTasksOfProject()
        {
            ProjectBLL projectBll = new ProjectBLL();
            List<Project> projects = projectBll.GetProjects();
            TaskStatuBLL taskStatuBll = new TaskStatuBLL();
            List<Task> tasks = new List<Task>();
            int taskCount = -1;

            if (projects.Count > 0)
            {
                List<TaskStatu> taskStatus = taskStatuBll.GetTaskStatus(projects[0].ProjectID);

                if (taskStatus.Count > 0)
                {
                    TaskBLL taskBll = new TaskBLL();
                    tasks = taskBll.GetProjectTasks(projects[0].ProjectID, taskStatus[0].TaskStatuID);

                    if (tasks.Count > 0)
                    {
                        taskCount = tasks.Count;
                    }
                }
            }

            Assert.AreEqual(tasks.Count, taskCount);
        }
    }
}