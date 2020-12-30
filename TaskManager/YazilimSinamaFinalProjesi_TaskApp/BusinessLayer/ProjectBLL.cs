using BusinessLayer.IBusinessLayers;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class ProjectBLL : BLL, IProjectBLL
    {
        // Projeleri getirir.
        public List<Project> GetProjects()
        {
            List<Project> projects = new List<Project>();
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("SELECT ProjeID, ProjeAdi FROM dbo.Proje");

            SqlDataReader dataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (dataReader.Read())
            {
                Project project = new Project(
                    Convert.ToInt32(dataReader["ProjeID"]),
                    dataReader["ProjeAdi"].ToString());
                projects.Add(project);
            }

            connection.Close();

            return projects;
        }

        // Proje ekler.
        public void AddProject(string projectName)
        {
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("INSERT INTO dbo.Proje (ProjeAdi) VALUES(@projectName)");

            sqlCommand.Parameters.AddWithValue("@projectName", projectName);
            sqlCommand.ExecuteNonQuery();

            connection.Close();
        }

        // Proje siler.
        public void DeleteProject(int projectID)
        {
            TaskStatuBLL taskStatuBll = new TaskStatuBLL();
            taskStatuBll.DeleteTaskStatus(projectID);

            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("DELETE FROM dbo.Proje WHERE ProjeID=@projectID;");

            sqlCommand.Parameters.AddWithValue("@projectID", projectID);
            sqlCommand.ExecuteNonQuery();

            connection.Close();
        }

        // Proje ismini günceller.
        public void UpdateProjectName(int projectID, string newProjectName)
        {
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("UPDATE dbo.Proje SET ProjeAdi = @newProjectName WHERE ProjeID=@projectID;");

            sqlCommand.Parameters.AddWithValue("@projectID", projectID);
            sqlCommand.Parameters.AddWithValue("@newProjectName", newProjectName);

            sqlCommand.ExecuteNonQuery();

            connection.Close();
        }

        // Projeyi getirir.
        public Project GetProject(int projectID)
        {
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("SELECT * FROM DBO.Proje WHERE ProjeID=@projectID;");

            sqlCommand.Parameters.AddWithValue("@projectID", projectID);

            Project project = null;
            SqlDataReader dataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (dataReader.Read())
            {
                project = new Project(
                    Convert.ToInt32(dataReader["ProjeID"]),
                    dataReader["ProjeAdi"].ToString());
            }

            connection.Close();

            return project;
        }
    }
}
