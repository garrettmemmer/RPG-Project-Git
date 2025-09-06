using UnityEngine;

public class SlowMotionController : MonoBehaviour
{
    [Header("Time Settings")]
    [Range(0f, 1f)] public float slowMotionFactor = 0.3f; // How slow time gets
    public float normalTimeScale = 1f; // Normal time
    public float transitionSpeed = 5f; // How smoothly time changes

    private float targetTimeScale;

    void Update()
    {
        // Check if space bar is being held
        if (Input.GetKey(KeyCode.Space))
        {
            targetTimeScale = slowMotionFactor;
        }
        else
        {
            targetTimeScale = normalTimeScale;
        }

        // Smoothly interpolate timescale
        Time.timeScale = Mathf.Lerp(Time.timeScale, targetTimeScale, transitionSpeed * Time.unscaledDeltaTime);
        Time.fixedDeltaTime = 0.02f * Time.timeScale; // keep physics consistent
    }
}
