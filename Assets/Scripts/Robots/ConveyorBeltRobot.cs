using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltRobot : MonoBehaviour
{
    [SerializeField]
    public Robot robot;

    [System.NonSerialized]
    public TexScroll conveyorBelt;

    public bool recievedOil = false;
    public bool GiveItemOil(Item item)
    {
        if (!recievedOil) recievedOil = true;
        else return false;
        return robot.wantsItem.id == item.id;
    }

    private void Update()
    {
        if(conveyorBelt != null)
        {
            float offset = Time.deltaTime * conveyorBelt.robotSpeed;
            transform.position = transform.position + (Vector3.left * offset);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DeathWall>())
        {
            Destroy(gameObject);
        }
    }
}
