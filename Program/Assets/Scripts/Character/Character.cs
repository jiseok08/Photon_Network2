using Photon.Pun;
using UnityEngine;

public class Character : MonoBehaviourPun
{
    [SerializeField] float speed;
    [SerializeField] Rotation rotation;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Animator animator;
    [SerializeField] Vector3 direction;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        rotation = GetComponent<Rotation>();
    }

    private void Start()
    {
        Disablecamera();
    }

    private void Update()
    {
        if(photonView.IsMine)
        {
            Countrol();

            Animate();

            Pause();
        }
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MouseManager.Instance.SetMouse(true);

            PanelManager.Instance.Open(Panel.Pause);
        }
    }

    public void Countrol()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        direction.Normalize();
    }

    void Animate()
    {
        animator.SetInteger("X", Mathf.Abs((int)direction.x));
        animator.SetInteger("Z", Mathf.Abs((int)direction.z));
    }

    private void FixedUpdate()
    {
        if(photonView.IsMine)
        {
            Move();

            rotation.RotateY(rigidbody);
        }
    }

    public void Move()
    {
        rigidbody.linearVelocity = rigidbody.transform.TransformDirection(direction).normalized * speed;
    }

    private void Disablecamera()
    {
        if(photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            Camera eyes = transform.GetComponentInChildren<Camera>();

            eyes.GetComponent<AudioListener>().gameObject.SetActive(false);

            eyes.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Robot"))
        {
            PhotonNetwork.Destroy(other.gameObject);
        }
    }
}
