using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public GameObject hitEffect;
    public GameObject shotEffect;

    private int HP = 50;
    private float moveSpeed = 2.0f;
    private float distance2Player;
    private GameObject player;
    private PlayerCtrl playerState;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        playerState = player.GetComponent<PlayerCtrl>();
    }
    void Update()
    {
        distance2Player = Vector3.Distance(transform.position, player.transform.position);

        if (distance2Player > 9.0f)
            Move();
        else
            StartCoroutine(Attack());
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            HP -= 10;

            Destroy(other.gameObject);
            GameObject hit = Instantiate(hitEffect, other.transform.position, other.transform.rotation);
            Destroy(hit, 1.0f);

            StartCoroutine(DelayMove());
            if (HP <= 0)
            {
                Destroy(gameObject);
                playerState.score += 100;
                playerState.UpdateState();
            }
        }
    }

    void Move()
    {
        transform.LookAt(player.transform);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    IEnumerator DelayMove()
    {
        anim.SetBool("isHit", true);
        float tempSpeed = moveSpeed;
        moveSpeed = 0f;
        yield return new WaitForSeconds(0.5f);
        moveSpeed = tempSpeed;
        anim.SetBool("isHit", false);
    }

    IEnumerator Attack()
    {
        anim.SetBool("isShot", true);
        yield return new WaitForSeconds(1.0f);

        Destroy(this.gameObject);

        GameObject shot = Instantiate(shotEffect, transform.position, transform.rotation);
        Destroy(shot, 1.0f);
        playerState.HP -= 10;
        playerState.UpdateState();
    }
      
}
