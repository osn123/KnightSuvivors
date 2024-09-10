using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCtrl : MonoBehaviour
{
    #region 移動とアニメ
    Rigidbody2D rb2d;
    Animator animator;
    float moveSpeed = 10;
    #endregion

    public GameDirect sceneDirect;
    public Slider sliderHP;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        MovePlayer();
        MoveCamera();
        MovePlayer();
    }
    void MovePlayer()
    {
        Vector2 dir = Vector2.zero;
        string trigger = "";

        if (Input.GetKey(KeyCode.UpArrow))
        {
            dir += Vector2.up;
            trigger = "isUp";
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dir -= Vector2.up;
            trigger = "isDown";
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir += Vector2.right;
            trigger = "isRight";
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir -= Vector2.right;
            trigger = "isLeft";
        }

        if (Vector2.zero == dir) return;

        rb2d.position += dir.normalized * moveSpeed * Time.deltaTime;

        animator.SetTrigger(trigger);


        if (rb2d.position.x < sceneDirect.WorldStart.x)
        {
            Vector2 pos = rb2d.position;
            pos.x = sceneDirect.WorldStart.x;
            rb2d.position = pos;
        }
        if (rb2d.position.y < sceneDirect.WorldStart.y)
        {
            Vector2 pos = rb2d.position;
            pos.y = sceneDirect.WorldStart.y;
            rb2d.position = pos;
        }

        if (sceneDirect.WorldEnd.x < rb2d.position.x)
        {
            Vector2 pos = rb2d.position;
            pos.x = sceneDirect.WorldEnd.x;
            rb2d.position = pos;
        }
        if (sceneDirect.WorldEnd.y < rb2d.position.y)
        {
            Vector2 pos = rb2d.position;
            pos.y = sceneDirect.WorldEnd.y;
            rb2d.position = pos;
        }
    }

    void MoveCamera()
    {
        Vector3 pos = transform.position;
        pos.z = Camera.main.transform.position.z;

        if (pos.x < sceneDirect.TileStart.x)
        {
            pos.x = sceneDirect.TileStart.x;
        }
        if (pos.y < sceneDirect.TileStart.y)
        {
            pos.y = sceneDirect.TileStart.y;
        }

        if (sceneDirect.TileEnd.x < pos.x)
        {
            pos.x = sceneDirect.TileEnd.x;
        }
        if (sceneDirect.TileEnd.y < pos.y)
        {
            pos.y = sceneDirect.TileEnd.y;
        }

        Camera.main.transform.position = pos;
    }

    void MoveSliderHP()
    {
        Vector3 pos = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
        pos.y -= 50;
        sliderHP.transform.position = pos;
    }
}
