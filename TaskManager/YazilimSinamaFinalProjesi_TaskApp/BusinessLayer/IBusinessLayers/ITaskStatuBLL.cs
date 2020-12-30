using Entities;
using System.Collections.Generic;

namespace BusinessLayer.IBusinessLayers
{
    interface ITaskStatuBLL
    {
        List<TaskStatu> GetTaskStatus(int projectID);
        void UpdateTaskStatu(int taskStatuID, string newTaskStatuName);
        void AddTaskStatu(int projectID, string taskStatuTitle);
        void DeleteTaskStatus(int projectID);
        void DeleteTaskStatu(int taskStatuID);
    }
}
