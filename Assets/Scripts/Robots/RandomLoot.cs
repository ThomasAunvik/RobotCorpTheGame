using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLoot : MonoBehaviour
{
    public List<Item> items;

    
    void GetRandomLoot()
    {
        Item item = items[Random.Range(0, items.Count)];
        Debug.Log(item.id);
    }
}
