using System.Collections;
using System.Collections.Generic;
using Pryanik.Admin.Editor.UI;
using Pryanik.Db.Models;
using UnityEngine;
using Zenject;

namespace Pryanik
{
    public interface IGridController
    {
        void Display(IEnumerable<ModelBase> models);
    }
    public class GridController : MonoBehaviour, IGridController
    {
        private ObjectButtonPool _pool;

        [Inject]
        private void Init(ObjectButtonPool pool)
        {
            _pool = pool;
        }

        public void Display(IEnumerable<ModelBase> models)
        {
            _pool.DespawnAll();
            foreach (var model in models)
            {
                _pool.Spawn().SetModel(model);
            }
        }
    }
}
