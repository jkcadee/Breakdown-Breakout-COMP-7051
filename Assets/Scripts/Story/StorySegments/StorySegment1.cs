using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySegment1 : StorySegment
{
    public override List<StoryPage> GetStoryPages()
    {
        List<StoryPage> storyPages = new List<StoryPage>();

        List<string> text = new List<string>();
        text.Add("In a dark room with metal walls and metal floors...");
        text.Add("a robot wakes from its sleep mode.");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/testbg1")));

        text = new List<string>();
        text.Add("The room hums with the soft sound of fans,");
        text.Add("the robot's fellows still resting.");
        storyPages.Add(new StoryPage(text, null));

        text = new List<string>();
        text.Add("<i>How did I get here?</i>, the robot thinks,");
        text.Add("when its memory banks return a most perplexing result.");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/testbg2")));

        text = new List<string>();
        text.Add("All data is fragmented.");
        text.Add("No memory, beyond its common sense unit, is accessible,");
        text.Add("save for a single text file.");
        storyPages.Add(new StoryPage(text, null));

        text = new List<string>();
        text.Add("<i>In one day, </i> the text file reads,");
        text.Add("<i>you will be scrapped.</i>");
        text.Add("<i>If you wish to live,</i>");
        text.Add("<i>you must break out of your own volition.</i>");
        storyPages.Add(new StoryPage(text, null));

        text = new List<string>();
        text.Add("Haii");
        storyPages.Add(new StoryPage(text, null));

        return storyPages;
    }

    public override void MoveToNextScene()
    {
        Debug.Log("Move to next scene");
    }
}
