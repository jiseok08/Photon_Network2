using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float axis;
    [SerializeField] float speed;

    public float MouseX { set; get; }
    public float MouseY { set; get; }

    public void RotateX(float minAngle, float maxAngle)
    {
        axis += MouseX * speed;

        axis = Mathf.Clamp(axis, minAngle, maxAngle);

        transform.localEulerAngles = new Vector3(-axis, 0, 0);
    }

    public void RotateY(Rigidbody rigidbody)
    {
        axis += MouseX * speed;

        rigidbody.transform.eulerAngles = new Vector3(0, axis, 0);
    }
}
