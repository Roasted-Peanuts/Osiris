using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class CreditsUI : MonoBehaviour
{
    public CanvasGroup fadeGroup;

    public void MainMenu()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while(fadeGroup.alpha != 1)
        {
            fadeGroup.alpha += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(0);
    }
}