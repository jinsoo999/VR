using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Text : MonoBehaviour {
    //Soccer 씬의 Controller (left)와 Controller (right)의 default에 삽입된 스크립트이다.
    public static int count = 0;
    public Text counttext;

    void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.tag == "SOCCERBALL")
        {   //만약 충돌한 오브젝트가 SOCCERBALL 태그를 가지고 있을 경우
            collision.gameObject.tag = "COLLISION";  //해당 오브젝트의 태그를 COLLISION으로 변경한 후
            count++;  //count를 1 더한 뒤
            counttext.text = "SCORE: " + count.ToString() + "/20";  //count를 스코어보드에 표시한다.
        }
        
    }
}
