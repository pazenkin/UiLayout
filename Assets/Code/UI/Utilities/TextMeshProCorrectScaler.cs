using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Utilities
{
    /// <summary>
    /// Более грамотное изменение размера
    /// </summary>
    public class TextMeshProCorrectScaler : MonoBehaviour
    {
        [SerializeField] private LayoutElement _spaceLeft;
        [SerializeField] private LayoutElement _spaceRight;
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
        [SerializeField] private float _defaultFontSize = 60f;
        [SerializeField] private float _defaultPreferredWidth = 100000f;
        
        private string _text;

        public void Update()
        {
            if (_text != _textMeshProUGUI.text)
            {
                StopAllCoroutines();
                StartCoroutine(UpdateTextScale());
                _text = _textMeshProUGUI.text;
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private IEnumerator UpdateTextScale()
        {
            if (_textMeshProUGUI.fontSize < _defaultFontSize && (_spaceLeft.preferredWidth > 5f || _text.Length > _textMeshProUGUI.text.Length))
            {
                _spaceLeft.preferredWidth = _defaultPreferredWidth;
                _spaceRight.preferredWidth = _defaultPreferredWidth;

                while (_textMeshProUGUI.fontSize < _defaultFontSize && _spaceLeft.preferredWidth > 5f)
                {
                    _spaceLeft.preferredWidth /= 10f;
                    _spaceRight.preferredWidth /= 10f;

                    yield return null;
                }
            }
        }
    }
}