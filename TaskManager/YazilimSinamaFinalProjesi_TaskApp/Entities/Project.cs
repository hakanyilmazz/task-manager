namespace Entities
{
    public class Project
    {
        public Project(int projectID, string projectName)
        {
            this.ProjectID = projectID;
            this.ProjectName = projectName;
        }

        // Gereken property'lere değer atamak için varsayılan kurucu method tanımlandı.
        public Project() { }

        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
    }
}
