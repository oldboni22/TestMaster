using System.Collections.Generic;
using Pryanik.Db.Models;
using Zenject;

namespace Pryanik.DB.ModelControllers
{
    public interface IQuestionController : ModelControllerBase<Question>
    {
        IEnumerable<Question> GetByTestId(int testId);
    }
    public class QuestionController : IQuestionController
    {
        private IDbConnectionManager _connectionManager;

        public QuestionController(IDbConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public IEnumerable<Question> GetByTestId(int testId)
        {
            using(var con = _connectionManager.GetConnection())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $"SELECT FROM Question WHERE test_id = {testId};";
                    var reader = command.ExecuteReader();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var text = reader.GetString(2);
                            var len = reader.GetInt32(3);
                            
                            yield return new Question(id,testId,text);
                        }
                    }
                }
            }
        }

        public void Create(Question model)
        {
            using (var con = _connectionManager.GetConnection())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $"INSERT INTO Question VALUES ({model.TestId},{model.Text}]);";
                    command.ExecuteReader().Dispose();
                }
            }
        }

        public void Update(Question model)
        {
            using (var con = _connectionManager.GetConnection())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $"UPDATE Question SET text = {model.Text}, WHERE id = {model.ID};";
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
                    command.CommandText = $"DELETE FROM Question WHERE id = {id};";
                    command.ExecuteReader().Dispose();
                }
            }
        }
    }
}