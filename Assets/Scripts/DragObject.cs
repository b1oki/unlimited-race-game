using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 _mOffset;
    private float _mZCoordinate;

    private void OnMouseDown()
    {
        _mZCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        _mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        var mousePoint = Input.mousePosition;
        mousePoint.z = _mZCoordinate;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag() => transform.position = GetMouseWorldPos() + _mOffset;
}