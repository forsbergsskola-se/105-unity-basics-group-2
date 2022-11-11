using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    private int current;
    public float distThreshold = 5f;
    
    private Vector3 deltaPosition;
    private float sqrDistToTarget;
    private float distThresholdSqr;

    private void Start()
    {
        distThresholdSqr = distThreshold * distThreshold;
    }

        
    private void Update()
    {
        deltaPosition = target[current].position - transform.position;
        sqrDistToTarget = deltaPosition.sqrMagnitude;
        if (  sqrDistToTarget > distThresholdSqr  )
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
            
        }
        else current = (current + 1) % target.Length;
    }
}
