using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class button : MonoBehaviour
{
    public GameObject buttonVR; // The physical button in VR
    public GameObject uiCanvas; // The UI canvas to activate
    public UnityEvent OnPress;
    public UnityEvent OnRelease;
    private GameObject Presser;
    private AudioSource Sound;
    private bool isPressed;

    private void Start()
    {
        Sound = GetComponent<AudioSource>();
        isPressed = false;

        // Ensure the canvas starts inactive
        if (uiCanvas != null)
        {
            uiCanvas.SetActive(false);
        }
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

            // Activate the UI canvas
            if (uiCanvas != null)
            {
                uiCanvas.SetActive(true);
                Debug.Log("UI Canvas activated");
            }

            Debug.Log("Button pressed once");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Only reset the button visual but do not reset isPressed
        if (other.gameObject == Presser)
        {
            buttonVR.transform.localPosition = new Vector3(0, 0.8f, 0);
            OnRelease.Invoke();
        }
    }
}
