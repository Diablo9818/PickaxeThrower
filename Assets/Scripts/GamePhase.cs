using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePhase
{
    private static bool _isPaused;
    private static bool _isActive;

    public static bool IsPaused=> _isPaused;
    public static bool IsActive => _isActive;

    public static void Activate()
    {
        _isActive = true;
        _isPaused = false;
        Debug.Log("Game is active");
    }

    public static void Pause()
    {
        _isActive = false;
        _isPaused = true;
        Debug.Log("Game is paused");
    }

}
