using System.Collections;
using System.Collections.Generic;
using Pryanik.Admin.Editor.UI;
using UnityEngine;
using Zenject;

namespace Pryanik.Admin.Editor
{
    
    public class EditorInstaller : MonoInstaller
    {
        [Header("Prefabs")]
        [SerializeField] private ObjectButton _objectButtonPrefab;
        
        [Header("Instances")]
        [SerializeField] private GridController _gridController;

        [SerializeField] private Transform _buttonParent;

        public override void InstallBindings()
        {
            Container.BindMemoryPool<ObjectButtonPool>().WithInitialSize(5).WithFactoryArguments(_buttonParent).FromInstance(_objectButtonPrefab);
            
            Container.BindInterfacesTo<GridController>().FromInstance(_gridController).AsCached();
        }
    }
}
