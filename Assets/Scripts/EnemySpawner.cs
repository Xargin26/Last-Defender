using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfig[] waveConfigs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoopWaveConfig());
    }

    IEnumerator LoopWaveConfig()
    {
        for (int i = 0; i < waveConfigs.Length; i++)
        {
            
            yield return StartCoroutine(EnemyPathing(waveConfigs[i]));
        }
    }

    IEnumerator EnemyPathing(WaveConfig waveConfig)
    {
        
        float enemyCount = waveConfig.GetEnemyCount();
        for (int i = 0; i < enemyCount; i++)
        {
            yield return StartCoroutine(InstantiateEnemy(waveConfig));
        }
    }

    IEnumerator InstantiateEnemy(WaveConfig waveConfig)
    {
        var enemyPerfab = waveConfig.GetEnemy();
        var transforms = waveConfig.GetPaths();
        var buildTime = waveConfig.GetBuildTime();
        var moveSpeed = waveConfig.GetMoveSpeed();
        var enemy = Instantiate(waveConfig.GetEnemy(), transforms[0].position, Quaternion.identity);
        var enemyPathing = enemy.GetComponent<EnemyPathing>();
        enemyPathing.SetTranforms(transforms);
        enemyPathing.SetMoveSpeed(moveSpeed);
        yield return new WaitForSeconds(buildTime);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
