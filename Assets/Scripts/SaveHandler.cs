using UnityEngine;
using System.IO;

public class SaveHandler : MonoBehaviour
{
    [SerializeField] private int _countBuildScenes;
    public SaveData SavedData { get; private set; }
    private DataGame LoadedDataGame;
    private string _pathData;
    public static SaveHandler Instance;

    public void Singlton()
    {
        if (Instance == null)
        {
            Instance = this;
        }else
        {
            Destroy(Instance);
        }

        DontDestroyOnLoad(gameObject);
        Initialized();
    }

    public void Initialized()
    {
        _pathData = $"{Application.dataPath}/Gamedata.json";

        LoadedDataGame = Load();

        if(LoadedDataGame == null)
        {
            SavedData = new SaveData(_countBuildScenes);
            Save();
        }
        else
        {
            SavedData = new SaveData(_countBuildScenes);
            SavedData.DataGame = LoadedDataGame;
        }
    }

    private DataGame Load()
    {
        if (!File.Exists(_pathData)) return null;
        string json = File.ReadAllText(_pathData);
        return JsonUtility.FromJson<DataGame>(json);
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(SavedData.DataGame);
        File.WriteAllText(_pathData, json);
    }
}
