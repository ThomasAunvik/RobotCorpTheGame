using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "RoboGame/Item", order = 2)]
public class Item : ScriptableObject
{
    [SerializeField]
    public string id;
    [SerializeField]
    public GameObject prefab;
}
