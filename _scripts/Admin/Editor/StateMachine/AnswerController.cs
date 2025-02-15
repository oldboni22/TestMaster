using System.Threading.Tasks;
using Pryanik.Admin.Editor.UI;
using Pryanik.DB.ModelControllers;
using Pryanik.Db.Models;

namespace Pryanik.Admin.Editor.StateMachine
{
    public class AnswerState : EditorState
    {
        private readonly IAnswerController _answerController;
        public AnswerState(EditorStateMachine stateMachine, IEditorWindowsManager editorWindowsManager, IGridController gridController, IAnswerController answerController) : base(stateMachine, editorWindowsManager, gridController)
        {
            _answerController = answerController;
        }

        public override void OnDelete(int id)
        {
            _answerController.Delete(id);
            _gridController.Display(_answerController.GetByQuestionId(_upperId));
        }

        public override async Task OnUpdate(ModelBase model)
        {
            var answer = (Answer)await _editorWindowsManager.OpenUpdateWindow(EditorObject.Answer,model);
            _answerController.Update(answer);
            _gridController.Display(_answerController.GetByQuestionId(_upperId));
        }

        public override async Task OnCreate()
        {
            var answer = (Answer)await _editorWindowsManager.OpenCreateWindow(EditorObject.Answer,_upperId);
            _answerController.Create(answer);
            _gridController.Display(_answerController.GetByQuestionId(_upperId));
        }

        public override void OnStateEnter()
        {
            _gridController.Display(_answerController.GetByQuestionId(_upperId));
        }

        public override void EnterNextState(int id)
        {
        }

        public override void EnterPrevState()
        {
            _stateMachine.SwitchState(EditorObject.Question);
        }
    }
}