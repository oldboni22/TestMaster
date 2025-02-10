using System.Collections;
using System.Collections.Generic;
using Pryanik.Admin.Editor.StateMachine;
using Pryanik.Admin.Editor.UI;
using Pryanik.Db.Models;
using UnityEngine;

namespace Pryanik
{
    public abstract class EditorState
    {

        protected readonly EditorStateMachine _stateMachine;
        protected readonly IEditorWindowsManager _editorWindowsManager;
        
        protected int _upperId;
        public abstract void OnDelete(int id);
        public abstract void OnUpdate(ModelBase model);
        public abstract void OnCreate();

        public void SetUpperId(int id) => _upperId = id;
        
        public abstract void OnStateEnter();
        
        public abstract void EnterNextState(int id);
        public abstract void EnterPrevState();

        protected EditorState(EditorStateMachine stateMachine, IEditorWindowsManager editorWindowsManager)
        {
            _stateMachine = stateMachine;
            _editorWindowsManager = editorWindowsManager;
        }
    }
}
