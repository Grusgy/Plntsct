using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/Wave")]
public class Wave : ScriptableObject
{
    public int numberOfEnemies;
    public GameObject enemy;

    [Header("Musí být stejné množství èísel, kolik bude spawnuto enemákù a hodnota musí být mezi 0-5")]
    public int[] spawnPositions;
}
