using LayerLab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_UI : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _loosePanel;

    public void ShowLoseWindow()
    {
        GamePhase.Pause();
        _loosePanel.gameObject.SetActive(true);
    }

    public void ShowWinWindow()
    {
        GamePhase.Pause();
        _winPanel.gameObject.SetActive(true);
        print("You win");
    }
}
