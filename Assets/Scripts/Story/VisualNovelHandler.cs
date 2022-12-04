using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System;

public class VisualNovelHandler : MonoBehaviour
{
    public GameObject textLine;
    public GameObject content;
    public GameObject background;
    CanvasGroup contentCv;
    List<StoryPage> storyPages;
    VNActions vnActions;
    int currentTextIndex, pageIndex = 0;
    LevelManager lm;

    public float opacityChangeRate = 0.04f;
    Action zeroVisCallback;
    Action updateCallback;

    // creates text based on the current page's text index
    private void InstantiateText()
    {
        GameObject textObj = Instantiate(textLine, content.transform);
        TMP_Text text = textObj.GetComponent<TMP_Text>();
        text.text = storyPages[pageIndex].storyText[currentTextIndex];
        currentTextIndex++;
        updateCallback = IncreaseVisibility;
    }

    // continues the text or gets ready to move to the next scene
    private void ProgressText()
    {
        if(pageIndex != storyPages.Count && currentTextIndex < storyPages[pageIndex].storyText.Count)
        {
            InstantiateText();
        } 
        else
        {
            pageIndex++;
            SetBackground();
            currentTextIndex = 0;
            updateCallback = DecreaseVisibility;

            if(pageIndex == storyPages.Count)
                zeroVisCallback = GetComponent<StorySegment>().MoveToNextScene;
        }
    }

    private void SkipScene(InputAction.CallbackContext _)
    {
        GetComponent<StorySegment>().MoveToNextScene();
    }

    private void NextTextInput(InputAction.CallbackContext _)
    {
        // cannot click while the content isn't fully opaque
        if (contentCv.alpha == 1)
            ProgressText();
    }

    // sets bg based on what the current page has
    private void SetBackground()
    {
        Image image = background.GetComponent<Image>();
        if(pageIndex < storyPages.Count && storyPages[pageIndex].background)
        {
            image.sprite = storyPages[pageIndex].background;
        }
    }

    // gets rid of the current text and instantiates the next page's text
    private void WipeText()
    {
        if (pageIndex == storyPages.Count)
        {
            return;
        }

        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
        
        InstantiateText();
    }

    // increases content vis, and removes the update callback
    private void IncreaseVisibility()
    {
        if(contentCv.alpha >= 1)
        {
            updateCallback = null;
            return;
        }

        contentCv.alpha += opacityChangeRate;
    }

    // decreases content vis, and calls zeroVisCallback (if any) when invisible
    private void DecreaseVisibility()
    {
        if (contentCv.alpha <= 0)
        {
            WipeText();

            if(zeroVisCallback != null)
                zeroVisCallback();

            zeroVisCallback = null;
            return;
        }

        contentCv.alpha -= opacityChangeRate;
    }

    private void Awake()
    {
        vnActions = new VNActions();
    }

    private void OnEnable()
    {
        vnActions.Player.Continue.Enable();
        vnActions.Player.Continue.performed += NextTextInput;
        vnActions.Player.Skip.Enable();
        vnActions.Player.Skip.performed += SkipScene;
    }

    private void OnDisable()
    {
        vnActions.Player.Continue.Disable();
        vnActions.Player.Continue.performed -= NextTextInput;
        vnActions.Player.Skip.Disable();
        vnActions.Player.Skip.performed -= SkipScene;
    }

    // sets the scene
    private void Start()
    {
        contentCv = content.GetComponent<CanvasGroup>();
        storyPages = GetComponent<StorySegment>().GetStoryPages();
        contentCv.alpha = 0;
        updateCallback = IncreaseVisibility;
        InstantiateText();
        SetBackground();
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        Level_Timer.PauseTime();
        lm.DeactivatePlayer();
    }

    private void OnDestroy()
    {
        lm.ActivatePlayer();
        Level_Timer.StartTime();
    }

    private void FixedUpdate()
    {
        if (updateCallback != null)
            updateCallback();
    }
}
