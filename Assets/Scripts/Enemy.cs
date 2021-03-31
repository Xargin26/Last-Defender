using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float hp;
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetDamage(collision);
    }

    private void GetDamage(Collider2D collision)
    {
        var damageDealer = collision.GetComponent<DamageDealer>();
        hp -= damageDealer.GetDamage();
        if (hp <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
        var explosionParticle = Instantiate(explosionParticles, transform.position, transform.rotation);
        Destroy(explosionParticle, 1f);
    }

    void Attack()
    {

    }
}
