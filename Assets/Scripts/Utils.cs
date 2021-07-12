using System;
using Unity.Mathematics;
using UnityEngine;

public static class Utils
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
        
        if (deltaAngle > 180)  
            return currentRotation - math.min(deltaAngle - 180,rotationSpeed);
        
        return currentRotation + math.min(deltaAngle,rotationSpeed);

    }
    
    public static bool HasComponent(this GameObject go, Type type)
    {
        return go.GetComponent(type) != null;
    }

}