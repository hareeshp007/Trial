using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float horizontal;
    [SerializeField] 
    private float vertical;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        handleInput();
        Movement();
    }
    private void handleInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    private void Movement()
    {
       if(horizontal!=0||vertical!=0)
        {
            Vector3 movement=new Vector3(horizontal,0, vertical);
            movement.Normalize();
            MoveRigidbody(movement);
        }
    }
    void MoveRigidbody(Vector3 movement)
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = currentPosition + movement * speed * Time.deltaTime;
        GetComponent<Rigidbody>().MovePosition(newPosition);
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Fallable"))
        {
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
