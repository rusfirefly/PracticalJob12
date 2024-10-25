using TMPro;
using UnityEngine;

public class HudHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private TMP_Text _messageTMP;
    [SerializeField] private TMP_Text _keyMessage;

    private void OnEnable()
    {
        Coin.Collectible += OnCollectible;
    }

    private void OnDisable()
    {
        Coin.Collectible -= OnCollectible;
    }

    public void ShomMessageKey() => _keyMessage.gameObject.SetActive(true);

    public void SetMessage(string message) => _messageTMP.text = message;

    private void OnCollectible()
    {
        _coinText.text = $"Coin: {SaveHandler.Instance.SavedData.GetScore}";
    }

}
