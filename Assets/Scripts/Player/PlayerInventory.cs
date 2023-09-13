using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{   
    [SerializeField] private int currentWoods;
    [SerializeField] private float currentWater;

    public int CurrentWoods {get => currentWoods; set => currentWoods = value;}
    public float CurrentWater {get => currentWater; set => currentWater = value;}

    
    [SerializeField] private float maxWater;

    public void AddWater(float water)
    {
        if(currentWater < maxWater)
        {
            currentWater += water;
        }
    }
}
