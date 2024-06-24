using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Utilities
{
    public class ScrollRectCorrector : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;

        public void Reload()
        {
            _scrollRect.content.anchoredPosition = new Vector2(_scrollRect.content.sizeDelta.x / 2f, 0f);
        }
    }
}