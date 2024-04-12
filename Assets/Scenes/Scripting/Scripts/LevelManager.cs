using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Alteruna;


public class LevelManager : CommunicationBridge
{
    public int sceneBuildIndex;
    public BallController ball;
    public TextMeshProUGUI labelPlayerName;

    private PlayerRecord playerRecord;
    private int playerIndex;

    void Start()
    {
        playerRecord = GameObject.Find("Player Record").GetComponent<PlayerRecord>();
        playerIndex = 0;
        SetupPlayer();
    }

    private void SetupPlayer()
    {
        ball.SetUpBall(playerRecord.playerColours[playerIndex]);
        labelPlayerName.text = playerRecord.playerList[playerIndex].name;
    }

    public void NextPlayer(int previousPutts)
    {
        playerRecord.AddPutts(playerIndex, previousPutts);
        if (playerIndex < playerRecord.playerList.Count - 1)
        {
            playerIndex++;
            SetupPlayer();
        }
        else
        {
            if (playerRecord.levelIndex == playerRecord.levels.Length - 1)
            {
                Multiplayer.LoadScene("Scoreboard");
            }
            else
            {
                playerRecord.levelIndex++;
                Multiplayer.LoadScene(playerRecord.levels[playerRecord.levelIndex]);
            }
        }
    }
}

