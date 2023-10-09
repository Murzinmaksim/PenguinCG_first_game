using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using CrazyGames;

public class GameManager : MonoBehaviour
{

    //[DllImport("__Internal")]
    //private static extern void ShowAdv();

    [SerializeField] private GameObject _PauseMenu;
    [SerializeField] private GameObject _finishWindow;
    [SerializeField] private GameObject _hook;
    [SerializeField] private GameObject _StartPointRod;
    [SerializeField] private GameObject _StartPointBoat;
    [SerializeField] private GameObject _BoatBuyList;
    [SerializeField] private GameObject _RodBuyList;
    [SerializeField] private GameObject _DonateBuyList;
    [SerializeField] private GameObject _ButtonNewLive;
    [SerializeField] private GameObject _buttonMusic;
    [SerializeField] private GameObject _buttonSound;
    //[SerializeField] private GameObject _buttonRateGame;
    [SerializeField] private GameObject _contentControler;
    [SerializeField] private GameObject _tutorialControler;
    [SerializeField] private GameObject _music;

    private void Start()
    {
        
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            ShowAdv();
            
            if (Progress.Instance.PlayerInfo.TutorialCompleat == false)
            {
                Time.timeScale = 0f;
                _tutorialControler.SetActive(true);
            }

            //if (Progress.Instance.PlayerInfo.ClickRateGame == true)
            //{
            //    _buttonRateGame.SetActive(false);
            //}

            if (Progress.Instance.PlayerInfo.MusicOff != true)
            {
                _buttonMusic.SetActive(false);
                _music.SetActive(true);
            }
            else
            {
                _buttonMusic.SetActive(true);
                _music.SetActive(false);
            }
            if (Progress.Instance.PlayerInfo.SoundOff != true)
            {
                _buttonSound.SetActive(false);
            }
            else
            {
                _buttonSound.SetActive(true);
            }
            _StartPointRod.GetComponent<RodStart>().StartRod(Progress.Instance.PlayerInfo.SelectedRodName);
            _StartPointBoat.GetComponent<BoatStart>().StartBoat(Progress.Instance.PlayerInfo.SelectedBoatName);
        }

    }

    void ShowAdv()
    {
        _music.SetActive(false);
        CrazyAds.Instance.beginAdBreak(musicOn, AdError);
    }

    void musicOn()
    {
        _music.SetActive(true);
    }

    void AdError()
    {
        if (Progress.Instance.PlayerInfo.TutorialCompleat == false)
        {
            Time.timeScale = 0f;
        }
        print("Ad has not been displayed");
    }

    public void MusicSwap()
    {
        if (Progress.Instance.PlayerInfo.MusicOff == true)
        {
            Progress.Instance.PlayerInfo.MusicOff = false;
            _music.SetActive(true);
            _buttonMusic.SetActive(false);
        }
        else
        {
            Progress.Instance.PlayerInfo.MusicOff = true;
            _music.SetActive(false);
            _buttonMusic.SetActive(true);
        }
    }

    public void SoundSwap()
    {
        bool soundOff = _hook.GetComponent<Hook>().SoundOff();
        if (soundOff == true)
        {
            _buttonSound.SetActive(true);
        }
        else
        {
            _buttonSound.SetActive(false);
        }
       
    }

    public void ShowPauseWindow()
    {
        _PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        _hook.GetComponent<Hook>().pauseActive(true);
    }

    public void PlayGame()
    {
        _PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        _hook.GetComponent<Hook>().pauseActive(false);
    }

    public void ClickBoatBuyButtonList()
    {
        _BoatBuyList.transform.SetSiblingIndex(3);
        _RodBuyList.transform.SetSiblingIndex(2);
        _DonateBuyList.transform.SetSiblingIndex(1);
        _contentControler.GetComponent<ContentControler>().SwapContent();
    }

    public void ClickRodBuyButtonList()
    {
        _RodBuyList.transform.SetSiblingIndex(3);
        _BoatBuyList.transform.SetSiblingIndex(2);
        _DonateBuyList.transform.SetSiblingIndex(1);
        _contentControler.GetComponent<ContentControler>().SwapContent();
    }

    public void ClickDonateBuyButtonList()
    {
        _DonateBuyList.transform.SetSiblingIndex(3);
        _RodBuyList.transform.SetSiblingIndex(2);
        _BoatBuyList.transform.SetSiblingIndex(1);
        _contentControler.GetComponent<ContentControler>().SwapContent();
    }

    public void AgainGame()
    {
        
        pauseNextlevelAnActive();
        _finishWindow.SetActive(false);
        _hook.GetComponent<Hook>().pauseActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuLevel()
    {
        pauseNextlevelAnActive();
        SceneManager.LoadScene(0); 
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GameLevel()
    {

        pauseNextlevelAnActive();
        SceneManager.LoadScene(1);
        
    }

    public void ShopLevel()
    {
        pauseNextlevelAnActive();
        SceneManager.LoadScene(2);
    }

    private void pauseNextlevelAnActive()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1) return;
            Time.timeScale = 1f;
            Progress.Instance.PlayerInfo.NewLive = false;
    }

    private void checkNewLive()
    {
        if (Progress.Instance.PlayerInfo.NewLive == false) return; 
        _ButtonNewLive.SetActive(false);
    }

    public void ShowFinishWindow()
    {
       _finishWindow.SetActive(true);
        checkNewLive();
       _finishWindow.GetComponent<Animator>().Play("finishWindow");
       Time.timeScale = 0f;
       _hook.GetComponent<Hook>().pauseActive(true);
    }

}
