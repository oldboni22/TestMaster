
using System.Threading.Tasks;
using Pryanik.Admin.Editor.StateMachine;
using Pryanik.Admin.Editor.UI;
using Pryanik.DB.ModelControllers;
using Pryanik.Db.Models;
using Zenject;

namespace Pryanik.Admin.Editor
{
    public enum EditorMode
    {
        Navigation,Edit,Delete
    }
    
    public interface IEditorController
    {
        Task OnObjectButtonClick(ModelBase model);
        Task OnCreate();
        void OnPrevLayer();
        void OnSearch(string searchStr);
        void SwitchState(EditorObject editorObject);
        void SwitchMode(EditorMode mode);
    }
    public class EditorController : IEditorController
    {
        private readonly EditorStateMachine _stateMachine;
        
        [Inject]
        public EditorController(IGridController gridController,IEditorWindowsManager editorWindowsManager,IModelControllerHub modelControllerHub)
        {
            _stateMachine = new EditorStateMachine(modelControllerHub,editorWindowsManager,gridController,modelControllerHub);
        }

        public async Task OnObjectButtonClick(ModelBase model)
        {
            await _stateMachine.OnObjectButtonClick(model);
        }

        public async Task OnCreate()
        {
            await _stateMachine.OnCreate();
        }

        public void OnPrevLayer()
        {
            _stateMachine.OnPrevLayer();
        }

        public void OnSearch(string searchStr)
        {
            _stateMachine.OnSearch(searchStr);
        }

        public void SwitchState(EditorObject editorObject)
        {
            _stateMachine.SwitchState(editorObject);
        }

        public void SwitchMode(EditorMode mode)
        {
            _stateMachine.SwitchEditorMode(mode);
        }
    }
}
