using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    int transformIndex = 0;
    List<Transform> transforms;

    // Start is called before the first frame update
    void Start()
    {
        transforms = waveConfig.GetPaths();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltimeSpeed = waveConfig.GetMoveSpeed() * Time.deltaTime;
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

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }
}
