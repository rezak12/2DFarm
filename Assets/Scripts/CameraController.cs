using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _lerpSpeed = 1f;
    [SerializeField] private float _topLimit = 10f;
    [SerializeField] private float _bottomLimit = -10f;
    [SerializeField] private float _rightLimit = 10f;
    [SerializeField] private float _leftLimit = -10f;

    private void Awake()
    {
        if (!_player)
        {
            _player = FindObjectOfType<PlayerMovement>().transform;
        }
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = this.transform.position;

        newPosition = Vector3.Lerp(transform.position, _player.position, _lerpSpeed * Time.fixedDeltaTime);
        newPosition.y = Mathf.Min(newPosition.y, _topLimit);
        newPosition.y = Mathf.Max(newPosition.y, _bottomLimit);
        newPosition.x = Mathf.Min(newPosition.x, _rightLimit);
        newPosition.x = Mathf.Max(newPosition.x, _leftLimit);
        newPosition.z = -10f;
        transform.position = newPosition;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 topPoint =
        new Vector3(this.transform.position.x,
        _topLimit, this.transform.position.z);
        Vector3 bottomPoint =
        new Vector3(this.transform.position.x,
        _bottomLimit, this.transform.position.z);
        Vector3 leftPoint =
        new Vector3(_leftLimit,
        this.transform.position.y, this.transform.position.z);
        Vector3 rightPoint =
        new Vector3(_rightLimit,
        this.transform.position.y, this.transform.position.z);
        Gizmos.DrawLine(topPoint, bottomPoint);
        Gizmos.DrawLine(leftPoint, rightPoint);
    }
}
