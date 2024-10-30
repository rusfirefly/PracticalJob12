using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

public enum SceneID { MainMenu = 0, LoadScene = 1, LobbyScene=2, TutorialScene = 3, SceneNumber=4}

[System.Serializable]
public class DataGame
{
    public List<Level> Levels;

    public DataGame()
    {
        Levels = new List<Level>();
    }

    public int CurrentLevelID;
    public int LobbyPortalID;
    public int PointID;
    public int Score;
    public bool Key;
}

[System.Serializable]
public class Level
{
    public int LevelID { get; private set; }    
    public int CurrentCoin;
    public int Coin { get; private set; }
    public int CountCoin { get; private set; }
    
    public Level()
    {
        ClearInfoAboutLevel();
    }

    public void SetInformationAboutLevel(int coint, int countCoinInLevele)
    {
        Coin = coint;
        CountCoin = countCoinInLevele;
    }

    public void UpdateCoint(int coin)
    {
        Coin = coin;
    }

    public void ClearInfoAboutLevel()
    {
        CountCoin = CountCoin = LevelID = 0;
    }
}

public class SaveData 
{
    public DataGame DataGame { get; set; }

    public int GetScore => DataGame.Score;

    public int GetLevelID => DataGame.CurrentLevelID;

    public int GetPointId => DataGame.PointID;

    public bool IsKey => DataGame.Key;

    public int GetLobbyPortalID=> DataGame.LobbyPortalID;

    public SaveData() 
    {
        DefauldValue();
    }

    private void DefauldValue()
    {
        DataGame = new DataGame();
        DataGame.CurrentLevelID = (int)SceneID.TutorialScene;
        DataGame.PointID = 0;
        DataGame.Score = 0;
        DataGame.Key = false;
        DataGame.LobbyPortalID = -1;

        Level firstLevel = new Level();
        DataGame.Levels.Add(firstLevel);
    }

    public void NewCoin() => DataGame.Score++;

    public void SetPoint(int pointId) => DataGame.PointID = pointId;

    public void SetLevelId(int levelID)=> DataGame.CurrentLevelID = levelID;
    
    public void SetPortallId(int lobbyPortaID)=> DataGame.LobbyPortalID = lobbyPortaID;

    public void PickUpKey() => DataGame.Key = true;

}
