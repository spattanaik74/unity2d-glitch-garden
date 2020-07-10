using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //Conif parameters
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 3f;
    [SerializeField] Attacker[] attackerPrefabArray;

    bool spawn = true;

   IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            AttackerSpawn();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void AttackerSpawn()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        SpawnAttacker(attackerPrefabArray[attackerIndex]);
    }

    private void SpawnAttacker(Attacker myAttacker)
    {

        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;

    }
}
