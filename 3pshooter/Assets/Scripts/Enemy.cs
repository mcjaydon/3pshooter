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
    public int turnSpeed = 5;
    public Transform GunEnd;
    public Transform aimer;
    public Transform BadGuy;
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
		    transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
		    RaycastHit2D hit = Physics2D.Raycast(GunEnd.transform.position, aimer.position - GunEnd.position);
		    if (hit.collider != null)
		    {
                //Debug.Log("whoopdidoo " + hit.collider.gameObject.tag);
		
   
		    }
		    if (hit.collider.gameObject.tag == "Player")
		    {
		        Player player = hit.transform.GetComponent<Player>();
		        player.Lose();

		    }

    }

    private void Die ()
    {
       Destroy(gameObject);
    }

}
