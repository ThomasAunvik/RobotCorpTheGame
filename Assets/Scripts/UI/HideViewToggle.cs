using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HideViewToggle : MonoBehaviour
{
    enum DefaultViewState
    {
       None, View, Hidden
    }

    [SerializeField]
    private Button button;
    [SerializeField]
    private TMP_Text button_text;

    [SerializeField]
    private string toggleOnText = "";
    [SerializeField]
    private string toggleOffText = "";

    [SerializeField]
    private RectTransform targetToggle;

    [SerializeField]
    private DefaultViewState defaultViewState;

    private void Awake()
    {
        button.onClick.AddListener(ToggleView);

        if (defaultViewState == DefaultViewState.None) return;
        targetToggle.gameObject.SetActive(defaultViewState == DefaultViewState.View);
        UpdateText();
    }

    private void ToggleView()
    {
        targetToggle.gameObject.SetActive(!targetToggle.gameObject.activeSelf);
        UpdateText();

    }

    private void UpdateText()
    {
        if (button_text)
        {
            button_text.text = targetToggle.gameObject.activeSelf ? toggleOnText : toggleOffText;
        }
    }
}
