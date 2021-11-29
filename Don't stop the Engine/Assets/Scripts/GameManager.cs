using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float starttime=5.0f;
    public GameObject readgo;
    public int totallife = 5;
    private int currentlife ;
    public int score = 0;
    public GameObject lifetext;
    public GameObject scoretext;
    public GameObject speedtext;
    CarControl carControl;
    public int currentspeed;
    public Rigidbody rb;
    void Start()
    {
        currentlife = totallife;
        StartCoroutine(Time());
        lifetext.GetComponent<Text>().text = "LIFE: " + currentlife.ToString();
        speedtext.GetComponent<Text>().text ="SPEED: "+ currentspeed.ToString()+" :KM/H";
        currentspeed = (int)(rb.velocity.magnitude/0.277f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!CarControl.istime&&starttime == 0)
        {
            readgo.GetComponent<Text>().text = "go";
            CarControl.istime = true;
            updatespeed();
        }
        updatespeed();
    }
    IEnumerator Time()
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
        speedtext.GetComponent<Text>().text ="SPEED: "+ currentspeed.ToString()+" KM/H";
    }
}
