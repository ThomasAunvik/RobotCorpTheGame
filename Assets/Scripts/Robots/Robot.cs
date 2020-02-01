using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Robot", menuName = "RoboGame/Robot", order = 3)]
public class Robot : ScriptableObject
{
    public Item wantsItem;
    public GameObject prefab;
}
