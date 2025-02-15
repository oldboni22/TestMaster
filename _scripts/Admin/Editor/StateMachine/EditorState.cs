using System.Threading.Tasks;
using Pryanik.Admin.Editor.StateMachine;
using Pryanik.Admin.Editor.UI;
using Pryanik.Db.Models;


namespace Pryanik.Admin.Editor.StateMachine
{
    public abstract class EditorState
    {

        protected readonly EditorStateMachine _stateMachine;
        protected readonly IEditorWindowsManager _editorWindowsManager;
        protected readonly IGridController _gridController;
        
        protected int _upperId;
        public abstract void OnDelete(int id);
        public abstract Task OnUpdate(ModelBase model);
        public abstract Task OnCreate();

        public void SetUpperId(int id) => _upperId = id;
        
        public abstract void OnStateEnter();
        
        public abstract void EnterNextState(int id);
        public abstract void EnterPrevState();

        protected EditorState(EditorStateMachine stateMachine, IEditorWindowsManager editorWindowsManager,IGridController gridController)
        {
            _stateMachine = stateMachine;
            _editorWindowsManager = editorWindowsManager;
            _gridController = gridController;
        }
    }
}
