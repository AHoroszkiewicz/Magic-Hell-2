using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundGenerator : MonoBehaviour
{
    [SerializeField] RuleTile backgroundRule;
    [SerializeField] Tilemap tileMap;
    [SerializeField] int spawnSize = 16;
    private int maxX, maxY, minX, minY;

    private IEnumerator Start()
    {
        while (true)
        {
            Vector3Int currentCell = tileMap.WorldToCell(transform.position);
            maxX = currentCell.x + spawnSize / 2;
            minX = currentCell.x - spawnSize / 2;
            maxY = currentCell.y + spawnSize / 2;
            minY = currentCell.y - spawnSize / 2;
            for (int i = minX; i < maxX; i++)
            {
                for (int j = minY; j < maxY; j++)
                {
                    Vector3Int checkedCell = new Vector3Int(i,j);
                    if (!tileMap.HasTile(checkedCell))
                    {
                        tileMap.SetTile(checkedCell, backgroundRule);
                    }
                }
            }
            yield return new WaitForSeconds(1);
        }
    }
}
