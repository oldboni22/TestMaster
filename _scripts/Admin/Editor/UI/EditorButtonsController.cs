using System;
using UnityEngine;

namespace Pryanik.Admin.Editor.UI
{
    public interface IEditorButtonsController
    {
        void BlockCreateButton();
        void ResetButtonStates();
    }
    public class EditorButtonsController : MonoBehaviour, IEditorButtonsController
    {
        [SerializeField] private ModeToggleButton _delete, _edit;
        [SerializeField] public Color baseButtonsColor;
        private void Start()
        {
            _delete.SetController(this);
            _edit.SetController(this);
        }

        public void BlockCreateButton()
        {
            
        }

        public void ResetButtonStates()
        {
            _delete.SetActive(false);
            _edit.SetActive(false);
        }
    }
}