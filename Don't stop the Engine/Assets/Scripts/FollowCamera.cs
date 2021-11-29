using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform PlayerPos;
    private Vector3 offsetPos;
    private Vector3 tempos;
    void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        offsetPos = new Vector3(-0.507f,2.28f,-5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tempos = PlayerPos.position + PlayerPos.TransformDirection(offsetPos);
        this.transform.position = Vector3.Lerp(this.transform.position,tempos,Time.fixedDeltaTime*2);
        this.transform.LookAt(PlayerPos);
    }
}
