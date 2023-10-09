using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    [SerializeField] private float _speedRod;
    // Start is called before the first frame update
    private Hook _hook;
    [SerializeField] private GameObject _pointStart;
    void Awake()
    {
        _hook = GameObject.Find("hook").GetComponent<Hook>();

        _hook.addRod(gameObject, _pointStart, _speedRod);
    }

}
