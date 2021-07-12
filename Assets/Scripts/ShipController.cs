using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Ship), typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour
{
    private Ship _ship;
    private Rigidbody2D _body;

    public Vector2 bulletOffset;

    public GameObject projectile;
    
    // Start is called before the first frame update
    void Start()
    {
        _ship = GetComponent<Ship>();
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void MoveTowards(Vector2 position)
    {
        var pos = transform.position;
        Vector2 deltapos = position - new Vector2(pos.x, pos.y);
        _body.velocity = math.min(_body.velocity + deltapos * _ship.GetAcceleration(), deltapos * _ship.GetMaxSpeed());

        var r = _ship.transform.rotation;
        Vector2 move = Utils.GetVectorFromAngleD(r.eulerAngles.z) * _ship.GetAcceleration();
        var rotation = r.eulerAngles;
        float angle = Utils.GetPartialAngle(_ship.GetTurnSpeed(), rotation.z, deltapos);
        float dist = Vector2.Distance(_ship.transform.position, position);

        Quaternion rot = Quaternion.Euler(rotation.x, rotation.y,angle);
        
        if (dist < _ship.GetAcceleration())
            move *= _ship.GetMoveThreshold();
        
        if(dist > 2f * _ship.GetMoveThreshold() * _ship.GetAcceleration())
            _body.MovePosition((Vector2)(transform.position) + move);
        _ship.transform.rotation = rot;
    }
    
    public void Shoot()
    {
        var pos = transform.position;
        var rot = Utils.GetAngleD(transform.rotation.eulerAngles.normalized);
        
        Vector3 position = new Vector3(
            pos.x + math.sin(rot) * bulletOffset.x,
            pos.y + math.cos(rot) * bulletOffset.y, 
            pos.z);
        print(position);
        Instantiate(projectile, position, transform.rotation);

    }

    public static List<Projectile> GetProjectiles(List<GameObject> projectiles)
    {
        List<Projectile> shots = new List<Projectile>();

        foreach (var go in projectiles)
        {
            Projectile p;
            if(go.TryGetComponent(out p))
                shots.Add(p);
        }
        
        return shots;
    }
    
}
