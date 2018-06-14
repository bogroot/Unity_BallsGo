using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour {

    public GameObject maincam;
    public GameObject sencondcam;

    private bool mainon;

	void Start () {
        maincam.SetActive(true);
        sencondcam.SetActive(false);
        mainon = true;
       
	}
	
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.V) && mainon==true)
        {
            maincam.SetActive(false);
            sencondcam.SetActive(true);
            mainon = false;
        }
        else if(Input.GetKeyDown(KeyCode.V) && mainon==false)
        {
            maincam.SetActive(true);
            sencondcam.SetActive(false);
            mainon = true;
        }
	}
}
