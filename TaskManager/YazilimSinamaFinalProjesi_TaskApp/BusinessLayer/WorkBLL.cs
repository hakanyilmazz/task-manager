using BusinessLayer.IBusinessLayers;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class WorkBLL : BLL, IWorkBLL
    {
        // Projeye ait tüm işleri getirir.
        public List<Work> GetTaskWorks(int taskID)
        {
            List<Work> works = new List<Work>();
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("SELECT * FROM dbo.TaskWork WHERE TaskID = @taskID");

            sqlCommand.Parameters.AddWithValue("@taskID", taskID);

            SqlDataReader dataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (dataReader.Read())
            {
                Work myWork = new Work(
                    Convert.ToInt32(dataReader["IsID"]),
                    Convert.ToInt32(dataReader["TaskID"]),
                    Convert.ToInt32(dataReader["ProjeID"]),
                    Convert.ToDateTime(dataReader["Tarih"]),
                    dataReader["IsTakipDurum"].ToString(),
                    dataReader["IsTakipYapilacakIs"].ToString(),
                    dataReader["IsTakipAciklama"].ToString());
                works.Add(myWork);
            }

            connection.Close();

            return works;
        }

        // Bir göreve iş ekler.
        public void AddWork(int taskID, int projectID, List<Work> workList)
        {
            List<Work> oldWorks = GetTaskWorks(taskID);

            // Veritabanında bir göreve ait iş sayısı 6'yı geçmesin diye kontrol yapılıyor.
            if (oldWorks.Count < 7)
            {
                // Toplamda 6 adet iş var mı ona bakıyor. En fazla aradaki fark kadar iş ekleyecek.
                int difference = workList.Count - oldWorks.Count;
                difference = Math.Abs(difference);

                SqlConnection connection = database.OpenConnection();
                SqlCommand sqlCommand;
                string query = "INSERT INTO dbo.TaskWork (TaskID, ProjeID, IsTakipDurum, IsTakipYapilacakIs, IsTakipAciklama, Tarih) " +
                    "VALUES (@taskID, @projectID, @JobTrackingStatus, @JobTrackingWorkToDo, @JobTrackingDetail, @Date)";

                int lineCounter = 0;
                foreach (var work in workList)
                {
                    if (lineCounter < difference)
                    {
                        sqlCommand = database.CreateConnection(query);

                        sqlCommand.Parameters.AddWithValue("@taskID", taskID);
                        sqlCommand.Parameters.AddWithValue("@projectID", projectID);
                        sqlCommand.Parameters.AddWithValue("@JobTrackingStatus", work.JobTrackingStatus);
                        sqlCommand.Parameters.AddWithValue("@JobTrackingWorkToDo", work.JobTrackingWorkToDo);
                        sqlCommand.Parameters.AddWithValue("@JobTrackingDetail", work.JobTrackingDetail);
                        sqlCommand.Parameters.AddWithValue("@Date", work.Date);

                        sqlCommand.ExecuteNonQuery();
                        lineCounter++;

                        connection.Close();
                    }
                }
            }
        }

        // Projedeki tüm işleri siler.
        public void DeleteWorks(int projectID)
        {
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("DELETE FROM dbo.TaskWork WHERE ProjeID=@projectID");

            sqlCommand.Parameters.AddWithValue("@projectID", projectID);
            sqlCommand.ExecuteNonQuery();

            connection.Close();
        }

        // Bir görevdeki tüm işleri siler.
        public void DeleteWork(int taskID)
        {
            SqlConnection connection = database.OpenConnection();
            SqlCommand sqlCommand = database.CreateConnection("DELETE FROM dbo.TaskWork WHERE TaskID=@taskID;");
            
            sqlCommand.Parameters.AddWithValue("@taskID", taskID);
            sqlCommand.ExecuteNonQuery();

            connection.Close();
        }

        // İş bilgilerini günceller.
        public void UpdateWorks(int taskID, int projectID, List<Work> works)
        {
            DeleteWork(taskID);
            AddWork(taskID, projectID, works);
        }
    }
}
