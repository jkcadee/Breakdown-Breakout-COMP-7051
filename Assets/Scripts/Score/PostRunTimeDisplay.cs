using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PostRunTimeDisplay : MonoBehaviour
{
    void Start()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        text.text = Level_Timer.GetTime() + " seconds";
    }
}
