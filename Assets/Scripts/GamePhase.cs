using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GamePhase
{
    private  bool _isPaused;
    private  bool _isActive;

    public  bool IsPaused=> _isPaused;
    public bool IsActive => _isActive;

    public void Activate()
    {
        _isActive = true;
        _isPaused = false;
        Time.timeScale = 1;
        Debug.Log("Game is active");
    }

    public  void Pause()
    {
        _isActive = false;
        _isPaused = true;
        Time.timeScale = 0;
        Debug.Log("Game is paused");
    }

}
