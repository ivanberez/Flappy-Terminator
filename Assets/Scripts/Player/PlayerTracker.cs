using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _xOffSet;

    private void OnValidate()
    {
        SetPosition();
    }

    private void Update()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        Vector3 targetPosition = transform.position;
        targetPosition.x = _playerTransform.position.x + _xOffSet;

        transform.position = targetPosition;
    }
}
