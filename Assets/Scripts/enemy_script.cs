using UnityEngine;

public class Enemy_script : Main_script
{
    public Transform player;

    [Header("Enemy AI")]
    public float patrolDistance = 2f;
    public float detectRange = 4f;
    public float attackRange = 1.5f;
    public float stopDistance = 0.4f;

    [Header("Attack")]
    public float attackCooldown = 1.2f;
    private float attackTimer;

    private Vector2 startPos;
    private int patrolDirection = 1;

    private bool playerDetected = false;

    private enum EnemyState
    {
        Patrol,
        Detect,
        Attack,
        Death
    }

    private EnemyState currentState;

    void Start()
    {
        startPos = transform.position;
        currentState = EnemyState.Patrol;
    }

    void Update()
    {
        if (player == null || currentState == EnemyState.Death)
            return;

        Ground_collision();

        float distanceX = player.position.x - transform.position.x;
        float absDistance = Mathf.Abs(distanceX);

        attackTimer -= Time.deltaTime;

        switch (currentState)
        {
            case EnemyState.Patrol:

                playerDetected = false;
                Patrol();

                if (absDistance < detectRange)
                    currentState = EnemyState.Detect;

                break;

            case EnemyState.Detect:

                playerDetected = true;
                DetectPlayer(distanceX, absDistance);

                if (absDistance < attackRange)
                    currentState = EnemyState.Attack;

                if (absDistance > detectRange)
                    currentState = EnemyState.Patrol;

                break;

            case EnemyState.Attack:

                Attack(distanceX, absDistance);

                if (absDistance > attackRange)
                    currentState = EnemyState.Detect;

                break;
        }

        UpdateAnimations();
    }

    void Patrol()
    {
        movement_info(patrolDirection);

        if (Mathf.Abs(transform.position.x - startPos.x) >= patrolDistance)
        {
            patrolDirection *= -1;
            startPos = transform.position;
        }

        flip(patrolDirection);
    }

    void DetectPlayer(float distanceX, float absDistance)
    {
        float dir = Mathf.Sign(distanceX);

        if (absDistance > stopDistance)
        {
            movement_info(dir);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        flip(dir);
    }

    void Attack(float distanceX, float absDistance)
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

        float dir = Mathf.Sign(distanceX);
        flip(dir);

        if (attackTimer <= 0f)
        {
            anime.SetTrigger("attack");
            attackTimer = attackCooldown;
        }
    }

    void UpdateAnimations()
    {
        anime.SetFloat("speed", Mathf.Abs(rb.linearVelocity.x));
        anime.SetBool("detected", playerDetected);
    }

    public void Die()
    {
        currentState = EnemyState.Death;
        rb.linearVelocity = Vector2.zero;
        anime.SetTrigger("death");
    }
}