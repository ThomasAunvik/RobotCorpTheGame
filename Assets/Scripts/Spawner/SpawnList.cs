using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnList", menuName = "RoboGame/SpawnList", order = 1)]
public class SpawnList : ScriptableObject
{
    public List<GameObject> entities;
}
