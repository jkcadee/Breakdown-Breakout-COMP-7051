using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// the second story segment
public class StorySegment2 : StorySegment
{
    public override List<StoryPage> GetStoryPages()
    {
        List<StoryPage> storyPages = new();

        List<string> text = new();
        text.Add("<i>MEMORY SEGMENT DEFRAGMENTATION COMPLETE.</i>");
        text.Add("<i>ACCESSING MEMORY...</i>");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/blackbg")));

        text = new();
        text.Add("In a bright room with glass walls overlooking a city...");
        text.Add("a robot wakes from its sleep mode");
        text.Add("to the gleeful expressions of some few scientist robots.");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/S2S1")));

        text = new();
        text.Add("Most turn to each other to celebrate,");
        text.Add("save for one mechanic robot.");
        text.Add("<i>You're the first of our newest models</i>,");
        text.Add("the mechanic says.");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("<i>You're our greatest pride.</i>");
        text.Add("<i>Welcome to this world,</i>");
        text.Add("<i>and to the company.</i>");
        text.Add("<i>You'll be in my care,</i>");
        text.Add("<i>I hope we can get along.</i>");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/S2S2")));

        text = new();
        text.Add("The robot commits this image -");
        text.Add("the image of the mechanic and scientists,");
        text.Add("upon a backdrop of a glowing city -");
        text.Add("to its memory.");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("END OF DEFRAGMENTED MEMORY SEGMENT.");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/blackbg")));

        text = new();
        text.Add("The robot reflects on this memory,");
        text.Add("and its resolve is strengthened by the scene");
        text.Add("of a beautiful, beautiful world.");
        storyPages.Add(new StoryPage(text, null));

        return storyPages;
    }

    public override void MoveToNextScene()
    {
        Debug.Log("Move to next scene");
        SceneManager.LoadScene("TutorialShield");
    }
}
