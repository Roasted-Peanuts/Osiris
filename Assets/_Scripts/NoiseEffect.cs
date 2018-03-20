//Coded by Abishek J Reuben

using System.Collections;
using UnityEngine;

public class NoiseEffect : MonoBehaviour 
{
    #region Variables

    public GameObject[] noiseImages;
    public GameObject[] cctvImages;
    public bool isNoising = false;

    #endregion

    #region UnityFunctions

    private void Start()
    {
        StartCoroutine(Noise());
        StartCoroutine(CCTV());
    }

    #endregion

    #region CustomFunctions

    IEnumerator Noise()
    {
        while (true)
        {
            while (isNoising)
            {
                for (int i = 0; i < noiseImages.Length; i++)
                {
                    if (isNoising)
                    {
                        noiseImages[i].SetActive(true);
                        yield return new WaitForSeconds(0.05f);
                        noiseImages[i].SetActive(false);
                    }
                }
            }
            yield return null;
        }
    }

    IEnumerator CCTV()
    {
        while (true)
        {
            while (isNoising)
            {
                for (int i = 0; i < cctvImages.Length; i++)
                {
                    if (isNoising)
                    {
                        cctvImages[i].SetActive(true);
                        yield return new WaitForSeconds(0.05f);
                        cctvImages[i].SetActive(false);
                    }
                }
            }
            yield return null;
        }
    }

    #endregion
}