using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    List<Transform> transforms;
    int transformIndex = 0;
    [SerializeField] float moveSpeed;
    Transform nextTranform;

    // Start is called before the first frame update
    void Start()
    {
        nextTranform = transforms[0];
    }

    // Update is called once per frame
    void Update()
    {
        var deltimeSpeed = moveSpeed * Time.deltaTime;
        if(transform.position == nextTranform.position)
        {
            if (transformIndex == transforms.Count - 1)
            {
                Destroy(gameObject);
            }
            else
            {
                GetNextTranform();
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextTranform.position, deltimeSpeed);
        }
    }

    void GetNextTranform()
    {
        transformIndex++;
        nextTranform = transforms[transformIndex];
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
