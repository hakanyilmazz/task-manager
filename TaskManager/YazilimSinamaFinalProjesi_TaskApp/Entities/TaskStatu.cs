namespace Entities
{
    public class TaskStatu
    {
        public TaskStatu(int taskStatuID, string taskStatuTitle, int projectID)
        {
            TaskStatuID = taskStatuID;
            TaskStatuTitle = taskStatuTitle;
            ProjectID = projectID;
        }

        // Gereken property'lere değer atamak için varsayılan kurucu method tanımlandı.
        public TaskStatu() { }

        public int TaskStatuID { get; set; }
        public string TaskStatuTitle { get; set; }
        public int ProjectID { get; set; }
    }
}
