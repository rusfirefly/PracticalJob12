using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [field:SerializeField] public InteractiveView InteractiveView { get; private set; }
    [SerializeField] private string _caption;
    [SerializeField, TextArea(3,10)] private string _message;

    private void Start()
    {
        InteractiveView.Inizialize(_caption, _message);
    }

    public abstract void OnInteract();

    public void ShowMessage()
    {
        SetVisibleText(true);
    }

    public void HideMessage()
    {
        SetVisibleText(false);
    }

    private void SetVisibleText(bool visible) => InteractiveView.SetVisible(visible); //_interactableView.gameObject.SetActive(visible);

    
}
