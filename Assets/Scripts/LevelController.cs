using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject LoseLabel;

    int numberOfAttacker = 0;
    bool levelTimerFinished = false;


    private void Start()
    {
        winLabel.SetActive(false);
        LoseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttacker++;
    }
    public void AttackerKilled()
    {
        numberOfAttacker--;
        if(numberOfAttacker <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().SceneLoad();
    }

    public void HandleLoseCondition()
    {
        LoseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {

        levelTimerFinished = true;
        StopSpawner();
    }
    private void StopSpawner()
    {
        Spawn[] spawnerArray = FindObjectsOfType<Spawn>();
        foreach(Spawn spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
