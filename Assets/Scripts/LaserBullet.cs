using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    [SerializeField] float laserSpeed;
    [SerializeField] float laserMaxLength = 10;
    [SerializeField] float laserPadding;
    [SerializeField] float damage;
    [SerializeField] float defaultDamageCoolDown;

    float damageCoolDown;
    SpriteRenderer laserBulletSpriteRenderer;
    Coroutine shootCoroutine;

    private void Awake()
    {
        laserBulletSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //laserBulletSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Shoot()
    {
        shootCoroutine = StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {   
        while (true)
        {
            var rayInfo = Physics2D.Raycast(transform.position, Vector2.up, laserBulletSpriteRenderer.size.y, LayerMask.GetMask("Enemy"));
            if(rayInfo.collider != null)
            {
                laserBulletSpriteRenderer.size = new Vector2(laserBulletSpriteRenderer.size.x, rayInfo.distance);
                HitEnemy(rayInfo);
            }
            else
            {
                laserBulletSpriteRenderer.size = Vector2.MoveTowards(laserBulletSpriteRenderer.size, new Vector2(laserBulletSpriteRenderer.size.x, laserMaxLength), laserSpeed * Time.deltaTime);
            }
            yield return null;
        }
    }

    private void HitEnemy(RaycastHit2D rayInfo)
    {
        damageCoolDown += Time.deltaTime;
        if(damageCoolDown > defaultDamageCoolDown)
        {
            damageCoolDown = 0;
            var enemy = rayInfo.collider.gameObject.GetComponent<Enemy>();
            enemy.GetDamage(damage);
        }
    }

    public void StopShoot()
    {
        if (shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
            shootCoroutine = null;
            Destroy(gameObject);
        }
    }
}
