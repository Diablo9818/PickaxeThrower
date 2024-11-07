using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCountShower : MonoBehaviour
{
    [SerializeField] private EnemyLevelController _controller;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        _text.text = _controller.TotalEnemy.ToString()+"/"+ _controller.TotalEnemy;
    }


    private void OnEnable()
    {
        _controller.TotalCountChanged += UpdateCounterText;
    }

    private void OnDisable()
    {
        _controller.TotalCountChanged += UpdateCounterText;
    }

    void UpdateCounterText(int count)
    {
        _text.text = count.ToString() + "/" + _controller.TotalEnemy;
        print("enemy count changed!");
    }
}
