using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ballcontroller : MonoBehaviour {

    public Transform cuepo;
    public GameObject bal;
    public GameObject cue;
    private Rigidbody ba;

    public Slider xuli;

    public GameManager a;

    private float minforce = 1.0f;
    private float maxforce = 90.0f;
    private float maxchargetime = 1.0f;
    private float chargespeed;
    public float speed;
    public float force;
    Vector3 savepo;
    public Vector3 init;


    void Start () {
        ba = bal.GetComponent<Rigidbody>();
        chargespeed = (maxforce - minforce) / maxchargetime;
        init = transform.position;
    }


    void FixedUpdate ()
    {
        
            if (ba.velocity == new Vector3(0, 0, 0))
            {
                cue.SetActive(true);
                transform.eulerAngles = new Vector3(0, -90, 0); ;
                moveandhit();

            }
            else if (ba.velocity != new Vector3(0, 0, 0))
            {
                cue.SetActive(false);
            }
        

    }

    

    void moveandhit()
    {
        
        xuli.value = minforce;
        float h = Input.GetAxis("Horizontal");
        cuepo.RotateAround(transform.position, Vector3.up, h * speed);
        Vector3 direct = transform.position - cuepo.position;
        direct.Normalize();

        if(force>maxforce  )
        {
            force = maxforce;
            chargespeed = -chargespeed;
        }
        else if(force<minforce)
        {
            force = minforce;
            chargespeed = -chargespeed;
        }
        else if(Input.GetMouseButtonDown(0))
        {
            savepo = cuepo.position;
            force = minforce;
        }
        else if(Input.GetMouseButton(0) )
        {
            if( Mathf.Abs(cuepo.localPosition.z)<0.4f)
            {
                cuepo.Translate(Vector3.forward * Time.deltaTime, Space.Self);
            }
  
            force += chargespeed *Time.deltaTime;
            xuli.value = force;
        }
        else if(Input.GetMouseButtonUp(0) )
        {

            cuepo.position = savepo;
            ba.AddForce(new Vector3(direct.x, 0, direct.z) * force);
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            cuepo.position = transform.position;
        }   
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="hole")
        {
            StartCoroutine(Resetpos());
            if (a.sixround == true)
            {
                a.sixscore -=2;
            }
            else if (a.sixround == false)
            {
                a.ninesocre -= 2;
            }
        }
    }
    IEnumerator Resetpos()
    {
        yield return new WaitForSeconds(1.0f);
        transform.localPosition = new Vector3(0.95f, 0.4f, 0.0f);
    }
}
