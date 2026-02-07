using Mirror;
using UnityEngine;

public class ColisionSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    private NetworkIdentity networkIdentity;
    private Player player;
    void Start()
    {
        networkIdentity = GetComponentInParent<NetworkIdentity>();
        player = GetComponentInParent<Player>();
    }
    void OnCollisionEnter(Collision collision)
    {
        source.PlayOneShot(clip);
    }

    void OnCollisionExit(Collision collision)
    {
        if (!networkIdentity.isLocalPlayer) return;
        player.isGrounded = false;
    }

    void OnCollisionStay(Collision collision)
    {
        if (!networkIdentity.isLocalPlayer) return;
        player.isGrounded = true;
    }
}
