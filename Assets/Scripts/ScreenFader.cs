﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    Animator anim;
    public bool isFading = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public IEnumerator FadeToClear()
    {
        isFading = true;
        anim.SetTrigger("FadeIn");

        while (isFading)
            yield return null;
    }

    public IEnumerator FadeToBlack()
    {
        isFading = true;
        anim.SetTrigger("FadeOut");

        while (isFading)
            yield return null;
    }

    void AnimationComplete()
    {
        isFading = false;
    }
}