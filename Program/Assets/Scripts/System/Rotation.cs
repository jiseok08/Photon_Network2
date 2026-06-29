using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float axis;
    [SerializeField] float speed;

    [SerializeField] float mouseX;
    [SerializeField] float mouseY;

    private void Update()
    {
        mouseX += Input.GetAxisRaw("Mouse X");
        mouseX += Input.GetAxisRaw("Mouse Y");
    }

    public void RotateX(float minAngle, float maxAngle)
    {
        Mathf.Clamp(axis, minAngle, maxAngle);
    }

    public void RotateY(Rigidbody rigidbody)
    {
        axis += mouseX * speed * Time.fixedDeltaTime;

        

        rigidbody.transform.eulerAngles = new Vector3(0, axis, 0);
    }
}
