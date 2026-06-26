using Photon.Pun;
using UnityEngine;

public class Character : MonoBehaviourPun
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
        direction.x += Input.GetAxisRaw("Horizontal");
        direction.z += Input.GetAxisRaw("Vertical");

        Debug.Log(direction.x + ", " + direction.z);

        Vector3.Normalize(direction);
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        rb.MovePosition(direction * speed * Time.deltaTime);

        Debug.Log("MOVE");
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
