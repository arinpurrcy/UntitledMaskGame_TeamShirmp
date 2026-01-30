using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject _player;

    public float _smoothSpeed = 0.125f;
    public float _rotationSpeed = 5.0f;

    public Vector3 _offset;
    public Vector3 _desiredOffset;
    void Start()
    {
        _offset = transform.position - _player.transform.position;
        _desiredOffset = _offset;
    }

    void LateUpdate()
    {
        transform.position = _offset + _player.transform.position;
        if (Input.GetMouseButton(1))
        {
            float horizontalLook = Input.GetAxis("Mouse X") * _rotationSpeed;
            _desiredOffset = Quaternion.AngleAxis(horizontalLook, Vector3.up) * _desiredOffset;
        }
    }
}
