using UnityEngine;

namespace DefaultNamespace
{
    public class LifeAttribute : MonoBehaviour
    {
        public float life;



        public void Damage(float damage)
        {
            life -= damage;
        }
    }
}