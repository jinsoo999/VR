using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Baseball_Speed : MonoBehaviour {
    //Baseball 씬의 Controller(right)에 속한 PC_Baseball_Bast_LOD_0오브젝트에 삽입된 스크립트이다.

    public Text speedtext;
    float baseball_speed;
    public static float baseball_total = 0.0f;
    public static float baseball_max = 0.0f;
    public static float baseball_min = 1000.0f;


    void OnCollisionEnter(Collision col)
    {   
        if (col.gameObject.tag == "BASEBALL") ;
        {   //충돌한 오브젝트의 태그가 BASEBALL일 경우

            col.gameObject.tag = "COLLISION";  //해당 오브젝트의 태그를 COLLISION으로 변경한 후

            float baseball_speedX = col.gameObject.GetComponent<BaseBall>().speedX;
            float baseball_speedY = col.gameObject.GetComponent<BaseBall>().speedY;
            float baseball_speedZ = col.gameObject.GetComponent<BaseBall>().speedZ;
            //해당 오브젝트의 X,Y,Z벡터의 속도를 구한 후 

            baseball_speed = Mathf.Round(((baseball_speedX + Mathf.Abs(baseball_speedY) + Mathf.Abs(baseball_speedZ)) / 3) * 100) / 100;
            //절댓값을 전부 합산한 뒤

            baseball_total = baseball_total + baseball_speed; //전체 속도에 추가한다.
            speedtext.text = "SPEED: " + baseball_speed.ToString();  //스코어보드에 표시하는 것은 절댓값의 합산이다.

            if (baseball_speed > baseball_max)  //속도의 최댓값을 구한다.
                baseball_max = baseball_speed;
            else if (baseball_speed < baseball_min)  //속도의 최소값을 구한다.
                baseball_min = baseball_speed;
        }
    }
}
