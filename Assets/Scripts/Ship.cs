using UnityEngine;

public class Ship : MonoBehaviour
{

    [SerializeField, Range(0, 400f)]
    private float Acceleration;

    [SerializeField, Range(0f, 1f)] 
    public float MoveThreshold;

    [SerializeField, Range(0, 1080f)]
    private float TurnSpeed;

    [SerializeField, Range(0, 1000f)] 
    private float MaxSpeed;

    
    public float GetMaxSpeed()
    {
        return MaxSpeed;
    }

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
