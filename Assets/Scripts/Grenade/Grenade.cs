using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    //Bools
    public bool CanFireShrapnel;

    //Floats
    public float CountDown;
    public float TimeBetweenExplosion;

    //GameObjects and Particles
    public GameObject ExplosionSource;
    public GameObject ShrapnelSource;
    public GameObject Grenadesprite;

    public GameObject ExplosionRadius;
    public ParticleSystem ExplosionParticles;

    public GameObject Shrapnel;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GrenadeGoBoom());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    //Exploding
    IEnumerator GrenadeGoBoom()
    {
        Debug.Log("Counting Down...");
        yield return new WaitForSeconds(CountDown);

        //Sprite Destruction
        Destroy(Grenadesprite);

        //Spawning Explosion and Shrapnel
        Instantiate(ExplosionRadius, ExplosionSource.transform.position, ExplosionSource.transform.rotation);
        Instantiate(ExplosionParticles, ExplosionSource.transform.position, ExplosionSource.transform.rotation);

        if(CanFireShrapnel == true)
        {
            Debug.Log("Firing Shrapnel...");
            ShrapnelFiring();
        }

        //Destroying
        Destroy(gameObject);

    }

    //Shrapnel Firing
    void ShrapnelFiring()
    {
        Debug.Log("Shrapnel fired!");
    }
}
