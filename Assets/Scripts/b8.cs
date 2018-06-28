using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b8 : MonoBehaviour {

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
                a.sixscore += 8;
            }
            else if (a.sixround == false)
            {
                a.ninesocre += 8;
            }
            a.goalnum += 1;
            transform.position = init;
            gameObject.SetActive(false);
        }
    }
}
