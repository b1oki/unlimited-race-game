using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 _mOffset;
    private float _mZCoordinate;
    private void OnMouseDown()
    {
        var position = gameObject.transform.position;
        _mZCoordinate = Camera.main.WorldToScreenPoint(position).z;
        _mOffset = position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        var mousePoint = Input.mousePosition;
        mousePoint.z = _mZCoordinate;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + _mOffset;
    }
}
