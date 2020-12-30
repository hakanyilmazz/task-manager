using Entities;
using System;
using System.Collections.Generic;

namespace BusinessLayer.IBusinessLayers
{
    interface ITaskBLL
    {
        List<Task> GetProjectTasks(int projectID, int taskStatuID);
        void DeleteTasks(int projectID);
        int GetLastAddedTaskID();
        void AddTask(int projectID, int taskStatuID, string projectName, string technicalExpert, int predictTime, int actualTime,
            string workDetail, string nots, List<Work> workList);
        int GetPredictTime();
        List<Task> GetTaskStatusTasks(int taskStatuID);
        void DeleteTaskForTaskStatu(int taskStatuID);
        void DeleteTask(int taskID);
        Task GetTask(int taskID);
        void UpdateTask(int taskID, int projectID, string technicalExpert, DateTime date, int predictTime, int actualTime, 
            string workDetail, string nots, List<Work> works);
        void UpdateTaskForTaskStatu(int taskID, int taskStatuID);
    }
}
