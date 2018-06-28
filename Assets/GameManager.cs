using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int sixscore = 0;
    public int ninesocre = 0;
    public bool sixround = true;
    public int goalnum = 0;
    private bool end;
    public Text sixui;
    public Text nineui;
    public Text round;

    public GameObject next;
    public GameObject quit;

    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    public GameObject b5;
    public GameObject b6;
    public GameObject b7;
    public GameObject b8;
    public GameObject b9;


    public Image image;
    public ballcontroller white;
	void Start () {
        round.text = "小六的回合";
        StartCoroutine(Resetpos());
        end = false;
        sixui.text = "小六的分数：";
        nineui.text = "阿九的分数：";
        image.enabled = false;

        next.SetActive(false);
        quit.SetActive(false);
    }
	
	
	void Update ()
    {
		if(goalnum==9 && end==false)
        {
            sixround = false;
            round.text = "阿九的回合";
            white.transform.position = white.init;
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
            b4.SetActive(true);
            b5.SetActive(true);
            b6.SetActive(true);
            b7.SetActive(true);
            b8.SetActive(true);
            b9.SetActive(true);
            goalnum = 0;
            StartCoroutine(Resetpos());
            end = true;
        }
        else if(goalnum==9 && end==true)
        {
            if(sixscore>ninesocre)
            {
                round.text = "小六获胜！";
            }
            else if(sixscore<ninesocre)
            {
                round.text = "阿九获胜！";
            }
            else if(sixscore==ninesocre)
            {
                round.text = "    平局！";
            }
            Cursor.visible = true;
            image.enabled = true;

            next.SetActive(true);
            quit.SetActive(true);
        }

        sixui.text = "小六的分数：" + sixscore;
        nineui.text = "阿九的分数：" + ninesocre;
	}

    IEnumerator Resetpos()
    {
        yield return new WaitForSeconds(3.0f);
        round.text = "";
    }

}
