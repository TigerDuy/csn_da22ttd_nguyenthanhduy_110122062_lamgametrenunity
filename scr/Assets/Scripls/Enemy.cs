using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    private Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject==null)
        {
            playerObject = FindObjectOfType<GameObject>();
        }
        if(playerObject!=null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.Log("No player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform!=null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            collision.gameObject.SetActive(false);
            AudioManager.instance.PlayDeadClip();
            GameManager.instance.EnemySkillPlayer();
        }
        if(collision.tag=="Bullet")
        {
            Destroy(gameObject);
            GameManager.instance.AddScore(1);
        }
    }


}