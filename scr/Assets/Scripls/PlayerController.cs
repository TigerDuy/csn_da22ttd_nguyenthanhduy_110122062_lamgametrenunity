using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    private Camera mainCamera;
    //Bullet
    public GameObject BulletPrefabs;
    public Transform firePoint;
    public float fireRate = 0.5f;
    private float nextFireTime;


    // Start is called before the first frame update
    void Start()
    {
        // Lấy thành phần Rigidbody2D từ nhân vật
        rb = GetComponent<Rigidbody2D>();

        //Animtions
        animator = GetComponent<Animator>();

        //Camera
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Nhận input từ bàn phím hoặc tay cầm
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        //update animations
        UpdateAnimationState();
        
        //Bullet
        if(Input.GetMouseButton(0)&&Time.time>=nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

     void FixedUpdate()
    {
        // Áp dụng lực để di chuyển nhân vật
        rb.velocity = moveInput * moveSpeed;

        rotatePlayer();
    }

    void UpdateAnimationState()
    {
        if(moveInput.magnitude>0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void rotatePlayer()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            transform.localScale = new Vector3(2, -2, 0);
        else
            transform.localScale = new Vector3(2, 2, 0);
    }
    void Shoot()
    {
        Instantiate(BulletPrefabs, firePoint.position, firePoint.rotation);
        AudioManager.instance.PlayShootingClip();
    }
}
