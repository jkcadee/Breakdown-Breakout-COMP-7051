using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    /** Changes the scene. 
     @param sceneName
    */
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        if (sceneName == "Title_Screen")
        {
            Level_Timer.PauseTime();
            Level_Timer.ResetTime();
        }
        else {
            Level_Timer.StartTime();
        }
    }
}
