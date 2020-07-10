using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }
    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public bool HaveStar(int amount)
    {
        return stars >= amount;
    }

    public void Addstar(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }
    public void SpendStar(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
       
    }
  
}
