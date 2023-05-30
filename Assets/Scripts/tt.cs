using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tt : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float movementSpeed;

    public Transform playerTransform;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        print(Time.time);
        ConstMovement();
    }

    private void ConstMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 z1 = new Vector3(x * (movementSpeed * Time.deltaTime), 0, z * (movementSpeed * Time.deltaTime));
        transform.Translate(z1, Space.World);
    }

    public Vector3 decrease = new Vector3(0, -1, 0);

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pickable"))
        {
            Vector3 newPosition = playerTransform.position;
            newPosition.y += 1f;
            playerTransform.position = newPosition;
            other.gameObject.transform.SetParent(playerTransform);
            Vector3 decreasePosition = newPosition + decrease;
            other.gameObject.transform.position = decreasePosition;

            decrease.y -= 1;
            other.gameObject.tag = "Finish";
        }
    }
}