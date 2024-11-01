using UnityEngine;
using System.IO;

public class SaveHandler : MonoBehaviour
{
    [SerializeField] private bool _isSingleton;
    public SaveData SavedData { get; private set; }
    public int IdSceneTutorial { get => 3; }

    private DataGame LoadedDataGame;
    private string _pathData;

    public static SaveHandler Instance;

    public void Singlton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(this);
                return;
            }
        }

        Initialized();
        DontDestroyOnLoad(gameObject);
    }

    public void Initialized()
    {
        _pathData = $"{Application.dataPath}/Gamedata.json";

        LoadedDataGame = Load();

        if(LoadedDataGame == null)
        {
            SavedData = new SaveData();
            Save();
        }
        else
        {
            SavedData = new SaveData();
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
