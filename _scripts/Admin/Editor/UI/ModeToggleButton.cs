using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pryanik.Admin.Editor.UI
{
    public  class ModeToggleButton : MonoBehaviour
    {
        
        
        [SerializeField] private EditorMode _mode;
        [SerializeField] private Color _activeColor;

        [Header("UiElements")]
        [SerializeField] private Button _button;
        
        
        private EditorButtonsController _buttonsController;
        private bool _isActive = false;

        [Inject] private IEditorController _editorController;
        
        public void SetActive(bool val)
        {
            _isActive = val;
            if (_isActive)
            {
                _buttonsController.ResetButtonStates();
                _editorController.SwitchMode(_mode);
                SetSelectedColor();
            }
            else
            {
                _editorController.SwitchMode(EditorMode.Navigation);
                SetBaseColor();
            }
        }

        public void SetController(EditorButtonsController controller) => _buttonsController = controller;

        void SetSelectedColor()
        {
            _button.image.DOKill();
            _button.image.DOColor(_activeColor,.75f).SetLoops(-1,LoopType.Yoyo);
        }

        void SetBaseColor()
        {
            _button.image.DOKill();
            _button.image.DOColor(_buttonsController.baseButtonsColor,.35f);
        }

    }
}
