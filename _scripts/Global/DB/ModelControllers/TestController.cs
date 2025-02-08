﻿using System.Collections;
using System.Collections.Generic;
using Pryanik.Db.Models;
using Zenject;

namespace Pryanik.DB.ModelControllers
{

    public interface ITestController : ModelControllerBase<Test>
    {
       
    }
    public class TestController : ITestController
    {

        private IDbConnectionManager _connectionManager;


        [Inject]
        private void Init(IDbConnectionManager connectionManager)
        { 
            _connectionManager = connectionManager;
        }
        
        public IEnumerable<Test> GetAll()
        {
            using(var con = _connectionManager.GetConnection())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Test;";
                    var reader = command.ExecuteReader();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var themeId = reader.GetInt32(1);
                            var name = reader.GetString(2);
                            var dur = reader.GetInt32(3);
                            
                            yield return new Test(id,themeId,name,dur);
                        }
                    }
                }
            }
        }

        public Test GetById(int id)
        {
            Test test;
            using(var con = _connectionManager.GetConnection())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $"SELECT FROM Test WHERE Id = {id};";
                    var reader = command.ExecuteReader();
                    using (reader)
                    {
                        reader.Read();

                        var themeId = reader.GetInt32(1);
                        var name = reader.GetString(2);
                        var dur = reader.GetInt32(3);
                        test = new Test(id, themeId, name, dur);
                    }
                }
            }

            return test;
        }

        public void Create(Test model)
        {
            using (var con = _connectionManager.GetConnection())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $"INSERT INTO Test VALUES ({model.ThemeId},{model.Name},{model.Duration});";
                    command.ExecuteReader().Dispose();
                }
            }
        }

        public void Update(Test model)
        {
            using (var con = _connectionManager.GetConnection())
            {
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $"UPDATE Test SET name = {model.Name},duration = {model.Duration} WHERE id = {model.ID};";
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
                    command.CommandText = $"DELETE FROM Test WHERE Id = {id};";
                    command.ExecuteReader().Dispose();
                }
            }
        }
    }
}