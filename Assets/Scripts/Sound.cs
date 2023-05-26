using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource sonidoMotor;
    public AudioSource sonidoPito;

    private Rigidbody coche;
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        coche = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = coche.velocity.magnitude;
        sonidoMotor.pitch = (speed/10) + 0.4f;
        sonidoMotor.volume = (speed/10) + 0.3f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("pi");
            sonidoPito.PlayOneShot(sonidoPito.clip,1);
        }      

    }
}
