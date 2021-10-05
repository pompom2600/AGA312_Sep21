using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum MoveDirection { Up, Down, Left, Right }

public class TweenFun : JMC
{
    public Camera cam;
    public GameObject player;
    public Ease movementEase;
    bool canMove = true;
    public float tweenTime = 1f;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            TweenPosition(MoveDirection.Up);

        if (Input.GetKeyDown(KeyCode.DownArrow))
            TweenPosition(MoveDirection.Down);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            TweenPosition(MoveDirection.Left);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            TweenPosition(MoveDirection.Right);
    }


    void TweenPosition(MoveDirection dir)
    {
        if (!canMove)
            return;

        canMove = false;

        Vector3 current = player.transform.position;
        switch (dir)
        {
            case MoveDirection.Up:
                player.transform.DOLocalMoveZ(current.z + 5, 1f).SetEase(movementEase).OnComplete(() => canMove = true);
                break;
            case MoveDirection.Down:
                player.transform.DOLocalMoveZ(current.z - 5, 1f).SetEase(movementEase).OnComplete(() => canMove = true);
                break;
            case MoveDirection.Left:
                player.transform.DOLocalMoveX(current.x - 5, 1f).SetEase(movementEase).OnComplete(() => canMove = true);
                break;
            case MoveDirection.Right:
                player.transform.DOLocalMoveX(current.x + 5, 1f).SetEase(movementEase).OnComplete(() => canMove = true);
                break;
        }
        player.transform.DOPunchScale(Vector3.one * .2f, tweenTime, 3, .5f);
        player.transform.DORotate(new Vector3(Random.Range(0, 360f), Random.Range(0, 360f), Random.Range(0, 360f)), tweenTime).SetEase(Ease.OutCirc);
        player.GetComponent<Renderer>().material.DOColor(RandomColor(), tweenTime);

        cam.DOShakePosition(tweenTime, 1, 1, 90);
    }



}
