using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour {
    //Baseball_Chart, Baseball_Graph, BaseballOver, Soccer_Chart, Soccer_Graph, SoccerOver 씬의 
    //Controller (right)에 삽입된 스크립트이다.
    public bool isTrigger; //트리거 입력 상태를 확인하는 변수
    private SteamVR_TrackedObject controller; //바이브 컨트롤러 정보를 가진 스크립트 변수
    private SteamVR_Controller.Device device; //바이브 컨트롤러 정보를 가지고 조작을 담당하는 스크립트 변수
    
    void Start () {
        controller = GetComponent<SteamVR_TrackedObject>();
        //바이브 컨트롤러 정보를 가진 스크립트를 controller에 저장
        isTrigger = false;
        //트리거는 처음에 입력되어 있지 않으므로 false
	}
	
	void Update () {
        device = SteamVR_Controller.Input((int)controller.index);
        //바이브 컨트롤러의 디바이스 입력 정보를 실시간으로 device에 저장

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {//바이브 컨트롤러의 trigger 버튼이 클릭됐을 때 Main 씬으로 이동한다.
            isTrigger = true;

            SceneManager.LoadScene("Main");

            Debug.Log("true");
        }
        else
        {
            isTrigger = false;
        }
    }
}
