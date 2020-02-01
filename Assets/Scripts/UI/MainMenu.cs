using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private Button loadingButton;
    [SerializeField]
    private Slider LoadingSlider;

    [Header("Loading")]
    [SerializeField]
    private string scene;
    [SerializeField]
    private float secondsOfLoading = 30;
    [SerializeField]
    [Range(0,100)]
    private float amountOfPercentage = 1;
    [SerializeField]
    private float updateFakeLoading = 1;
    [SerializeField]
    private float loadingLerp = 0.1f;

    private float loadingProgress = 0;
    private bool isLoading = false;


    private void Awake()
    {
        LoadingSlider.gameObject.SetActive(false);
        loadingButton.gameObject.SetActive(true);
        loadingButton.onClick.AddListener(LoadingButton_Pressed);
    }

    private void LoadingButton_Pressed()
    {
        loadingButton.gameObject.SetActive(false);
        LoadingSlider.gameObject.SetActive(true);

        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        float timeUpdate = Time.time;
        float incrimentLoading = amountOfPercentage / secondsOfLoading;

        isLoading = true;
        while (loadingProgress <= amountOfPercentage)
        {
            if(Time.time > timeUpdate + updateFakeLoading)
            {
                loadingProgress += incrimentLoading * updateFakeLoading;
                timeUpdate = Time.time;
            }

            LoadingSlider.value = Mathf.Lerp(LoadingSlider.value, loadingProgress, loadingLerp);
            yield return null;
        }

        AsyncOperation op = SceneManager.LoadSceneAsync(scene);
        while (!op.isDone)
        {
            float calculatedProgress = Mathf.Lerp(loadingProgress, LoadingSlider.maxValue, op.progress);
            LoadingSlider.value = Mathf.Lerp(LoadingSlider.value, calculatedProgress, loadingLerp);
            yield return null;
        }
    }
}
