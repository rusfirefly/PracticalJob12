using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private HudHandler _hudHanlder;
    [SerializeField] private SaveHandler _saveHandler;

    private SaveHandler Instance => SaveHandler.Instance;
    private int _levelID => SceneManager.GetActiveScene().buildIndex - 3;
    private int _countCoinInLevel;
    private int _pickUpCoinCount;

    private void Start()
    {
        Initialize();
    }

    private void OnEnable()
    {
        Coin.Collectible += OnCollectible;
    }

    private void OnDisable()
    {
        Coin.Collectible -= OnCollectible;
    }

    private void OnCollectible()
    {
        _pickUpCoinCount++;
        Instance.SavedData.NewCoin();
        _hudHanlder.SetCoinText(_pickUpCoinCount);
    }

    private void Initialize()
    {
        _saveHandler.Singlton();
        Instance.SavedData.RestartData();
        _countCoinInLevel = GetCountCoin();
        Instance.SavedData.SetCountCoinInLevel(_countCoinInLevel);
        SetLevelId();
        SetNewlevelData();
        Instance.Save();
    }

    private void SetLevelId()
    {
        Instance.SavedData.SetCurrentLevelId(SceneManager.GetActiveScene().buildIndex);
    }

    private void SetNewlevelData()
    {
        _hudHanlder.ClearCoinView();
    }
    
    private int GetCountCoin() => FindObjectsByType<Coin>(FindObjectsSortMode.None).Length;
}
