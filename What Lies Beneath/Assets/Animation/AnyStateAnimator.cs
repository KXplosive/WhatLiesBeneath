using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyStateAnimator : MonoBehaviour
{
    private Animator animator;

    private Dictionary<string, AnyStateAnimation> animations = new Dictionary<string, AnyStateAnimation>();

    private string currentAnimationLegs = string.Empty;

    private string currentAnimationBody = string.Empty;

    private void Awake() {
        this.animator = GetComponent<Animator>();
    }

}
