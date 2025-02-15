using System.Threading.Tasks;
using Pryanik.Admin.Editor.UI;
using Pryanik.DB.ModelControllers;
using Pryanik.Db.Models;

namespace Pryanik.Admin.Editor.StateMachine
{
    public class QuestionState : EditorState
    {
        private readonly IQuestionController _questionController;
        public QuestionState(EditorStateMachine stateMachine, IEditorWindowsManager editorWindowsManager, IGridController gridController, IQuestionController questionController) : base(stateMachine, editorWindowsManager, gridController)
        {
            _questionController = questionController;
        }

        public override void OnDelete(int id)
        {
            _questionController.Delete(id);
            _gridController.Display(_questionController.GetByTestId(_upperId));
        }

        public override async Task OnUpdate(ModelBase model)
        {
            
            var q = (Question)await _editorWindowsManager.OpenUpdateWindow(EditorObject.Question,model);
            _questionController.Update(q);
            _gridController.Display(_questionController.GetByTestId(_upperId));
        }
        

        public override async Task OnCreate()
        {
            
            var q = (Question)await _editorWindowsManager.OpenCreateWindow(EditorObject.Question,_upperId);
            _questionController.Create(q);
            _gridController.Display(_questionController.GetByTestId(_upperId));
        }

        public override void OnStateEnter()
        {
            _gridController.Display(_questionController.GetByTestId(_upperId));
        }

        public override void EnterNextState(int id)
        {
            _stateMachine.SwitchState(EditorObject.Answer,id);
        }

        public override void EnterPrevState()
        {
            _stateMachine.SwitchState(EditorObject.Test);
        }
    }
}