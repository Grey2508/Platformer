using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody PlayerBody;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public float MaxAngleGround;
    public float MaxSpeed;
    public Transform ColliderTransform;

    private float _jumpFrameCounter = 3;

    private int _directionVelocity;
    private bool _crouching;

    public bool Grounded
    {
        get;
        private set;
    }

    void Update()
    {
        if (_crouching || !Grounded)
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15);
        }
        else
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 15);
        }
    }

    public void SetCrouch(bool value)
    {
        _crouching = value;
    }

    public void Jump()
    {
        if (!Grounded)
            return;

        PlayerBody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);

        _jumpFrameCounter = 0;
    }

    public void SetDirectionVelocity(int value)
    {
        _directionVelocity = value;
    }

    private void FixedUpdate()
    {
        float speedMultiplier = (Grounded ? 1f : 0.2f);

        //ограниечение скорости в полете
        if (!Grounded)
        {
            if (PlayerBody.velocity.x > MaxSpeed && _directionVelocity > 0)
                speedMultiplier = 0;
            if (PlayerBody.velocity.x < -MaxSpeed && _directionVelocity < 0)
                speedMultiplier = 0;
        }

        PlayerBody.AddForce(_directionVelocity * MoveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);

        //добавление трения
        if (Grounded)
        {
            PlayerBody.AddForce(-PlayerBody.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15);
        }

        _jumpFrameCounter++;

        //кувырок в прыжке
        if (_jumpFrameCounter == 2)
        {
            PlayerBody.freezeRotation = false;
            PlayerBody.AddRelativeTorque(0, 0, 10, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);

        if (angle < MaxAngleGround && !Grounded)
        {
            Grounded = true;
            PlayerBody.freezeRotation = true;
        }

        if (collision.contactCount == 1) //чтобы при падении на наклонную поверхность не оставался в полный рост
        {
            if (angle > MaxAngleGround)
                Grounded = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }
}
