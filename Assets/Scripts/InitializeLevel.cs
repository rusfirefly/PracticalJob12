using UnityEngine;

public class InitializeLevel : MonoBehaviour
{
    [SerializeField] private SaveHandler _saveHandler;
    [SerializeField] private int _coin;
    [SerializeField] private int _levelID;
    private int _countCoin;

    private void Start()
    {
        _saveHandler.Singlton();
        CoutingCoinInLevel();

        _coin = SaveHandler.Instance.SavedData.DataGame.Levels[_levelID].CountCoin;
        //
    }

    private void CoutingCoinInLevel()
    {
        _countCoin = FindObjectsByType<Coin>(FindObjectsSortMode.InstanceID).Length;
        Debug.Log($"count coin: {_countCoin}");
    }
}
