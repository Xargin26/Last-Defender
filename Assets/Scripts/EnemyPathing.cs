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
        if(transformIndex == transforms.Count - 1)
        {
            Destroy(gameObject);
        }

        if(transform.position == nextTranform.position)
        {
            GetNextTranform();
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(transform.position, nextTranform.position, moveSpeed);
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
