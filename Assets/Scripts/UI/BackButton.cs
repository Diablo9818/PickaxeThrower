using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject _board;
    [SerializeField] private Button _backButton;
    [SerializeField] private MenuPanel _menuPanel;

    private void OnEnable()
    {
        _backButton.onClick.AddListener(HideBoard);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(HideBoard);
    }

    private void HideBoard()
    {
        _board.SetActive(false);
        _menuPanel.gameObject.SetActive(true);
    }
}
