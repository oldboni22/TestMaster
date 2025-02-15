using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Pryanik.Admin.Editor.UI
{
    public interface ISearchField
    {
        void ResetField();
        void SetActive(bool val);
    }
    public class SearchField : MonoBehaviour
    {
        [Inject]
        private void Init(IEditorController editorController)
        {
            GetComponent<TMP_InputField>().onValueChanged.AddListener(editorController.OnSearch);
        }
    }
}
