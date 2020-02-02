using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private static Storage instance;
    public static Storage _instance { get {
            if (instance) return instance;
            else return null;
        } }

    private void Awake()
    {
        if (instance)
            Destroy(this);

        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public float coins = 0;
}
