using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    List<Transform> transforms;
    int transformIndex = 0;
    [SerializeField] float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltimeSpeed = moveSpeed * Time.deltaTime;
        if (transform.position == transforms[transformIndex].position)
        {
            if (transformIndex == transforms.Count - 1)
            {
                Destroy(gameObject);
            }
            else
            {
                transformIndex++;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, transforms[transformIndex].position, deltimeSpeed);
        }
    }

    public void SetTranforms(List<Transform> transforms)
    {
        this.transforms = transforms;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }
}
