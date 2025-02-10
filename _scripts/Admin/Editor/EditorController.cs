using System.Collections;
using System.Collections.Generic;
using Pryanik.Admin.Editor.StateMachine;
using Pryanik.Db.Models;
using UnityEngine;
using Zenject;

namespace Pryanik.Admin.Editor
{
    public interface IEditorController
    {
        void OnDelete(int id);
        void OnUpdate(ModelBase model);
        void OnCreate();

        void OnNextLayer(int id);
        void OnPrevLayer();
    }
    public class EditorController
    {
        private readonly IGridController _gridController;
        private readonly EditorStateMachine _stateMachine;
        
        [Inject]
        public EditorController(IGridController gridController)
        {
            _gridController = gridController;
        }
    }
}
