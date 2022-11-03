using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class VisualNovelHandler : MonoBehaviour
{
    public GameObject textLine;
    public GameObject content;
    StoryPage storyPage;
    VNActions vnActions;
    int currentIndex = 0;

    private void NextTextBox()
    {
        if(currentIndex < storyPage.storyText.Count)
        {
            GameObject textObj = Instantiate(textLine, content.transform);
            TMP_Text text = textObj.GetComponent<TMP_Text>();
            text.text = storyPage.storyText[currentIndex];
            currentIndex++;
        }
    }

    private void NextTextInput(InputAction.CallbackContext _)
    {
        NextTextBox();
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

    void Start()
    {
        List<string> text = new List<string>();
        text.Add("In a dark room with metal walls and metal floors...");
        text.Add("a robot wakes from its sleep mode.");
        text.Add("text");

        storyPage = new StoryPage(text, null);
    }
}
