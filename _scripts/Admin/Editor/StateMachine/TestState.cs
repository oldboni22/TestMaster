using System.Threading.Tasks;
using Pryanik._scripts.Admin.Editor;
using Pryanik.Admin.Editor.UI;
using Pryanik.DB.ModelControllers;
using Pryanik.Db.Models;

namespace Pryanik.Admin.Editor.StateMachine
{
    public class TestState : EditorState
    {

        private readonly ITestController _testController;
        public TestState(EditorStateMachine stateMachine, IEditorWindowsManager editorWindowsManager, IGridController gridController,ITestController testController) : base(stateMachine, editorWindowsManager, gridController)
        {
            _testController = testController;
        }

        public override void OnDelete(int id)
        {
            _testController.Delete(id);
            _gridController.Display(_testController.GetByThemeId(_upperId));
        }

        public override async Task OnUpdate(ModelBase model)
        {
            _editorWindowsManager.OpenUpdateWindow(EditorObject.Test,model);
            await _editorWindowsManager.WindowOpenedWaiter();
            _gridController.Display(_testController.GetByThemeId(_upperId));
        }

        public override async Task OnCreate()
        {
            _editorWindowsManager.OpenCreateWindow(EditorObject.Test);
            await _editorWindowsManager.WindowOpenedWaiter();
            _gridController.Display(_testController.GetByThemeId(_upperId));
            
        }

        public override void OnStateEnter()
        {
            _gridController.Display(_testController.GetByThemeId(_upperId));
        }

        public override void EnterNextState(int id)
        {
            _stateMachine.SwitchState(EditorObject.Question,id);
        }

        public override void EnterPrevState()
        {
            _stateMachine.SwitchState(EditorObject.Theme);
        }
    }
}