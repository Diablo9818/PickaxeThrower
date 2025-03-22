using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoosePanel : MonoBehaviour
{
    [SerializeField] private Button _restartLevelButton;
    [SerializeField] private Button _quitButton;
    
    private LevelSpawner _levelSpawner;

    public void Init(LevelSpawner levelSpawner)
    {
        _levelSpawner = levelSpawner;
        
        _restartLevelButton.onClick.AddListener(RestartLevel);
        _quitButton.onClick.AddListener(QuitGame);
    }
    
    private void OnDisable()
    {
        _restartLevelButton.onClick.RemoveListener(RestartLevel);
        _quitButton.onClick.RemoveListener(QuitGame);
    }

    private void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    private void RestartLevel()
    {
        _levelSpawner.RestartLevel();
        print("Level restarted!");
    }
}
