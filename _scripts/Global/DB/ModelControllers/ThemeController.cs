using System.Collections;
using System.Collections.Generic;
using Pryanik.Db.Models;
using Zenject;

namespace Pryanik.DB.ModelControllers
{

    public interface IThemeController : ModelControllerBase<Theme>
    {
        
    }
    public class ThemeController : IThemeController
    {
        private readonly IDbConnectionManager _connectionManager;
        
        [Inject]
        public ThemeController(IDbConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }
        
        public IEnumerable<Theme> GetAll()
        {
            using(var con = _connectionManager.GetConnection())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Theme;";
                    var reader = command.ExecuteReader();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var name = reader.GetString(1);
                            yield return new Theme(id, name);
                        }
                    }
                }
            }
        }

        public Theme GetById(int id)
        {
            Theme theme;
            using(var con = _connectionManager.GetConnection())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $"SELECT FROM Theme WHERE Id = {id};";
                    var reader = command.ExecuteReader();
                    using (reader)
                    {
                        reader.Read();
                        var name = reader.GetString(1);
                        theme = new Theme(id, name);
                    }
                }
            }

            return theme;
        }
        
        public void Create(Theme theme)
        {
            using (var con = _connectionManager.GetConnection())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $"INSERT INTO Theme VALUES ({theme.Name});";
                    command.ExecuteReader().Dispose();
                }
            }
        }

        public void Update(Theme theme)
        {
            using (var con = _connectionManager.GetConnection())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $"UPDATE Theme SET name = {theme.Name} WHERE id = {theme.ID};";
                    command.ExecuteReader().Dispose();
                }
            }
        }

        public void Delete(int id)
        {
            using (var con = _connectionManager.GetConnection())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $"DELETE FROM Theme WHERE Id = {id};";
                    command.ExecuteReader().Dispose();
                }
            }
        }
    }
}