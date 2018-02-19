using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour {
    void Start()
    {
        Debug.Log("Init BoxScript");

    }

    void OnCollisionEnter()
    {
        Debug.Log("On Collision Enter BoxScript");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("On Trigger Enter BoxScript");
    }
}
