using Assets.Scripts.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiFuelListener : MonoBehaviour
{
    public GameObject fuelImageObject;
    List<GameObject> fuelObjects = new List<GameObject>();

    void OnEnable()
    {
        var player = GameManager.Player.GetComponent<SpacebarController>();
        player.OnFuelPickup += FuelPickup;
        player.OnFuelUse += FuelUse;
    }

    void FuelPickup()
    {
        fuelObjects.Add(
            Instantiate<GameObject>(fuelImageObject, transform)
        );
    }

    void FuelUse()
    {
        var objectToDestroy = fuelObjects[fuelObjects.Count - 1];
        fuelObjects.Remove(objectToDestroy);
        Destroy(objectToDestroy);
    }
}

