using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Pryanik.Db.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pryanik.Admin.Editor.UI
{
    public class UpdateCreateWindow : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private TMP_InputField _inputField;
        private TMP_Text _placeholder;
        
        [Header("TestSpecific")] 
        [SerializeField]
        private Slider _durSlider, _lenSlider;
        [SerializeField] private TMP_Text _durLabel, _lenLabel;

        [Header("AnswerSpecific")] 
        [SerializeField]
        private Toggle _correctToggle;


        private void Start()
        {
            _placeholder = _inputField.placeholder.GetComponent<TMP_Text>();
        }

        #region ModeSetters

        void SetInputField(string placeholder, string text)
        {
            _inputField.text = text;
            _placeholder.text = placeholder;
        }
        void SwitchTestSpecific(bool val)
        {
            _durLabel.gameObject.SetActive(val);
            _durSlider.gameObject.SetActive(val);
            
            _lenLabel.gameObject.SetActive(val);
            _lenSlider.gameObject.SetActive(val);
        }
        void SwitchAnswerSpecific(bool val)
        {
            _correctToggle.gameObject.SetActive(val);
        }
        
        void EnterThemeMode([CanBeNull] Theme theme)
        {
            SwitchAnswerSpecific(false);
            SwitchTestSpecific(false);

            var text = theme == null ? "" : theme.Text;
            
            SetInputField("Название темы",text);
        }

        void EnterTestMode([CanBeNull] Test test)
        {
            SwitchAnswerSpecific(false);
            SwitchTestSpecific(true);

            bool isUpdate = test != null;

            if (isUpdate)
            {
                SetInputField("Название теста", test.Text);
                _durLabel.text = $"{test.Duration}";
                _durSlider.value = test.Duration;
                _lenLabel.text = $"{test.Length}";
                _lenSlider.value = test.Length;
            }
            else
            {
                SetInputField("Название теста", "");
                _durLabel.text = $"0";
                _durSlider.value = 0;
                _lenLabel.text = $"0";
                _lenSlider.value = 0;
            }
        }
        void EnterThemeMode([CanBeNull] Question question)
        {
            SwitchAnswerSpecific(false);
            SwitchTestSpecific(false);

            var text = question == null ? "" : question.Text;
            
            SetInputField("Текст вопроса",text);
        }

        void EnterAnswerMode([CanBeNull] Answer answer)
        {
            SwitchAnswerSpecific(true);
            SwitchTestSpecific(false);

            bool isUpdate = answer != null;

            if (isUpdate)
            {
                SetInputField("Текст ответа", answer.Text);
                _correctToggle.isOn = answer.IsCorrect;
            }
            else
            {
                SetInputField("Текст ответа", "");
                _correctToggle.isOn = false;
            }
        }
        #endregion
        
        
        
    }
}
