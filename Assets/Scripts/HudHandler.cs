using TMPro;
using UnityEngine;

public class HudHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private TMP_Text _messageTMP;
    [SerializeField] private TMP_Text _keyMessage;

    private SaveHandler Instance => SaveHandler.Instance;
    private int _currentLevelId => Instance.SavedData.GetLevelID - 3;

    public void ShomMessageKey() => _keyMessage.gameObject.SetActive(true);

    public void SetMessage(string message) => _messageTMP.text = message;

    public void ClearCoinView()
    {
        SetCoinText(0);
    }

    public void SetCoinText(int coin)
    {
        _coinText.text = $"Coin: {coin}/{Instance.SavedData.DataGame.CountCoinInLevel}";
    }

}
