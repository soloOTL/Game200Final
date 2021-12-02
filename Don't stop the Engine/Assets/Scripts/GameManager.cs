using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float starttime=5.0f;
    public GameObject readgo;
    public static int totallife = 3;
    private int currentlife ;
    public static int score = 0;
    public GameObject lifetext;
    public GameObject scoretext;
    public GameObject player;
    
    public int currentspeed;
    public Rigidbody rb;
    public static bool isfinished;
    public CheckPoints[] checkPoints;
    public GameObject wintext;
    public float readygotime = 2.0f;
    public GameObject winscoretext;
    void Start()
    {
        currentlife = totallife;
        StartCoroutine(startTime());
        lifetext.GetComponent<Text>().text = "LIFE: " + currentlife.ToString();
        winscoretext.GetComponent<Text>().text = "";
        currentspeed = (int)(rb.velocity.magnitude/0.277f);
        isfinished = false;
        wintext.GetComponent<Text>().text = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CarControl.istime&&starttime == 0)
        {
            updatespeed();
            CarControl.istime = true;
            readgo.GetComponent<Text>().text = "GO";
            readygotime-=Time.deltaTime;

        }
        updatespeed();
        if(isfinished)
        {
            checkiffinish();
        }
        if(readygotime<=0)
        {
            readgo.GetComponent<Text>().text = "";
        }
        else if(starttime<=0)
        {
            readygotime -= Time.deltaTime;
        }
 
    }
    IEnumerator startTime()
    {
        while (starttime >= 0)
        {
            readgo.GetComponent<Text>().text = starttime.ToString();
            yield return new WaitForSeconds(1);
            starttime--;
        }
    }
    void updatespeed()
    {
        currentspeed = (int)(rb.velocity.magnitude / 0.277f);
        
    }
     public void  checkiffinish()
    {
        for(int i=0;i<6;i++)
        {
            if(checkPoints[i].ischecked)
            {
                if (i == 5)
                {
                    player.GetComponent<AudioSource>().Stop();
                    wintext.GetComponent<Text>().text = "FINISHED 1ST";
                    winscoretext.GetComponent<Text>().text = score.ToString();
                    if (!this.GetComponent<AudioSource>().isPlaying)
                    {
                        this.GetComponent<AudioSource>().loop = true;
                        this.GetComponent<AudioSource>().Play();
                    }
                    
                   
                }
                else
                    continue;
            }
        }
    }
  public void updatelife()
    {
        lifetext.GetComponent<Text>().text = "LIFE: " + currentlife.ToString();
    }
}
