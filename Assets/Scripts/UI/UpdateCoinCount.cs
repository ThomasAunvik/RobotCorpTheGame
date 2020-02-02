using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateCoinCount : MonoBehaviour
{
    [SerializeField]
    private TMP_Text coinText;

    void Start()
    {
        if (Storage._instance)
        {
            coinText.text = Storage._instance.coins.ToString();
        }
    }
}
