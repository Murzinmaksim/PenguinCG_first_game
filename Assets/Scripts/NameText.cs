using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameText : MonoBehaviour
{

    [SerializeField] GameObject _enName;
    [SerializeField] GameObject _ruName;
    [SerializeField] GameObject _trName;

    void Start()
    {
        if (Language.Instance.CurrentLanguage == "en")
        {
             _enName.SetActive(true);
        }
        else if (Language.Instance.CurrentLanguage == "ru")
        {
            _ruName.SetActive(true);
        }
        else if (Language.Instance.CurrentLanguage == "tr")
        {
            _trName.SetActive(true);
        }
        else
        {
            _enName.SetActive(true);
        }
    }
}
