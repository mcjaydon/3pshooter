using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public WaitForSeconds fireRate = new WaitForSeconds(0.07f);
    public LineRenderer LaserLine;
    public Text WinText;
    public Text NextLevelText;
 
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
        WinText.text = "";

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
        Vector2 endOfLaserLine = hit.point;
		    if (hit.collider != null)
		    {
		       
		        if (hit.collider.gameObject.tag == "Player")
		        {
		            Player player = hit.transform.GetComponent<Player>();
		            player.Lose();
		           StartCoroutine(EnemyLaser(hit.point)); 
		            LaserLine.SetPosition(0, GunEnd.position);
		            LaserLine.SetPosition(1, endOfLaserLine);


            }
		        
                
        }


    }

    private void Die ()
    {
       Destroy(gameObject);
        WinText.text = "You Won!";
        NextLevelText.text = "Next Level -->";

    }

    public IEnumerator EnemyLaser(Vector2 hitPoint)
    {
        LaserLine.enabled = true;
        yield return fireRate;
        LaserLine.enabled = false;

    }




}
