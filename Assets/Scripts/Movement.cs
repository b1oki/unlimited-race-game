using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Text levelBar;
    public Text haulBar;
    public GameObject road;

    private const float RoadSpeed = 5f;
    private const float RoadBlockLength = 10f;
    private const float WorldBackLimit = -RoadBlockLength;
    private float _roadLength;
    private Transform[] _roadPieces;
    private int _roadPiecesLength;
    private bool _isGameOver;
    private int _level = 0;
    private bool _isMoveSide;

    private void Start()
    {
        _isGameOver = false;
        var roadChildren = road.GetComponentsInChildren<Transform>();
        _roadPieces = roadChildren.Skip(1).ToArray();
        _roadPiecesLength = _roadPieces.Length;
        _roadLength = RoadBlockLength * _roadPiecesLength;
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