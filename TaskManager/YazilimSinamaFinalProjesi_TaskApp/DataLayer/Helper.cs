using System.Data.SqlClient;

namespace DataLayer
{
    // Thread Safety Singleton oluşturuldu. Nesnenin sürekli oluşmasının önüne geçildi. (Static)
    public class Helper
    {
        private static Helper instance = null;

        // Ayrı thread'lerde tekrar nesne oluşmasını önlemek için oluşturuldu.
        private static readonly object padlock = new object();

        // Nesneyi dışarıdan oluşturulmaya kapattık.
        private Helper() { }

        public static Helper CreateInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Helper();
                    }

                    return instance;
                }
            }
        }

        public SqlConnection OpenConnection()
        {
            // Sql config bilgileri.
            SqlConnection connection = new SqlConnection("Server=.;database=TaskManager;trusted_connection=true");
            connection.Open();

            return connection;
        }

        public SqlCommand CreateConnection(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, OpenConnection());
            return sqlCommand;
        }
    }
}
