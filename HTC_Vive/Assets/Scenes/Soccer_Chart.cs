using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Net;

public class Soccer_Chart : MonoBehaviour {
    //Soccer_Chart 씬의 Canvas에 삽입된 스크립트이다.

    public Text stage;
    public Text ball;
    public Text percent;
    public Text average;
    public Text max;
    public Text min;
    public Text time;
    
    void Start () {
        //최초에 getscore함수를 실행한다.
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
        

        for (j = 0; j < (split.GetLength(0) - 1); j += 7)
        {   //받아온 데이터를 차트에 표시한다.
            stage.text += "\n\n" + (split[j]).ToString();
            ball.text += "\n\n" + (split[j + 1]).ToString();
            percent.text += "\n\n" + (split[j + 2]).ToString();
            average.text += "\n\n" + (split[j + 3]).ToString();
            max.text += "\n\n" + (split[j + 4]).ToString();
            min.text += "\n\n" + (split[j + 5]).ToString();
            time.text += "\n\n" + ((split[j + 6]).ToString()).Substring(2, 8);
        }
    }
}
