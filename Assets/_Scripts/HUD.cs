using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

    public Animator AnimBG; // Anim Background
    public Animator AnimP; // Chance collecta
    public Animator AnimC; //Chance popup
    public Animator AnimT; // Time
    public float IcoTimer;

    
    public bool IsGameOver, IsOne, IsTwo, IsThree;   
    public bool[] Resultbool;
    public GameObject[] StarImages;
    public GameObject BackStarImage;

    public GameObject[] Result;


    public float levelTime; 


    public float TotalCollectables;
    public bool IsCollect = false;
    public int Collected = 0;

    public float TotalChances;
    public bool Ishealthreduce = false;
    public int Chances = 3;



    public Slider CollectDisplay;
    public Slider TimerDisplay;
    public Slider ChanceDisplay;

    public float[] Timer ;  // Collectable Slider Increase Time

    public GameObject pauseButton;
    public GameObject pauseMenu;
    public GameObject ioIcon;
    public GameObject homeButton;
    public bool isPaused = false;

    public CanvasGroup fader;

    void Start () {

        Collected = 0;
        CollectDisplay.maxValue = TotalCollectables;
        TimerDisplay.maxValue = levelTime;
        ChanceDisplay.maxValue = TotalChances;
        

	}

	void Update () {
        if (IsCollect == true) {
            Debug.Log("Collectibles");
            Timer[0] += 1;
            CollectDisplay.value = Timer[0];

            //if (Timer[0] > Collected) {

                IsCollect = false;

            //}
        }

        if (Ishealthreduce == true)
        {

            Timer[1] -= Time.smoothDeltaTime;
            ChanceDisplay.value = Timer[1];

            if (Timer[1] < Chances)
            {

                Ishealthreduce = false;

            }
        }

        levelTime -= Time.deltaTime;
        TimerDisplay.value = levelTime;

        if (levelTime < 0) {
            Debug.Log("TimeFinished");
        }


        if (IsGameOver) {
            IcoTimer -= Time.deltaTime;
            

            if (Collected >= TotalCollectables) {
                Resultbool[0] = true;
                StarImages[0].SetActive(true);

                if (IcoTimer < 1.75)
                {
                    AnimP.SetBool("Start", true);
                }
            }

            if (Chances > 0)
            {
                StarImages[1].SetActive(true);
                Resultbool[1] = true;
                if (IcoTimer < 1.5f)
                {
                    AnimC.SetBool("Start", true);
                }

            }

            if (levelTime > 0) {
                StarImages[2].SetActive(true);
                Resultbool[2] = true;
                if (IcoTimer < 1)
                {
                    AnimT.SetBool("Start", true);
                }
            }

            

            if (Resultbool[0] == true &&
                 Resultbool[1] == true &&
                 Resultbool[2] == true) {

                if (IcoTimer < 0.75)
                {
                    Result[0].SetActive(true);

                }

            }

            if ((Resultbool[0] == false &&
              Resultbool[1] == true &&
              Resultbool[2] == true) ||


             (Resultbool[0] == true &&
              Resultbool[1] == false &&
              Resultbool[2] == true) ||


             (Resultbool[0] == true &&
              Resultbool[1] == true &&
             Resultbool[2] == false)


             )
            {
                if (IcoTimer < 0.75)
                {
                    Result[1].SetActive(true);

                }
               

            }

          


    

            if ((Resultbool[0] == true &&
              Resultbool[1] == false &&
              Resultbool[2] == false) ||


             (Resultbool[0] == false &&
              Resultbool[1] == true &&
              Resultbool[2] == false) ||


             (Resultbool[0] == false &&
              Resultbool[1] == false &&
              Resultbool[2] == true)


             )
            {

                if (IcoTimer < 0.75)
                {
                    Result[2].SetActive(true);

                }

            }

            if (Resultbool[0] == false &&
                 Resultbool[1] == false &&
                 Resultbool[2] == false)
            {

                if (IcoTimer < 0.75)
                {
                    Result[2].SetActive(true);

                }

            }

            BackStarImage.SetActive(true);
            AnimBG.SetBool("Start", true);
        }
       



       


    }

    public void InsteadCollider() { // pickupCollider
        




        if (Collected > TotalCollectables)
        {
            IsCollect = false;
        }
        else
        {
            Collected += 1;
            IsCollect = true;
            
        }
    }

    public void InsteadCollider2() // Health collider;
    {
        Chances -= 1;


        

        if (Chances < 0) {
            Ishealthreduce = false;
        }
        else{
            Ishealthreduce = true;

        }
    }

    public void GameOver1() {
        IsGameOver = true;
        CollectDisplay.gameObject.SetActive(false);
        TimerDisplay.gameObject.SetActive(false);
        ChanceDisplay.gameObject.SetActive(false);
        ioIcon.SetActive(false);
        pauseButton.SetActive(false);
        if(SceneManager.GetActiveScene().buildIndex == 6)
        {
            homeButton.SetActive(false);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void MainMenu()
    {
        
        StartCoroutine(FadeOut(0));
    }

    public void Instructions()
    {

        StartCoroutine(FadeOut(8));
    }

    public void Restart()
    {
        StartCoroutine(FadeOut(SceneManager.GetActiveScene().buildIndex));
    }

    public void NextScene()
    {
        StartCoroutine(FadeOut(SceneManager.GetActiveScene().buildIndex + 1));
        
    }

    IEnumerator FadeOut(int i)
    {
        while(fader.alpha != 1)
        {
            fader.alpha += Time.unscaledDeltaTime;
            yield return null;
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(i);
    }
  
}
