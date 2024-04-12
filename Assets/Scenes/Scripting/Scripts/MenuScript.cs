using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Alteruna;

public class MenuScript : CommunicationBridge
{
    public TMP_InputField InputPlayerName;
    public PlayerRecord playerRecord;
    public Button buttonStart;
    public Button buttonAddPlayer;
    public void ButtonAddPlayer()
    {
        playerRecord.AddPlayer(InputPlayerName.text);
        buttonStart.interactable = true;
        InputPlayerName.text = "";
        if (playerRecord.playerList.Count == playerRecord.playerColours.Length)
        {
            buttonAddPlayer.interactable = false;
        }
    }

    public void ButtonStart()
    {
        Multiplayer.LoadScene(playerRecord.levels[0]);
    }
}
