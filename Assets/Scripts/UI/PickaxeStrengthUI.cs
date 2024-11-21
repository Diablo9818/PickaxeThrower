using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickaxeStrengthUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private StrenghtSellPanel _sellPanel;

    private void Awake()
    {
        int strengthCount = PlayerPrefs.GetInt("PickaxeStrenght");
        _text.text = strengthCount.ToString();
    }

    private void OnEnable()
    {
        _sellPanel.OnStrengthCountChanged += UpdateCounterText;
    }

    private void OnDisable()
    {
        _sellPanel.OnStrengthCountChanged -= UpdateCounterText;
    }

    private void UpdateCounterText(int count)
    {
        _text.text = count.ToString();
    }
}
