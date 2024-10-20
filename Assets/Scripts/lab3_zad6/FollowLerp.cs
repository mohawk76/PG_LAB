using UnityEngine;

public class FollowLerp : MonoBehaviour
{
    // Smooth towards the height of the target

    public Transform target;
    public float yVelocity = 0.1f;

    void Update()
    {
        float newPosition = Mathf.Lerp(transform.position.y, target.position.y, yVelocity);
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
    }
}