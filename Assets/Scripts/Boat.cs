using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] private int _multiplicationMoney;
   
    void Awake()
    {
        Hook hook = GameObject.Find("hook").GetComponent<Hook>();
        //GameObject pointStart = gameObject.transform.GetChild(0).gameObject;

        hook.addBoat(_multiplicationMoney);
    }

   
}
