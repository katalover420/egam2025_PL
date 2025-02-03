using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraShake : MonoBehaviour
{
    public bool start = false;
    public float timeShaking = 1f;
    public AnimationCurve curve;
    public IEnumerator CameraShaking()
    {
        Vector3 startPosition = transform.position;
        float elaspedTime = 0f;
        while (elaspedTime < timeShaking)
        {
            elaspedTime += Time.deltaTime;
            float strength = curve.Evaluate(elaspedTime / timeShaking);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;


        }
        transform.position = startPosition;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
