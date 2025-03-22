using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickAxeMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private PickaxeSellPanel _sellPanel;

    private void Awake()
    {
        int pickaxeCount = PlayerPrefs.GetInt("Pickaxe");
        _text.text = pickaxeCount.ToString();
    }

    private void OnEnable()
    {
        _sellPanel.OnPickaxesCountChanged += UpdateCounterText;
    }

    private void OnDisable()
    {
        _sellPanel.OnPickaxesCountChanged -= UpdateCounterText;
    }

    private void UpdateCounterText(int count)
    {
        _text.text = count.ToString();
    }
}
