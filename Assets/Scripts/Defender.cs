using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    public int GetStarCost()
    {
        return starCost;
    }

    public void AddStar(int amount)
    {
        FindObjectOfType<StarDisplay>().Addstar(amount);
    }
}
