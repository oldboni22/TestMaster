using System.Threading.Tasks;
using Pryanik.Admin.Editor.UI;
using Pryanik.DB.ModelControllers;
using Pryanik.Db.Models;

namespace Pryanik.Admin.Editor.StateMachine
{
    public class ThemeState : EditorState
    {
        private readonly IThemeController _themeController;
        
        public ThemeState(EditorStateMachine stateMachine, IEditorWindowsManager editorWindowsManager, IGridController gridController,IThemeController themeController) : base(stateMachine, editorWindowsManager, gridController)
        {
            _themeController = themeController;
        }

        public override void OnDelete(int id)
        {
            _themeController.Delete(id);
            _gridController.Display(_themeController.GetAll());
        }

        public override async Task OnUpdate(ModelBase model)
        { 
            var theme = (Theme)await _editorWindowsManager.OpenUpdateWindow(EditorObject.Theme, model);
            _themeController.Update(theme);
            _gridController.Display(_themeController.GetAll());
        }

        public override async Task OnCreate()
        {
            var theme = (Theme)await _editorWindowsManager.OpenCreateWindow(EditorObject.Theme,-1);
            _themeController.Create(theme);
            _gridController.Display(_themeController.GetAll());
        }

        public override void OnStateEnter()
        {
            _gridController.Display(_themeController.GetAll());
        }

        public override void EnterNextState(int id)
        {
            _stateMachine.SwitchState(EditorObject.Test,id);
        }

        public override void EnterPrevState(){}
    }
}