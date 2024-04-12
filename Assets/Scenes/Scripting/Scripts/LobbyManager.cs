using UnityEngine;
using System.Collections.Generic;
using static PlayerRecord;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance { get; private set; }

    public List<Player> Players { get; private set; } = new List<Player>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPlayer(Player player)
    {
        Players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        Players.Remove(player);
    }

    public void StartGame()
    {
        // Notify other scripts that the game should start
    }

    // Other lobby management methods
}
