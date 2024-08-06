using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [field:SerializeField] public InteractiveView InteractiveView { get; private set; }
    [SerializeField] private string _caption = "Мост";
    [SerializeField, TextArea(3,10)] private string _message = "Для поднятия моста нажмите <color=yellow>(E)</color>";

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
