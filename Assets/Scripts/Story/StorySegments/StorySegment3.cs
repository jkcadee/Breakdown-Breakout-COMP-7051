using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySegment3 : StorySegment
{
    public override List<StoryPage> GetStoryPages()
    {
        List<StoryPage> storyPages = new();

        List<string> text = new();
        text.Add("<i>MEMORY SEGMENT DEFRAGMENTATION COMPLETE.</i>");
        text.Add("<i>ACCESSING MEMORY...</i>");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/blackbg")));

        text = new();
        text.Add("In a small exam room with a soft, pale light...");
        text.Add("a robot has just finished its checkup.");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/S3S1")));

        text = new();
        text.Add("Long after the robot first awoke,");
        text.Add("the robot continues to receive regular maintenance");
        text.Add("from the mechanic.");
        text.Add("The pair have built a strong rapport,");
        text.Add("with every checkup being filled with chatter.");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("Today, however, the mechanic speaks much less,");
        text.Add("for earlier, the company they work for made an announcement:");
        text.Add("the oldest robots would be scrapped for parts,");
        text.Add("in order to make newer, more efficient workers.");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("The robot is still too new to be scrapped.");
        text.Add("The fate of its friend, however, is more ambiguous.");
        text.Add("But the mechanic's demeanor serves to stir worry.");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("<i>You're good to go</i>, the mechanic says.");
        text.Add("The robot begins to speak, but hesitates.");
        text.Add("<i>See you another time</i>, the robot chokes out.");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/S3S2")));

        text = new();
        text.Add("And without another word exchanged...");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("the robot closes the door.");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("END OF DEFRAGMENTED MEMORY SEGMENT.");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/blackbg")));

        text = new();
        text.Add("The robot reflects on this memory,");
        text.Add("and its resolve is strengthened by the memory");
        text.Add("of the mechanic whom it once knew.");
        storyPages.Add(new StoryPage(text, null));

        return storyPages;
    }

    public override void MoveToNextScene()
    {
        Debug.Log("Move to next scene");
        SceneManager.LoadScene("Level3");
    }
}
