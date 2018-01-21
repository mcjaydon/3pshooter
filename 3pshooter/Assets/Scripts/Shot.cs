using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public float damage = 100000f;
    public Transform gunEnd ;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private LineRenderer laserLine;
    public Transform aimer;
    public float nextFire;
    private RaycastHit hit;

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            laserLine.SetPosition(0, gunEnd.position);
            laserLine.SetPosition(1, aimer.position);
            


                        if (Physics.Raycast(gunEnd.position, aimer.position, out hit, weaponRange))
                        {
                            Debug.Log("FUUUUUUCKKKYEA");

                        }
        }



    }

    IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;

    }
}