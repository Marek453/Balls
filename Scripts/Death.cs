using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Melon melon;
    private Rigidbody rigidbody;

    void Start()
    {
        melon = GetComponentInParent<Melon>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter()
    {
        if (rigidbody.velocity.magnitude > 55)
        {
            melon._Player.SetActive(false);
            GameObject dead = Instantiate(melon.Explose);
            melon.isDead = true;
            foreach (var obj in dead.GetComponentsInChildren<Rigidbody>())
            {
                obj.velocity += melon.CamPos.transform.forward * 10 * melon.speed;
            }
            dead.transform.position = this.transform.position;
            NetworkServer.Spawn(dead);
            Invoke("Dead", 2);
        }
    }

    void Dead()
    {
        NetworkStartPosition[] array = GameObject.FindObjectsOfType<NetworkStartPosition>();
        foreach (NetworkStartPosition val in array)
        {
            melon.isDead = false;
            melon._Player.SetActive(true);
            transform.position = val.gameObject.transform.position;
            transform.rotation = val.gameObject.transform.rotation;
            rigidbody.velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
