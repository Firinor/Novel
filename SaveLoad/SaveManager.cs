using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

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

    public static void Save<T>(string path, T data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void CreateNewSave(int account)
    {
        Save(GetPath(account), new SaveData(account, null));
    }

    public static void Save(int account)
    {
        Data.Account = account;
        Data.Progress = PlayerManager.GetProgress();

        Save(GetPath(account), Data);
    }


    public static void SaveOptions(int ScreenResolution = -1)
    {
        Save<OptionsParameters>(GetOptionPath(), OptionsOperator.GetParameters(ScreenResolutoin: ScreenResolution));
    }

    public static OptionsParameters LoadOptions()
    {
        return Load<OptionsParameters>(GetOptionPath());
    }

    public static SaveData Load(int account)
    {
        Data = Load<SaveData>(GetPath(account));

        if (Data == null)
        {
            CreateNewSave(account);
        }

        return Data;
    }

    public static T Load<T>(string path)
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            T data = (T)formatter.Deserialize(stream);
            stream.Close();
            return data;
        }
        else
        {
            return default;
        }
    }

    public bool FileExists(string path)
    {
        return File.Exists(path);
    }

    public bool FileExists(int i)
    {
        return FileExists(GetPath(i));
    }

    static string GetPath(int i)
    {
        return GetPath() + $"data{i}.save";
    }

    static string GetOptionPath()
    {
        return GetPath() + $"option.save";
    }

    static string GetPath()
    {
        //C:\Users\<userprofile>\AppData\LocalLow\<companyname>\<productname>
        return Application.persistentDataPath;
    }

    [System.Serializable]
    public class SaveData
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