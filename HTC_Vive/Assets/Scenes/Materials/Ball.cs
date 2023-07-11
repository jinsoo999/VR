using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public Vector3 direction;
    public float speed;
    public int count = 0;


    [SerializeField] bool bKeepMoving = false;

    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(5.0f, 0.0f, 0.0f);
    }

    void Update()
    {
        if (bKeepMoving && rigidBody.velocity.magnitude < 0.1f)
        {
            // rigidBody.velocity = new Vector3(Random.Range(0.0f, 50.0f), 0.0f, Random.Range(0.0f, 50.0f));
        }
    }

    /*
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        //Destroy(gameObject, 5.0f);
    }
    
    void Update () {
        //speed = 0.1f;

        // transform.Translate(Vector3.forward * speed * Time.deltaTime); 안 튕김

        //GetComponent<Rigidbody>().AddForce(transform.forward * speed); 움직임 이상
    }
    
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        ExcecuteReBounding(collision);
    }
    void ExcecuteReBounding(Collision collision)
    {
        ContactPoint cp = collision.contacts[0];
        Vector3 dir = transform.position - cp.point; // 접촉지점에서부터 탄위치 의 방향
        GetComponent<Rigidbody>().AddForce((dir).normalized * 100f);
    }*/
}
