using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class GanfaulMovement : MonoBehaviour
{
    public float speed = 4f;
    public float turnSpeed = 120f;

    CharacterController cc;
    Animator anim;
    float yVel;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        var k = Keyboard.current;
        if (k == null) return;

        float turn = (k.dKey.isPressed ? 1 : 0) - (k.aKey.isPressed ? 1 : 0);
        float fwd = (k.wKey.isPressed ? 1 : 0) - (k.sKey.isPressed ? 1 : 0);

        transform.Rotate(0f, turn * turnSpeed * Time.deltaTime, 0f);

        if (cc.isGrounded && yVel < 0) yVel = -2f;
        yVel += Physics.gravity.y * Time.deltaTime;

        Vector3 move = transform.forward * fwd * speed;
        move.y = yVel;
        cc.Move(move * Time.deltaTime);

        anim.SetFloat("Speed", Mathf.Abs(fwd));
    }
}