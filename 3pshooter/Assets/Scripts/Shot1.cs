using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot1 : MonoBehaviour
{
    public LineRenderer laserline;
    public  WaitForSeconds shotDuration= new WaitForSeconds(0.07f);
    public Transform gunEnd;
    public Transform aimer;
    public float range =50f;
    public float damage = 10f;
	// Use this for initialization
	void Start ()
	{
        GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Fire1"))

	    {
            if (laserline == null)
            {
                Debug.Log("No Laserline");
            }
            Vector2 endOfLaserLine = Shot();
            laserline.SetPosition(0,gunEnd.position);
	        laserline.SetPosition(1, endOfLaserLine);
            StartCoroutine(ShotEffect());
	        
	    }
	}

    IEnumerator ShotEffect()
    {
        laserline.enabled = true;
        yield return shotDuration;
        laserline.enabled = false;
    }

    Vector2 Shot()
    {
        
     
        RaycastHit2D hit = Physics2D.Raycast(gunEnd.transform.position, aimer.position - gunEnd.position);
      if  (hit != null)
        {
           
            if(hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                   Enemy enemy = hit.transform.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(damage);

                    }

                    return hit.point;
                } else
                {
                    return hit.point;
                }
            }


        }
        return aimer.position;
    }
}
