using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject[] items;

    private int[] itemCounts;

    private int equippedItem;
    // Start is called before the first frame update
    void Start()
    {
        itemCounts = new int[items.Length];
        for (int i = 0; i < itemCounts.Length; i++) {
            itemCounts[i] = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha0)) {
            Equip(0);
        }
        if (Input.GetKey(KeyCode.Alpha1)) {
            Equip(1);
        }
        if (Input.GetKey(KeyCode.Alpha2)) {
            Equip(2);
        }
        if (Input.GetKey(KeyCode.Alpha3)) {
            Equip(3);
        }
        if (Input.GetKey(KeyCode.Alpha4)) {
            Equip(4);
        }
        if (Input.GetKey(KeyCode.Alpha5)) {
            Equip(5);
        }
        if (Input.GetKey(KeyCode.Alpha6)) {
            Equip(6);
        }
        if (Input.GetKey(KeyCode.Alpha7)) {
            Equip(7);
        }
        if (Input.GetKey(KeyCode.Alpha8)) {
            Equip(8);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            ConsumeItem();
        }
    }

    void Equip(int index) {
        if (itemCounts[index] != 0) {
            equippedItem = index;
        }
    }

    void ConsumeItem() {
        Debug.Log("Fired");
        if (itemCounts[equippedItem] > 0) {
            itemCounts[equippedItem] -= 1;
            Instantiate(items[equippedItem], transform.position, transform.rotation);
        }
            // if (itemCounts[equippedItem] == 0) {
            //     equippedItem -= 1;
            // }
    }
}
