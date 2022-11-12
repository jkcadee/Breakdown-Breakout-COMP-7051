using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StorySegment : MonoBehaviour
{
    public abstract List<StoryPage> GetStoryPages();
    public abstract void MoveToNextScene();
}
