using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private static Storage instance;
    public static Storage _instance { get {
            if (instance) return instance;
            else return new Storage();
        } }

    private void Awake()
    {
        if (!instance)
            DontDestroyOnLoad(gameObject);
        else Destroy(this);
    }

    public float coins = 0;
}
