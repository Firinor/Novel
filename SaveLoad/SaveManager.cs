using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using SaveLoadLib;
using static SaveLoadLib.GlobalSaveManager;

public class SaveManager : MonoBehaviour
{
    public static SaveData Data;

    void Awake()
    {
        OptionsOperator.LoadOptions();
    }

    internal static int PlayerAccount()
    {
        if (Data == null)
            return -1;

        return Data.Account;
    }

    public static void CreateNewSave(int account)
    {
        GlobalSaveManager.Save(GlobalSaveManager.GetPath(account), new SaveData(account, null));
    }

    public static void Save(int account)
    {
        Data.Account = account;
        Data.Progress = PlayerManager.GetProgress();

        GlobalSaveManager.Save(GlobalSaveManager.GetPath(account), Data);
    }


    public static void SaveOptions(int ScreenResolution = -1)
    {
        Save<OptionsParameters>(GlobalSaveManager.GetOptionPath(),
            OptionsOperator.GetParameters(ScreenResolutoin: ScreenResolution));
    }

    [System.Serializable]
    public class SaveData : AbstractSaveData
    {
        public int Account;
        public Dictionary<int, bool> Progress;

        public SaveData(int Account = -1, Dictionary<int, bool> Progress = null)
        {
            this.Account = Account;
            this.Progress = Progress;
        }
    }
}