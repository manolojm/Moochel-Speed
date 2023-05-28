using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camaras : MonoBehaviour
{
    public Camera[] camaras;
    public GameObject retrovisorPrincipal;
    public GameObject retrovisor1;
    public GameObject retrovisor2;

    void Start()
    {
        ActivaCamara(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) {
            ActivaCamara(1);
        }
            
        if (Input.GetKeyDown("2")) {
            ActivaCamara(2);
        }
            
        if (Input.GetKeyDown("3")) {
            ActivaCamara(3);
        }

        if (Input.GetKeyDown("4")) {
            ActivaCamara(4);
        }
    }


    // Solo se activan los retrovisores en las cámaras 1 y 2
    void ActivaCamara(int numeroCamara)
    {
        for (int i = 0; i < camaras.Length; i++)
        {
            camaras[i].enabled = false;
        }

        camaras[ numeroCamara - 1 ].enabled = true;

        if (numeroCamara == 1 || numeroCamara == 2) {
            retrovisorPrincipal.SetActive(true);
            retrovisor1.SetActive(true);
            retrovisor2.SetActive(true);
        } else {
            retrovisorPrincipal.SetActive(false);
            retrovisor1.SetActive(false);
            retrovisor2.SetActive(false);
        }
            
    }
}
