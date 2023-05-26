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

    public int ajusteAguja=157;
    private float speed;

    public TextMeshProUGUI speedText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed=coche.velocity.magnitude;
        speedText.text = ((int) speed * 4).ToString();
        aguja.transform.eulerAngles = new Vector3(0,0,speed*-3 + ajusteAguja);
        
    }
}
