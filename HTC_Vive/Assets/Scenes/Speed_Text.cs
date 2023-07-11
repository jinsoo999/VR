using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed_Text : MonoBehaviour {
    //Soccer 씬의 Controller (left)와 Controller (right)의 default에 삽입된 스크립트이다.
    public Text speedtext;
    float soccerball_speed;
    public static float soccer_total = 0.0f;
    public static float soccer_max = 0.0f;
    public static float soccer_min = 100.0f;
  

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "SOCCERBALL") ;
        {   //충돌한 오브젝트의 태그가 SOCCERBALL일 경우
            col.gameObject.tag = "COLLISION";  //해당 오브젝트의 태그를 COLLISION으로 변경한 후
            float soccerball_speedX = col.gameObject.GetComponent<Soccer_Ball>().speedX;
            float soccerball_speedY = col.gameObject.GetComponent<Soccer_Ball>().speedY;
            float soccerball_speedZ = col.gameObject.GetComponent<Soccer_Ball>().speedZ;
            //해당 오브젝트의 X,Y,Z벡터의 속도를 구한 후 
            soccerball_speed = Mathf.Round(((soccerball_speedX + Mathf.Abs(soccerball_speedY) + Mathf.Abs(soccerball_speedZ)) / 3) * 100) / 100;
            //절댓값을 전부 합산한 뒤
            soccer_total = soccer_total + soccerball_speed;  //전체 속도에 추가한다.
            speedtext.text = "SPEED: " + soccerball_speed.ToString();  //스코어보드에 표시하는 것은 절댓값의 합산이다.

            if (soccerball_speed > soccer_max)  //속도의 최댓값을 구한다.
                soccer_max = soccerball_speed;
            else if (soccerball_speed < soccer_min)  //속도의 최소값을 구한다.
                soccer_min = soccerball_speed;
        }
    }
}
