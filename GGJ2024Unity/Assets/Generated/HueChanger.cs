using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueChanger : MonoBehaviour
{
    [SerializeField] private float hueSpeed = 1f;
    [SerializeField] private float oscillationFrequency = 1f;
    [SerializeField] private float oscillationAmplitude = 1f;

    private MeshRenderer meshRenderer;
    private Vector3 initialPosition;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        float hue = Mathf.Repeat(Time.time * hueSpeed, 1f);
        meshRenderer.material.SetFloat("_Hue", hue);

        float amplitude = oscillationAmplitude * transform.localScale.y;
        float offset = Mathf.Sin(Time.time * oscillationFrequency) * amplitude;
        transform.position = initialPosition + Vector3.up * offset;
    }
}