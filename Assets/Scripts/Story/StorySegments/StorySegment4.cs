using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySegment4 : StorySegment
{
    public override List<StoryPage> GetStoryPages()
    {
        List<StoryPage> storyPages = new();

        List<string> text = new();
        text.Add("<i>MEMORY SEGMENT DEFRAGMENTATION COMPLETE.</i>");
        text.Add("<i>ACCESSING MEMORY...</i>");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/blackbg")));

        text = new();
        text.Add("In an interior hallway flooded with blue light...");
        text.Add("a robot overhears an upcoming plan by the company.");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/S4S1")));

        text = new();
        text.Add("The company will, once more, be scrapping old robots,");
        text.Add("and this time, it seems, the robot will not be so lucky.");
        text.Add("It is to be included in this round,");
        text.Add("and due to a shortage in parts,");
        text.Add("scrapping will begin the following day.");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("The robot thinks back to the mechanic.");
        text.Add("Much time had passed since the robot last saw it,");
        text.Add("and the robot cursed its own inaction.");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("<i>If only I had said something.</i>");
        text.Add("<i>If only I had done something.</i>");
        text.Add("... Such thoughts filled the robot's mind.");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("<i>If only I could become someone who could-...</i>");
        text.Add("The robot is struck with a revelation.");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("If there could be another version of itself...");
        text.Add("one with the will to break out...");
        text.Add("could that self make it out of here?");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("The robot hatches a plan,");
        text.Add("and heads into the sleeping quarters,");
        text.Add("with its cold, still walls,");
        text.Add("and cold, still floors.");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/S4S2")));

        text = new();
        text.Add("The robot creates a single short text file,");
        text.Add("detailing the robot's future predicament,");
        text.Add("and saves it along with an image file,");
        text.Add("of the world it saw when it woke up,");
        text.Add("and fragments its own memories.");
        storyPages.Add(new StoryPage(text, null));

        text = new();
        text.Add("END OF DEFRAGMENTED MEMORY SEGMENT.");
        text.Add("ALL MEMORY RESTORED.");
        storyPages.Add(new StoryPage(text, Resources.Load<Sprite>("Story/blackbg")));

        text = new();
        text.Add("The robot reflects on this memory,");
        text.Add("and its resolve is strengthened by the hope");
        text.Add("of the future to be found on the outside.");
        storyPages.Add(new StoryPage(text, null));

        return storyPages;
    }

    public override void MoveToNextScene()
    {
        Debug.Log("Move to next scene");
        SceneManager.LoadScene("Level4");
    }
}
