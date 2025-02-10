using Zenject;

namespace Pryanik.DB.ModelControllers
{
    public interface IModelControllerHub
    {
        public IThemeController GetThemeController();
        public ITestController GetTestController();
        public IQuestionController GetQuestionController();
        public IAnswerController GetAnswerController();
    }
    
    public class ModelControllerHub : IModelControllerHub
    {
        private readonly IThemeController _themeController;
        private readonly ITestController _testController;
        private readonly IQuestionController _questionController;
        private readonly IAnswerController _answerController;
        
        [Inject]
        public ModelControllerHub(IDbConnectionManager connectionManager)
        {
            _themeController = new ThemeController(connectionManager);
            _testController = new TestController(connectionManager);
            _questionController = new QuestionController(connectionManager);
            _answerController = new AnswerController(connectionManager);
        }

        public IThemeController GetThemeController() => _themeController;

        public ITestController GetTestController() => _testController;

        public IQuestionController GetQuestionController() => _questionController;

        public IAnswerController GetAnswerController() => _answerController;
    }
}