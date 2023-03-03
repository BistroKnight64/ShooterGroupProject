using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAI : MonoBehaviour
{
    //Components
    public CircleCollider2D AttackRadius;

    //GameObjects
    public GameObject AttackRadiusBase;
    public GameObject Bullet;
    public GameObject Player;
    public GameObject TargetSpot;
    //Bools
    public bool CanShoot;
    public bool IsAbleToShoot;

    public bool IsTargeting;
    

    //Floats
    public float ReloadingDelays;
    public float StartStootingDelay;

    public float TargetingDelay;

    //Vector
   

    // Start is called before the first frame update
    void Start()
    {
        //AttackRadiusBase is the Attack Radius center
        AttackRadius = AttackRadiusBase.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Shooting
        if (CanShoot == true && IsAbleToShoot == true)
        {
            StartCoroutine(ShootDelay());
        }

        //Targeting
        if(IsTargeting == true )
        {
            StartCoroutine(Targeting());
        }
    }

    //This Coroutine Lets the Player Shoot
    IEnumerator ShootDelay()
    {
        CanShoot = false;

        //Lets animation play before Shooting Bullet
        yield return new WaitForSeconds(StartStootingDelay);

        //Shooting
        Instantiate(Bullet, TargetSpot.transform.position, TargetSpot.transform.rotation);

        //Cool Down
        yield return new WaitForSeconds(ReloadingDelays);

        CanShoot = true;
    }

    //This Makes the Enemy Aim at the player, but only every now and then
    IEnumerator Targeting()
    {
        IsTargeting = false;

        //TargetSpot Equals Player
        TargetSpot.transform.position = Player.transform.position;
        TargetSpot.transform.rotation = Player.transform.rotation;

        //CoolDown
        yield return new WaitForSeconds(TargetingDelay);

        IsTargeting = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If The Player Enters The Enemies range
        if (collision.gameObject.CompareTag("Player"))
        {
            CanShoot = true;
        }
        else
        {
            CanShoot = false;
        }
    }
}
