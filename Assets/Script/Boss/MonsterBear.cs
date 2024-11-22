using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBear : MonoBehaviour
{
    private Animator anim;
    private Rigidbody body;
    
    public enum StateEnemy
    {
        Idle,
        Attack
    }
}
