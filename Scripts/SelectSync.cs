using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSync : NetworkBehaviour
{
    [SyncVar(hook = "SyncSelect")]
    public int Select;
    [Command]
    void CmdChangeSelect(int st)
    {
        RpcChangeSelect( st);
    }

    [ClientRpc]
    void RpcChangeSelect(int st)
    {
        SyncSelect(0, st);
    }

    void SyncSelect(int st, int sd)
    {
        Select = sd;
    }

    private void Start()
    {
        if (!isLocalPlayer) return;
        CmdChangeSelect(PlayerPrefs.GetInt("BallSelect"));
    }
}
