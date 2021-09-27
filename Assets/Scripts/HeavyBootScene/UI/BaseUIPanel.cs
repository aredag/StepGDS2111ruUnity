using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class BaseUIPanel : MonoBehaviour, IUIPanel
{
#region Serialized Fields
    [SerializeField] float _showHideDuration = 0.5f;
#endregion

#region Protected Fields
    protected CanvasGroup _canvasGroup;
#endregion


    void Start()
    {
       Initialize(); 
    }

    public virtual void Initialize()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void DeInitialize()
    {
        
    }

    public virtual void ShowUIPanel()
    {
        if(!_canvasGroup) return;
        
        _canvasGroup.DOFade(1, _showHideDuration).OnComplete(delegate
        {
            _canvasGroup.interactable = true;
        });
    }

    public virtual void HideUIPanel()
    {
        if(!_canvasGroup) return;
        
        _canvasGroup.interactable = false;
        _canvasGroup.DOFade(0, _showHideDuration);

    }

    public virtual void ShowUIPanel_Async()
    {
        throw new System.NotImplementedException();
    }

    public virtual void HideUIPanel_Async()
    {
        throw new System.NotImplementedException();
    }

    void OnDestroy()
    {
       DeInitialize(); 
    }
}
