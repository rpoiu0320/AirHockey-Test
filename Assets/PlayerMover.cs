using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private float curSpeed;
    private Rigidbody rb;

    private Vector3 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-moveSpeed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(moveSpeed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, moveSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -moveSpeed);
        }

        //    private void Move()
        //{
        //    rb.AddForce(moveDir * moveSpeed * Time.deltaTime, ForceMode.Force);
        //}

        //private void OnMove(InputValue value)
        //{
        //    moveDir.x = value.Get<Vector2>().x;
        //    moveDir.z = value.Get<Vector2>().y;
        //}
    }
}