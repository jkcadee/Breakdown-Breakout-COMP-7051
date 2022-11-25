using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySegment5 : StorySegment
{
    public override List<StoryPage> GetStoryPages()
    {
        List<StoryPage> storyPages = new();

        List<string> text = new();
        text.Add("At last, the robot reaches the top of the building.");
        text.Add("Looking down at the cityscape around and in the distance,");
        text.Add("the robot is awash with emotion.");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/S5S1")));

        text = new();
        text.Add("On the rooftop lies a helicopter, and, with quick thinking,");
        text.Add("the robot removes the tail rotor and attaches it to itself.");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("With a start, the robot leaps from the edge,");
        text.Add("and gently descends into a bright world.");
        storyPages.Add(new StoryPage(text, null));

        return storyPages;
    }

    public override void MoveToNextScene()
    {
        Debug.Log("Move to next scene");
        SceneManager.LoadScene("Title_Screen");
    }
}
