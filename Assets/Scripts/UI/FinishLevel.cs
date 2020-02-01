using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishLevel : MonoBehaviour
{
    [SerializeField]
    private string mainScene;
    [SerializeField]
    private Button endButton;
    [SerializeField]
    private TMP_Text endText;
    [SerializeField]
    private RectTransform endUI;
    [SerializeField]
    private Slider progressSlider;
    [SerializeField]
    private TMP_Text secondsLeftText;
    [SerializeField]
    private int timeToFinish = 10;

    void Start()
    {
        endUI.gameObject.SetActive(false);
        endButton.onClick.AddListener(ReturnToMain);
    }

    private void Update()
    {
        float secondsLeft = timeToFinish - Time.timeSinceLevelLoad;
        secondsLeftText.text = "Seconds Left: " + (secondsLeft < 0 ? 0 : (int)secondsLeft);
    }

    public void EndLevel()
    {
        int coins = 0;
        if (progressSlider.value >= 30) coins = 10;
        if (progressSlider.value >= 60) coins = 15;
        if (progressSlider.value >= 90) coins = 25;
        if (progressSlider.value >= 100) coins = 40;

        endUI.gameObject.SetActive(true);
        endText.text = "You earned " + coins + " coins.";
        if (Storage._instance)
        {
            Storage._instance.coins += coins;
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log("Update");
    }

    private void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log("LateUpdate");
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(mainScene);
    }
}
