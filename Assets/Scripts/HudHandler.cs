using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private TMP_Text _messageTMP;
    [SerializeField] private TMP_Text _keyMessage;

    [SerializeField] private Image _mainMenu;
    [SerializeField] private Image _finishCanvas;

    private SaveHandler Instance => SaveHandler.Instance;

    private int _currentLevelId => Instance.SavedData.GetLevelID - Instance.IdSceneTutorial;

    private bool _isFinishGame;

    public void ShomMessageKey() => _keyMessage.gameObject.SetActive(true);

    public void SetMessage(string message) => _messageTMP.text = message;

    public void ClearCoinView()
    {
        SetCoinText(0);
    }

    public void SetCoinText(int coin)
    {
        _coinText.text = $"гексаэдр: {coin}/{Instance.SavedData.DataGame.CountCoinInLevel}";
    }

    public void ShowMainMenu()
    {
        if (_isFinishGame) return;

        if (_mainMenu)
        {
            _mainMenu.gameObject.SetActive(true);
        }

        SetPauseGame(pause:true);
    }

    public void HideMainMenu() 
    {
        if (_isFinishGame) return;

        SetPauseGame(pause: false);

        if (_mainMenu)
        {
            _mainMenu.gameObject.SetActive(false);
        }
    }

    private void SetPauseGame(bool pause)
    {
        List<IPaused> pausedObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IPaused>().ToList();

        foreach (IPaused obj in pausedObjects)
        {
            if (pause)
            {
                obj.Pause();
            }
            else
            {
                obj.Resume();
            }
        }
    }
    
    public void ShowFinishMenu()
    {
        if (_finishCanvas)
        {
            _finishCanvas.gameObject.SetActive(true);
            _isFinishGame = true;
        }
    }

}
