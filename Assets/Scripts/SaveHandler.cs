using UnityEngine;
using System.IO;

public class SaveHandler : MonoBehaviour
{
    public SaveData savesData { get; private set; }
    private string _pathData;
    public static SaveHandler instance;

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }else
        {
            Destroy(instance);
        }

        DontDestroyOnLoad(gameObject);
        Initialized();
    }

    public void Initialized()
    {
        _pathData = $"{Application.dataPath}/Gamedata.json";
        
        savesData = Load();
        if(savesData == null)
        {
            savesData = new SaveData();
            Save();
        }
    }

    private SaveData Load()
    {
        if (!File.Exists(_pathData)) return null;
        string json = File.ReadAllText(_pathData);
        return JsonUtility.FromJson<SaveData>(json);
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(savesData.dataGame);
        Debug.Log(json);
        File.WriteAllText(_pathData, json);
    }
}
