using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {


    public Texture2D FadeOutTexture;         // Texture that overlay on the top of the screen.

    public float FadeSpeed;                  // Fading Speed;

    private int DrawDepth = -1000;           // Texture's order in draw hierarchy : a low value makes the texture on top.

    private float AlphaValue = 1.0f;         // Texture's alpha value between 0 and 1.

    private float FadeDir = -1;              // Fading Direction.


    private void OnGUI()
    {
        AlphaValue += FadeDir * FadeSpeed * Time.deltaTime;  // Converting to time based operation.

        AlphaValue = Mathf.Clamp01(AlphaValue);              // Clamping the value between 0 and 1.

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, AlphaValue);   //setting the Alpha value;

        GUI.depth = DrawDepth;                              // Making the texture render on the Top of the scene;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), FadeOutTexture);
    }

    public float BeginFade(int Direction)
    {
        FadeDir = Direction;
        return FadeSpeed;
    }
    private void OnLevelWasLoaded(int level)
    {

        BeginFade(-1);
    }
}
