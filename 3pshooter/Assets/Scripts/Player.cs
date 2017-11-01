using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        HandleMovement(horizontal);
        float horizontal = Input.GetAxis("Horizontal");
    }
    private void HandleMovement(float horizontal)
    {
        rb.velocity = Vector2.left;  
    }
}
