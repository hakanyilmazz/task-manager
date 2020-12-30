using Entities;
using System.Collections.Generic;

namespace BusinessLayer.IBusinessLayers
{
    interface IWorkBLL
    {
        List<Work> GetTaskWorks(int taskID);
        void AddWork(int taskID, int projectID, List<Work> workList);
        void DeleteWorks(int projectID);
        void DeleteWork(int taskID);
        void UpdateWorks(int taskID, int projectID, List<Work> works);
    }
}
