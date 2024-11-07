using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StrenghtSellPanel:MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Button _buyButton;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private int _price;

    public void Init(Wallet wallet)
    {
        _wallet = wallet;
    }

    private void OnEnable()
    {
        _priceText.text = $"{_price}";
        _buyButton.onClick.AddListener(SellStrenght);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(SellStrenght);
    }

    private void SellStrenght()
    {
        if (_wallet.isEnought(_price))
        {
            _wallet.RemoveCoins(_price);
            int pickaxeStrenght = PlayerPrefs.GetInt("PickaxeStrenght");
            pickaxeStrenght += 1;
            PlayerPrefs.SetInt("PickaxeStrenght", pickaxeStrenght);
            print("Sell is done");
        }
        else
        {
            print("No money");
        }
    }
}