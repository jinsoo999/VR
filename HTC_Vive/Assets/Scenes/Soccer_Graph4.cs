using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Net;

public class Soccer_Graph4 : MonoBehaviour {
    //Soccer_Graph 씬의 Graph (3)오브젝트에 삽입된 스크립트이다.

    public Transform pointPrefab;
    private int resolution = 0;
    Transform[] points;

    void Start()
    {   //시작 시 getscore함수를 호출한다.
        getscore();
    }

    public void getscore()
    {   //DB로부터 데이터를 받아온다.
        WebRequest totalscore = WebRequest.Create("http://220.69.209.170/jjs/select2.php");
        WebResponse response = totalscore.GetResponse();
        StreamReader stream = new StreamReader(response.GetResponseStream());
        int j = 0;
        string firstStr = stream.ReadToEnd();
        Debug.Log(firstStr);
        string[] split = firstStr.Split(new char[] { '/' });

        resolution = ((split.GetLength(0) - 1) / 7);  //해당 컨텐츠를 실행한 횟수를 resolution에 저장한다. 
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        position.y = position.z = 0f;
        points = new Transform[resolution];
        for (int i = 0; i < resolution; i++)
        {   //받아온 데이터 중 사용자가 여태껏 받아친 공의 최대 속도를 막대그래프 형식으로 표시한다.
            Transform point = Instantiate(pointPrefab);
            point.localScale = scale;

            point.localScale += new Vector3(0, float.Parse(split[j + 4]) / 50, 0);
            point.localScale -= new Vector3(0.015f, 0, 0);
            position.x = (i + 0.5f) * step - 1f;

            position.y = float.Parse(split[j + 4]) / 100;


            point.localPosition = position;
            point.SetParent(transform, false);
            points[i] = point;
            j += 7;
        }
    }
}
