using Photon.Pun;
using UnityEngine;
using UnityEngine.UIElements;

public class Head : MonoBehaviourPunCallbacks
{
    [SerializeField] Rotation rotation;

    [SerializeField] float minimumAngle = -55f;
    [SerializeField] float maximumAngle = 55f;

    private void Awake()
    {
        rotation = GetComponentInParent<Rotation>();
    }

    private void FixedUpdate()
    {
        rotation.MouseY = Input.GetAxisRaw("Mouse Y");

        rotation.RotateX(minimumAngle, maximumAngle);
    }
}
