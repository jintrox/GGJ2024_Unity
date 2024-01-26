using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshHueChanger : MonoBehaviour
{
    [SerializeField] float hueSpeed = 1f;
    [SerializeField] float oscillationFrequency = 1f;
    [SerializeField] float oscillationAmplitude = 1f;

    MeshRenderer meshRenderer;
    Vector3 initialPosition;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        initialPosition = transform.position;
    }

    void Update()
    {
        float hue = Mathf.Repeat(Time.time * hueSpeed, 1f);
        float yOffset = Mathf.Sin(Time.time * oscillationFrequency) * oscillationAmplitude;
        transform.position = initialPosition + Vector3.up * yOffset;
        meshRenderer.material.SetFloat("_Hue", hue);
    }
}