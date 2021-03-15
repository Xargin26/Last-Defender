using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "WaveConfig")]
public class WaveConfig : ScriptableObject
{

    [Range(0,10)] [SerializeField] float moveSpeed;
    [SerializeField] GameObject pathing;
    [SerializeField] GameObject enemy;
    [Range(0.1f, 1f)] [SerializeField] float buildTime;
    [SerializeField] float enemyCount;

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public List<Transform> GetPaths()
    {
        List<Transform> paths = new List<Transform>();
        foreach (Transform path in pathing.transform)
        {
            paths.Add(path);
        }
        return paths;
    }

    public GameObject GetEnemy()
    {
        return enemy;
    }

    public float GetBuildTime()
    {
        return buildTime;
    }

    public float GetEnemyCount()
    {
        return enemyCount;
    }
}
