using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _leaderboardButton;

    [SerializeField] private  SettingsPanel _settings;
    [SerializeField] private GameObject _leaderboard;
    [SerializeField] private MenuPanel _menuPanel;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(Play);
        _settingsButton.onClick.AddListener(ShowSettings);
        _leaderboardButton.onClick.AddListener(ShowLeaderboard);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(Play);
        _settingsButton.onClick.RemoveListener(ShowSettings);
        _leaderboardButton.onClick.RemoveListener(ShowLeaderboard);
    }

    private void Play()
    {
        SceneManager.LoadScene("Game");
    }

    private void ShowSettings()
    {
        _menuPanel.gameObject.SetActive(false);
        _settings.gameObject.SetActive(true);
    }

    private void ShowLeaderboard()
    {
        _menuPanel.gameObject.SetActive(false);
        _leaderboard.gameObject.SetActive(true);
    }
}
