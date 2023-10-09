using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using CrazyGames;

public class CoinManager : MonoBehaviour
{
    //[DllImport("__Internal")]
    //private static extern void SetToLeaderboard(int value);

    //[DllImport("__Internal")]
    //private static extern void AddCoinsExtern(int value);

    public int NumberOfCoins;
    private int _CoinsAllInLevel;
    [SerializeField] private TextMeshProUGUI _coin;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _maxScore;
    [SerializeField] private TextMeshProUGUI _bank;
    [SerializeField] GameObject _advButton;
    [SerializeField] private GameObject _music;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _maxScore.text = Progress.Instance.PlayerInfo.Score.ToString();
        }
        else
        {

            NumberOfCoins = Progress.Instance.PlayerInfo.Coins;
            _bank.text = NumberOfCoins.ToString();
            //transform.parent = null;
        }
    }

    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    AddCoins(1000);
        //}
       
    }

    private void MusicOn()
    {
        if (Progress.Instance.PlayerInfo.MusicOff != true) {
            _music.SetActive(true);
        }
    }

    private void MusicOff()
    {
        _music.SetActive(false);
    }

    public void SaveToProgress()
    {
        Progress.Instance.PlayerInfo.Coins = NumberOfCoins;
        Progress.Instance.Save();
    }

    public void SpendMoney(int value)
    {
        NumberOfCoins -= value;
        _bank.text = NumberOfCoins.ToString();
    }

    public void ShowAdvButton()
    {
        CrazyAds.Instance.beginAdBreakRewarded(AddCoinsAdv, AdError);
        _advButton.SetActive(false);
    }

    public void finalFishing()
    {
        _coin.text = _CoinsAllInLevel.ToString();
    }

    public void updateScore()
    {
        if (Progress.Instance.PlayerInfo.Score < _CoinsAllInLevel) {
            Progress.Instance.PlayerInfo.Score = _CoinsAllInLevel;
            //SetToLeaderboard(Progress.Instance.PlayerInfo.Score);
        }
    }

    public void Money2x()
    {
        NumberOfCoins += _CoinsAllInLevel;
        _CoinsAllInLevel = _CoinsAllInLevel * 2;
        updateScore();
        SaveToProgress();
        MusicOn();
    }

    public void SaveNewLive()
    {
        Progress.Instance.PlayerInfo.CoinForNewLive = _CoinsAllInLevel;
        Progress.Instance.PlayerInfo.NewLive = true;
        MusicOn();
    }

    public void NewLive()
    {
        _CoinsAllInLevel = Progress.Instance.PlayerInfo.CoinForNewLive;
        _score.text = _CoinsAllInLevel.ToString();
        Progress.Instance.PlayerInfo.CoinForNewLive = 0;
    }

    public void AddCoins(int value)
    {
        NumberOfCoins += value;
        _CoinsAllInLevel += value;
        _bank.text = NumberOfCoins.ToString();
        _score.text = _CoinsAllInLevel.ToString();
        SaveToProgress();
    }

    void AddCoinsAdv()
    {
        int value = 100;
        NumberOfCoins += value;
        _bank.text = NumberOfCoins.ToString();
        SaveToProgress();
    }

    void AdError()
    {
        print("Ad has not been displayed");
    }

}
