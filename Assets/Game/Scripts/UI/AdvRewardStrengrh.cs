using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YG;

public class AdvRewardStrengrh : MonoBehaviour
{
    [SerializeField] private string rewardID;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Button _advButton;

    public event UnityAction<int> OnStrengthCountChanged;


    private void OnEnable()
    {
        _advButton.onClick.AddListener(MyRewardAdvShow);
    }

    private void OnDisable()
    {
        _advButton.onClick.RemoveListener(MyRewardAdvShow);
    }

    public void MyRewardAdvShow()
    {
        YG2.RewardedAdvShow(rewardID, () =>
        {
            int pickaxeStrenght = PlayerPrefs.GetInt("PickaxeStrenght");
            pickaxeStrenght += 1;
            PlayerPrefs.SetInt("PickaxeStrenght", pickaxeStrenght);
            OnStrengthCountChanged?.Invoke(pickaxeStrenght);
            gameObject.SetActive(false);
            _sellButton.gameObject.SetActive(true);
        });
    }
}

