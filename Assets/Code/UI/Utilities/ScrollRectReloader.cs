using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Utilities
{
    /// <summary>
    /// Обновление позиции скроллбара после загрузки контента
    /// </summary>
    public class ScrollRectReloader : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;

        private void OnEnable()
        {
            Reload();
        }

        public void Reload()
        {
            _scrollRect.content.anchoredPosition = new Vector2(_scrollRect.content.sizeDelta.x / 2f, 0f);
        }
    }
}