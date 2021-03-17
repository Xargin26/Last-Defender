using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float shootSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] float sidePadding;
    Coroutine fireCoroutine;
    Vector3 minSidePos;
    Vector3 maxSidePos;

    // Start is called before the first frame update
    void Start()
    {
        var minPos = Camera.main.pixelRect.min;
        var maxPos = Camera.main.pixelRect.max;
        minSidePos = Camera.main.ScreenToWorldPoint(minPos);
        maxSidePos = Camera.main.ScreenToWorldPoint(maxPos);
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
            fireCoroutine = StartCoroutine(AutoShoot());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
    }

    private IEnumerator AutoShoot()
    {
        while(true)
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

        var newXPos = horizontalInput + transform.position.x;
        var newYPos = verticalInput + transform.position.y;
        newXPos = Mathf.Clamp(newXPos, minSidePos.x + sidePadding, maxSidePos.x - sidePadding);
        newYPos = Mathf.Clamp(newYPos, minSidePos.y + sidePadding, maxSidePos.y - sidePadding);
        transform.position = new Vector3(newXPos, newYPos, 0);
    }
}
