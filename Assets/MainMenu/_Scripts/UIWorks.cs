using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWorks : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject Levels;


    public Fader Fd;
    public Animator anim;
    public Animator animPlay;
    public UI_Manager UI_M;
    public GameObject CameraObj;
    public GameObject CameraTarget;
    public float CameraTransformspeed;
    public Camera Cam;



    
	
	void Start () {
        Cam = CameraObj.GetComponent<Camera>();
	}
	
	
	void Update () {

       


        if (UI_M.IsPlay == true) {

           

            
            Levels.SetActive(true);

            anim.SetBool("Start", true);
            animPlay.SetBool("Start", true);



        }
        if (UI_M.Level[0] == true || UI_M.Level[1] == true || UI_M.Level[2] == true ||

            UI_M.Level[3] == true || UI_M.Level[4] == true || UI_M.Level[5] == true)
        {
           
            CameraObj.transform.position = Vector3.MoveTowards(CameraObj.transform.position, CameraTarget.transform.position, CameraTransformspeed*Time.smoothDeltaTime);
            anim.SetBool("Start", false);
        }

        if (Vector3.Distance(CameraObj.transform.position, CameraTarget.transform.position) < 2.5f) {
            Fd.isClickToNext = true;
        }
	}

    public IEnumerator MoveCamera()
    {
        while (true)
        {
            CameraObj.transform.position = Vector3.MoveTowards(CameraObj.transform.position, CameraTarget.transform.position, CameraTransformspeed * Time.smoothDeltaTime);
            animPlay.SetBool("Start", true);
            yield return null;
        }
    }
}
