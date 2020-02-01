using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private SpawnList spawnList;
    [SerializeField]
    private TexScroll conveyorBelt;
    void Start()
    {
        //SpawnRobot(0);
    }

    void Update()
    {
        
    }

    public void SpawnRobot(int spawnNumber)
    {
        if (spawnNumber > spawnList.entities.Count) spawnNumber = spawnList.entities.Count;
        else if (spawnNumber < 0) spawnNumber = 0;

        GameObject robot = Instantiate(spawnList.entities[spawnNumber]);
        robot.transform.position = transform.position;
        robot.GetComponent<ConveyorBeltRobot>().conveyorBelt = conveyorBelt;
    }
}
