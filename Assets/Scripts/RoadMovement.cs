using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    public float roadSpeed;
    private float _roadLength;
    private float _roadBackLimit;
    private float _roadStartPosition;

    private void Start()
    {
        _roadLength = GetComponent<Collider>().bounds.size.z;
        _roadStartPosition = transform.position.z;
        _roadBackLimit = -20.0f;
    }

    private void Update()
    {
        MoveWorld();
    }

    private void MoveWorld()
    {
        var newRoadPos = transform.position;
        newRoadPos.z -= roadSpeed * Time.deltaTime;
        if (newRoadPos.z < _roadBackLimit)
        {
            newRoadPos.z = _roadStartPosition;
        }
        transform.position = newRoadPos;
    }
}