using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private SaveHandler _saveHandler;
    [SerializeField] private MainMenuHandler _mainMenuHandler;

    private void Start()
    {
        _saveHandler.Singlton();
        _mainMenuHandler.Initialize();
    }
}
