using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class Melon : Player
{
    public override float Speed { get => speed; set => speed = value; }
    public override float SpeedLook { get => speedLook; set => speedLook = value; }
    public override float SpeedJump { get => speedJump; set => speedJump = value; }

    public float speed = 9;
    public float speedLook = 0.7f;
    public float speedJump = 68;
    public bool isDead = false;
    public GameObject Explose;
    public AudioClip boost;
    private Slider BoostSlider;
    private Rigidbody rigidbody;
    private ColisionSound colisionSound;


    void Start()
    {
        rigidbody = _Player.GetComponent<Rigidbody>();
        colisionSound = GetComponentInChildren<ColisionSound>();
        Cursor.lockState = CursorLockMode.Locked;
        BoostSlider = GameObject.Find("Boost").GetComponent<Slider>();
    }

    void Update()
    {
        Move();
        Look();
        Boost();
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Boost()
    {
        if (BoostSlider.value == 100)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                BoostSlider.value = 0;
                rigidbody.velocity += CamPos.transform.forward * 10 * speed;
                colisionSound.source.PlayOneShot(boost);
            }
        }
        else
        {
            BoostSlider.value += 4 * Time.deltaTime;
        }
    }

    void Move()
    {
        Vector2 _Input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 dir = CamPos.transform.forward * _Input.y + CamPos.transform.right * _Input.x;
        rigidbody.AddForce(dir.x * Speed * 100 * Time.deltaTime, 0, dir.z * Speed * 100 * Time.deltaTime);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector3(0, SpeedJump * 700 * Time.fixedDeltaTime, 0));
        }
    }

    void Look()
    {
        float rotX = CamPos.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * SpeedLook * 100 * Time.deltaTime;
        CamPos.transform.localEulerAngles = new Vector3(0, rotX, 0);
    }
}
