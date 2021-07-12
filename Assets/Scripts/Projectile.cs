using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{

    public Animator animator;
    
    public float CollideDamage;
    public float CollideImpact;
    public float Speed;
    public float Recoil;

    private Collider2D collider;
    
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();

    }

    private void OnCollisionEnter2D(Collision2D contact)
    {
        print("Collided");
        animator.SetTrigger("Collided");
        LifeAttribute attribute;
        if(contact.collider.TryGetComponent(out attribute))
            attribute.Damage(CollideDamage);
        Rigidbody2D body;
        if(contact.collider.TryGetComponent(out body))
        {
            var position = body.transform.position;
            body.AddForce((position - transform.position) * CollideImpact, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.rotation.eulerAngles.normalized * Speed;
    }
}
