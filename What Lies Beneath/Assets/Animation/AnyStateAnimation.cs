using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RIG {BODY, LEGS };

public class AnyStateAnimation : MonoBehaviour {

    public RIG AnimationRig { get; private set; }

    public string Name { get; set; }
    public bool Active { get; set; }

    public AnyStateAnimation(RIG rig, string name) {
        this.AnimationRig = rig;
        this.Name = name;
    }

}
