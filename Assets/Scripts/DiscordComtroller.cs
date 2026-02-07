using Discord;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;
using Mirror;
using UnityEngine.SceneManagement;

public class DiscordComtroller : MonoBehaviour
{
  public static Discord.Discord discord;
  public ActivityManager activityManager;

  public static DiscordComtroller singleton;
  public bool DiscordDisponible;

  void Awake()
  {
    DontDestroyOnLoad(base.gameObject);
    if (singleton == null)
    {
      singleton = this;
    }
    else
    {
      DestroyImmediate(base.gameObject);
    }
  }
  void Start()
  {
    foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
    {
      if (p.ToString() == "System.Diagnostics.Process (Discord)")
      {
        Debug.Log("Discord is Anable");
        DiscordDisponible = true;
      }
    }
    if (DiscordDisponible == true)
    {
      discord = new Discord.Discord(1177975555900047481, (System.UInt64)Discord.CreateFlags.Default);
      activityManager = discord.GetActivityManager();
    }
  }

  void OnApplicationQuit()
  {
    if (discord == null) return;
    discord.Dispose();
  }

  void MainMenu()
  {
    if (DiscordDisponible == true)
    {
      Activity activity = new Activity();
      activity.Party.Size.CurrentSize = 0;
      activity.Party.Size.MaxSize = 0;
      activity.State = "Main Menu";
      activity.Details = "( ͡° ͜ʖ ͡°)";
      activity.Timestamps.Start = 0;
      activity.Assets.SmallImage = "";
      activity.Assets.SmallText = "";
      activity.Assets.LargeImage = "balls_logo_main";
      activity.Assets.LargeText = "Balls";
      activityManager.UpdateActivity(activity, res => { });
    }
  }

  void Game()
  {
    if (DiscordDisponible == true)
    {
      Activity activity = new Activity();
      activity.State = "Playing Solo";
      GameObject[] Players = PlayerList.singlenton.Players;
      foreach (var ball in Players)
      {
        if (ball.GetComponent<NetworkIdentity>().isLocalPlayer)
        {
          activity.Details = "Ball select: " + ball.GetComponent<Player>().NameBall;
        }
      }
      activity.Party.Id = "ae488379-351d-4a4f-ad32-2b9b01c91657";
      activity.Party.Size.CurrentSize = Players.Length;
      activity.Party.Size.MaxSize = NetworkServer.maxConnections;
      activity.Timestamps.Start = 0;
      activity.Assets.SmallImage = "";
      activity.Assets.SmallText = "";
      activity.Assets.LargeImage = "balls_logo_main";
      activity.Assets.LargeText = "Balls";
      activityManager.UpdateActivity(activity, res => { });
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (DiscordDisponible == true)
    {
      if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
      {
        MainMenu();
      }
      else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene"))
      {
        Game();
      }
      discord.RunCallbacks();
    }
  }
}
