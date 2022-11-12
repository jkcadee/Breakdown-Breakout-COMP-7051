using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextVisibilityIncrease : MonoBehaviour
{
    CanvasGroup cv;

    void Start()
    {
        cv = GetComponent<CanvasGroup>();
        cv.alpha = 0;
    }

    void FixedUpdate()
    {
        if(cv.alpha < 1)
            cv.alpha += 0.04f;
    }
}
