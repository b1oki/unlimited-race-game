using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Text levelBar;
    public Text haulBar;
    public GameObject road;

    public float RoadSpeed;
    public float RoadBlockLength;
    
    private float WorldBackLimit;
    private float _roadLength;
    private List<Transform> _roadPieces;
    private int _roadPiecesLength;
    private bool _isGameOver;
    private int _level;
    private bool _isMoveSide;

    private void Start()
    {
        WorldBackLimit = -RoadBlockLength;
        var roadChildren = road.GetComponentsInChildren<Transform>();
        _roadPieces = new List<Transform>();
        foreach (var roadChild in roadChildren)
        {
            if (roadChild.CompareTag("Ground"))
            {
                _roadPieces.Add(roadChild);
            }
        }
        _roadPiecesLength = _roadPieces.Count;
        _roadLength = RoadBlockLength * _roadPiecesLength;
        _level = 0;
        _isGameOver = false;
    }

    private void Update()
    {
        if (_isGameOver) return;
        MoveWorld();
    }

    private void MoveWorld()
    {
        foreach (var roadBlock in _roadPieces)
        {
            var newRoadPos = roadBlock.position;
            newRoadPos.z -= RoadSpeed * Time.deltaTime;
            if (newRoadPos.z < WorldBackLimit)
            {
                newRoadPos.z += _roadLength;
            }

            roadBlock.position = newRoadPos;
        }
    }

    private void LateUpdate()
    {
        if (_isGameOver) return;
    }

    private void GameOver()
    {
        _isGameOver = true;
    }

    private void UpdateLevelBar()
    {
        if (levelBar is null) return;
        levelBar.text = _level.ToString();
    }

    private void UpdateHaulBar()
    {
        if (haulBar is null) return;
        haulBar.text = transform.position.z.ToString("0");
    }
}