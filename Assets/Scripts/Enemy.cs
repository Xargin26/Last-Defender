using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float hp;
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] float shootCD;
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioClip explodeSound;
    float cdTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        shootCD = Random.Range(0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public void GetDamage(float damageValue)
    {
        hp -= damageValue;  
        if (hp <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(explodeSound, Camera.main.transform.position);
        var explosionParticle = Instantiate(explosionParticles, transform.position, transform.rotation);
        Destroy(explosionParticle, 1f);
    }

    void Attack()
    {
        cdTime += Time.deltaTime;
        if (cdTime > shootCD)
        {
            cdTime = 0;
            shootCD = Random.Range(1f, 2f);
            var newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            var bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = new Vector2(0, -bulletSpeed);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
        }
    }
}
