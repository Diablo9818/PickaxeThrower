using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCountShower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private EnemyLevelController _controller;


    public void Init(EnemyLevelController enemyLevelController)
    {
        _controller = enemyLevelController;
        
        _text.text = _controller.TotalEnemy.ToString()+"/"+ _controller.TotalEnemy;
        _controller.TotalCountChanged += UpdateCounterText;
        Debug.Log("EnemyCountShower is active");
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
