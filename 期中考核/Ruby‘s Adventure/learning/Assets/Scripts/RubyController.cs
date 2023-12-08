using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public int maxHealth = 5;
    private int currentHealth;
    public int Health { get { return currentHealth; } }
    public int speed = 3;
    //Ruby无敌时间
    public float timeInvincible = 2.0f;
    public bool isInvincible;
    public float invincibleTimer;//计时器
    private Vector2 lookDirection = new Vector2(1,0);
    private Animator animator;
    private Vector3 respawnPosition;
    public GameObject projectilePrefab;

    public AudioClip playerHit;
    public AudioSource audioSource;
    public AudioSource walkAudioSource;
    public AudioClip walkSound;
    public AudioClip attackSoundClip;

   

    // Start is called before the first frame update
    private void Start()
    {
        // Application.targetFrameRate = 60;帧率
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
        respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);//向量
        //Ruby是否运动
        if (!Mathf.Approximately(move.x, 0) || (!Mathf.Approximately(move.y, 0)))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
            if (!walkAudioSource.isPlaying)
            {
                walkAudioSource.clip = walkSound;
                walkAudioSource.Play();
            }
        }
        else
        {
            walkAudioSource.Stop();
        }
        //动画控制
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = transform.position;

        position = position + speed * move * Time.deltaTime;
        // transform.position = position;
        // position.x = position.x + speed * horizontal * Time.deltaTime;
        rigidbody2d.MovePosition(position);

        //无敌时间
        if (isInvincible)
        {
            invincibleTimer = invincibleTimer - Time.deltaTime;
            if (invincibleTimer <= 0)
            {
                isInvincible = false;
            }
        }

        //修复机器人
        if (Input.GetKeyDown(KeyCode.J))
        {
            Launch();
        }

        //与NPC对话
        if(Input.GetKeyDown(KeyCode.K))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position +
                            Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NPCDialog npcDialog = hit.collider.GetComponent<NPCDialog>();
                if (npcDialog != null)
                {
                    npcDialog.DisplayDialog();
                }
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        if(amount<0)
        {
            if (isInvincible)
            { 
                return;
            } 
            //受到伤害
            isInvincible = true;
            invincibleTimer = timeInvincible;
            PlaySound(playerHit);
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if (currentHealth <= 0)
        {
            Respawn();
        }
        UIHealthBar.instance.SetValue(currentHealth /(float) maxHealth);
    }


    private void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab,
             rigidbody2d.position , Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
        animator.SetTrigger("Launch");
    }
    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
    private void Respawn()
    {
        ChangeHealth(maxHealth);
        transform.position = respawnPosition;
    }

}
