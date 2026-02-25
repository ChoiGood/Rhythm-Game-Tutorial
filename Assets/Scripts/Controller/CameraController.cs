using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform thePlayer;  // 카메라가 따라갈 타겟
    [SerializeField] private float followSpeed = 15;

    private Vector3 playerDistance = new Vector3();

    private float hitDistance = 0;
    [SerializeField] private float zoomDistance = -1.25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerDistance = transform.position - thePlayer.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 t_destPos = thePlayer.position + playerDistance + (transform.forward * hitDistance);
        transform.position = Vector3.Lerp(transform.position, t_destPos, followSpeed * Time.deltaTime);
    }

    public IEnumerator ZoomCam()
    {
        hitDistance = zoomDistance;

        yield return new WaitForSeconds(0.15f);

        hitDistance = 0;
    }
}
