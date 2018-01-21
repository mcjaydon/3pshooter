using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 10f;

    public void TakeDamage(float ammount)
    {
        health -= ammount;
        if (health <= 0f)
        {
            Die();
        }

    }
	void Start ()
    {

		
	}
		void Update () {
		
	}

    private void Die ()
    {
        Destroy(gameObject);
    }

}
