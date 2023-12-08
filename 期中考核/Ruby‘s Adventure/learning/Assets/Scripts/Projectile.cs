using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //齿轮
    private Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);//向量
    }

    private void Update()
    {
        //齿轮在移动一定距离后自动销毁
        if (transform.position.magnitude > 100)
        {
           Destroy(gameObject);
       }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //修复机器人
        EnemyController enemyController = collision.gameObject.
           GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.Fix();
        }
        Destroy(gameObject);
    }
}
