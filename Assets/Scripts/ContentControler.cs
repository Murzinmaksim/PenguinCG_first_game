using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentControler : MonoBehaviour
{
    private RectTransform rectTransform;
    [SerializeField] private float _speedControl;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = gameObject.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.GetComponent<RectTransform>();
    }

    public void SwapContent()
    {
        rectTransform = gameObject.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.GetComponent<RectTransform>();
    }

    public void ClickRight()
    {
        rectTransform.position += new Vector3(-(_speedControl), 0f, 0f);
    }

    public void ClickLeft()
    {
        rectTransform.position += new Vector3(_speedControl, 0f, 0f);
    }
}
