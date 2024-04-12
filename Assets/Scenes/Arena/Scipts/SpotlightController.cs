using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    public Transform player;
    public LayerMask obstacleLayerMask;
    public float maxIntensity = 10f;
    public float minIntensity = 1f;
    public float intensityDistanceFactor = 0.1f;

    private Light spotlight;

    void Start()
    {
        spotlight = GetComponent<Light>();
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity, obstacleLayerMask))
            {
                direction = (hit.point - transform.position).normalized;
            }

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            float intensity = Mathf.Lerp(maxIntensity, minIntensity, distanceToPlayer * intensityDistanceFactor);
            spotlight.intensity = intensity;
        }
    }
}
