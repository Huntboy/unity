using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBoardManager : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI putts;

    private PlayerRecord playerRecord; 

    void Start()
    {
        playerRecord = GameObject.Find("Player Record").GetComponent<PlayerRecord>();
        name.text = "";
        putts.text = "";
        foreach (var player in playerRecord.GetScoreboardList())
        {
            name.text += player.name + "\n";
            putts.text += player.totalPutts + "\n";
        }
    }

    void Update()
    {
        putts.fontSize = name.fontSize;
    }

    public void ButtonReturenMenu()
    {
        Destroy(playerRecord.gameObject);
        SceneManager.LoadScene("Menu");
    }
}