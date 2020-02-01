using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoad : MonoBehaviour
{
    [SerializeField]
    private string mainScene;

    void Start()
    {
        SceneManager.LoadScene(mainScene);
    }
}
