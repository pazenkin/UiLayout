using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Utilities
{
    public class TooltipSizeCorrector : MonoBehaviour
    {
        [SerializeField] private LayoutElement _spaceLeft;
        [SerializeField] private LayoutElement _spaceRight;
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
        [SerializeField] private float _defaultFontSize = 60f;
        [SerializeField] private float _defaultPreferredWidth = 100000f;

        public IEnumerator CorrectingScale()
        {
            yield return null;
            
            while (_textMeshProUGUI.fontSize < _defaultFontSize && _spaceLeft.preferredWidth > 5f)
            {
                _spaceLeft.preferredWidth /= 10f;
                _spaceRight.preferredWidth /= 10f;

                yield return null;
            }
        }

        public void ReturnToDefault()
        {
            _spaceLeft.preferredWidth = _defaultPreferredWidth;
            _spaceRight.preferredWidth = _defaultPreferredWidth;
        }
    }
}