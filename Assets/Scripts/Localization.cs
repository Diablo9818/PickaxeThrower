using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Localization : MonoBehaviour
{
    public string ru, en, tr;

    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private LocalizationData _localizationData;

    private void Awake()
    {
        SwitchLanguage(YG2.lang);
    }

    public void SwitchLanguage(string lang)
    {
        switch (lang)
        {
            case "ru":
                textComponent.text = ru;
                textComponent.font = _localizationData.RuFont;
                YG2.SwitchLanguage(lang);
                break;
            case "tr":
                textComponent.text = tr;
                textComponent.font = _localizationData.TrFont;
                YG2.SwitchLanguage(lang);
                break;
            default:
                textComponent.text = en;
                YG2.SwitchLanguage(lang);
                break;
        }
    }
}
