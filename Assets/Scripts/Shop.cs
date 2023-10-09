using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{

    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private int _price;
    [SerializeField] private int _typeProduct;

    //PlayerModifier _playerModifier;

    //[DllImport("__Internal")]
    //private static extern void SetToLeaderboard(int value);

    private void Start()
    {
        if (_typeProduct == 0) {
            foreach (string rod in Progress.Instance.PlayerInfo.BuyRodName)
            {
                if (Progress.Instance.PlayerInfo.SelectedRodName == rod && gameObject.name == Progress.Instance.PlayerInfo.SelectedRodName)
                {
                    InstallButtonAtStart1();
                }
                else if (gameObject.name == rod)
                {
                    InstallButtonAtStart2();
                }
            }
        }
        else
        {
            foreach (string boat in Progress.Instance.PlayerInfo.BuyBoatName)
            {
                if (Progress.Instance.PlayerInfo.SelectedBoatName == boat && gameObject.name == Progress.Instance.PlayerInfo.SelectedBoatName)
                {
                    InstallButtonAtStart1();
                }
                else if (gameObject.name == boat)
                {
                    InstallButtonAtStart2();
                }
            }
        }
        //_playerModifier = FindObjectOfType<PlayerModifier>();
    }

    private void InstallButtonAtStart1()
    {
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    private void InstallButtonAtStart2()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void ClickButtonShopBuyRod()
    {
        if (_coinManager.NumberOfCoins >= _price)
        {
            _coinManager.SpendMoney(_price);
            Progress.Instance.PlayerInfo.Coins = _coinManager.NumberOfCoins;
            string rodName;
            for (int i = 0; i < Progress.Instance.PlayerInfo.BuyRodName.Length; i++)
            {
                rodName = Progress.Instance.PlayerInfo.BuyRodName[i];
                if (rodName == "")
                {
                    Progress.Instance.PlayerInfo.BuyRodName[i] = gameObject.name;

                    Progress.Instance.Save();

                    SwapTextRod(gameObject.name);
                    gameObject.transform.GetChild(3).gameObject.SetActive(false);
                    gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    return;
                }
            }   
        } 
    }

    public void ClickButtonShopBuyBoat()
    {
        if (_coinManager.NumberOfCoins >= _price)
        {
            _coinManager.SpendMoney(_price);
            Progress.Instance.PlayerInfo.Coins = _coinManager.NumberOfCoins;
            string boatName;
            for (int i = 0; i < Progress.Instance.PlayerInfo.BuyBoatName.Length; i++)
            {
                boatName = Progress.Instance.PlayerInfo.BuyBoatName[i];
                if (boatName == "")
                {
                    Progress.Instance.PlayerInfo.BuyBoatName[i] = gameObject.name;

                    Progress.Instance.Save();

                    SwapTextRod(gameObject.name);
                    gameObject.transform.GetChild(3).gameObject.SetActive(false);
                    gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    return;
                }
            }
        }
    }

    public void ClickButtonShopChooseRod()
    {
        SwapTextRod(gameObject.name);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    private void SwapTextRod(string newRod)
    {
        if (_typeProduct == 0)
        {
            GameObject buttonSwap = GameObject.Find(Progress.Instance.PlayerInfo.SelectedRodName);
            buttonSwap.transform.GetChild(1).gameObject.SetActive(false);
            buttonSwap.transform.GetChild(2).gameObject.SetActive(true);
            Progress.Instance.PlayerInfo.SelectedRodName = newRod;
            Progress.Instance.Save();
        }
        else
        {
            GameObject buttonSwap = GameObject.Find(Progress.Instance.PlayerInfo.SelectedBoatName);
            buttonSwap.transform.GetChild(1).gameObject.SetActive(false);
            buttonSwap.transform.GetChild(2).gameObject.SetActive(true);
            Progress.Instance.PlayerInfo.SelectedBoatName = newRod;
            Progress.Instance.Save();
        }
    }

    //public void ClickButtonShopSelected()
    //{
    //    if (_coinManager.NumberOfCoins >= 20)
    //    {
    //        _coinManager.SpendMoney(20);
    //        Progress.Instance.PlayerInfo.Coins = _coinManager.NumberOfCoins;
    //        Progress.Instance.PlayerInfo.SelectedRodName = gameObject.name;
    //        //_playerModifier.SetWidth(Progress.Instance.PlayerInfo.BuyRodName);
    //    }
    //}

    //public void BuyWidth()
    //{
    //    if (_coinManager.NumberOfCoins >= 20)
    //    {
    //        _coinManager.SpendMoney(20);
    //        Progress.Instance.PlayerInfo.Coins = _coinManager.NumberOfCoins;
    //        Progress.Instance.PlayerInfo.SelectedRodName = "rob1";
    //        //_playerModifier.SetWidth(Progress.Instance.PlayerInfo.BuyRodName);
    //    }
    //}

    //public void BuyHeigth()
    //{
    //    if (_coinManager.NumberOfCoins >= 20)
    //    {
    //        _coinManager.SpendMoney(20);
    //        Progress.Instance.PlayerInfo.Coins = _coinManager.NumberOfCoins;
    //        Progress.Instance.PlayerInfo.SelectedRodName = "rob1";
    //        //_playerModifier.SetHeight(Progress.Instance.PlayerInfo.BuyRodName);

    //        SetToLeaderboard(Progress.Instance.PlayerInfo.MaxCoinsInLevel);
    //    }
    //}

}
