using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private GameObject playerFrefab;
    [SerializeField] private float spawnMinX;
    [SerializeField] private float spawnMaxX;
    [SerializeField] private float spawnMinY;
    [SerializeField] private float spawnMaxY;

    internal void Spawn()
    {
        Vector3 pos = new Vector3(Random.Range(spawnMinX, spawnMaxX), Random.Range(spawnMinY, spawnMaxY), 1);
        Server.Instance.InstantiateGameObject(playerFrefab.name, pos, Quaternion.identity);
    }


    #endregion
}
