using System;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] StartUIPanel _startUIPanel;
    [SerializeField] BackUIPanel _backUIPanel;

    public Action OnStartButtonClicked;
    public Action OnBackButtonClicked;

    void Awake()
    {
        _startUIPanel.OnStartButtonClicked += _backUIPanel.ShowUIPanel;
        _backUIPanel.OnBackButtonClicked += _startUIPanel.ShowUIPanel;
    }

    void OnDestroy()
    {
        OnStartButtonClicked -= _backUIPanel.ShowUIPanel;
        OnBackButtonClicked -= _startUIPanel.ShowUIPanel;
    }
}
