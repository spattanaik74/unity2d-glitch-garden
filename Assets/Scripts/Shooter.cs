using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectileObject, handGun;
    Spawn myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECT_PARENT_NAME = "projectiles";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECT_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECT_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
            
    }

    private void SetLaneSpawner()
    {
        Spawn[] spawners = FindObjectsOfType<Spawn>();

        foreach(Spawn spawner in spawners)
        {
            bool IsCloseEnough = Mathf.Abs 
                (spawner.transform.position.y - transform.position.y)
                 <= Mathf.Epsilon;
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {

            return true;
        }
    }

    public void Shot()
    {
       GameObject newProjectile =  Instantiate(projectileObject, handGun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
