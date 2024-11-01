
[System.Serializable]
public class DataGame
{
    public int CurrentLevelID;
    public int? LevelCompleteID;
    public int? PortalID;
    public int Score;
    public int CountCoinInLevel;
    public bool Key;
}

public class SaveData 
{
    public DataGame DataGame { get; set; }

    public int GetScore => DataGame.Score;

    public int GetCountCoinInLevel => DataGame.CountCoinInLevel;

    public int GetLevelID => DataGame.CurrentLevelID;

    public bool IsKey => DataGame.Key;

    public SaveData() 
    {
        DefauldValue();
    }

    private void DefauldValue()
    {
        DataGame = new DataGame();
        DataGame.CurrentLevelID = (int)SceneID.TutorialScene;
        DataGame.Score = 0;
        DataGame.Key = false;
        DataGame.PortalID = null;
    }

    public void SetCountCoinInLevel(int count)=> DataGame.CountCoinInLevel = count;

    public void NewCoin() => DataGame.Score++;

    public void SetCurrentLevelId(int levelID) => DataGame.CurrentLevelID = levelID;
    
    public void SetPortallId(int lobbyPortaID)=> DataGame.PortalID = lobbyPortaID;

    public void PickUpKey() => DataGame.Key = true;

    public void ClearCoinInScene() => DataGame.Score = 0;

    public void SetLevelCompleteID(int id) => DataGame.LevelCompleteID = id;

    public void RestartData()
    {
        DefauldValue();
    }

}
