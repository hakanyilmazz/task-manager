using Entities;
using System.Collections.Generic;

namespace BusinessLayer.IBusinessLayers
{
    interface IProjectBLL
    {
        List<Project> GetProjects();
        void AddProject(string projectName);
        void DeleteProject(int projectID);
        void UpdateProjectName(int projectID, string newProjectName);
        Project GetProject(int projectID);
    }
}
