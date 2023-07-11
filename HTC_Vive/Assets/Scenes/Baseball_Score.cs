using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Baseball_Score : MonoBehaviour {
    //Baseball 씬의 Controller(right)에 속한 PC_Baseball_Bast_LOD_0오브젝트에 삽입된 스크립트이다.

    public static int count = 0;
    public Text counttext;


    void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.tag == "BASEBALL")
        {   //만약 충돌한 오브젝트가 BASEBALL 태그를 가지고 있을 경우

            collision.gameObject.tag = "COLLISION";  //해당 오브젝트의 태그를 COLLISION으로 변경한 후
            count++;  //count를 1 더한 뒤
            counttext.text = "SCORE: " + count.ToString() + "/20";  //count를 스코어보드에 표시한다.
        }
    }
}
