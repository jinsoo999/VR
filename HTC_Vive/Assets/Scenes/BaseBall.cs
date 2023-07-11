using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseBall : MonoBehaviour {
    //Ball프리팹에 삽입되는 스크립트이다. 

    [SerializeField] bool bKeepMoving = false;
    
    public float speedX;
    public float speedY;
    public float speedZ;

    Rigidbody rigidBody;
        
    void Start()
    {   //발사되는 공의 X,Y,Z의 속도를 설정해준다.
        speedX = Random.Range((float)(Fire.firestage * 12), (float)(Fire.firestage * 20));
        speedY = Random.Range(0.0f, 1.0f);
        speedZ = Random.Range(-1.0f, 1.0f);

        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(speedX, speedY, speedZ);

        Destroy(gameObject, 3.0f);
    }
}
