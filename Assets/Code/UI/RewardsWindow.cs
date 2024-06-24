using System.Collections;
using System.Collections.Generic;
using Code.Inventory;
using Code.UI.Elements;
using Code.UI.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardsWindow : BaseWindow
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private Transform _contentParent;
    [SerializeField] private ScrollRectCorrector _scrollRectCorrector;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private ScrollRect _scrollRect;
    
    [Space]
    [SerializeField] private InventoryItemUi _itemUiPrefab;

    private readonly List<InventoryItemUi> _activeItems = new();
    
    protected override void Awake()
    {
        base.Awake();
        _closeButton.onClick.AddListener(Hide);
    }

    protected override void PreShow(params object[] args)
    {
        _titleText.text = (string)args[0];
        var items = (List<InventoryItem>)args[1];
        
        foreach (var inventoryItem in items)
        {
            var itemUi = Instantiate(_itemUiPrefab, _contentParent);
            itemUi.Construct(inventoryItem, this);
            _activeItems.Add(itemUi);
        }
    }

    protected override IEnumerator PostShow(object[] args)
    {
        yield return null;
        _scrollRectCorrector.Reload();
        yield return null;
        _canvasGroup.alpha = 1f;
        _canvasGroup.interactable = true;
    }

    protected override IEnumerator PreHide()
    {
        _canvasGroup.interactable = false;
        _canvasGroup.alpha = 0f;
        yield return null;
    }

    protected override void PostHide()
    {
        foreach (var item in _activeItems)
        {
            Destroy(item.gameObject);
        }
        _activeItems.Clear();
    }
    
    public void ChangeScrollRectInteractive(bool value)
    {
        _scrollRect.enabled = value;
    }
}