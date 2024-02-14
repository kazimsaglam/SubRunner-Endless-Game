using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 5f;
    public Vector3 offset;
    private float y;

    private void Update()
    {
        Vector3 followPos = target.position + offset;

        RaycastHit hit;
        if(Physics.Raycast(target.position, Vector3.down, out hit, 2.5f))
        {
            y = Mathf.Lerp(y, hit.point.y, Time.deltaTime * followSpeed);
        }
        else
        {
            y = Mathf.Lerp(y, target.position.y, Time.deltaTime * followSpeed);
        }
        followPos.y = offset.y + y;
        transform.position = followPos;
    }
}
