using Pryanik.Admin.Editor.UI;
using Pryanik.DB.ModelControllers;

namespace Pryanik.Admin.Editor.StateMachine
{
    public class EditorStateFactory
    {
        private readonly IGridController _gridController;
        private readonly IModelControllerHub _modelControllerHub;
        private readonly IEditorWindowsManager _editorWindowsManager;
        private readonly EditorStateMachine _stateMachine;
        
        public EditorStateFactory(IGridController gridController, IModelControllerHub modelControllerHub, IEditorWindowsManager editorWindowsManager,EditorStateMachine stateMachine)
        {
            _gridController = gridController;
            _modelControllerHub = modelControllerHub;
            _editorWindowsManager = editorWindowsManager;
            _stateMachine = stateMachine;
        }


        public EditorState GetThemeState() => new ThemeState(_stateMachine, _editorWindowsManager, _gridController,
            _modelControllerHub.GetThemeController());

        public EditorState GetTestState() => new TestState(_stateMachine, _editorWindowsManager, _gridController,
            _modelControllerHub.GetTestController());

        public EditorState GetQuestionState() => new QuestionState(_stateMachine, _editorWindowsManager,
            _gridController, _modelControllerHub.GetQuestionController());

        public EditorState GetAnswerState() => new AnswerState(_stateMachine, _editorWindowsManager, _gridController,
            _modelControllerHub.GetAnswerController());
    }
}