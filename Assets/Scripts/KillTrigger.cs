using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class KillTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<NetworkIdentity>() != null && other.GetComponentInParent<NetworkIdentity>().tag == "Player")
        {
            NetworkStartPosition[] spawns = FindObjectsOfType<NetworkStartPosition>();
            foreach (NetworkStartPosition spawner in spawns)
            {
                other.transform.position = spawner.gameObject.transform.position;
                other.transform.rotation = spawner.gameObject.transform.rotation;
                other.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }
    }
}
