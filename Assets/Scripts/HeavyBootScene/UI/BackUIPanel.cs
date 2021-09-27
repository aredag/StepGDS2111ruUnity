using System;
using UnityEngine;
using UnityEngine.UI;

public class BackUIPanel : BaseUIPanel 
{
#region Serialized Fields
    [SerializeField] Button _backButton;
    [SerializeField] int _sceneIndexToUnload = 1;
#endregion
#region Events
    public Action OnBackButtonClicked;
#endregion
    public override void Initialize()
    {
        base.Initialize();
        HideUIPanel();
        BackToMainMenu();
    }

    void BackToMainMenu()
    {
        _backButton.onClick.AddListener(delegate
        {
             LoadScene.UnloadSceneAsyncWithIndex(_sceneIndexToUnload); 
             HideUIPanel();
        });
        
       _backButton.onClick.AddListener(() => OnBackButtonClicked?.Invoke());
    }


    public override void DeInitialize()
    {
        base.DeInitialize();
        _backButton.onClick.RemoveAllListeners();
    }
}
