using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHint : MonoBehaviour
{

    public GameObject arrow;
    public float invisibleTimer;


    private Vector3 spawnLocation;
    // Start is called before the first frame update


    // Update is called once per frame
    void Start()
    {
        arrow.SetActive(false);
        StartCoroutine(ShowArrow(invisibleTimer));
    }

    // show arrow hint after set time
    IEnumerator ShowArrow(float invisibleTimer) {
        yield return new WaitForSeconds(invisibleTimer);
        arrow.SetActive(true);
    }
}
