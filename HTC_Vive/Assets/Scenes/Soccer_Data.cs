using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Net;

public class Soccer_Data : MonoBehaviour {
    //SoccerOver 씬의 Camerarig오브젝트에 삽입된 스크립트이다.

    public Text stagetext;
    public Text balltext;
    public Text pertext;
    public Text avrtext;
    public Text maxtext;
    public Text mintext;
    
    void Start()
    {   //Camerarig에 삽입된 Canvas에 진행한 게임의 결과를 표시한다.

        stagetext.text = "STAGE RECORD:" + Soccer_Fire.firestage.ToString();  //진행한 스테이지 기록
        balltext.text = "BALL RECORD:" + Soccer_Fire.total_soccercount.ToString();  //받아친 공의 총합
        pertext.text = "SUCCESS PERCENTAGE:" + string.Format("{0:0.##}", ((float)(Soccer_Fire.total_soccercount * 100) / (float)(20 * Soccer_Fire.firestage))) + "%";
        //자신이 공을 받아치는데 성공한 확률
        avrtext.text = "SPEED AVERAGE:" + string.Format("{0:0.##}", Speed_Text.soccer_total / Soccer_Fire.total_soccercount);  //받아친 공의 평균 속도
        maxtext.text = "MAX SPEED:" + string.Format("{0:0.##}", Speed_Text.soccer_max);  //받아친 공의 최고 속도
        mintext.text = "MIN SPEED:" + string.Format("{0:0.##}", Speed_Text.soccer_min);  //받아친 공의 최저 속도

        insert();
    }
    

    public void insert()
    {   //진행한 게임의 결과를 DB에 전송한다.

        string address = "http://220.69.209.170/jjs/insert2.php";
        WWWForm Form = new WWWForm();

        Form.AddField("stage", Soccer_Fire.firestage);  //진행한 스테이지 기록
        Form.AddField("ball", Soccer_Fire.total_soccercount);  //받아친 공의 총합
        Form.AddField("percent", string.Format("{0:0.##}", ((float)(Soccer_Fire.total_soccercount * 100) / (float)(20 * Soccer_Fire.firestage))));
        //자신이 공을 받아치는데 성공한 확률
        Form.AddField("average", string.Format("{0:0.##}", Speed_Text.soccer_total / Soccer_Fire.total_soccercount));  //받아친 공의 평균 속도
        Form.AddField("max", string.Format("{0:0.##}", Speed_Text.soccer_max));  //받아친 공의 최고 속도
        Form.AddField("min", string.Format("{0:0.##}", Speed_Text.soccer_min));  //받아친 공의 최저 속도

        WWW wwwURL = new WWW(address, Form);
    }
}
