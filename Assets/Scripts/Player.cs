using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float shootSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed;
    bool onShoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerShoot();
    }

    private void PlayerShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            onShoot = true;
            StartCoroutine(AutoShoot());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            onShoot = false;
        }
    }

    private IEnumerator AutoShoot()
    {
        while(onShoot)
        {
            var newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            var rigidbody = newBullet.GetComponent<Rigidbody2D>();
            var force = new Vector2(0, bulletSpeed);
            rigidbody.velocity = force;
            yield return new WaitForSeconds(shootSpeed);
        }
    }

    private void PlayerMove()
    {
        var horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        Vector3 vector = new Vector3(horizontalInput, verticalInput, 0);
        transform.position += vector;
    }
}
