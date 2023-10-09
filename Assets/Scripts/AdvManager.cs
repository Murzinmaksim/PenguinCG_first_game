using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using CrazyGames;

public class AdvManager : MonoBehaviour
{

    //[DllImport("__Internal")]
    //private static extern void AddMultiplicationMoney();

    //[DllImport("__Internal")]
    //private static extern void AddNewLive();

    //[DllImport("__Internal")]
    //private static extern void AddReductionFishSpeed();

    [SerializeField] private GameObject _advWindowReductionMoveSpeed;
    [SerializeField] private GameObject _buttonAdvWindowReductionMoveSpeed;
    [SerializeField] private GameObject _fishGenerator;
    [SerializeField] private GameObject _hook;
    [SerializeField] private GameObject _CoinManager;
    [SerializeField] private GameObject _FishGenerator;
    [SerializeField] private GameObject _music;

    void Start()
    {
        StartCoroutine(advWindowReductionMoveSpeed());
    }


    private IEnumerator advWindowReductionMoveSpeed()
    { 
        yield return new WaitForSeconds(20f);
        _buttonAdvWindowReductionMoveSpeed.SetActive(true);
    }

    public void ShowAdvWindowReductionMoveSpeed()
    {
        _buttonAdvWindowReductionMoveSpeed.SetActive(false);
        _advWindowReductionMoveSpeed.SetActive(true);
        _hook.GetComponent<Hook>().pauseActive(true);
        Time.timeScale = 0f;
    }

    private void PlayGame()
    {
        Time.timeScale = 1f;
        _hook.GetComponent<Hook>().pauseActive(false);
    }

    public void ClickAdvButtonReductionMoveSpeed()
    {
        _music.SetActive(false);
        CrazyAds.Instance.beginAdBreakRewarded(AdvButtonReductionMoveSpeed, AdError);
        //AddReductionFishSpeed();
        _advWindowReductionMoveSpeed.SetActive(false);
        PlayGame();
        StartCoroutine(advWindowReductionMoveSpeed());
       
    }

    void AdvButtonReductionMoveSpeed()
    {
        _FishGenerator.GetComponent<FishGenerator>().startDecelerationEffect();
    }

    public void ClickAdvButton2xMoney()
    {
        _music.SetActive(false);
        Progress.Instance.PlayerInfo.NewLive = false;
        CrazyAds.Instance.beginAdBreakRewarded(AdvButton2xMoney, AdError);
        //AddMultiplicationMoney();
        PlayGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }

    void AdvButton2xMoney()
    {
        _CoinManager.GetComponent<CoinManager>().Money2x();
    }

    public void ClickAdvButtonNewLive()
    {
        _music.SetActive(false);
        //AddNewLive();
        CrazyAds.Instance.beginAdBreakRewarded(AdvButtonNewLive, AdError);
        PlayGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     
    }

    void AdvButtonNewLive()
    {
        _CoinManager.GetComponent<CoinManager>().SaveNewLive();
    }

    public void AnShowAdvWindowReductionMoveSpeed()
    {
        PlayGame();
        _advWindowReductionMoveSpeed.SetActive(false);
        StartCoroutine(advWindowReductionMoveSpeed());
    }

    void AdError()
    {
        print("Ad has not been displayed");
    }

}
