using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b3 : MonoBehaviour {

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
                a.sixscore += 3;
            }
            else if (a.sixround == false)
            {
                a.ninesocre += 3;
            }
            a.goalnum += 1;
            transform.position = init;
            gameObject.SetActive(false);
        }
    }
}
