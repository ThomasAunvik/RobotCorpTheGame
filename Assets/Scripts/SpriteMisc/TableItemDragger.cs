using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TableItemDragger : MonoBehaviour
{
    [SerializeField]
    private List<Item> items;
    private List<(Item, GameObject)> spawnedItems = new List<(Item, GameObject)>();
    [SerializeField]
    private List<Transform> placableSpots;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private TMP_Text sliderText;

    private bool isHoldingItem = false;
    private GameObject holdingItem;

    void Awake()
    {
        for(int i = 0; i < items.Count; i++)
        { 
            spawnedItems.Add((items[i], Instantiate(items[i].prefab, placableSpots[i])));
            TableItem item = spawnedItems[i].Item2.AddComponent<TableItem>();
            item.item = items[i];
            spawnedItems[i].Item2.transform.position = placableSpots[i].position;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isHoldingItem) return;

            TableItem item = GetItemFromMousePos();
            if(item != null)
            {
                isHoldingItem = true;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                holdingItem = Instantiate(item.gameObject);
                holdingItem.transform.position = new Vector3(ray.origin.x, ray.origin.y, 0);
                holdingItem.GetComponent<TableItem>().item = item.item;

                holdingItem.AddComponent<FollowMouse>();
                
            }
        }else if (Input.GetMouseButtonUp(0))
        {
            if (!isHoldingItem) return;

            isHoldingItem = false;
            Item item = holdingItem.GetComponent<TableItem>().item;

            ConveyorBeltRobot robot = GetRobotFromMousePos();

            Destroy(holdingItem);
            if (robot == null) return;

            if (robot.GiveItemOil(item))
            {
                Debug.Log("Gave Robot Oil. (Item: " + item.id + ")");
                slider.value += 5;
            }
            else
            {
                Debug.Log("Gave Robot Bad Oil. (Item: " + item.id + ")");
                slider.value -= 10;
            }

            sliderText.text = "Progress: " + slider.value + "%";
        }
    }

    private TableItem GetItemFromMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hit = Physics2D.RaycastAll(ray.origin, Vector3.forward);
        if (hit.Length > 0)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                TableItem item;
                if (item = hit[i].collider.GetComponent<TableItem>())
                {
                    if (item.item == null) continue;

                    return item;
                }
            }
        }
        return null;
    }

    private ConveyorBeltRobot GetRobotFromMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hit = Physics2D.RaycastAll(ray.origin, Vector3.forward);
        if (hit.Length > 0)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                ConveyorBeltRobot robot;
                if (robot = hit[i].collider.GetComponent<ConveyorBeltRobot>())
                {
                    return robot;
                }
            }
        }
        return null;
    }
}
