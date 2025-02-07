using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet_UI : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TextMeshProUGUI _text;

    public void Init(Wallet wallet)
    {
        _wallet = wallet;
        _text.text = _wallet.Coins.ToString();
        _wallet.TotalCoinsChanged += UpdateCounterText;
        Debug.Log("waleet has been inicialized");
    }

    private void OnDisable()
    {
        _wallet.TotalCoinsChanged -= UpdateCounterText;
    }

    private void UpdateCounterText(int count)
    {
        _text.text = count.ToString();
    }
}
