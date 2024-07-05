[System.Serializable]
public class DataGame
{
    public int levelID;
    public int pointID;
    public string playerName;
    public int score;
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
        dataGame.levelID = 0;
        dataGame.pointID = 0;
        dataGame.playerName = "no name";
        dataGame.score = 0;
    }

    public void SetPlayerName(string name) => dataGame.playerName = name;
    
    public void NewCoin() => dataGame.score++;

    public void SetPoint(int pointId) => dataGame.pointID = pointId;

    public void SetLevelId(int levelID)=> dataGame.levelID = levelID;


    public int GetScore() => dataGame.score;

    public int GetLevelID() => dataGame.levelID;

    public int GetPointId() => dataGame.pointID;
}
