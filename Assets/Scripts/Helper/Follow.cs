using UnityEngine;

namespace Helper{
    public class Follow : MonoBehaviour
    {
        [SerializeField] private Transform target; // The target object to follow
        [SerializeField] private Vector3 offset;   // The offset from the target's position
        [SerializeField] private float followSpeed = 5.0f; // The speed at which this object follows the target
        [SerializeField] private bool followXAxis = true; // Whether to follow the X axis
        [SerializeField] private bool followYAxis = true; // Whether to follow the Y axis

        void Update()
        {
            if (target == null)
            {
                Debug.LogWarning("Target not assigned to FollowObject.");
                return;
            }

            // Calculate the desired position based on the target's position and offset
            Vector3 desiredPosition = target.position + new Vector3(offset.x , offset.y,offset.z);
            transform.position = Vector3.Lerp(transform.position, new Vector3(followXAxis? desiredPosition.x:0,followYAxis?desiredPosition.y:0,desiredPosition.z), followSpeed * Time.deltaTime);
        }
    }
}