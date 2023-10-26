using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] levels;
    private int zPos = 281;
    private bool creatingLevel = false;
    private int levelNumber;
    private GameObject spawnedLevel;

    void Update(){
        if (creatingLevel == false){
            creatingLevel = true;
            StartCoroutine(GenerateLevel());
        }
    }

    IEnumerator GenerateLevel(){
        levelNumber = Random.Range(0, 2);
        spawnedLevel = Instantiate(levels[levelNumber], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 500;
        yield return new WaitForSeconds(5);
        creatingLevel = false;
    }     
}
