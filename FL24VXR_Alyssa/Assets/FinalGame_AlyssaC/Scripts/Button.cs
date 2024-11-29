using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class button : MonoBehaviour
{
    public GameObject buttonVR;
    public UnityEvent OnPress;
    public UnityEvent OnRelease;
    GameObject Presser;
    AudioSource Sound;
    bool isPressed;

    private void Start()
    {
        Sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            buttonVR.transform.localPosition = new Vector3(0, 0.003f, 0);
            Presser = other.gameObject;
            OnPress.Invoke();
            Sound.Play();
            isPressed = true;

            Debug.Log("hi");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Presser)
        {
            buttonVR.transform.localPosition = new Vector3(0, 0.8f, 0);
            OnRelease.Invoke();
            isPressed = false;
        }
    }

    //public void SpawnSphere()
    //{
    //    Debug.Log("Sphere Epic TIme");
    //    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //    sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    //    sphere.transform.localPosition = new Vector3(0, 1, -10);
    //    sphere.AddComponent<Rigidbody>();
    //}
}
