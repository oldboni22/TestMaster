
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
    }
    public class EditorController
    {
        private readonly EditorStateMachine _stateMachine;
        
        [Inject]
        public EditorController(IGridController gridController,IEditorWindowsManager editorWindowsManager,IModelControllerHub modelControllerHub)
        {
            _stateMachine = new EditorStateMachine(modelControllerHub,editorWindowsManager,gridController,modelControllerHub);
        }
    }
}
