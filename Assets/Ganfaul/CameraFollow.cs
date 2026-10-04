using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float height = 2f;
    public float lookHeight = 1.5f;
    public float followSmooth = 8f;
    public float rotateSmooth = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desired = target.position - target.forward * distance + Vector3.up * height;
        transform.position = Vector3.Lerp(transform.position, desired, followSmooth * Time.deltaTime);

        Vector3 lookPoint = target.position + Vector3.up * lookHeight;
        Quaternion lookRot = Quaternion.LookRotation(lookPoint - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, rotateSmooth * Time.deltaTime);
    }
}