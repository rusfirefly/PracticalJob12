using TMPro;
using UnityEngine;

public class InteractiveView : MonoBehaviour
{
    [SerializeField] private Canvas _interactableView;
    [SerializeField] private TMP_Text _captionTMP;
    [SerializeField] private TMP_Text _messageTMP;
    [SerializeField] private bool _isLockCamera;

    public void Inizialize(string caption, string message)
    {
        _captionTMP.text = caption;
        _messageTMP.text = message;
    }

    public void SetVisible(bool visible)=> _interactableView.enabled = visible;

    public void LookAtCamera()
    {
        if (_isLockCamera == false) return;

        Vector3 direction = Camera.main.transform.forward;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation *= Quaternion.Euler(0, 180, 0);
        _interactableView.transform.rotation = rotation;
    }
}
