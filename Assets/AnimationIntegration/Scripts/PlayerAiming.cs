using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] private Transform _targetBone;
    [SerializeField] private Transform _pelvisBone;
    [SerializeField] private float _additionalAngleOffset;

    private Transform _transform;
    private Camera _camera;
    private float _pelvisBoneRotationY;
    public Vector3 mousePosition;

    private void Awake()
    {
        _transform = transform;
        _camera = Camera.main;
        _pelvisBoneRotationY = _pelvisBone.eulerAngles.y;
    }

    public void LateUpdate()
    {
        Aim();
    }

    private void Aim()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
            mousePosition = hit.point;

        float angle = Vector3.SignedAngle(mousePosition - _transform.position, _transform.forward, Vector3.up);
        float pelvisOffsetY = _pelvisBone.eulerAngles.y - _pelvisBoneRotationY;
        _targetBone.localEulerAngles = Vector3.right * (angle + pelvisOffsetY + _additionalAngleOffset);
    }
}
