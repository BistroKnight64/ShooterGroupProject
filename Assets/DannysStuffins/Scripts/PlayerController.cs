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
    // Animator
    private Animator Anim;
    //bool
    private bool canShoot = true;
    private bool IsWalking = false;
    // is facing LEFT side
    private bool IsFacingSide = false;
    private bool IsFacingFront = false;
    //game objects
    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0f || verticalInput != 0f)
        {
            PlayerRB.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
            IsWalking = true;
            Anim.SetBool("IsWalking", IsWalking);
            if (verticalInput < 0)
            {
                //face towards camera
                IsFacingFront = true;
                Anim.SetBool("IsFacingFront", IsFacingFront);
            }
            else
            {
                //face away from camera
                IsFacingFront = false;
                Anim.SetBool("IsFacingFront", IsFacingFront);
            }

            if (horizontalInput < 0)
            {
                //face left
                IsFacingSide = true;
                Anim.SetBool("IsFacingSide", IsFacingSide);
            }
            else
            {
                //face right
                IsFacingSide = false;
                Anim.SetBool("IsFacingSide", IsFacingSide);
            }
        }

        else
        {
            PlayerRB.velocity = new Vector2(0f, 0f);
            IsWalking = false;
            Anim.SetBool("IsWalking", IsWalking);
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