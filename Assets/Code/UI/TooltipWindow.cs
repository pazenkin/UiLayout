using System.Collections;
using Code.Inventory;
using Code.UI.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class TooltipWindow : BaseWindow
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Image _icon;
        [SerializeField] private TooltipSizeCorrector _tooltipSizeCorrector;
        
        protected override void PreShow(params object[] args)
        {
            _canvasGroup.interactable = true;
            var item = (InventoryItem)args[0];
            
            _title.text = item.Title;
            _description.text = item.Description;
            _icon.sprite = item.Icon;
        }

        protected override IEnumerator PostShow(object[] args)
        {
            yield return _tooltipSizeCorrector.CorrectingScale();
            _canvasGroup.alpha = 1f;
        }

        protected override void PostHide()
        {
            _canvasGroup.interactable = false;
            _canvasGroup.alpha = 0f;
            _tooltipSizeCorrector.ReturnToDefault();
        }
    }
}