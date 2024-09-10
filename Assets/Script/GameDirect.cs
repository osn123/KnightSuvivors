using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameDirect : MonoBehaviour
{
    public GameObject grid;
    public Tilemap tileCol;

    public Vector2 TileStart;
    public Vector2 TileEnd;
    public Vector2 WorldStart;
    public Vector2 WorldEnd;

    void Start()
    {
        foreach (Transform item in grid.GetComponentInChildren<Transform>())
        {
            if (TileStart.x > item.position.x)
            {
                TileStart.x = item.position.x;
            }
            if (TileStart.y > item.position.y)
            {
                TileStart.y = item.position.y;
            }
            if (TileEnd.x < item.position.x)
            {
                TileEnd.x = item.position.x;
            }
            if (TileEnd.y < item.position.y)
            {
                TileEnd.y = item.position.y;
            }
        }

        float cameraSize = Camera.main.orthographicSize;
        float aspect = (float)Screen.width / (float)Screen.height;

        WorldStart = new Vector2(TileStart.x - cameraSize * aspect, TileStart.y - cameraSize);
        WorldEnd = new Vector2(TileEnd.x + cameraSize * aspect, TileEnd.y + cameraSize);

    }
    void Update()
    {

    }
}
