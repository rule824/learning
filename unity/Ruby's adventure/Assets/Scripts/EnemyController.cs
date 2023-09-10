using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed = 100f;
    public Rigidbody2D rbody;
    public float changeDirectionTime = 2f;
    private float changeDirectionTimer;
    [SerializeField] bool isVertical;
    private Vector2 moveDirection;
    private Animator anim;
    private bool isFixed;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveDirection = isVertical ? Vector2.up : Vector2.right;
        changeDirectionTimer = changeDirectionTime;
        isFixed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFixed) {
            return;
        }
        changeDirectionTimer -= Time.deltaTime;
        if (changeDirectionTimer < 0) {
            moveDirection *= -1;
            changeDirectionTimer = changeDirectionTime;
        }
        Vector2 position = rbody.position;
        position.x += moveDirection.x * speed * Time.deltaTime;
        position.y += moveDirection.y * speed * Time.deltaTime;
        rbody.MovePosition(position);
        anim.SetFloat("moveX", moveDirection.x);
        anim.SetFloat("moveY", moveDirection.y);
    }

    void OnCollisionEnter2D(Collision2D other) {
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        if (pc != null) {
            pc.changeHealth(-1);
        }
    }

    public void Fixed() {
        isFixed = true;
        rbody.simulated = false;
        anim.SetTrigger("Fix");
    }
}
