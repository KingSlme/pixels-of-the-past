using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 18f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform weapon;

    Vector2 moveInput;
    public Rigidbody2D myRigidBody2D;
    public Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;

    public bool canDoAnything = true;
    bool hasDied = false;
    bool canFire = true;

    // Audio
    [SerializeField] AudioClip playerDeathSFX;

    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        HazardDetector();

        if(canDoAnything)
        {
            Run();
            FlipSprite();
        }

        if(FindObjectOfType<PlayerHealth>().playerHealth <= 0)
        {
            StartCoroutine(PlayerDeath());
        }
    }

    void OnFire(InputValue value)
    {
        if(canDoAnything && canFire)
        {
            myAnimator.SetTrigger("isUsingStaff");
            //if(!isAlive) {return; }
            StartCoroutine(fireProjectile());
        }

    }

    IEnumerator fireProjectile()
    {
        canFire = false;
        Instantiate(bullet, weapon.position, transform.rotation);
        yield return new WaitForSecondsRealtime(1f);
        canFire = true;
    }

    void OnMove(InputValue value)
    {
        if(canDoAnything)
        {
            moveInput = value.Get<Vector2>();
        }
    }

    // Horizontal Movement
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidBody2D.velocity.y);
        myRigidBody2D.velocity = playerVelocity;
        // Running Animation if Moving
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody2D.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void OnJump(InputValue value)
    {
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;}

        if(value.isPressed && canDoAnything)
        {
            myRigidBody2D.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    // Changes Direction Player Faces
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody2D.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody2D.velocity.x), 1f);
        }
    }

    void HazardDetector()
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Hazards")))
        {
            FindObjectOfType<PlayerHealth>().playerHealth = 0;
        }
    }

    IEnumerator PlayerDeath()
    {   

        if(!hasDied)
        {
            // Makes sure method doesn't stack (animation stacking first frame)
            hasDied = true;

            canDoAnything = false;
            myAnimator.SetBool("isRunning", false);
            myRigidBody2D.velocity = new Vector2(0f, 0f);
            myAnimator.SetTrigger("isDead");
            AudioSource.PlayClipAtPoint(playerDeathSFX, Camera.main.transform.position);
            yield return new WaitForSecondsRealtime(4f);
            Destroy(gameObject);
            // Reload Scene
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
