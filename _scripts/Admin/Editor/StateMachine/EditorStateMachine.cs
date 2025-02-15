
using Pryanik.Admin.Editor.UI;
using Pryanik.DB.ModelControllers;
using Pryanik.Db.Models;
using Task = System.Threading.Tasks.Task;

namespace Pryanik.Admin.Editor.StateMachine
{
    public class EditorStateMachine
    {
        private EditorState _curState;

        private readonly EditorState _theme, _test, _question, _answer;
        private EditorMode _mode = EditorMode.Navigation;
        
        public EditorStateMachine(IModelControllerHub controllerHub, IEditorWindowsManager editorWindowsManager,IGridController gridController, IModelControllerHub modelControllerHub)
        {
            var factory = new EditorStateFactory(gridController, modelControllerHub, editorWindowsManager, this);
            
            _theme = factory.GetThemeState();
            _test = factory.GetTestState();
            _question = factory.GetQuestionState();
            _answer = factory.GetAnswerState();
            
            SwitchState(EditorObject.Theme);
        }
        
        public void SwitchState(EditorObject editorObject,int upperId = -1)
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
            
            if(upperId != -1)
                _curState.SetUpperId(upperId);
            _curState.OnStateEnter();
        }

        public async Task OnCreate()
        {
            await _curState.OnCreate();
        }
        public async Task OnObjectButtonClick(ModelBase model)
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
                    await _curState.OnUpdate(model);
                    break;
            }
        }

        public void OnPrevLayer()
        {
            _curState.EnterPrevState();
        }

        public void SwitchEditorMode(EditorMode mode)
        {
            _mode = mode;
        }

        public void OnSearch(string searchStr)
        {
            
        }
    }
}
