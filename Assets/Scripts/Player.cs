using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float minX, maxX, minY, maxY;
    //public float speed;// poder usarla en unity pero es mala practica ponerla publica
    [SerializeField] float speed; // [serializeField] esta variable (speed) se puede unificar en el inspector pero sigue siendo privada
    // Start is called before the first frame update
    void Start()
    {
        //camera.main: devuelve el primer componente prendido y esta taggeado como Main Camera
        Vector2 esqInfIzq =(Camera.main).ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 esqSupDer=(Camera.main).ViewportToWorldPoint(new Vector2(1, 1));
        minX = esqInfIzq.x;
        maxX = esqSupDer.x;
        minY = esqInfIzq.y;
        maxY = esqSupDer.y;

        Debug.Log("min X: " + minX);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(0.1f, 0));
        }*/
        //Velocidad - mov
        float moveH=Input.GetAxis("Horizontal"); //es entre -1 y 1
        float moveV = Input.GetAxis("Vertical");


        transform.Translate(new Vector2(moveH * speed * Time.deltaTime ,
                   moveV * speed*Time.deltaTime));
        //verificar posicion
            transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX, maxY),//si el transform.position.x es menor que minX entonces coge ese valor para el convertirse en el menor, lo mismo con el maximo
            Mathf.Clamp(transform.position.y, minY, maxY));


        /*transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX, maxX),//Mathf.Clamp(valor que yo quiero evaluar, un minimo, un maximo)
            Mathf.Clamp(transform.position.y, minY, maxY));*/

        //speed = 10;
        //GetComponent obetener comoponente como transform
    }



}