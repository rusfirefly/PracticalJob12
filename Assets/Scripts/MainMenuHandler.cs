using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    private LoadScene _loadHandler;
    private const int None = -1;

    public void Initialize()
    {
        _loadHandler = FindFirstObjectByType<LoadScene>();

        if(SaveHandler.Instance.SavedData.DataGame.LevelCompleteID > None)
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
        SaveHandler.Instance.SavedData.DataGame.PortalID = (int)sceneId;
        SaveHandler.Instance.Save();
    }
}
