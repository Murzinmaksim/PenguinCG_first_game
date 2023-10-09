using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialControler : MonoBehaviour
{
    [SerializeField] private GameObject[] _panel;
    [SerializeField] private GameObject _buttonRight;
    [SerializeField] private GameObject _buttonLeft;
    [SerializeField] private GameObject _buttonPause;
    private int id = 0;

    void Start()
    {

        _buttonLeft.SetActive(false);
      
            _buttonPause.SetActive(false);
        
    }

    public void ClickRight()
    {
        id++;
        if (id == _panel.Length - 1)
        {
            _buttonRight.SetActive(false);
        }
        else
        {
            _buttonLeft.SetActive(true);
        }
        _panel[id].SetActive(true);
        _panel[id - 1].SetActive(false);
    }

    public void ClickLeft()
    {
        id--;
        if (id == 0)
        {
            _buttonLeft.SetActive(false);
        }
        else
        {
            _buttonRight.SetActive(true);
        }
        _panel[id].SetActive(true);
        _panel[id + 1].SetActive(false);
    }

    public void ClickEnd() 
    {
        Progress.Instance.PlayerInfo.TutorialCompleat = true;

        Progress.Instance.Save();

        Time.timeScale = 1f;
        gameObject.SetActive(false);
        _buttonPause.SetActive(true);
    }
}
