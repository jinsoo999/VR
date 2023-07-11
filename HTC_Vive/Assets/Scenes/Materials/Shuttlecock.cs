using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuttlecock : MonoBehaviour {

    public Vector3 direction;
    public float speed;
    public int count = 0;


    [SerializeField] bool bKeepMoving = false;

    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(10.0f, 10.0f, 0.0f);
    }

    void Update()
    {
        if (bKeepMoving && rigidBody.velocity.magnitude < 0.1f)
        {
            // rigidBody.velocity = new Vector3(Random.Range(0.0f, 50.0f), 0.0f, Random.Range(0.0f, 50.0f));
        }
    }
}
