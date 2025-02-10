using System.Collections.Generic;
using Pryanik.Db.Models;
using UnityEngine;
using Zenject;

namespace Pryanik.Admin.Editor.UI
{
    public class ObjectButtonPool : MonoMemoryPool<ObjectButton>
    {
        [Inject] private Transform _parent;
        private readonly List<ObjectButton> _buttons = new(15);

        protected override void OnCreated(ObjectButton item)
        {
            _buttons.Add(item);
            item.transform.parent = _parent;
        }

        protected override void OnDespawned(ObjectButton item)
        {
            item.Reset();
        }
        
        public void DespawnAll()
        {
            foreach (var button in _buttons)
            {
                Despawn(button);
            }
        }
    }
}