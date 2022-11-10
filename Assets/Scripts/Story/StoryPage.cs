using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPage
{
    public List<string> storyText;
    public Sprite background;

    public StoryPage(List<string> st, Sprite bg) 
    {
        storyText = st;
        background = bg;
    }
}
