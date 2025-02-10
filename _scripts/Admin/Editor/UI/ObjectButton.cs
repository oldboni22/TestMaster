using System;
using System.Collections;
using System.Collections.Generic;
using Pryanik.Db.Models;
using TMPro;
using UnityEngine;
using Zenject;

namespace Pryanik.Admin.Editor.UI
{
    public class ObjectButton : MonoBehaviour
    {
        private IEditorController _editorController;
        private ModelBase _model;

        [SerializeField] private TMP_Text _text; 
        
        [Inject]
        private void Init(IEditorController editorController)
        {
            _editorController = editorController;
        }

        public void SetModel(ModelBase model)
        {
            _model = model;
            _text.text = model.Text;
            
            gameObject.SetActive(true);
        }

        public void Reset()
        {
            gameObject.SetActive(false);
        }

        public void OnClick() => _editorController.OnObjectButtonClick(_model);
    }
}
