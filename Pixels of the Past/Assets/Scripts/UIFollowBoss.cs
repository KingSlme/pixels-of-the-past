using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowBoss : MonoBehaviour
{
    BossStats bossStats;
    [SerializeField] GameObject thingToFollow;

    void Start() 
    {
        bossStats = FindObjectOfType<BossStats>();
    }

    void LateUpdate()
    {   if(!bossStats.hasDied)
        { 
        transform.position = thingToFollow.transform.position + new Vector3(0f, 2.66f, 0f);
        }
    }
}
