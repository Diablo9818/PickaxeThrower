using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YG;

public class PickaxeSellPanel : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Button _buyButton;
    [SerializeField] private TextMeshProUGUI  _priceText;
    [SerializeField] private int _price;
    [SerializeField] private Button _advButton;
    [SerializeField] private string rewardID;
    public event UnityAction<int> OnPickaxesCountChanged;

    private int _touchCount = 0;

    public void Init(Wallet wallet)
    {
        _wallet = wallet;
    }

    private void OnEnable()
    {
        _priceText.text = $"{_price}";
        _buyButton.onClick.AddListener(SellPickaxe);
        _advButton.onClick.AddListener(MyRewardAdvShow);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(SellPickaxe);
        _advButton.onClick.RemoveListener(MyRewardAdvShow);
    }

    private void SellPickaxe()
    {
        if (_wallet.isEnought(_price))
        {
            _wallet.RemoveCoins(_price);
            AddPickAxe();
            print("Sell is done");
            _touchCount++;

            if (_touchCount >= 4)
            {
                _buyButton.gameObject.SetActive(false);
                _advButton.gameObject.SetActive(true);
                _touchCount = 0;
            }

        }
    }

    private void MyRewardAdvShow()
    {
        YG2.RewardedAdvShow(rewardID, () =>
        {
            AddPickAxe();
            _advButton.gameObject.SetActive(false);
            _buyButton.gameObject.SetActive(true);

        });
    }

    private void AddPickAxe()
    {
        int pickaxeCount = PlayerPrefs.GetInt("Pickaxe");
        pickaxeCount += 1;
        PlayerPrefs.SetInt("Pickaxe", pickaxeCount);
        OnPickaxesCountChanged?.Invoke(pickaxeCount);
    }
}