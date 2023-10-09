using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodStart : MonoBehaviour
{
    public GameObject[] _RodPrefab;
  

    public void StartRod(string NameRod)
    {

        foreach (GameObject rod in _RodPrefab)
        {
            if (rod.name == NameRod)
            {
                GameObject newRod = Instantiate(rod);
                newRod.GetComponent<Transform>().position = gameObject.transform.position;
                return;
            } 
        }
      
    }
 
}
