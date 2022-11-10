using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class VisualNovelHandler : MonoBehaviour
{
    public GameObject textLine;
    public GameObject content;
    CanvasGroup contentCv;
    List<StoryPage> storyPages;
    VNActions vnActions;
    int currentTextIndex, pageIndex = 0;

    public float opacityChangeRate = 0.04f;
    Action zeroVisCallback;
    Action updateCallback;

    private void InstantiateText()
    {
        GameObject textObj = Instantiate(textLine, content.transform);
        TMP_Text text = textObj.GetComponent<TMP_Text>();
        text.text = storyPages[pageIndex].storyText[currentTextIndex];
        currentTextIndex++;
        updateCallback = IncreaseVisibility;
    }

    private void ProgressText()
    {
        if(pageIndex == storyPages.Count)
        {
            zeroVisCallback = GetComponent<StorySegment>().MoveToNextScene;
        } 
        else if(currentTextIndex < storyPages[pageIndex].storyText.Count)
        {
            InstantiateText();
        } 
        else
        {
            pageIndex++;
            currentTextIndex = 0;
            updateCallback = DecreaseVisibility;
        }
    }

    private void NextTextInput(InputAction.CallbackContext _)
    {
        ProgressText();
    }

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

    private void IncreaseVisibility()
    {
        if(contentCv.alpha >= 1)
        {
            updateCallback = null;
            return;
        }

        contentCv.alpha += opacityChangeRate;
    }

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
    }

    private void OnDisable()
    {
        vnActions.Player.Continue.Disable();
        vnActions.Player.Continue.performed -= NextTextInput;
    }

    private void Start()
    {
        contentCv = content.GetComponent<CanvasGroup>();
        storyPages = GetComponent<StorySegment>().GetStoryPages();
        contentCv.alpha = 0;
        updateCallback = IncreaseVisibility;
        InstantiateText();
    }

    private void FixedUpdate()
    {
        if (updateCallback != null)
            updateCallback();
    }
}
