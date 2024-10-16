
[System.Serializable]
public class DataGame
{
    public int LevelID;
    public int PointID;
    public string PlayerName;
    public int Score;
    public bool Key;
}

public class SaveData 
{
    public DataGame DataGame { get; private set; }

    public SaveData() 
    {
        DefauldValue();
    }

    private void DefauldValue()
    {
        DataGame = new DataGame();
        DataGame.LevelID = 0;
        DataGame.PointID = 0;
        DataGame.PlayerName = "no name";
        DataGame.Score = 0;
        DataGame.Key = false;
    }

    public void SetPlayerName(string name) => DataGame.PlayerName = name;
    
    public void NewCoin() => DataGame.Score++;

    public void SetPoint(int pointId) => DataGame.PointID = pointId;

    public void SetLevelId(int levelID)=> DataGame.LevelID = levelID;

    public int GetScore() => DataGame.Score;

    public int GetLevelID() => DataGame.LevelID;

    public int GetPointId() => DataGame.PointID;

    public bool IsKey() => DataGame.Key;

    public void PickUpKey() => DataGame.Key = true;
}
