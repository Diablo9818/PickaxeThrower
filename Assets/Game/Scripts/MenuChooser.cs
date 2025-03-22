using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChooser : MonoBehaviour
{
    [SerializeField] private Canvas _albomMenuUI;
    [SerializeField] private Canvas _portraintMenuUI;

    private Canvas _menuUI;

    public void Init(bool isOrientationPortrait)
    {
        if (isOrientationPortrait)
        {
            _menuUI = _portraintMenuUI;
        }
        else
        {
            _menuUI = _albomMenuUI;
        }

    }

    public void ShowMenu()
    {
        _menuUI.gameObject.SetActive(true);
    }
}
