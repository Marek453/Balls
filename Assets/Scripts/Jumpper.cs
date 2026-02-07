using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpper : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        other.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000);
    }
}
