using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] bool startsFacingRight;
    [SerializeField] float moveSpeed;

    // For Agro Movement
    public bool bossCanMove = false;
    public Animator bossAnimator;

    BoxCollider2D bossBoxCollider2D;

    void Awake()
    {
        bossAnimator = GetComponent<Animator>();

        bossBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {   
        if(bossCanMove)
        {
            Vector3 scale = transform.localScale;

            if(player.transform.position.x > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * -1 * (startsFacingRight ? -1 : 1);
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                scale.x = Mathf.Abs(scale.x) * (startsFacingRight ? -1 : 1);
                transform.Translate(moveSpeed * Time.deltaTime * -1, 0, 0);
            }
            transform.localScale = scale;
        }
    }

    // Reset Boss Position
    void OnTriggerEnter2D(Collider2D other)
    {
        // Other is the object being collided into!
        
        // Reset Boss Position
        if(other.tag == "Platform")
        {
            transform.position = new Vector3(-27.01f, -13.15f, 0f);
        }
    }
}
