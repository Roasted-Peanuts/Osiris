using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public int collectibleScore;
    public int collectibleCount;
    public int deathCount;
    public int key;
    public float timer;
    public int star;

    public bool collectibleStar = false;
    public bool healthStar = true;
    public bool timerStar = true;
    
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
