using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Text levelBar;
    public Text haulBar;
    public GameObject road;
    private Transform[] _roadPieces;

    private const float RoadSpeed = 5f;
    private const float RoadBlockLength = 10f;
    private float _roadLength;
    private bool _isGameOver;
    private int _level = 0;
    private bool _isMoveSide;
    private int _roadPiecesLength;

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
            if (newRoadPos.z < transform.position.z - RoadBlockLength)
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