using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b2 : MonoBehaviour {

    public GameManager a;
    public Vector3 init;
    void Start()
    {
        init = transform.position;
    }

   
  
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "hole")
        {
            if (a.sixround == true)
            {
                a.sixscore += 2;
            }
            else if (a.sixround == false)
            {
                a.ninesocre += 2;
            }
            a.goalnum += 1;
            transform.position = init;
            gameObject.SetActive(false);
        }
    }
}
