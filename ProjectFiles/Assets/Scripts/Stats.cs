using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[CreateAssetMenu(menuName = "New State", fileName = "New State")]
public class Stats : ScriptableObject
{


    public float moveSpeed;

    public float jumpForce;
    public int extraJumps;

    public float gravityScale;

    public RuntimeAnimatorController anim;
}
