using Mirror;
using UnityEngine;

public class DisableUselesComponent : NetworkBehaviour
{
    public Behaviour[] behs; 
    void Start()
    {
        if (!isLocalPlayer)
        {
            foreach (Behaviour behaviour in behs)
            {
                Destroy(behaviour);
            }
        }
    }
}
