using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect_Start_D : MonoBehaviour {

    private Outline outline;
    private float StartX = 20f;
    private float timer = 1f;
    private bool forward = true;
    private float target = 52f;
    private void Start()
    {
        outline = GetComponent<Outline>();
        outline.effectDistance = new Vector2(StartX, 0);
    }
    // Update is called once per frame
    void Update () {
        if (forward)
            target = (1-timer)*32f;
        else
            target = timer * 32f;
        timer -= Time.deltaTime; 
        outline.effectDistance = new Vector2(StartX +target, 0);

        if (timer<=0)
        {
            forward = !forward;
            timer = 1f;
        }
	}
}
