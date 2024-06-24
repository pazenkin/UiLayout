using System.Collections;
using UnityEngine;

public abstract class BaseWindow : MonoBehaviour
{
    public static TWindow Get<TWindow>() where TWindow : BaseWindow
    {
        return FindObjectOfType<TWindow>(true);
    }
        
    private bool _awaiting = false;
    
    protected virtual void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void Show(params object[] args)
    {
        if (_awaiting) return;
        _awaiting = true;
        PreShow(args);
        gameObject.SetActive(true);
        StartCoroutine(ShowCoroutine(args));
    }

    private IEnumerator ShowCoroutine(params object[] args)
    {
        yield return PostShow(args);
        _awaiting = false;
    }
    
    public void Hide()
    {
        if (_awaiting) return;
        _awaiting = true;
        StartCoroutine(HideCoroutine());
    }
    
    private IEnumerator HideCoroutine()
    {
        yield return PreHide();
        gameObject.SetActive(false);
        PostHide();
        _awaiting = false;
    }

    protected virtual void PreShow(params object[] args) { }
    protected virtual IEnumerator PostShow(object[] args) { yield return null; }
    protected virtual IEnumerator PreHide() { yield return null; }
    protected virtual void PostHide() { }
}