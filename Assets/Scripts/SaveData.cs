[System.Serializable]
public class DataGame
{
    public int LevelID;
    public int PointID;
    public string PlayerName;
    public int Score;
}

public class SaveData 
{
    public DataGame dataGame { get; private set; }

    public SaveData() 
    {
        DefauldValue();
    }

    private void DefauldValue()
    {
        dataGame = new DataGame();
        dataGame.LevelID = 0;
        dataGame.PointID = 0;
        dataGame.PlayerName = "no name";
        dataGame.Score = 0;
    }

    public void SetPlayerName(string name) => dataGame.PlayerName = name;
    
    public void NewCoin() => dataGame.Score++;

    public void SetPoint(int pointId) => dataGame.PointID = pointId;

    public void SetLevelId(int levelID)=> dataGame.LevelID = levelID;

    public int GetScore() => dataGame.Score;

    public int GetLevelID() => dataGame.LevelID;

    public int GetPointId() => dataGame.PointID;
}
