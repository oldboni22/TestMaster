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

        private EditorMode _mode = EditorMode.Navigation;
        
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

        public void OnCreate()
        {
            _curState.OnCreate();
        }

        public void OnObjectButtonClick(ModelBase model)
        {
            switch (_mode)
            {
                case EditorMode.Navigation:
                    _curState.EnterNextState(model.ID);
                    break;
                case EditorMode.Delete:
                    _curState.OnDelete(model.ID);
                    break;
                case EditorMode.Edit:
                    _curState.OnUpdate(model);
                    break;
            }
        }

        public void OnPrevLayer()
        {
            _curState.EnterPrevState();
        }
    }
}
