using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAI : MonoBehaviour
{
    //Components
    public CircleCollider2D AttackRadius;

    //GameObjects
    public GameObject AttackRadiusBase;

    //Bools
    public bool CanShoot;
    public bool IsAbleToShoot;

    //Floats
    public float ShootingDelays;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Shooting
        if (CanShoot == true && IsAbleToShoot == true)
        {

        }
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(ShootingDelays);
    }
}
