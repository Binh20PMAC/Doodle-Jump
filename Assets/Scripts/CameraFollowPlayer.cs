using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float smoothSpeed = 4f;

    [SerializeField]
    private Vector3 offset;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = new Vector3(0 + offset.x, player.position.y + offset.y, -1);

        if (player.position.y  > transform.position.y)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothPositon = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = new Vector3(0, smoothPositon.y, -1);
        }
    }

 
}
