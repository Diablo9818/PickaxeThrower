using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YG;

public class StrengthSellPanel:MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Button _buyButton;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private int _price;
    [SerializeField] private Button _advButton;
    [SerializeField] private string rewardID;

    private int _touchCount = 0;

    public event UnityAction<int> OnStrengthCountChanged;

    public void Init(Wallet wallet)
    {
        _wallet = wallet;
    }

    private void OnEnable()
    {
        _priceText.text = $"{_price}";
        _buyButton.onClick.AddListener(SellStrenght);
        _advButton.onClick.AddListener(MyRewardAdvShow);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(SellStrenght);
        _advButton.onClick.RemoveListener(MyRewardAdvShow);
    }

    private void SellStrenght()
    {
        if (_wallet.isEnought(_price))
        {
            _wallet.RemoveCoins(_price);
            AddStrength();
            _touchCount++;

            if (_touchCount >= 4)
            {
                _buyButton.gameObject.SetActive(false);
                _advButton.gameObject.SetActive(true);
                _touchCount = 0;
            }
            print("Sell is done");
        }
    }

    private void MyRewardAdvShow()
    {
        YG2.RewardedAdvShow(rewardID, () =>
        {
            AddStrength();
            _advButton.gameObject.SetActive(false);
            _buyButton.gameObject.SetActive(true);
        });
    }

    private void AddStrength()
    {
        int pickaxeStrenght = PlayerPrefs.GetInt("PickaxeStrenght");
        pickaxeStrenght += 1;
        PlayerPrefs.SetInt("PickaxeStrenght", pickaxeStrenght);
        OnStrengthCountChanged?.Invoke(pickaxeStrenght);
    }
}