using System.Collections;
using System.Collections.Generic;
using Pryanik.Db.Models;

namespace Pryanik.DB.ModelControllers
{
    public interface ModelControllerBase<T> where T : ModelBase
    {
        void Create(T model);
        void Update(T model);
        void Delete(int id);
    }
}