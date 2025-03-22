using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickaxeCountShower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Shooter _shooter;

    public void Init(Shooter shooter)
    {
        _shooter = shooter;
        _shooter.TotalCountChanged += UpdateCounterText;
    }

    private void Awake()
    {
        _text.text = PlayerPrefs.GetInt("Pickaxe").ToString();
    }


    private void OnDisable()
    {
        _shooter.TotalCountChanged -= UpdateCounterText;
    }

    private void UpdateCounterText(int count)
    {
        _text.text = count.ToString();
    }
}
