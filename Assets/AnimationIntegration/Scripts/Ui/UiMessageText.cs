using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class UiMessageText : MonoBehaviour
{
    private TMP_Text _uiMessageText;
    private readonly Dictionary<UiMessageType, string> _uiMsgDictionary = new Dictionary<UiMessageType, string>();
    private readonly string[] UI_MESSAGES =
    {
        "",
        "Нажмите ПРОБЕЛ для добивания"
    };

    private void Awake()
    {
        _uiMessageText = GetComponent<TMP_Text>();
        _uiMsgDictionary.Add(UiMessageType.None, UI_MESSAGES[0]);
        _uiMsgDictionary.Add(UiMessageType.FinishEnemy, UI_MESSAGES[1]);
    }

    private void OnEnable()
    {
        EventManager.OnShowUiMessage.AddListener(ShowUiMessage);
    }

    private void ShowUiMessage(UiMessageType type)
    {
        _uiMessageText.text = _uiMsgDictionary[type];
    }
}
