using Pryanik;
using Pryanik.DB;
using Pryanik.DB.ModelControllers;
using Pryanik.Db.Models;
using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    [SerializeField] private string _dbName;
    public override void InstallBindings()
    {

        Container.BindInterfacesTo<DbConnectionManager>().FromInstance(new DbConnectionManager(_dbName)).AsCached();    
        
        BindModelManagers();
        
        Container.BindInterfacesTo<AdminManager>().FromNew().AsCached();
        Container.BindInterfacesTo<UserManager>().FromNew().AsCached();
        Container.BindInterfacesTo<SelectedTestManager>().FromNew().AsCached();
    }

    void BindModelManagers()
    {
        Container.Bind<IThemeController>().To<ThemeController>().FromNew().AsCached();
        Container.Bind<ITestController>().To<TestController>().FromNew().AsCached();
        Container.Bind<IQuestionController>().To<QuestionController>().FromNew().AsCached();
        Container.Bind<IAnswerController>().To<AnswerController>().FromNew().AsCached();
    }
    
}