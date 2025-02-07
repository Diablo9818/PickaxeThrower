using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "LocalizationData", menuName = "Data/LocalizationData", order = 1)]
public class LocalizationData : ScriptableObject
{
    [SerializeField] private TMP_FontAsset _ruFont;
    [SerializeField] private TMP_FontAsset _trFont;

    public TMP_FontAsset RuFont => _ruFont;
    public TMP_FontAsset TrFont => _trFont;
}
