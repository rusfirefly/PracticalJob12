using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour, IPaused
{
    [SerializeField] private HudHandler _hudHanlder;
    [SerializeField] private SaveHandler _saveHandler;

    private SaveHandler Instance => SaveHandler.Instance;

    private int _levelID => SceneManager.GetActiveScene().buildIndex - Instance.IdSceneTutorial;

    public bool IsPaused { get; set; }

    private int _countCoinInLevel;
    private int _pickUpCoinCount;

    private void Start()
    {
        Initialize();
        LookCursor();
    }

    private void OnEnable()
    {
        Coin.Collectible += OnCollectible;
        PlayerInput.Paused += OnPaused;
        Portal.Finish += OnFinish;
    }

    private void OnDisable()
    {
        Coin.Collectible -= OnCollectible;
        PlayerInput.Paused -= OnPaused;
        Portal.Finish -= OnFinish;
    }

    public void Pause()
    {
        IsPaused = true;
    }

    public void Resume()
    {
        IsPaused = false;
    }

    private void OnFinish()
    {
        Cursor.lockState  = CursorLockMode.Confined;

        List<IPaused> pausedObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IPaused>().ToList();

        foreach (IPaused obj in pausedObjects)
        {
           obj.Pause();
        }

        _hudHanlder.ShowFinishMenu();
    }

    private void OnPaused()
    {
        IsPaused = !IsPaused;

        if (IsPaused)
        {
            _hudHanlder.ShowMainMenu();
            ConfinedCursor();
        }
        else
        {
            _hudHanlder.HideMainMenu();
            LookCursor();
        }
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

        _countCoinInLevel = GetCountCoin();
        Instance.SavedData.SetCountCoinInLevel(_countCoinInLevel);
        SetLevelId();
        SetNewlevelData();
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

    private void LookCursor()=>Cursor.lockState = CursorLockMode.Locked;

    private void ConfinedCursor() => Cursor.lockState = CursorLockMode.Confined;
}
