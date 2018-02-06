using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class Player: MonoBehaviour
{
    public float speed = 5f;
 
    private float movementX = 0f;
    private float movementY = 0f;
    private Rigidbody2D rb;
    public float turnSpeed = 50f;   
	// Use this for initialization
	void Start ()
	{
	    rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    movementY = Input.GetAxis("Vertical");
	    movementX = Input.GetAxis("Horizontal");  
    rb.velocity = new Vector2(movementX * speed,movementY * speed );
	    if (Input.GetKey(KeyCode.J)) 
	    {   
	        transform.Rotate(Vector3.back*turnSpeed * Time.deltaTime);
	    }
	    if (Input.GetKey(KeyCode.K))
	    {
	        transform.Rotate( Vector3.forward*turnSpeed * Time.deltaTime);
        }




	}

   public void Lose()
    {
        Destroy(gameObject);
    }
}
    