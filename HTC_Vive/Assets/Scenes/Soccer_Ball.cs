using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soccer_Ball : MonoBehaviour {
    //Soccerball 프리팹에 삽입되는 스크립트이다.
    [SerializeField] bool bKeepMoving = false;

    public float speedX, speedY, speedZ;

    Rigidbody rigidBody;

    void Start()
    {   //발사되는 공의 X,Y,Z의 속도를 설정해준다.

        speedX = Random.Range((float)(Soccer_Fire.firestage * 16), (float)(Soccer_Fire.firestage * 24));
        speedY = Random.Range(1.0f, 2.5f);
        speedZ = Random.Range(-2.5f, 2.5f);

        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(speedX, speedY, speedZ);

        Destroy(gameObject, 3.0f);
    }
}
