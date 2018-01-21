using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot1 : MonoBehaviour
{
    private LineRenderer laserline;
    private  WaitForSeconds shotDuration= new WaitForSeconds(0.7f);
    public Transform gunEnd;
    public Transform aimer;
    public float range =50f;
    public float damage = 10f;
	// Use this for initialization
	void Start ()
	{
	  
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Fire1"))

	    {
            laserline.SetPosition(0,gunEnd.position);
	        laserline.SetPosition(1, aimer.position);
            StartCoroutine(ShotEffect());
	        Shot();
	    }
	}

    IEnumerator ShotEffect()
    {
        laserline.enabled = true;
        yield return shotDuration;
        laserline.enabled = false;
    }

    void Shot()
    {
        RaycastHit hit;
      if  (Physics.Raycast(gunEnd.transform.position, aimer.transform.forward, out hit, range))
        {
            Debug.Log("YYYYYYYEEEEEEESSSSS");
            
        }
    }
}
