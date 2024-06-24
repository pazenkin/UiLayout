using System.Collections;
using Code.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Code.UI.Elements
{
    public class InventoryItemUi : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Image _icon;

        private const float DELAY = 0.5f;

        private InventoryItem _data;
        private Coroutine _timerCoroutine;
        private RewardsWindow _rewardsWindow;

        public void Construct(InventoryItem data, RewardsWindow rewardsWindow)
        {
            _data = data;
            _icon.sprite = _data.Icon;
            _rewardsWindow = rewardsWindow;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _timerCoroutine = StartCoroutine(DownObserver());
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            StopCoroutine(_timerCoroutine);
        }

        private IEnumerator DownObserver()
        {
            yield return new WaitForSeconds(DELAY);
            BaseWindow.Get<TooltipWindow>().Show(_data);
            _rewardsWindow.ChangeScrollRectInteractive(false);
            StartCoroutine(UpObserver());
        }

        private IEnumerator UpObserver()
        {
            do
            {
                yield return null;
            } while (Input.GetMouseButton(0));
            
            BaseWindow.Get<TooltipWindow>().Hide();
            _rewardsWindow.ChangeScrollRectInteractive(true);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}