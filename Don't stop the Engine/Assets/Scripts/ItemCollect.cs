using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollect : MonoBehaviour
{
    public GameObject car;

    public GameManager gameManager;
    public GameObject scoretext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag.CompareTo("SpeedUp")==0)
        { 
           
            car.GetComponent<CarControl>().currentenginepower += 200;//
            Destroy(c.gameObject);
        }
        
        
        
        if (c.gameObject.tag.CompareTo("Coin")==0)
        { 
            
            GameManager.score += 100;
            Destroy(c.gameObject);
            updatescore();
        }
        
    }
    void updatescore()
    {
        scoretext.GetComponent<Text>().text = "SCORE: " + GameManager.score.ToString();
    }
}
