using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level_Timer : MonoBehaviour
{

    public static Level_Timer Instance;

    //Represents how much time has passed
    public static float time;

    //Represents whether or not the timer is on
    public static bool timer_on;

    // Start is called before the first frame update
    private void Awake()
    {

        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        if (Level_Timer.Instance != null)
        {
            ResetTime();
            PauseTime();
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (timer_on == true)
        {
            time += Time.deltaTime;
        }
        Debug.Log(time);
    }

    public static float GetTime() {
        return time;
    }

    public static void ResetTime() {
        time = 0.0f;
    }

    public static void PauseTime()
    {
        timer_on = false;
    }

    public static void StartTime()
    {
        timer_on = true;
    }
}
