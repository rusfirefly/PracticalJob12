using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private SaveHandler _saveHandler;
    [SerializeField] private MainMenuHandler _mainMenuHandler;

    private void Awake()
    {
        _saveHandler.Singlton();
        _mainMenuHandler.Initialize();
    }
}
