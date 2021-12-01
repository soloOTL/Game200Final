using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarControl : MonoBehaviour
{
    public MeshRenderer[] wheelmesh;
    public WheelCollider[] wheel;
    private float maxangle;
    private float maxtoque;
    //public GameObject warningtext;
    public static bool istime = false;
    public bool handbrake = false;
    public float handbrakedragfactor = 0.5f;
    public float initdragmulitpx = 0.5f;
    public float handbraketime = 0.0f;
    public float handbraketimer=1.0f;
    public AudioClip[] soundcontrol;
    public Rigidbody rb;
    public float throttle = 0.0f;
    private float steer = 0.0f;
    public float topspeed=160.0f;
   public  const float minturn = 10;
    public const float maxturn = 15;
   public float currentvelocity;
    public float currentenginepower = 0.0f;
    public static Quaternion carrotation;
   
    void Start()
    {
        maxangle = 30;
        maxtoque = 200;
        rb=GetComponent<Rigidbody>();
        carrotation = transform.rotation;
        topspeed *= 0.277f;
        this.GetComponent<AudioSource>().clip = soundcontrol[0];
        this.GetComponent<AudioSource>().Play();
        //warningtext.GetComponent<Text>().text = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 r = transform.InverseTransformDirection(rb.velocity);
        steer = Input.GetAxisRaw("Horizontal");
        throttle= Input.GetAxisRaw("Vertical");
        currentvelocity = rb.velocity.magnitude;
        
        if (istime)
        {
            move();
            updateengine();
            checkspeed();
            //checkcarrotation();
            checkhandbrake();
            rebirth();
        }
       
    }


    void move()
    {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.GetComponent<AudioSource>().clip = soundcontrol[1];
            this.GetComponent<AudioSource>().playOnAwake = false;
            this.GetComponent<AudioSource>().loop = true;
            this.GetComponent<AudioSource>().Play();

        }
        for (int i = 0; i < 2; i++)
        {
            wheel[i].steerAngle = steer * maxangle;
        }
        foreach (var o in wheel)
        {
            o.motorTorque = currentenginepower * throttle;
        }

        for (int i = 0; i < 4; i++)
        {
            wheelmesh[i].transform.localRotation = Quaternion.Euler(wheel[i].rpm * 6, wheel[i].steerAngle, 0);
        }
    }

    void checkhandbrake()
    {
      
        if (Input.GetKey("space"))
        {
            if (!handbrake)
            {
                handbrake = true;
                handbraketime = Time.time;

                this.GetComponent<AudioSource>().clip = soundcontrol[2];
                this.GetComponent<AudioSource>().Play();
                this.GetComponent<AudioSource>().loop = false;

                foreach (var o in wheel)
                {
                    o.brakeTorque = handbrakedragfactor*rb.velocity.magnitude;
                    
                }
            }
        }
        else if (handbrake)
        {
            handbrake = false;
           // StartCoroutine((IEnumerator)stophandbrake(Mathf.Min(5, Time.time - handbraketime)));
            foreach (var o in wheel)
            {
                o.brakeTorque = 0;
            }

        }
    }

    void updateengine()
    {if (throttle == 0&&currentenginepower>0)
            currentenginepower -= Time.deltaTime * 200;
        else if(throttle>0&&currentenginepower<maxtoque)
        {
            currentenginepower += Time.deltaTime * 200;
        }

    }



    //void checkcarrotation()
    //{
    //    if(transform.eulerAngles.z<-90|| transform.eulerAngles.z > 90)
    //    {
            
    //       // warningtext.GetComponent<Text>().text = "PRESS F TO REBIRTH";
    //    }
    //}
    private void rebirth()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            transform.position = new Vector3(CheckPoints.currentcheckpoint.x,3,CheckPoints.currentcheckpoint.z);
            transform.rotation = carrotation;
        }
    }
    void checkspeed()
    {
        if((rb.velocity.magnitude/0.277f)>=65)
        {
            this.GetComponent<AudioSource>().clip = soundcontrol[3];
            this.GetComponent<AudioSource>().playOnAwake = false;
            this.GetComponent<AudioSource>().loop = true;
            this.GetComponent<AudioSource>().Play();
            
        }
        //else if((rb.velocity.magnitude / 0.277f) < 70&&!handbrake)
        //{
        //    this.GetComponent<AudioSource>().clip = soundcontrol[1];
        //    this.GetComponent<AudioSource>().playOnAwake = false;
        //    this.GetComponent<AudioSource>().loop = true;
        //    this.GetComponent<AudioSource>().Play();
        //}
        else if((rb.velocity.magnitude / 0.277f) ==0)
        {
            this.GetComponent<AudioSource>().clip = soundcontrol[0];
            this.GetComponent<AudioSource>().playOnAwake = false;
            this.GetComponent<AudioSource>().loop = true;
            this.GetComponent<AudioSource>().Play();
        }
    }
}
