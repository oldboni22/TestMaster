using System.Collections;
using System.Collections.Generic;
using Pryanik.Db.Models;
using Zenject;

namespace Pryanik.DB.ModelControllers
{

    public interface IAnswerController : ModelControllerBase<Answer>
    {
        IEnumerable<Answer> GetByQuestionId(int questionId);
    }
    public class AnswerController : IAnswerController
    {
        
        private IDbConnectionManager _connectionManager;

        [Inject]
        private void Init(IDbConnectionManager connectionManager)
        { 
            _connectionManager = connectionManager;
        }

        public IEnumerable<Answer> GetByQuestionId(int questionId)
        {
            using(var con = _connectionManager.GetConnection())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $"SELECT FROM Answer WHERE question_id = {questionId};";
                    var reader = command.ExecuteReader();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var text = reader.GetString(2);
                            var isCorrect = reader.GetInt32(3);
                            
                            yield return new Answer(id,questionId,text,isCorrect);
                        }
                    }
                }
            }
        }
        
        public void Create(Answer model)
        {
            using (var con = _connectionManager.GetConnection())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $"INSERT INTO Answer VALUES ({model.QuestionId},{model.Text},{model.IsCorrect}]);";
                    command.ExecuteReader().Dispose();
                }
            }
        }

        public void Update(Answer model)
        {
            using (var con = _connectionManager.GetConnection())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $"UPDATE Answer SET text = {model.Text},is_correcr = {model.IsCorrect} WHERE id = {model.ID};";
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
                    command.CommandText = $"DELETE FROM Answer WHERE id = {id};";
                    command.ExecuteReader().Dispose();
                }
            }
        }

        
    }
}