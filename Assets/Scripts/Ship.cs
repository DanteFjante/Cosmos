using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ship : MonoBehaviour
{

    [SerializeField, Range(0, 400f)]
    private float Acceleration;

    [SerializeField, Range(0f, 1f)] 
    public float MoveThreshold;

    [SerializeField, Range(0, 1080f)]
    public float TurnSpeed;
    
    
    public float GetAcceleration()
    {
        return Acceleration * Time.deltaTime;
    }
    
    public float GetMoveThreshold()
    {
        return MoveThreshold;
    }

    public float GetTurnSpeed()
    {
        return TurnSpeed * Time.deltaTime;
    }
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
