using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour {

    public UI_Manager UI_M;

    public bool isClickToNext = false;
    public bool GotoMain = false;
    public bool isClickToQuit = false;
    public bool isOut = false;
    public GameObject FadeMaker;
    Fading FadeScript;


    public float WaitForFade;
    public float FadingTime;

    void Start()
    {
        FadeScript = FadeMaker.GetComponent<Fading>();
    }
    private void Update()
    {
        if (GotoMain == true)
        {
            WaitForFade -= Time.deltaTime;
            if (WaitForFade < 0)
            {
                //
                FadingTime = FadeScript.BeginFade(1);


            }
            if (WaitForFade < -1)
            {
                SceneManager.LoadScene(0);
                Debug.Log("LOL");
            }
        }
        if (isClickToNext == true)
        {
            WaitForFade -= Time.deltaTime;
            if (WaitForFade < 0)
            {
                //
                FadingTime = FadeScript.BeginFade(1);


            }
            if (WaitForFade < -1)
            {
                if (UI_M.Level[0] == true)
                {
                    SceneManager.LoadScene(1);
                }
                if (UI_M.Level[1] == true)
                {
                    SceneManager.LoadScene(2);
                }
                if (UI_M.Level[2] == true)
                {
                    SceneManager.LoadScene(3);
                }
                if (UI_M.Level[3] == true)
                {
                    SceneManager.LoadScene(4);
                }
                if (UI_M.Level[4] == true)
                {
                    SceneManager.LoadScene(5);
                }
                if (UI_M.Level[5] == true)
                {
                    SceneManager.LoadScene(6);
                }
                if (UI_M.Level[6] == true)
                {
                    SceneManager.LoadScene(7);
                }
                if (UI_M.Level[7] == true)
                {
                    SceneManager.LoadScene(8);
                }

                Debug.Log("LOL");
            }
        }
        if (isOut == true)
        {
            WaitForFade -= Time.deltaTime;
            if (WaitForFade < 0)
            {
                //
                FadingTime = FadeScript.BeginFade(1);


            }
            if (WaitForFade < -1)
            {
                SceneManager.LoadScene(2);
                Debug.Log("LOL");
            }
        }
        if (isClickToQuit == true)
        {
            WaitForFade -= Time.deltaTime;
            if (WaitForFade < 0)
            {
                //
                FadingTime = FadeScript.BeginFade(1);


            }
            if (WaitForFade < -1)
            {
               Application.Quit();
                Debug.Log("LOL");
            }
        }

    }
    
}
