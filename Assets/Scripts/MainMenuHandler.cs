using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    private LoadScene _loadHandler;

    public void Initialize()
    {
        _loadHandler = FindFirstObjectByType<LoadScene>();
        
        if(SaveHandler.Instance.SavedData.GetLevelID != (int)SceneID.TutorialScene)
        {
            _continueButton.gameObject.SetActive(true);
        }
    }

    public void NewGame()
    {

        LoadScene(SceneID.TutorialScene);
    }

    public void ContinueGame()
    {
        LoadScene(SceneID.LobbyScene);
    }

    public void LoadScene(SceneID sceneID)
    {
        SaveSceneID(sceneID);

        SceneManager.LoadScene((int)SceneID.LoadScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void SaveSceneID(SceneID sceneId)
    {
        SaveHandler.Instance.SavedData.DataGame.LobbyPortalID = (int)sceneId;
        SaveHandler.Instance.Save();

    }
}
