using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LangControler : MonoBehaviour
{
    [SerializeField] GameObject _ruFlag;
    [SerializeField] GameObject _enFlag;
    [SerializeField] GameObject _trFlag;

    void Start()
    {
        SwapLang();
    }

    public void SwapLang()
    {
        if (Language.Instance.CurrentLanguage == "en")
        {
            _enFlag.SetActive(true);
        }
        else if (Language.Instance.CurrentLanguage == "ru")
        {
            _ruFlag.SetActive(true);
        }
        else if (Language.Instance.CurrentLanguage == "tr")
        {
            _trFlag.SetActive(true);
        }
        else
        {
            _enFlag.SetActive(true);
        }
    }

    public void ClickEnFlag()
    {
        Language.Instance.SetLang("en");
        _ruFlag.SetActive(false);
        _trFlag.SetActive(false);
        SwapLang();
        SceneManager.LoadScene(0);
    }

    public void ClickRuFlag()
    {
        Language.Instance.SetLang("ru");
        _enFlag.SetActive(false);
        _trFlag.SetActive(false);
        SwapLang();
        SceneManager.LoadScene(0);
    }

    public void ClickTrFlag()
    {
        Language.Instance.SetLang("tr");
        _enFlag.SetActive(false);
        _ruFlag.SetActive(false);
        SwapLang();
        SceneManager.LoadScene(0);
    }

}
