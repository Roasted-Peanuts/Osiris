using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour {
    public Fader FD;

    public bool IsPlay = false;
    public bool IsOption = false;
    public bool IsQuite = false;

    public bool[] Level;

    Fading fadingScript;
    UIWorks uiWorks;

    // Use this for initialization
    void Awake () {
        fadingScript = FindObjectOfType<Fading>();
        uiWorks = FindObjectOfType<UIWorks>();
	}
	

    public void Play() {
        IsPlay = true;
        Debug.Log(IsPlay);
    }
    public void Options() {
        IsOption = true;
    }



    public void Level1() {

        Level[0] = true;
    }

    public void Level2() {

        Level[1] = true;
    }

    public void Level3() {

        Level[2] = true;
    }

    public void Level4()
    {

        Level[3] = true;
    }

    public void Level5()
    {
        Level[4] = true;

    }

    public void Level6()
    {
        Level[5] = true;
    }

    public void Credits()
    {
        StartCoroutine( uiWorks.MoveCamera());
        Level[6] = true;
    }

    public void Instructions()
    {
        StartCoroutine(uiWorks.MoveCamera());
        Level[7] = true;
    }

    public void Exit()
    {
        Application.Quit();
    }

}
