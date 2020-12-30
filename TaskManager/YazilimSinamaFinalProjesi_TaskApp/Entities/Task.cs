using System;

namespace Entities
{
    public class Task
    {
        public Task(int taskID, int projectID, int taskStatuID, int predictTime,
            int actualTime, string projectName, string technicalExpert, DateTime date,
            string workDetail, string nots)
        {
            TaskID = taskID;
            ProjectID = projectID;
            PredictTime = predictTime;
            ActualTime = actualTime;
            ProjectName = projectName;
            TechnicalExpert = technicalExpert;
            Date = date;
            WorkDetail = workDetail;
            Nots = nots;
            TaskStatuID = taskStatuID;
        }

        // Gereken property'lere değer atamak için varsayılan kurucu method tanımlandı.
        public Task() { }
        
        public int TaskID { get; set; }
        public int TaskStatuID { get; set; }
        public int ProjectID { get; set; }
        public int PredictTime { get; set; }
        public int ActualTime { get; set; }
        public string ProjectName { get; set; }
        public string TechnicalExpert { get; set; }
        public DateTime Date { get; set; }
        public string WorkDetail { get; set; }
        public string Nots { get; set; }
    }
}
