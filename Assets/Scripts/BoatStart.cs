using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatStart : MonoBehaviour
{
    public GameObject[] _BoatPrefab;


    public void StartBoat(string NameBoat)
    {

        foreach (GameObject boat in _BoatPrefab)
        {
            if (boat.name == NameBoat)
            {
                GameObject newBoat = Instantiate(boat);
                newBoat.GetComponent<Transform>().position = gameObject.transform.position;
                return;
            } 
        }
      
    }
 
}
