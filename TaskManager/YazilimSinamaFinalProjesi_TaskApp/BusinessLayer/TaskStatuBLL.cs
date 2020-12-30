using BusinessLayer.IBusinessLayers;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class TaskStatuBLL : BLL, ITaskStatuBLL
    {
        // Projeye ait tüm görev durumlarını getirir.
        public List<TaskStatu> GetTaskStatus(int projectID)
        {
            List<TaskStatu> taskStatus = new List<TaskStatu>();
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("SELECT * FROM dbo.TaskStatu WHERE ProjeID = @projectID");

            sqlCommand.Parameters.AddWithValue("@projectID", projectID);

            SqlDataReader dataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (dataReader.Read())
            {
                TaskStatu taskStatu = new TaskStatu(
                    Convert.ToInt32(dataReader["TaskStatuID"]),
                    dataReader["TaskStatuTitle"].ToString(),
                    Convert.ToInt32(dataReader["ProjeID"]));
                taskStatus.Add(taskStatu);
            }

            connection.Close();

            return taskStatus;
        }

        // Görev durumunu günceller.
        public void UpdateTaskStatu(int taskStatuID, string newTaskStatuName)
        {
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("UPDATE dbo.TaskStatu SET TaskStatuTitle = @newTaskStatuName WHERE TaskStatuID=@taskStatuID");
            
            sqlCommand.Parameters.AddWithValue("@taskStatuID", taskStatuID);
            sqlCommand.Parameters.AddWithValue("@newTaskStatuName", newTaskStatuName);

            sqlCommand.ExecuteNonQuery();

            connection.Close();
        }

        // Bir projeye görev durumu ekler.
        public void AddTaskStatu(int projectID, string taskStatuTitle)
        {
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand;
            string query = "INSERT INTO dbo.TaskStatu (TaskStatuTitle, ProjeID) VALUES (@taskStatuTitle, @projectID)";

            sqlCommand = database.CreateConnection(query);

            sqlCommand.Parameters.AddWithValue("@taskStatuTitle", taskStatuTitle);
            sqlCommand.Parameters.AddWithValue("@projectID", projectID);

            sqlCommand.ExecuteNonQuery();

            connection.Close();
        }

        // Projedeki tüm görev durumlarını siler. Bunu yaparkende önce işleri, sonra görevleri silecektir.
        public void DeleteTaskStatus(int projectID)
        {
            TaskBLL taskBll = new TaskBLL();
            taskBll.DeleteTasks(projectID);

            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("DELETE FROM dbo.TaskStatu WHERE ProjeID=@projectID;");
            
            sqlCommand.Parameters.AddWithValue("@projectID", projectID);
            sqlCommand.ExecuteNonQuery();

            connection.Close();
        }

        // Projedeki bir tane görev durumunu siler. Bunun için görevleri ve görevlere ait işleri silecektir.
        public void DeleteTaskStatu(int taskStatuID)
        {
            TaskBLL taskBll = new TaskBLL();
            taskBll.DeleteTaskForTaskStatu(taskStatuID);

            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("DELETE FROM dbo.TaskStatu WHERE TaskStatuID=@taskStatuID;");

            sqlCommand.Parameters.AddWithValue("@taskStatuID", taskStatuID);
            sqlCommand.ExecuteNonQuery();

            connection.Close();
        }
    }
}
