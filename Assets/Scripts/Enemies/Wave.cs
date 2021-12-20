using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/Wave")]
public class Wave : ScriptableObject
{
    public int numberOfEnemies;
    public GameObject enemy;

    [Header("Mus� b�t stejn� mno�stv� ��sel, kolik bude spawnuto enem�k� a hodnota mus� b�t mezi 0-5")]
    public int[] spawnPositions;
}
