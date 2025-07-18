using UnityEngine;

[ExecuteAlways]
public class DayNightCycle : MonoBehaviour
{
    [Header("Day/Night Settings")]
    [Tooltip("Time (in seconds) it takes for a full 360° rotation (one full day).")]
    public float dayDurationInSeconds = 60f;

    void Update()
    {
        if (dayDurationInSeconds <= 0f) return;

        // Calculate how many degrees to rotate this frame
        float degreesPerSecond = 360f / dayDurationInSeconds;
        float rotationAmount = degreesPerSecond * Time.deltaTime;

        // Apply rotation to the light
        transform.Rotate(Vector3.right, rotationAmount);
    }
}

