using System;

namespace Entities
{
    public class Work
    {
        public Work(int workID, int taskID, int projectID, DateTime date, string jobTrackingStatus, string jobTrackingWorkToDo, string jobTrackingDetail)
        {
            WorkID = workID;
            TaskID = taskID;
            ProjectID = projectID;
            Date = date;
            JobTrackingStatus = jobTrackingStatus;
            JobTrackingWorkToDo = jobTrackingWorkToDo;
            JobTrackingDetail = jobTrackingDetail;
        }

        // Gereken property'lere değer atamak için varsayılan kurucu method tanımlandı.
        public Work() { }

        public int WorkID { get; set; }
        public int TaskID { get; set; }
        public int ProjectID { get; set; }
        public DateTime Date { get; set; }
        public string JobTrackingStatus { get; set; }
        public string JobTrackingWorkToDo { get; set; }
        public string JobTrackingDetail { get; set; }
    }
}
