using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<WaveSystemSO> waves;

    private void Start()
    {
        StartCoroutine (EnemySpawn());
    }

    private IEnumerator EnemySpawn()
    {
            for (int i = 0; i < waves.Capacity; i++)
            {
                    for (int j = 0; j < waves[i].enemyAmount; j++)
                    {
                    Vector3 playerPos = player.transform.position;
                    Vector3 enemySpawn;
                    int randomNumber = Random.Range(1, 4);
                    switch (randomNumber)
                    {
                        case 1:
                            enemySpawn = new Vector3(-4, Random.Range(-6f, 6f), 0);
                            enemySpawn += playerPos;
                            break;

                        case 2:
                            enemySpawn = new Vector3(4, Random.Range(-6f, 6f), 0);
                            enemySpawn += playerPos;
                            break;

                        case 3:
                            enemySpawn = new Vector3(Random.Range(-4f, 4f), -6, 0);
                            enemySpawn += playerPos;
                            break;

                        case 4:
                            enemySpawn = new Vector3(Random.Range(-4f, 4f), 6, 0);
                            enemySpawn += playerPos;
                            break;

                        default:
                            Debug.Log("enemy spawn error");
                            enemySpawn = new Vector3(0, 0, 0);
                            break;
                    }
                        Instantiate(waves[i].enemyPrefab, enemySpawn, Quaternion.identity).transform.parent = gameObject.transform;
                        yield return new WaitForSeconds(60/ waves[i].enemyAmount );
                    }
            }
        }
}
