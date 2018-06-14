using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcontroller : MonoBehaviour {

    public Transform ball;
    public Transform cuepo;
    public GameObject bal;
    public float speed;
    public GameObject cue;
    public int force;
    private Rigidbody ba;


    void Start () {
        ba = bal.GetComponent<Rigidbody>();
        cue.SetActive(true);
    }
	
	
	void FixedUpdate ()
    {
        
        if (ba.velocity == new Vector3(0, 0, 0))
        {
            cue.SetActive(true);
            transform.eulerAngles = new Vector3(0, -90, 0); ;
            moveandhit();

        }
        else if(ba.velocity!=new Vector3(0,0,0))
        {
            cue.SetActive(false);
            
        }
   
        
    }

    void moveandhit()
    {
        float h = Input.GetAxis("Horizontal");
        cuepo.RotateAround(ball.position, Vector3.up, h * speed);
        Vector3 direct = transform.position - cuepo.position;
        direct.Normalize();
        if (Input.GetMouseButton(0))
        {
            ba.AddForce(new Vector3(direct.x, 0, direct.z) * force);
        }
    }
   
}
