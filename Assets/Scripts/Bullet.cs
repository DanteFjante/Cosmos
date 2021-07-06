using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{

    public float speed;
    public float damage;
    public float explosiveForce;
    public BulletStatus status;

    public MeshRenderer[] graphics;

    // Start is called before the first frame update
    void Start()
    {
        SetDead();

    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void Show(bool show)
    {
        if (graphics == null)
            return;

        foreach (var renderer in graphics)
        {
            renderer.enabled = show;
        }
    }
    
    public void SetDead()
    {
        Show(false);
        status = BulletStatus.Dead;
    }
    
    public enum BulletStatus
    {
        Dead,
        Loading, 
        Shooting,
        Shot,
        Flying,
        Hitting,
        Exiting,
    }
}
