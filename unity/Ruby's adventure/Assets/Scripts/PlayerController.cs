using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    private int maxHealth = 5;
    private int minHealth = 0;
    private int currentHealth;
    private Vector2 lookDirection = new Vector2(1, 0);
    private float invicinbleTime = 2f;
    private float invincibleTimer;
    private bool isInvincible = false;
    public int myMaxHealth() { return maxHealth; }
    public int myCurrentHealth() { return currentHealth; }
    // Start is called before the first frame update
    Rigidbody2D rbody;
    Animator anim;
    public GameObject bulletPrefab;
    void Start()
    {
        currentHealth = 2;
        invincibleTimer = 0;
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        UImanager.instance.UpdateHealthBar(currentHealth, maxHealth);
    }

    public void changeHealth(int amount) {
        if (amount < 0) {
            if (isInvincible) return;
        }
        isInvincible = true;
        invincibleTimer = invicinbleTime;
        //约束生命值
        currentHealth = Mathf.Clamp(currentHealth+amount, minHealth, maxHealth);
        UImanager.instance.UpdateHealthBar(currentHealth, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A:-1 D:0
        float moveY = Input.GetAxisRaw("Vertical"); // S:-1 W:0
        Vector2 moveVector = new Vector2(moveX, moveY);
        if (moveVector.x != 0 || moveVector.y != 0) {
            lookDirection = moveVector;
        }

        anim.SetFloat("Look X", lookDirection.x);
        anim.SetFloat("Look Y", lookDirection.y);
        Vector2 position = transform.position;
        if (Input.GetKeyDown(KeyCode.J)) {
            GameObject bullet = Instantiate(bulletPrefab, rbody.position, Quaternion.identity);
            BulletController bc = bullet.GetComponent<BulletController>();
            if (bc != null) {
                Vector2 bcPosition;
                bcPosition.x = position.x;
                bcPosition.y = position.y+1;
                bc.position = bcPosition;
                bc.Move(lookDirection, 300);
            }
        }
        position.x += moveX * speed * Time.deltaTime;
        position.y += moveY * speed * Time.deltaTime;

        transform.position = position;
        if (isInvincible) {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0) {
                isInvincible = false;
            }
        }
    }
}
