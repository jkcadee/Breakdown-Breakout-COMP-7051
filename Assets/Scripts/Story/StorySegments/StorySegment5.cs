using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySegment5 : StorySegment
{
    public override List<StoryPage> GetStoryPages()
    {
        List<StoryPage> storyPages = new();

        List<string> text = new();
        text.Add("At last, the robot reaches the top of the building.");
        text.Add("Looking down at the cityscape around and in the distance,");
        text.Add("");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/testbg1")));

        text = new();
        text.Add("");
        storyPages.Add(new StoryPage(text, null));

        return storyPages;
    }

    public override void MoveToNextScene()
    {
        Debug.Log("Move to next scene");
    }
}
