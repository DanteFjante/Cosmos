using Unity.Mathematics;
using UnityEngine;

public class Utils
{


    public static float GetAngleR(Vector2 vector)
    {

        if(vector.x < 0)
            return math.acos(vector.normalized.y) ; 
        return -math.acos(vector.normalized.y) ; 

    }
    public static float GetAngleD(Vector2 vector)
    {
        return math.degrees(GetAngleR(vector));
    }
    
    public static Vector2 GetVectorFromAngleR(float angle)
    {
        return new Vector2(-math.sin(angle), math.cos(angle));
    }
    
    public static Vector2 GetVectorFromAngleD(float angle)
    {
        return GetVectorFromAngleR(math.radians(angle));
    }

    public static float GetPartialAngle(float rotationSpeed, float currentRotation, Vector2 desiredPosition)
    {
        float deltaAngle = (GetAngleD(desiredPosition) - currentRotation + 720) % 360 ;
        Debug.Log("Delta: " + (currentRotation - math.min(deltaAngle - 180,rotationSpeed)));
        
        if (deltaAngle > 180)  
            return currentRotation - math.min(deltaAngle - 180,rotationSpeed);
        
        return currentRotation + math.min(deltaAngle,rotationSpeed);

    }
    
    public static Vector2 GetPartialVector()
    {
        return Vector2.zero;
    }

}