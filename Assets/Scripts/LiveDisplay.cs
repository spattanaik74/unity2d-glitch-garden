using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;
    float lives;
    
    Text liveText;

    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        liveText = GetComponent<Text>();
        UpdateDispaly();
       
    }

    private void UpdateDispaly()
    {
        liveText.text = lives.ToString();
    }
    public void TakeLife()
    {
        lives -= damage;
        UpdateDispaly();

        if(lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

}
