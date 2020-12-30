using BusinessLayer.IBusinessLayers;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class TaskBLL : BLL, ITaskBLL
    {
        // Projeye ait görevleri, görev durumlarına göre getirir.
        public List<Task> GetProjectTasks(int projectID, int taskStatuID)
        {
            List<Task> tasks = new List<Task>();
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("SELECT * FROM dbo.Task WHERE ProjeID = @projectID AND TaskStatuID = @taskStatuID");

            sqlCommand.Parameters.AddWithValue("@projectID", projectID);
            sqlCommand.Parameters.AddWithValue("@taskStatuID", taskStatuID);

            SqlDataReader dataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (dataReader.Read())
            {
                Task task = new Task(
                    Convert.ToInt32(dataReader["TaskID"]),
                    Convert.ToInt32(dataReader["ProjeID"]),
                    Convert.ToInt32(dataReader["TaskStatuID"]),
                    Convert.ToInt32(dataReader["TahminiSure"]),
                    Convert.ToInt32(dataReader["GerceklesenSure"]),
                    dataReader["ProjeAdi"].ToString(),
                    dataReader["TeknikUzman"].ToString(),
                    Convert.ToDateTime(dataReader["Tarih"]),
                    dataReader["IsAciklamasi"].ToString(),
                    dataReader["Notlar"].ToString());
                tasks.Add(task);
            }

            connection.Close();

            return tasks;
        }

        // Projedeki tüm görevleri siler.
        public void DeleteTasks(int projectID)
        {
            WorkBLL workBll = new WorkBLL();
            workBll.DeleteWorks(projectID);

            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("DELETE FROM dbo.Task WHERE ProjeID=@projectID;");

            sqlCommand.Parameters.AddWithValue("@projectID", projectID);
            sqlCommand.ExecuteNonQuery();

            connection.Close();
        }

        // Son eklenen görevin ID değerini döndürür. Görev eklerken son eklenen görev için iş ekleme işleminde gerekli oluyor.
        public int GetLastAddedTaskID()
        {
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand;
            sqlCommand = database.CreateConnection("SELECT MAX(TaskID) AS TaskID FROM dbo.Task");

            int taskId = 0;
            SqlDataReader dataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (dataReader.Read())
            {
                taskId = Convert.ToInt32(dataReader["TaskID"]);
            }
            connection.Close();

            return taskId;
        }

        // Görev ekler.
        public void AddTask(int projectID, int taskStatuID, string projectName, string technicalExpert, int predictTime, int actualTime,
            string workDetail, string nots, List<Work> workList)
        {
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand;
            sqlCommand = database.CreateConnection("INSERT INTO dbo.Task (ProjeID, TaskStatuID, ProjeAdi,TeknikUzman,Tarih,TahminiSure,GerceklesenSure, IsAciklamasi,Notlar) " +
                "VALUES (@projectID, @taskStatuID, @projectName, @technicalExpert, GETDATE(), @predictTime, @actualTime, @workDetail, @nots)");

            sqlCommand.Parameters.AddWithValue("@projectID", projectID);
            sqlCommand.Parameters.AddWithValue("@taskStatuID", taskStatuID);
            sqlCommand.Parameters.AddWithValue("@projectName", projectName);
            sqlCommand.Parameters.AddWithValue("@technicalExpert", technicalExpert);
            sqlCommand.Parameters.AddWithValue("@predictTime", predictTime);
            sqlCommand.Parameters.AddWithValue("@actualTime", actualTime);
            sqlCommand.Parameters.AddWithValue("@workDetail", workDetail);
            sqlCommand.Parameters.AddWithValue("@nots", nots);

            sqlCommand.ExecuteNonQuery();

            connection.Close();

            WorkBLL workBll = new WorkBLL();
            workBll.AddWork(GetLastAddedTaskID(), projectID, workList);
        }

        /*
         * Görev için gereken tahmini süreyi hesaplamak için Median değerini buluyor.
         * Not: Ortalama değeri de seçilebilirdi. Ama ortalamayı çok fazla yükselten süre değerleri olursa, mesela tahmini süreler: 1, 2, 2, 3, 3, 365, şeklinde olursa,
         * genelde yapılan basit görevler için bile çok yüksek süre tahmini yapacaktır. O yüzden ağırlığın olduğu süreyi bulmak için median değeri kullanıldı.
         */
        public int GetPredictTime()
        {
            int median = 0;
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection(
                "SELECT ((SELECT MAX(GerceklesenSure) FROM " +
                "(SELECT TOP 50 PERCENT GerceklesenSure FROM dbo.Task ORDER BY GerceklesenSure) AS BottomHalf) + " +
                "(SELECT MIN(GerceklesenSure) FROM " +
                "(SELECT TOP 50 PERCENT GerceklesenSure FROM dbo.Task ORDER BY GerceklesenSure DESC) AS TopHalf)) / 2 AS Median");

            SqlDataReader dataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (dataReader.Read())
                median = dataReader["Median"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["Median"]);

            connection.Close();

            return median;
        }

        // Görev durumuna göre görevleri getirir.
        public List<Task> GetTaskStatusTasks(int taskStatuID)
        {
            List<Task> tasks = new List<Task>();
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("SELECT * FROM dbo.Task WHERE TaskStatuID=@taskStatuID");

            sqlCommand.Parameters.AddWithValue("@taskStatuID", taskStatuID);

            SqlDataReader dataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (dataReader.Read())
            {
                Task task = new Task(
                    Convert.ToInt32(dataReader["TaskID"]),
                    Convert.ToInt32(dataReader["ProjeID"]),
                    Convert.ToInt32(dataReader["TaskStatuID"]),
                    Convert.ToInt32(dataReader["TahminiSure"]),
                    Convert.ToInt32(dataReader["GerceklesenSure"]),
                    dataReader["ProjeAdi"].ToString(),
                    dataReader["TeknikUzman"].ToString(),
                    Convert.ToDateTime(dataReader["Tarih"]),
                    dataReader["IsAciklamasi"].ToString(),
                    dataReader["Notlar"].ToString());
                tasks.Add(task);
            }

            connection.Close();

            return tasks;
        }

        // Görev durumuna göre görevleri siler.
        public void DeleteTaskForTaskStatu(int taskStatuID)
        {
            List<Task> taskStatusTasks = GetTaskStatusTasks(taskStatuID);
            foreach (var task in taskStatusTasks)
            {
                WorkBLL workBll = new WorkBLL();
                workBll.DeleteWork(task.TaskID);
            }

            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("DELETE FROM dbo.Task WHERE TaskStatuID=@taskStatuID;");

            sqlCommand.Parameters.AddWithValue("@taskStatuID", taskStatuID);
            sqlCommand.ExecuteNonQuery();

            connection.Close();
        }

        // Görev siler.
        public void DeleteTask(int taskID)
        {
            WorkBLL workBll = new WorkBLL();
            workBll.DeleteWork(taskID);

            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("DELETE FROM dbo.Task WHERE TaskID=@taskID;");

            sqlCommand.Parameters.AddWithValue("@taskID", taskID);
            sqlCommand.ExecuteNonQuery();

            connection.Close();
        }

        // Görev id'sine göre görev getirir.
        public Task GetTask(int taskID)
        {
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand;

            sqlCommand = database.CreateConnection("SELECT * FROM dbo.Task WHERE TaskID=@taskID");
            sqlCommand.Parameters.AddWithValue("@taskID", taskID);

            Task task = null;
            SqlDataReader dataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (dataReader.Read())
            {
                task = new Task
                {
                    TaskID = Convert.ToInt32(dataReader["TaskID"]),
                    ProjectID = Convert.ToInt32(dataReader["ProjeID"]),
                    TaskStatuID = Convert.ToInt32(dataReader["TaskStatuID"]),
                    PredictTime = Convert.ToInt32(dataReader["TahminiSure"]),
                    ActualTime = Convert.ToInt32(dataReader["GerceklesenSure"]),
                    ProjectName = dataReader["ProjeAdi"].ToString(),
                    TechnicalExpert = dataReader["TeknikUzman"].ToString(),
                    Date = Convert.ToDateTime(dataReader["Tarih"]),
                    WorkDetail = dataReader["IsAciklamasi"].ToString(),
                    Nots = dataReader["Notlar"].ToString(),
                };
            }

            connection.Close();

            return task;
        }

        // Görev günceller.
        public void UpdateTask(int taskID, int projectID, string technicalExpert, DateTime date, int predictTime, int actualTime, string workDetail, string nots, List<Work> works)
        {
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("UPDATE dbo.Task SET TeknikUzman=@technicalExpert, Tarih=@date, " +
                "TahminiSure=@predictTime, GerceklesenSure=@actualTime, IsAciklamasi=@workDetail, Notlar=@nots WHERE TaskID=@taskID");

            sqlCommand.Parameters.AddWithValue("@taskID", taskID);
            sqlCommand.Parameters.AddWithValue("@technicalExpert", technicalExpert);
            sqlCommand.Parameters.AddWithValue("@date", date);
            sqlCommand.Parameters.AddWithValue("@predictTime", predictTime);
            sqlCommand.Parameters.AddWithValue("@actualTime", actualTime);
            sqlCommand.Parameters.AddWithValue("@workDetail", workDetail);
            sqlCommand.Parameters.AddWithValue("@nots", nots);

            sqlCommand.ExecuteNonQuery();

            connection.Close();

            WorkBLL workBll = new WorkBLL();
            workBll.UpdateWorks(taskID, projectID, works);
        }

        // Görev durumuna göre görevi günceller.
        public void UpdateTaskForTaskStatu(int taskID, int taskStatuID)
        {
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("UPDATE dbo.Task SET TaskStatuID=@taskStatuID WHERE TaskID=@taskID");

            sqlCommand.Parameters.AddWithValue("@taskID", taskID);
            sqlCommand.Parameters.AddWithValue("@taskStatuID", taskStatuID);

            sqlCommand.ExecuteNonQuery();

            connection.Close();
        }
    }
}
