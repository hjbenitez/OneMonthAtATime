using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEndDayAnimation : MonoBehaviour
{
    Animator endScreenAnimator;
    bool animationSet = false;
    // Start is called before the first frame update

    
    void Start()
    {
        endScreenAnimator = GetComponent<Animator>();
        animationSet = false;
    }

    private void Update()
    {
        endScreenAnimator.SetBool("animationSet", animationSet);
        if (!animationSet)
        {
            endScreenAnimator.SetInteger("index", GameManager.instance.GetEndIndex());
            animationSet = true;
        }
    }
}
