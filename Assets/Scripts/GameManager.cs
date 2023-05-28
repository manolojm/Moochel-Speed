using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void CargarMenu() {
        SceneManager.LoadScene("MenuScene");
    }

    public void CargaAyuda() {
        SceneManager.LoadScene("AyudaScene");
    }

    public void CargarSalir() {
        Application.Quit();
    }

    public void CargarEscena1() {
        SceneManager.LoadScene("Escena1");
    }

    public void CargarCreditos() {
        SceneManager.LoadScene("CreditosScene");
    }
}
