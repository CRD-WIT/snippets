using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public playerA thePlayer;
   
    private Vector3 PlayerStartPoint;

    public Text timertxt;
    public float distanceTimer;
    public float msec;
    public float sec;
    public float min;
    public bool A;
    public bool B;
    public bool simulate;

    public int answer;
    public string PlayerInputsec;
    public string PlayerInputmsec;
    public GameObject second;
    public GameObject mellisecond;
    public float finalanswersec;
    public float finalanswermsec;


    // Start is called before the first frame update
    void Start()
    {
       
        PlayerStartPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (simulate == true)
        {
            thePlayer.moveSpeed = 3;

            if (sec == finalanswersec & msec == finalanswermsec)
            {
                thePlayer.moveSpeed = 0;
                StopCoroutine("StopWatch");

            }

        }
        
    }
    public void resetgame()
    {
        

    }
    public void timeStart()
    {
        StartCoroutine("StopWatch");
    }
    IEnumerator StopWatch()
    {
        while (true)
        {
            distanceTimer += Time.deltaTime;
            msec = (int)((distanceTimer - (int)distanceTimer) * 100);
            sec = (int)(distanceTimer % 60);
            min = (int)(distanceTimer / 60 % 60);
            timertxt.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, msec);

            yield return null;
        }
    }
   
    public void StoreAnswer()
    {
        simulate = true;
        PlayerInputsec = second.GetComponent<Text>().text;
        int.TryParse(PlayerInputsec, out answer);
        finalanswersec = 1 * (float)answer;
        PlayerInputmsec = mellisecond.GetComponent<Text>().text;
        int.TryParse(PlayerInputmsec, out answer);
        finalanswermsec = 1 * (float)answer;
    }
   
}
