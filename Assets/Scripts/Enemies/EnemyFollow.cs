using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : EnemyBehaviour
{
    public float speed;
    private Transform target;
    private bool isMoving;
    private Animator animator;
    private float aggroDistance;
    private GameObject restartGameHandler;
    private AudioSource audioSource;
    bool playingSound = false;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        restartGameHandler = GameObject.FindGameObjectWithTag("RestartGameHandler");
        animator = GetComponent<Animator>();
        aggroDistance = GlobalConstants.DEFAULT_ENEMY_AGGRO_DISTANCE;
        speed = GlobalConstants.DEFAULT_MONSTER_WALK_SPEED;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < aggroDistance)
        {
            if (!playingSound)
            {
                playingSound = true;
                audioSource.Play(0);
            }

            isMoving = true;
            Vector3 oldPos = target.position;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);            
            Vector2 delta = new Vector2(transform.position.x, transform.position.y) - new Vector2(oldPos.x, oldPos.y);
            delta.Normalize();
            // Negate values to get correct animation
            animator.SetFloat("moveX", -delta.x);
            animator.SetFloat("moveY", -delta.y);
            animator.SetBool("isMoving", isMoving);

            if (Vector2.Distance(transform.position, target.position) < GlobalConstants.DEFAULT_MONSTER_KILL_DISTANCE)
            {
                restartGameHandler.GetComponent<RestartGameHandler>().EndGame();
            }
        } else if (isMoving)
        {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);
        }
    }
}
