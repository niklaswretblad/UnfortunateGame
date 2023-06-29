using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    public float moveSpeed = GlobalConstants.DEFAULT_WALK_SPEED;
    private float stamina = GlobalConstants.STAMINA_MAX;
    public bool moving = false;
    public bool running;
    public Rigidbody2D rb;

    private Vector2 movement;
    public Animator animator;

    private List<Item> inventory = new List<Item>();

    private Slider staminaBar;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        staminaBar = GameObject.FindGameObjectWithTag("StaminaBar").GetComponent<Slider>();
        //DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        running = false;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            moving = true;
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("isMoving", moving);            
        }

        if (Input.GetKey(KeyCode.LeftShift) && moving)
        {
            stamina -= Time.deltaTime / GlobalConstants.STAMINA_DEPLETION_TIME;

            if (stamina > 0f)
            {
                running = true;
            }
        }
        else
        {
            stamina += Time.deltaTime / GlobalConstants.STAMINA_RECHARGE_TIME;
        }

        stamina = Mathf.Clamp01(stamina);

        if (running)
        {
            animator.SetFloat("speed", GlobalConstants.DEFAULT_ANIMATION_RUN_SPEED);
            moveSpeed = GlobalConstants.DEFAULT_RUN_SPEED;
        }
        else
        {
            animator.SetFloat("speed", GlobalConstants.DEFAULT_ANIMATION_WALK_SPEED);
            moveSpeed = GlobalConstants.DEFAULT_WALK_SPEED;
        }

        staminaBar.value = stamina;
    }

    void FixedUpdate()
    {              
        rb.MovePosition(rb.position + (movement * moveSpeed * Time.fixedDeltaTime));
        

        if (moving)
        {
            moving = false;
            animator.SetBool("isMoving", moving);            
        }             
    }

    public void PickUpItems(List<Item> items)
    {
        inventory.AddRange(items);
    }

    public void AddItemToInventory(Item item)
    {
        inventory.Add(item);
    }

    public List<Item> GetInventory()
    {
        return inventory;
    }

    public void ClearInventory()
    {
        inventory.Clear();
    }

    public bool IsRunning()
    {
        return running;
    }

    public bool IsMoving()
    {
        return moving;
    }
}
