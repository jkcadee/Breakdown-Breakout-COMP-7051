using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPage
{
    public List<string> storyText;
    public Texture2D background;

    public StoryPage(List<string> st, Texture2D bg) 
    {
        storyText = st;
        background = bg;
    }
}
