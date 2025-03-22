using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LocalizationButton : MonoBehaviour
{
    [SerializeField] private Button _localizationButton;

    [SerializeField] private List <Sprite> _sprites;

    [SerializeField] private List<Localization> _localizations;
    [SerializeField] private List<string> _tags;

    private int _currentIndex;

    private void OnEnable()
    {
        _localizationButton.onClick.AddListener(ChangeLanguage);
        GetCurrentLanguage();
    }

    private void OnDisable()
    {
        _localizationButton.onClick.RemoveListener(ChangeLanguage); 
    }

    private void ChangeLanguage()
    {
        print("_currentIndex= " + _currentIndex);

        _currentIndex++;

        if (_currentIndex >= _tags.Count)
        {
            _currentIndex = 0;
        }

        foreach (var localization in _localizations)
        {
            localization.SwitchLanguage(_tags[_currentIndex]);
            _localizationButton.image.sprite = _sprites[_currentIndex];
        }
    }

    private void GetCurrentLanguage()
    {
        switch(YG2.lang)
        {
            case "ru":
                _currentIndex = 0;
                _localizationButton.image.sprite = _sprites[_currentIndex];
                break;
            case "en":
                _currentIndex = 1;
                _localizationButton.image.sprite = _sprites[_currentIndex];
                break;
            case "tr":
                _currentIndex = 2;
                _localizationButton.image.sprite = _sprites[_currentIndex];
                break;
        }
    }
}
