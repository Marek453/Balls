using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public Camera PlayerCam;
    public GameObject _Player;
    public GameObject CamPos;
    public virtual float Speed { get; set; }
    public virtual float SpeedLook { get; set; }
    public virtual float SpeedJump { get; set; }
    public string NameBall;
    public bool isGrounded = false;
}
