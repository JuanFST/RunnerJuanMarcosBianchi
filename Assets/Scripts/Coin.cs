using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<Obstacle>()!= null)
        {
            Destroy(gameObject);
            return;
        }

        // ver contra que choco al jugador
        if (other.gameObject.name != "Player")
        {
            return;
        }


        //sumar al score del jugador
        GameManager.inst.IncrementScore();

        //destruir objeto
        Destroy(gameObject);
    }

    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
