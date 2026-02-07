using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerList : NetworkBehaviour
{
    public GameObject Prefab,Obj;
    int count = 0;
    public GameObject[] Players;
    public static PlayerList singlenton;
    List<GameObject> list = new List<GameObject>();
    private void Awake()
    {
        singlenton = this;
    }

    public void Clear()
    {
        for (int i = 0; i < list.Count; i++)
        {
            DestroyImmediate(list[i]);
        }
        list.Clear();
    }
    [ClientRpc]
    public void RpcUpdateList()
    {
        Clear();
        Players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject ply in Players)
        {
            GameObject obj = Instantiate(Prefab, Obj.transform);
            obj.GetComponent<TMPro.TMP_Text>().text = ply.GetComponent<NickManager>()._name;
            list.Add(obj);
        }
    }
}
