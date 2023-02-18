using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float lerpSpeed = 1f;
    [SerializeField] private float topLimit = 10f;
    [SerializeField] private float bottomLimit = -10f;
    [SerializeField] private float rightLimit = 10f;
    [SerializeField] private float leftLimit = -10f;

    private void Awake()
    {
        if (!player)
        {
            player = FindObjectOfType<PlayerMovement>().transform;
        }
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = this.transform.position;

        newPosition = Vector3.Lerp(transform.position, player.position, lerpSpeed * Time.fixedDeltaTime);
        newPosition.y = Mathf.Min(newPosition.y, topLimit);
        newPosition.y = Mathf.Max(newPosition.y, bottomLimit);
        newPosition.x = Mathf.Min(newPosition.x, rightLimit);
        newPosition.x = Mathf.Max(newPosition.x, leftLimit);
        newPosition.z = -10f;
        transform.position = newPosition;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 topPoint =
        new Vector3(this.transform.position.x,
        topLimit, this.transform.position.z);
        Vector3 bottomPoint =
        new Vector3(this.transform.position.x,
        bottomLimit, this.transform.position.z);
        Vector3 leftPoint =
        new Vector3(leftLimit,
        this.transform.position.y, this.transform.position.z);
        Vector3 rightPoint =
        new Vector3(rightLimit,
        this.transform.position.y, this.transform.position.z);
        Gizmos.DrawLine(topPoint, bottomPoint);
        Gizmos.DrawLine(leftPoint, rightPoint);
    }
}
