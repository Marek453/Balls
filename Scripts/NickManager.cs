using System;
using Mirror;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

public class NickManager : NetworkBehaviour
{
    [SyncVar(hook = "SyncText")]
    public string _name;

    public GameObject Body,_GameObject;
    public Text Name;
    private Canvas Canvas;
    private Camera camera;
    void Start()
    {
        Canvas = Name.GetComponentInParent<Canvas>();
        camera = FindObjectOfType<Camera>();
        Init();
    }

    [Command]
    void CmdChangeNick(string st)
    {
        SyncText("", st);
    }

    void SyncText(string st, string sd)
    {
        _name = sd;
    }

    private void Init()
    {
        if (isLocalPlayer)
        {
            if(!SteamManager.Initialized)
            {
                CmdChangeNick("Player " + Environment.UserName);
            }
            else
            {
                CmdChangeNick(SteamFriends.GetPersonaName());
            }
        }
    }


    private void Update()
    {
        Name.text = _name;
        Body.transform.position = _GameObject.transform.position;
        GameObject canvas = Canvas.gameObject;
        canvas.transform.position = _GameObject.transform.position;
        canvas.transform.LookAt(camera.transform);
        Name.transform.position = _GameObject.transform.position + new Vector3(0,1,0);
    }
}
