using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandleAttackPlayer : MonoBehaviour
{
    HandleOutPut handleOutPut;
    private float timeCoolDown;
    float timeDefend = 2f;


    private void Awake()
    {
        handleOutPut = GetComponent<HandleOutPut>();
    }


    private void Update()
    {
        
        AttackCombo();
        Defend();
    }


    private void AttackCombo()
    {
        timeCoolDown -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeCoolDown < 0 )
        {
            timeCoolDown = 0.3f;
            int combo;
            combo = UnityEngine.Random.Range(1,4);
            string attackCombo = "Attack" + combo;
            handleOutPut.anim.SetTrigger(attackCombo);
        }
    }

    private void Defend()
    {
        if (Input.GetMouseButton(1) && timeDefend > 0)
        {
            timeDefend -= Time.deltaTime;
            Debug.Log(timeDefend);
            handleOutPut.anim.SetTrigger("Defend");
        }
        else
        {
          if (timeDefend <= 2)
          {
              timeDefend += Time.deltaTime;
          }
        }
    }

    
}
