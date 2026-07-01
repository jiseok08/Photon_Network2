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
        Countrol();
    }

    public void Countrol()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        if (direction.x > 0 || direction.z > 0)
        {
            animator.SetInteger("X", (int)direction.x);
            animator.SetInteger("Z", (int)direction.z);
        }

        direction.Normalize();
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
        rigidbody.MovePosition(rigidbody.position + rigidbody.transform.TransformDirection(direction) * speed * Time.fixedDeltaTime);
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
}
