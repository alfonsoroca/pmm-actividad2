using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    // Creamos las variables
    private Rigidbody2D bulletRB;
    private float speed = 2f;
    private Vector2 direction;
    private PlayerController playerController;
    private EnemyController enemyController;
    public AudioClip shootSound;    
      

    // Start is called before the first frame update
    void Start()
    {
        // Almacenamos el contenido en las variables
        bulletRB = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<PlayerController>();
        enemyController = FindObjectOfType<EnemyController>();
        // Sonido cuando se crea la bala (disparo)
        Camera.main.GetComponent<AudioSource>().PlayOneShot(shootSound);
    }

    private void FixedUpdate()
    {
        // Movimiento de la bala según la dirección del player
        bulletRB.velocity = direction * speed;
    }

    // Función que establece la dirección de la bala y que es llamada por el player y el enemy
    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }


    // Destruimos la bala
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
    
    // Destruimos la bala al contactar con el player o el enemigo teniendo en cuenta quien la ha disparado
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && this.tag == "EnemyBullet")
        {
            // Destruimos la bala
            DestroyBullet();
            // Llamamos a la función que controla cuando es alcanzado el player
            playerController.Hit();            
        }
        

        if (collision.gameObject.tag == "Enemy" && this.tag == "PlayerBullet" && enemyController != null)
        {
            // Destruimos la bala y el enemigo
            enemyController.DestroyEnemy();
            DestroyBullet();            
            // Llamamos a la función que controla cuando es alcanzado el enemy
            enemyController.Hit();            
        }

        DestroyBullet();
        
    }
}
