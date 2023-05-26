using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
using System;

// PROMETEO: Car Controller
// https://assetstore.unity.com/packages/tools/physics/prometeo-car-controller-209444

// Cartoon Race Track - Oval
// https://assetstore.unity.com/packages/3d/environments/roadways/cartoon-race-track-oval-175061

//  JoyStick pack
// https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631

// Añadir fixed joystick
// Assets/CartoonTracksPack1/Track1/Textures/road_normal.png (174.67 MB)
// Assets / CartoonTracksPack1 / Track1 / Textures / road.psd(549.86 MB)

public class CarController : MonoBehaviour
{

    public float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public GameObject frontDriverT, frontPassengerT;
    public GameObject rearDriverT, rearPassengerT;
    public float maxSteerAngle = 30;
    public float motorForce = 50;


    public int frenar = 500;
    public int frenarPedal = 50000;
    public bool pedalFreno;


    public int velocidadMaxima = 120;

    private Rigidbody coche;

    public ParticleSystem efectoRuedaR;
    public ParticleSystem efectoRuedaL;


    //public Joystick joyStick;


    public float speed;

    public bool cuatroPorCuatro;
    public Image cuatroPorCuatroImage;


    private void Start()
    {
        coche = GetComponent<Rigidbody>();

        coche.centerOfMass = new Vector3(0, 0, 0);

        //cuatroPorCuatroImage.enabled = false;
        cuatroPorCuatro = false;

    }

    private void Update()
    {
        Salir();
        GetInput();
        //EfectoRueda();
    }

    private void Salir()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        Steer();
        UpdateWheelPoses();
        if (!Frenar())
            Accelerate();
    }
    public void GetInput()
    {
        //m_horizontalInput = Input.GetAxis("Horizontal") + joyStick.Horizontal;
        m_horizontalInput = Input.GetAxis("Horizontal");
        //m_verticalInput = Input.GetAxis("Vertical") + joyStick.Vertical;
        m_verticalInput = Input.GetAxis("Vertical");
        pedalFreno = Input.GetKey(KeyCode.S);
        if (Input.GetKeyDown(KeyCode.F))
        {
            cuatroPorCuatro = !cuatroPorCuatro;
            cuatroPorCuatroImage.enabled = !cuatroPorCuatroImage.enabled;
        }

    }
    

    // Gira las ruedas delanteras
    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        frontDriverW.steerAngle = m_steeringAngle;
        frontPassengerW.steerAngle = m_steeringAngle;
    }

    private void Accelerate()
    {
        if (coche.velocity.magnitude * 4 > velocidadMaxima)  // no pasar vel maxima
        {

            frontDriverW.motorTorque = 0;
            frontPassengerW.motorTorque = 0;
            if (cuatroPorCuatro)
            {
                rearDriverW.motorTorque = 0;
                rearPassengerW.motorTorque = 0;

            }
        }
        else
        {
            frontDriverW.motorTorque = m_verticalInput * motorForce;
            frontPassengerW.motorTorque = m_verticalInput * motorForce;
            if (cuatroPorCuatro)
            {
                rearDriverW.motorTorque = m_verticalInput * motorForce;
                rearPassengerW.motorTorque = m_verticalInput * motorForce;

            }
        }
        
    }


    // Mueve las ruedas, se vea movimiento, no realiza el movimiento del coche
    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT.transform);
        UpdateWheelPose(frontPassengerW, frontPassengerT.transform);
        UpdateWheelPose(rearDriverW, rearDriverT.transform);
        UpdateWheelPose(rearPassengerW, rearPassengerT.transform);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }


    private bool Frenar()
    {

        if (pedalFreno)  //pulsamos `S` pedal freno
        {
            frontDriverW.brakeTorque = frenarPedal;
            frontPassengerW.brakeTorque = frenarPedal;
            rearDriverW.brakeTorque = frenarPedal;
            rearPassengerW.brakeTorque = frenarPedal;
            return true;
        }
        if (m_verticalInput == 0 && !pedalFreno)  //dejamos de acelerar
        {
            frontDriverW.brakeTorque = frenar;
            frontPassengerW.brakeTorque = frenar;
            rearDriverW.brakeTorque = frenar;
            rearPassengerW.brakeTorque = frenar;
        }
        else
        {
            frontDriverW.brakeTorque = 0;
            frontPassengerW.brakeTorque = 0;
            rearDriverW.brakeTorque = 0;
            rearPassengerW.brakeTorque = 0;
        }
        return false;
        
    }


    private void EfectoRueda()
    {
        speed = coche.velocity.magnitude;
        if (speed * 4 > 70 && (m_horizontalInput>0.5f || m_horizontalInput<-0.5f))
        {
            efectoRuedaL.Play();
            efectoRuedaR.Play();
        }
        else 
        {
            efectoRuedaL.Stop();
            efectoRuedaR.Stop();
        }
    }


}
