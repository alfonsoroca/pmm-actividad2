using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Creamos las variables
    private Rigidbody2D playerRB;
    private float movementX;
    private float speed = 1f;
    private float jumpForce = 4f;
    private bool inGround = true;
    private Animator playerAnimator;
    public GameObject bulletPrefab;
    private Vector3 direction;    
    private int health = 5;
    public GameObject cameraPlayer;
    private AudioSource playerAS;
    public AudioClip jumpSound;    
    public Text healthText;   
    public AudioClip gemCollectSound;
    public GameObject barrera;
    public GameObject bar;
    public GameObject arrow;
    public GameObject barPS;


    // Start is called before the first frame update
    void Start()
    {
        // Almacenamos el contenido en las variables
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerAS = GetComponent<AudioSource>();
        healthText.text = "Health: " + health.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        // Obtenemos la pulsación del teclado del jugador para desplazarse hotizontalmente
        movementX = Input.GetAxisRaw("Horizontal");

        // Indicamos el movimiento del eje horizontal
        transform.position += new Vector3(movementX, 0, 0) * speed * Time.deltaTime;

        // Giramos el player para que mire en la dirección en la que se mueve
        if(movementX < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            

        } else if (movementX > 0.0f) {

            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            
        }

        // Asociamos la animación running cuando presionamos una tecla para moverse
        playerAnimator.SetBool("running", movementX != 0.0f);                

        // Salto del player si se presiona la tecla flecha arriba y está en el suelo llamamos a la función Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && inGround)
        {
            playerAS.PlayOneShot(jumpSound);
            Jump();
        }

        // Disparo del player al presionar la tecla espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();            
        }

        // Cuando las gemas recogidas son igual o más de 100 se activa el bar y el sistema de partículas
        if (GameScoreController.totalGems >= 100)
        {
            // Desactivamos la barerra
            barrera.SetActive(false);

            // Activamos el bar y la flecha
            bar.SetActive(true);
            arrow.SetActive(true);
            barPS.SetActive(true);
        }   
        
    }

    // Salto del player
    private void Jump()
    {
        playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // Controlamos contacto del player con el suelo con dos listener
    // Controlamos el fin del juego (llegada al bar)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            inGround = true;
        }

        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Victory");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            inGround = false;
        }
    }

    // Disparo del player
    private void Shoot()
    {
        
        // Establecemos la dirección del componente script de Bullet y le pasamos la dirección
        // hacia la que mira el player
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        // Se crea la bala separada de nuestra posición sin rotación
        GameObject bullet = Instantiate(bulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        // Obtenemos el script de la bala y le asignamos la dirección
        bullet.tag = "PlayerBullet";
        bullet.GetComponent<BulletController>().SetDirection(direction);
    }

    // Función que controla la salud al ser alcanzado
    public void Hit()
    {
        // Cuando alcanzan al player le restan salud
        health -= 1;
        healthText.text = "Health: " + health.ToString();

        // Si la salud llega a 0, kaput
        if (health == 0)
        {
            // Antes de morir quitmaos la cámara de la jerarquía del player
            cameraPlayer.transform.parent = null;
            // Carga escena Game Over
            SceneManager.LoadScene("GameOver");

            // Destrucción del player
            Destroy(gameObject);
        }

    }
 
    // Función para ejecutar la recolección de gemas    
    public void GemCollect(int gems)
    {
        // Al audioSource le pasamos el clip de audio
        playerAS.PlayOneShot(gemCollectSound);
        
    }

    // Función que mata al player cuando se sale de la tierra
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DeathZone")
        {
            // Antes de morir quitmaos la cámara de la jerarquía del player
            cameraPlayer.transform.parent = null;
            // Carga escena Game Over
            SceneManager.LoadScene("GameOver");

            // Destrucción del player
            Destroy(gameObject);
        }
    }

}
