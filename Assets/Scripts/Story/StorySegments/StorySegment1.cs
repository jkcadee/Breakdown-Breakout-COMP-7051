using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySegment1 : StorySegment
{
    public override List<StoryPage> GetStoryPages()
    {
        List<StoryPage> storyPages = new();

        List<string> text = new();
        text.Add("In a dark room with metal walls and metal floors...");
        text.Add("a robot wakes from its sleep mode.");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/S1S1")));

        text = new();
        text.Add("The room hums with the soft sound of fans,");
        text.Add("the robot's fellows still resting.");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("<i>How did I get here?</i>, the robot wonders,");
        text.Add("when its memory banks return a most perplexing result.");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("All data is fragmented.");
        text.Add("No memory, beyond its common sense unit, is accessible,");
        text.Add("save for a single text file, and a single image.");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/S1S2")));

        text = new();
        text.Add("<i>In one day, </i> the text file reads,");
        text.Add("<i>you will be scrapped.</i>");
        text.Add("<i>If you wish to live,</i>");
        text.Add("<i>you must break out of your own volition.</i>");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("The image file contains a snapshot of unfamiliar robots,");
        text.Add("celebrating and cheering,");
        text.Add("and a radiant cityscape beyond a window.");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("The robot looks around the room,");
        text.Add("at the cold, still walls,");
        text.Add("at the cold, still floors,");
        text.Add("at the cold, still robots,");
        text.Add("and softly hovers to the exit.");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/S1S3")));

        return storyPages;
    }

    public override void MoveToNextScene()
    {
        Debug.Log("Move to next scene");
        SceneManager.LoadScene("Level1");
    }
}
