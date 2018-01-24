using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 30f;
    public float enemyHits = 0;
    public Sprite dood;
    public Sprite doodhurt1;
    public Sprite doodhurt2;
    private SpriteRenderer spriteRenderer;
    public void TakeDamage(float ammount)
    {
        health -= ammount;
        if (health == 30)
        {
            enemyHits = 0;
        }
        if (health == 20)
        {
            enemyHits = 1;
        }
        if (health == 10)
        {
            enemyHits = 2;
        }
        if (health <= 0f)
        {
            Die();
        }

    }
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
		
	}
		void Update () {
        if (enemyHits == 0)
        {
            spriteRenderer.sprite = dood;
        }
        if (enemyHits == 1)
        {
            spriteRenderer.sprite = doodhurt1;
        }
        if (enemyHits == 2)
        {
            spriteRenderer.sprite = doodhurt2;
        }
    }

    private void Die ()
    {
        Destroy(gameObject);
    }

}
