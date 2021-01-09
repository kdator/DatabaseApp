using System.Data.OleDb;

namespace Lab7
{
    /// <summary>
    /// Класс, отвечающий за соединение с базой данных.
    /// </summary>
    class Database
    {
        private static string provider = "Provider=Microsoft.ACE.OLEDB.12.0";
        private static string dataSource = @"Data Source=""C:\Users\User\Desktop\labs\бд\6 лаба\6 лаба..accdb""";
        private readonly string connectionString = provider + ";" + dataSource;
        private readonly OleDbConnection cn;

        public Database() {
            cn = new OleDbConnection(connectionString);
        }
        /// <summary>
        /// Получить соединение с базой данных.
        /// </summary>
        /// <returns>объект соединения</returns>
        public OleDbConnection GetConnection() {
            return cn;
        }

        /// <summary>
        /// Открыть соединение с базой.
        /// </summary>
        public void OpenConnection() {
            if (cn.State == System.Data.ConnectionState.Closed)
                cn.Open();
        }

        /// <summary>
        /// Закрыть соединение с базой.
        /// </summary>
        public void CloseConnection() {
            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }
    }
}
