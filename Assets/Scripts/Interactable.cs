using TMPro;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private TMP_Text _iteractableText;
    [SerializeField] private string _message = "Press E";

    public abstract void OnInteract();

    public void ShowMessage()
    {
        SetVisibleText(true);
        _iteractableText.text = _message;
    }

    public void HideMessage()
    {
        SetVisibleText(false);
    }

    private void SetVisibleText(bool visible)=> _iteractableText.gameObject.SetActive(visible);
}
