using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Language : MonoBehaviour
{


    //[DllImport("__Internal")]
    //private static extern string GetLang();

    public string CurrentLanguage;
    //[SerializeField] TextMeshProUGUI _languageText;

    public static Language Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CurrentLanguage = Progress.Instance.PlayerInfo.lang;
            //_languageText.text = CurrentLanguage;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void SetLang(string lang)
    {
        Progress.Instance.PlayerInfo.lang = lang;
        CurrentLanguage = lang;
        Progress.Instance.Save();
    }

}
