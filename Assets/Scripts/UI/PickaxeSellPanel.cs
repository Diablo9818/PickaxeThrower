using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PickaxeSellPanel : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Button _buyButton;
    [SerializeField] private TextMeshProUGUI  _priceText;
    [SerializeField] private int _price;
    public event UnityAction<int> OnPickaxesCountChanged;

    public void Init(Wallet wallet)
    {
        _wallet = wallet;
    }

    private void OnEnable()
    {
        _priceText.text = $"{_price}";
        _buyButton.onClick.AddListener(SellPickaxe);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(SellPickaxe);
    }

    private void SellPickaxe()
    {
        if(_wallet.isEnought(_price))
        {
            _wallet.RemoveCoins(_price);
            int pickaxeCount = PlayerPrefs.GetInt("Pickaxe");
            pickaxeCount += 1;
            PlayerPrefs.SetInt("Pickaxe", pickaxeCount);
            OnPickaxesCountChanged?.Invoke(pickaxeCount);
            print("Sell is done");
        }
        else
        {
            print("No money");
        }
    }
}