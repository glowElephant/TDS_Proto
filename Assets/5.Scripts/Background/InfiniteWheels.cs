using UnityEngine;

public class InfiniteWheels : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;
    [SerializeField] private Transform[] wheels;
    [SerializeField] private float wheelRotationSpeed = 360f;

    private void FixedUpdate()
    {
        float delta = scrollSpeed * Time.deltaTime;
        
        float wheelDelta = wheelRotationSpeed * Time.deltaTime;
        foreach (var wheel in wheels)
        {
            wheel.Rotate(0f, 0f, -wheelDelta, Space.Self);
        }
    }
}
