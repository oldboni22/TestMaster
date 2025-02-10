using System.Collections;
using System.Collections.Generic;
using Pryanik._scripts.Admin.Editor;
using Pryanik.Admin.Editor.UI;
using Pryanik.DB.ModelControllers;
using Pryanik.Db.Models;
using UnityEngine;

namespace Pryanik.Admin.Editor.StateMachine
{
    public class EditorStateMachine
    {
        private EditorState _curState;

        private EditorState _theme, _test, _question, _answer;
        private EditorObject _curObj;

        public EditorStateMachine(IModelControllerHub controllerHub, IEditorWindowsManager editorWindowsManager)
        {
            
        }
        
        public void SwitchState(EditorObject editorObject)
        {
            switch (editorObject)
            {
                case EditorObject.Theme:
                    _curState = _theme;
                    break;
                case EditorObject.Test:
                    _curState = _test;
                    break;
                case EditorObject.Answer:
                    _curState = _answer;
                    break;
                case EditorObject.Question:
                    _curState = _question;
                    break;
            }
        }
        
        public void OnDelete(int id)
        {
            _curState.OnDelete(id);
        }

        public void OnUpdate(ModelBase model)
        {
            _curState.OnUpdate(model);
        }

        public void OnCreate()
        {
            _curState.OnCreate();
        }

        public void OnNextLayer(int id)
        {
            _curState.EnterNextState(id);            
        }

        public void OnPrevLayer()
        {
            _curState.EnterPrevState();
        }
    }
}
