using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class CustomNetManager : NetworkManager
{
    public GameObject[] Balls;
    public GameObject Text;
    public GameObject[] Maps;
    
    public override void OnStartServer()
    {
        GameObject map = Instantiate(Maps[PlayerPrefs.GetInt("MapSelect")]);
        NetworkServer.Spawn(map);
    }

    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        PlayerList.singlenton.Clear();
    }
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        Transform startPos = GameObject.Find("SpecSpawn").transform;
        GameObject player = startPos != null
            ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
            : Instantiate(playerPrefab);

        // instantiating a "Player" prefab gives it the name "Player(clone)"
        // => appending the connectionId is WAY more useful for debugging!
        player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
        NetworkServer.AddPlayerForConnection(conn, player);
        StartCoroutine(_remove(conn, player));
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        StartCoroutine(RemovePlayer());
        NetworkServer.DestroyPlayerForConnection(conn);
    }
    
    IEnumerator RemovePlayer ()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerList.singlenton.RpcUpdateList();
    }

    IEnumerator _remove (NetworkConnectionToClient conn,GameObject player)
    {
        yield return new WaitForSeconds(1f);
        int i = player.GetComponent<SelectSync>().Select;
        print(i);
        NetworkServer.DestroyPlayerForConnection(conn);
        Transform startPos = GetStartPosition();
        GameObject ball = startPos != null
           ? Instantiate(Balls[i], startPos.position, startPos.rotation)
           : Instantiate(Balls[i]);
        ball.name = $"{"Ball " + i} [connId={conn.connectionId}]";
        NetworkServer.AddPlayerForConnection(conn, ball);
        yield return new WaitForSeconds(0.1f);
        PlayerList.singlenton.RpcUpdateList();
    }
}
