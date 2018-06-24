using UnityEngine;
using System.Collections;

public class FPSDisplay : MonoBehaviour
{
    private float deltaTime = 0.0f;
    private float msec = 0;
    private float fps = 0;
    private int count = 0;

    void Update()
    {
        deltaTime += Time.unscaledDeltaTime;
        count++;
        if (count > 5)
        {
            msec = deltaTime / count * 1000.0f ;
            fps = count / deltaTime;
            deltaTime = 0;
            count = 0;
        }
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 50);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 50;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
       
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}