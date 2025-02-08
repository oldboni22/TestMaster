using System.Collections;
using System.Collections.Generic;

namespace Pryanik.DB.ModelControllers
{
    public interface ModelControllerBase<T> where T : struct
    {
        void Create(T model);
        void Update(T model);
        void Delete(int id);
    }
}