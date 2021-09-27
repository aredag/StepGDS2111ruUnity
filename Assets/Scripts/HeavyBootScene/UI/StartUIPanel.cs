using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StartUIPanel : BaseUIPanel
{
#region Serialized Fields

    [SerializeField] Button _startButton;
    [SerializeField] int _startSceneIndex = 1;

#endregion

#region Events
    public Action OnStartButtonClicked;
#endregion
    public override void Initialize()
    {
       base.Initialize();
       _startButton.onClick.AddListener(() => OnStartButtonClicked?.Invoke());
       _startButton.onClick.AddListener(LoadStartScene); 
    }

    public override void DeInitialize()
    {
        base.DeInitialize();
       _startButton.onClick.RemoveAllListeners(); 
    }

    void LoadStartScene()
    {
        HideUIPanel();
        Generator.GenerateTextures();
        LoadScene.LoadSceneAsyncWithIndex(_startSceneIndex);    
    }

}
