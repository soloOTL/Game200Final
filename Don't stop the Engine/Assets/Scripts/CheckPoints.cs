using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    // Start is called before the first frame update
  
    public bool ischecked;
    public Vector3 currentposition;
    public static Vector3 currentcheckpoint;
    CarControl carControl;
    void Start()
    {
       currentposition = transform.position;
        ischecked = false;
        currentcheckpoint = new Vector3(77.56f,3.55f,-141.81f);
    }

    // Update is called once per frame
   
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag.CompareTo("Player")==0)
        {
            currentcheckpoint = currentposition;
            ischecked = true;
            //CarControl.carrotation = transform.rotation;
        }
    }
}
