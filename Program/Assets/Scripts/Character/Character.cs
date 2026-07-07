using Photon.Pun;
using UnityEngine;

public class Character : MonoBehaviourPun, IPunObservable
{
    [SerializeField] float speed;
    [SerializeField] float health = 100;
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
        if (photonView.IsMine)
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
        rotation.MouseX = Input.GetAxisRaw("Mouse X");

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
        if (photonView.IsMine)
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
        if (photonView.IsMine)
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
        if (other.CompareTag("Robot"))
        {
            PhotonView view = other.GetComponent<PhotonView>();

            if (view != null)
            {
                Debug.Log("Robot Object does not have a PhotonView");
            }

            if (view.IsMine || PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Destroy(view.gameObject);
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            // 내 오브젝트라면 다른 클라이언트에게 데이터를 전송합니다.
            stream.SendNext(health);
        }
        else
        {
            // 다른 클라이언트의 데이터를 받습니다.
            health = (float)stream.ReceiveNext();
        }
    }
}
