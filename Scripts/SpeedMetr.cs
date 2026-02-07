using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class SpeedMetr : NetworkBehaviour
{
    private TMP_Text Speedmetr;
    private Melon melon;
    private Rigidbody rigidbody;

    void Start()
    {
        melon = GetComponent<Melon>();
        rigidbody = GetComponentInChildren<Rigidbody>();
        Speedmetr = GameObject.Find("SpeedMetr").GetComponent<TMP_Text>();
    }
    void Update()
    {
        if (isLocalPlayer)
        {
            if (melon != null)
            {
                if (!melon.isDead)
                {
                    Speedmetr.text = "Speed" + "\n" + rigidbody.velocity.magnitude.ToString("0.0");
                }
            }
            else
            {
                Speedmetr.text = "Speed" + "\n" + rigidbody.velocity.magnitude.ToString("0.0");
            }
        }
    }
}
