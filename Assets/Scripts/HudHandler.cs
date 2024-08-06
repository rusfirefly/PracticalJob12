using TMPro;
using UnityEngine;

public class HudHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private TMP_Text _messageTMP;

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
        _coinText.text = $"Coin: {SaveHandler.instance.savesData.GetScore()}";
    }

    public void SetMessage(string message) => _messageTMP.text = message;

}
