using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    // public float speed; // para el GameObject cinemático
    private Rigidbody rb; // para el GameObject físico
    public float forceValue; // para el GameObject físico
    public float jumpValue; // para el GameObject físico
    private AudioSource audio;
    public int life = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // para el GameObject físico
        audio = GetComponent<AudioSource>(); // para acceder al componente de audio
    }

    // Update is called once per frame
    void Update()
    {
        // GameObject cinemático
        // transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);

        // GameObject físico, añadimos una fuerza de tipo impulso, que se da cuando el objeto va a saltar
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f) { 
            // para saltar se debe haber pulsado el botón de jump y además la velocidad en y de la esfera debe ser muy cercana a 0, o sea estar en contacto con el plano
            rb.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);
            // equivale a rb.AddForce(new(Vector3(0,1,0); salta en y una unidad y se le aplica la fuerza impulso, con la que se modifica tanto la fuerza como la velocidad
            audio.Play(); // cada vez que la esfera salta, emite el sonido
        }

        // para app mobile

        // salta con un toque
        /*if (Input.touchCount == 1); // detectamos que el toque sea uno solo

        if (Input.touches[0].phase == TouchPhase.Began && Mathf.Abs(rb.velocity.y) < 0.01f) // aseguramos que sea la fase inicial, la de toque para que salte
        {
            // para saltar se debe haber pulsado el botón de jump y además la velocidad en y de la esfera debe ser muy cercana a 0, o sea estar en contacto con el plano
            rb.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);
            // equivale a rb.AddForce(new(Vector3(0,1,0); salta en y una unidad y se le aplica la fuerza impulso, con la que se modifica tanto la fuerza como la velocidad
            audio.Play(); // cada vez que la esfera salta, emite el sonido
        }*/

        // salta cuando se produce un movimiento brsuco en el eje de las z
        if (Input.acceleration.z > 0.75f && Mathf.Abs(rb.velocity.y) < 0.01f) // aseguramos que sea la fase inicial, la de toque para que salte
        {
            // para saltar se debe haber pulsado el botón de jump y además la velocidad en y de la esfera debe ser muy cercana a 0, o sea estar en contacto con el plano
            rb.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);
            // equivale a rb.AddForce(new(Vector3(0,1,0); salta en y una unidad y se le aplica la fuerza impulso, con la que se modifica tanto la fuerza como la velocidad
            audio.Play(); // cada vez que la esfera salta, emite el sonido
        }

    }

    void FixedUpdate()
    {
        // GameObject físico, añadimos una fuerza constante
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * forceValue);

        // para app mobile
        rb.AddForce(new Vector3(Input.acceleration.x, 0, Input.acceleration.z) * forceValue);
   
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            print("Colisión");
            life -= 10;
            if (life == 0) { 
                print("La esfera ha muerto");
            }
            //Destroy(collision.gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        print("Entras en la zona oscura");
    }

   
}
