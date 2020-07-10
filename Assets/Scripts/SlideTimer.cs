using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideTimer : MonoBehaviour
{
    [Tooltip("Game Time In Second")]
    [SerializeField] float levelTimer = 10;
    bool triggerLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (triggerLevelFinished)
        {
            return;
        }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTimer;


        bool timerFinished = (Time.timeSinceLevelLoad >= levelTimer);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggerLevelFinished = true;
        }

    }
}
