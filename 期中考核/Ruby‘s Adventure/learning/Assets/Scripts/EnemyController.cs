using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    public float speed=3;
    public bool vertical;
    private int direction = 1;

    public float changeTime = 3;
    private float timer;//计时器
    private Animator animator;
    private AudioSource audioSource;
    public AudioClip[] hitSounds;
    private bool broken;//机器人是否修复

    public ParticleSystem smokeEffect;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        PlayMoveAnimation();
        broken = true;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!broken)
        {
            return;
        }//已修好机器人
        timer -= Time.deltaTime;

        if (timer<0)
        {
            direction = -direction;
            //animator.SetFloat("MoveX", direction);
            PlayMoveAnimation();
            timer = changeTime;
        }

        Vector2 position = rigidbody2d.position;

        if(vertical)//垂直运动
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else//水平运动
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }      
        rigidbody2d.MovePosition(position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        RubyController rubyController = collision.gameObject.GetComponent<RubyController>();
        if(rubyController!=null)
        {
            rubyController.ChangeHealth(-1);
        }
    }
    //控制动画


    private void PlayMoveAnimation()
    {
        if (vertical)//垂直动画
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
        }
        if (vertical)//水平动画
        {
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
        }
    }
    public void Fix()
    {
        broken = false;
        rigidbody2d.simulated = false;
        animator.SetTrigger("Fixed");
        smokeEffect.Stop();
        int randomNum = Random.Range(0, 2);
        //float randomNum2 = Random.Range(1f,2f);
        audioSource.Stop();
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(hitSounds[randomNum]);
        Invoke("PlayFixedSound", 1f);
    }

}
