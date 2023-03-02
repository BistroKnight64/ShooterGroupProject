using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private floats
    private float verticalInput;
    private float horizontalInput;
    //public float
    public float moveSpeed;
    public float fireRate;
    // RigidBody
    private Rigidbody2D PlayerRB;
    // shoot key
    public KeyCode shootKey;

    //bool
    private bool canShoot = true;

    //game objects
    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if(horizontalInput != 0f || verticalInput != 0f)
        {
            PlayerRB.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
        }
        else
        {
            PlayerRB.velocity = new Vector2(0f, 0f);
        }
        

        //this first sees if the canShoot bool is true. if so, then it will spawn a bullet, set canShoot to false, and start a corountine that will set the canShoot bool back to true
        if (Input.GetKey(shootKey) && canShoot)
        {
            Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);;
            canShoot = false;
            StartCoroutine(FireRate());
        }
    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}