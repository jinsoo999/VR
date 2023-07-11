using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LaserPointer : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    public GameObject baseball;
    public GameObject soccer;
    public GameObject data;

    public bool isTrigger; //트리거 입력 상태를 확인하는 변수

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    public GameObject laserPrefab;

    private GameObject laser;

    private Transform laserTransform;

    private Vector3 hitPoint;

    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);

        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);

        laserTransform.LookAt(hitPoint);

        laserTransform.localScale = new Vector3(laserTransform.localScale.x, 
            laserTransform.localScale.y, hit.distance);
    }

	void Start () {
        laser = Instantiate(laserPrefab);

        laserTransform=laser.transform;

        isTrigger = false;
        //트리거는 처음에 입력되어 있지 않으므로 false
    }
    
    void Update () {
        //if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        //{
        RaycastHit hit;
        if (Physics.Raycast(trackedObj.transform.position, laserTransform.forward, out hit, 100))
        {
            hitPoint = hit.point;
                ShowLaser(hit);
            if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                if (trackedObj == baseball)
                {

                }
                else if (trackedObj == soccer)
                {

                }
                else if (trackedObj == data)
                {

                }
                Debug.Log("true");
            }
            else
            {
                isTrigger = false;
            }

        }
        //}
        //else
        //{
          //  laser.SetActive(false);
        //}
	}
}
