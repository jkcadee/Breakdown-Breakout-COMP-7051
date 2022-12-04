using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// abstract story segment
public abstract class StorySegment : MonoBehaviour
{
    public abstract List<StoryPage> GetStoryPages(); // gives a list of story pages
    public abstract void MoveToNextScene(); // moves to some next scene
}
