using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickaxeCountShower : MonoBehaviour
{
    [SerializeField] private Shooter _shooter;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        _text.text = PlayerPrefs.GetInt("Pickaxe").ToString();
    }

    private void OnEnable()
    {
        _shooter.TotalCountChanged += UpdateCounterText;
    }

    private void OnDisable()
    {
        _shooter.TotalCountChanged -= UpdateCounterText;
    }

    void UpdateCounterText(int count)
    {
        _text.text = count.ToString();
    }
}
