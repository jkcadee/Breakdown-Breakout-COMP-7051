using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// one page of a story
public class StoryPage
{
    public List<string> storyText; // the individual lines of text for this page
    public Sprite background; // the background to be shown for this page

    public StoryPage(List<string> st, Sprite bg) 
    {
        storyText = st;
        background = bg;
    }
}
