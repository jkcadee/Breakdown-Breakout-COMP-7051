using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float explosionRate = 1.01f;
    bool imploding = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!imploding)
        {
            transform.localScale *= explosionRate;
            if (transform.localScale.x > 3) imploding = true;
        }
        else
        {
            transform.localScale /= explosionRate;
            if (transform.localScale.x < 0.05f) Destroy(gameObject);
        }
    }
}
