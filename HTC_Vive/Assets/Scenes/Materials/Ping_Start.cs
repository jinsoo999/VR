using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping_Start : MonoBehaviour {

    public GameObject ball;
    public Transform FirePos;

    float timer;
    int waitingTime;


    void Start()
    {
        timer = 0;
        waitingTime = 3;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            Instantiate(ball, FirePos.transform.position, FirePos.transform.rotation);

            Destroy(ball, 2.0f);
            timer = 0;
        }
    }
}
