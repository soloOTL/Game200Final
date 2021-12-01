using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinshLine : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isfinished;
    private bool startorfinish;
    GameManager gameManager;
    void Start()
    {
        isfinished = false;
        startorfinish = true;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (!startorfinish)
        {
            if (collider.tag.CompareTo("Player") == 0)
            {
                GameManager.isfinished = true;
            }
        }
        startorfinish = false;
    }
}
