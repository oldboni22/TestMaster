using Pryanik;
using Pryanik.DB;
using Pryanik.DB.ModelControllers;
using Pryanik.Db.Models;
using UnityEngine;
using Zenject;

namespace Pryanik
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private string _dbName;

        public override void InstallBindings()
        {

            Container.BindInterfacesTo<DbConnectionManager>().FromInstance(new DbConnectionManager(_dbName)).AsCached();

            Container.BindInterfacesTo<ModelControllerHub>().FromNew().AsCached();

            Container.BindInterfacesTo<AdminManager>().FromNew().AsCached();
            Container.BindInterfacesTo<UserManager>().FromNew().AsCached();
            Container.BindInterfacesTo<SelectedTestManager>().FromNew().AsCached();
        }



    }
}