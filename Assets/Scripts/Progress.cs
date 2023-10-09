using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int Coins;
    public int Score;
    public int firstStarte;
    public int CoinForNewLive;
    public bool NewLive;
    public bool SoundOff;
    public bool MusicOff;
    public bool TutorialCompleat;
    public string[] BuyRodName;
    public string[] BuyBoatName;
    public string SelectedRodName;
    public string lang;
    public string SelectedBoatName;
}

public class Progress : MonoBehaviour
{
    //[DllImport("__Internal")]
    //private static extern void SaveExtern(string date);
    //[DllImport("__Internal")]
    //private static extern void LoadExtern();

    public PlayerInfo PlayerInfo;
    public static Progress Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            //LoadExtern();
            //Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //PlayerInfo.ClickRateGame = false;
        if (PlayerInfo.firstStarte == 0)
        {
            PlayerInfo.SelectedRodName = "rod1";
            PlayerInfo.SelectedBoatName = "boat1";
            PlayerInfo.lang = "en";
            PlayerInfo.BuyBoatName = new string[7];
            PlayerInfo.BuyRodName = new string[7];
            PlayerInfo.BuyBoatName[0] = "boat1";
            PlayerInfo.BuyRodName[0] = "rod1";
            PlayerInfo.firstStarte = 1;
            Save();
        }
        Load();
        //LoadExtern();
    }

    //private void Update()
    //{
    //    //if (Input.GetKeyDown(KeyCode.Backspace))
    //    //{
    //    //    PlayerInfo = new PlayerInfo();
    //    //    Save();
    //    //}
    //}

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);

        PlayerPrefs.SetString("someJson", jsonString);
        PlayerPrefs.Save();
        //Load();
        //SaveExtern(jsonString);

    }

    public void Load()
    {

        string jsonString = PlayerPrefs.GetString("someJson");
        
        SetPlayerInfo(jsonString);

        

    }

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
    }

}
