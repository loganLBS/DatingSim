using UnityEngine;

public class CursorIdling : MonoBehaviour
{
    [SerializeField] private float rotationAmount = 5f; 
    [SerializeField] private float rotationSpeed = 1f; 

    [SerializeField] private RectTransform masked;

    private RectTransform thisRect;
    private float initialRotationZ;

    void Start()
    {
        thisRect = GetComponent<RectTransform>();
        initialRotationZ = thisRect.rotation.eulerAngles.z;
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * rotationSpeed) * rotationAmount;

        Quaternion newRotation = Quaternion.Euler(thisRect.rotation.eulerAngles.x, thisRect.rotation.eulerAngles.y, initialRotationZ + angle);

       
        thisRect.rotation = newRotation;

        masked.anchoredPosition = thisRect.anchoredPosition;
        masked.localScale = thisRect.localScale;
        masked.rotation = newRotation;
    }
}
