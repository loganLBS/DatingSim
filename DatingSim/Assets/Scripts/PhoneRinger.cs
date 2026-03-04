using UnityEngine;
using System.Collections;

public class PhoneRinger : MonoBehaviour
{
    public float amplitude = 5f;
    public float frequency = 10f;
    private Vector3 startRotation;

    void Start()
    {
        startRotation = transform.localEulerAngles;
    }

    public void StartRinging()
    {
        StartCoroutine(Ring());
    }

    public void StopRinging()
    {
        StopAllCoroutines();
        transform.localEulerAngles = startRotation;
    }

    IEnumerator Ring()
    {
        while (true)
        {
            float angle = Mathf.Sin(Time.time * frequency) * amplitude;
            transform.localEulerAngles = startRotation + new Vector3(0, 0, angle);
            yield return null;
        }
    }
}