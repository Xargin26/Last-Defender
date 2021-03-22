using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfig[] waveConfigs;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(LoopWaveConfig());
        }
        while (looping);
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
        for (int i = 0; i < waveConfig.GetEnemyCount(); i++)
        {
            var transforms = waveConfig.GetPaths();
            var enemy = Instantiate(waveConfig.GetEnemy(), transforms[0].position, Quaternion.identity);
            enemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetBuildTime());
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
