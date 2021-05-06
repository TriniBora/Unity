using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player obj;

    public int lives = 3;

    public bool isGrounded = false;
    public bool isMoving = false;
    public bool isInmune = false;

    public float speed = 5f;
    public float jumpForce = 3f;
    public float movHor;

    public float inmuneTimeCnt = 0f;
    public float inmuneTime = 0.5f;

    public LayerMask groundLayer;
    public float radius = 0.3f;
    public float groundRayDist = 0.5f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;

    private void Awake()
    {
        obj = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // accedo a todas las propiedades del componente RigidBody2D del Player
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movHor = Input.GetAxisRaw("Horizontal");

        isMoving = (movHor != 0f); // Para saber cuando el player se está moviendo

        isGrounded = (Physics2D.CircleCast(transform.position, radius, Vector3.down, groundRayDist, groundLayer)); // Para saber cuando el player está tocando el piso

        if (Input.GetKeyDown(KeyCode.Space))
            jump();

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);

        flip(movHor);
    }

    // Todo lo que involucra físicas 
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y); // permite mover al player mediante el RB en x con la velocidad indicada en la variable movHor 
    }

    // Girar el player a izquierda o derecha de acuerdo a si la velocidad en x es positiva o negativa
    private void flip(float _xValue)
    {
        Vector3 theScale = transform.localScale;

        if (_xValue < 0)
            theScale.x = Mathf.Abs(theScale.x) * -1;
        else
            if (_xValue > 0)
            theScale.x = Mathf.Abs(theScale.x);

        transform.localScale = theScale;
    }

    private void goInmune()
    {
        isInmune = true;
        inmuneTimeCnt = inmuneTime;
    }

    // Si el player no está en el suelo sale, sino salta
    public void jump()
    {
        if (!isGrounded) return;

        rb.velocity = Vector2.up * jumpForce;
        //AudioManager.obj.playJump();
    }

    public void getDamage()
    {
        lives--;
        //AudioManager.obj.playHit();

        // Actualizamos las viodas en el panel UI
        //UIManager.obj.updateLives();

        goInmune();

        if (lives <= 0)
        {
            //FXManager.obj.showPop(transform.position);
            Game.obj.gameOver();
        }
    }

    public void addLive()
    {
        lives++; // agrega vidas sin pasar el máximo definido
        if (lives > Game.obj.maxLives)
            lives = Game.obj.maxLives;

    }
    void OnDestroy()
    {
        obj = null;
    }

}
