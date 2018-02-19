using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Triggers : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
    
   Application.LoadLevel(Application.loadedLevel+1);

    }
}
