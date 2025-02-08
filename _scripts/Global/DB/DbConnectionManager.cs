using Mono.Data.Sqlite;

namespace Pryanik.DB
{
    public interface IDbConnectionManager
    {
        SqliteConnection GetConnection();
    }
    public class DbConnectionManager : IDbConnectionManager
    {

        private readonly string _conStr;
        
        public DbConnectionManager(string dbName)
        {
            _conStr = SetDataBaseClass.SetDataBase(dbName + ".db");;
        }

        public SqliteConnection GetConnection()
        {
            return new SqliteConnection(_conStr);
        }
    }
}