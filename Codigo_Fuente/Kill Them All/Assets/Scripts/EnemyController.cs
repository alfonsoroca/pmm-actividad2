using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Variables
    private GameObject playerGO;
    public GameObject bulletPrefab;    
    private float lastShoot;    
    private Transform playerPosition;
    private float speed = 0.5f;
    private static int kills = 0;
    
    // Start is called before the first frame update
    void Start()
    {        
        playerGO = GameObject.Find("Player");        
        playerPosition = playerGO.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Si el player no existe destruimos al enemigo y salimos de la función
        if (playerGO == null)
        {
            Destroy(gameObject);
            return;
        }

        // El enemigo va a mirar siempre al player para lo que utilizamos las posiciones del eje x del player
        // y del enemigo
        Vector3 direction = playerGO.transform.position - transform.position;
        if(direction.x >= 0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        // Movimiento del enemigo hacia el player
        transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);

        // El enemigo va a disparar siempre que la distancia en valor absoluto entre player y enemigo
        // sea inferior a una cantidad.
        float distance = Mathf.Abs(playerGO.transform.position.x - transform.position.x);
        // Debemos controlar la distancia y el tiempo pasado desde el último disparo para
        // que no se desborden los disparos del enemigo
        if(distance < 1.0f && Time.time > lastShoot + 2f)
        {
            Shoot();
            lastShoot = Time.time;
        }
    }
    private void Shoot()
    {
        // Control de la dirección de disparo
        Vector3 direction = new Vector3(0f, 0f, 0f); ;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        // Se crea la bala sin rotación separada de la posición del enemigo
        GameObject bullet = Instantiate(bulletPrefab, transform.position + direction * 0.2f, Quaternion.identity);
        bullet.tag = "EnemyBullet";
        bullet.GetComponent<BulletController>().SetDirection(direction);
        
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    // Función que destruye el enemigo cuando es alcanzado por una bala
    public void Hit()
    {
        // Cuando alcanzan al enemigo se ejecutan estas funciones        
        //Destroy(gameObject);
        kills += 1;
        GameScoreController.SetKills(kills);        
    }

    public static void ResetKills()
    {
        kills = 0;
    }

}
