using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialArrow : MonoBehaviour
{
    private float speed = 5f;
    private float height = 1f;
    private Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // create arrow hovering effect
        float newY = Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(initialPos.x, newY * height + initialPos.y, initialPos.z);
    }
}
