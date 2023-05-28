using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Velocimetro : MonoBehaviour
{
    public Image aguja;
    public Rigidbody coche;
    // Start is called before the first frame update

    public int ajusteAguja = 157;
    private float speed;
    private string marcha;

    public TextMeshProUGUI speedText;
    public TextMeshProUGUI marchaText;


    // Update is called once per frame
    void Update()
    {
        speed = coche.velocity.magnitude;
        speedText.text = ((int) speed * 4).ToString();
        aguja.transform.eulerAngles = new Vector3(0, 0, speed * -3 + ajusteAguja);

        CalcularMarcha(speed*4);
    }

    private void CalcularMarcha(float speed) {
        //speed = coche.velocity.magnitude;

        if (speed <= 0.5) {
            marcha = "P";
        } else {
            if (speed > 0 && speed <= 20) {
                marcha = "1";
            } else {
                if (speed > 20 &&  speed <= 40) {
                    marcha = "2";
                } else {
                    if (speed > 40 &&  speed <= 60) {
                        marcha = "3";
                    } else {
                        if (speed > 60 &&  speed <= 80) {
                            marcha = "4";
                        } else {
                            marcha = "5";
                        }
                    }
                }
            }
        }
        marchaText.text = marcha;
    }
}
