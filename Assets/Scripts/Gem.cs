using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [HideInInspector]
    public Vector2Int posIndex;
    //[HideInInspector] 
    public Board board;

    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;

    private bool mousePressed;
    private float swipAngle = 0;

    private Gem otherGem;

    public enum GemType {blue, green, red, yellow, purple, bomb, stone}
    public GemType type;

    public bool isMatched;

    private Vector2Int previousPos;

    public GameObject destroyEffect;

    public int blastSize = 2;

    public int ScoreValue = 10;

    void Start()
    {
         
    }

    void Update()
    {

        if (Vector2.Distance(transform.position, posIndex)> 0.01f)
        {
            transform.position = Vector2.Lerp(transform.position, posIndex, board.gemSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3 (posIndex.x, posIndex.y, 0f);
            board.allGems[posIndex.x, posIndex.y] = this;
        }


        transform.position = Vector2.Lerp(transform.position, posIndex, board.gemSpeed * Time.deltaTime);


        if(mousePressed && Input.GetMouseButtonUp(0))
        {
            mousePressed = false;

            if(board.currentState == Board.BoardState.move && board.roundMan.roundTime > 0)
            {
                finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                CalculateAngle();
            }
        }

    } 

    public void setUpGems(Vector2Int pos, Board theBoard)
    {
        posIndex = pos;  
        board = theBoard; 
    }

    private void OnMouseDown()
    {
        if (board.currentState == Board.BoardState.move && board.roundMan.roundTime > 0)
        {
            firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePressed = true;
        }
    }

    private void CalculateAngle ()
    {
        swipAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x- firstTouchPosition.x);
        swipAngle = swipAngle * 180 / Mathf.PI;
        Debug.Log(swipAngle);

        if (Vector3.Distance(firstTouchPosition, finalTouchPosition) > 0.5f)
        {
            MovePieces();
        }
    }

    private void MovePieces()
    {
        previousPos = posIndex; 

        // swip right
        if (swipAngle < 45 && swipAngle > -45 && posIndex.x < board.width - 1)
        {
            otherGem = board.allGems[posIndex.x + 1, posIndex.y];
            otherGem.posIndex.x--;
            posIndex.x++;
        }
        // swip Up
        else if (swipAngle > 45  && swipAngle <= 135 && posIndex.y < board.height - 1)
        {
            otherGem = board.allGems[posIndex.x , posIndex.y + 1];
            otherGem.posIndex.y--;
            posIndex.y++;
        }
        //swip  dwon 
        else if (swipAngle < -45 && swipAngle >= -135 && posIndex.y > 0 )
        {
            otherGem = board.allGems[posIndex.x, posIndex.y - 1];
            otherGem.posIndex.y++;
            posIndex.y--;
        }
        else if (swipAngle > 135 || swipAngle < -135 && posIndex.x > 0)
        {
            otherGem = board.allGems[posIndex.x - 1, posIndex.y];
            otherGem.posIndex.x++;
            posIndex.x--;
        }
        board.allGems[posIndex.x, posIndex.y] = this;
        board.allGems[otherGem.posIndex.x, otherGem.posIndex.y] = otherGem;

        StartCoroutine(CheckMoveCo());

    }

    public IEnumerator CheckMoveCo()
    {

        board.currentState = Board.BoardState.wait;

        yield return new WaitForSeconds(0.5f);

        board.matchfind.FindAllMatches();

        if (otherGem != null)
        {
            if(!isMatched && !otherGem.isMatched)
            {
                otherGem.posIndex = posIndex;
                posIndex = previousPos;

                board.allGems[posIndex.x, posIndex.y] = this;
                board.allGems[otherGem.posIndex.x, otherGem.posIndex.y] = otherGem;

                yield return new WaitForSeconds(0.5f);

                board.currentState = Board.BoardState.move;

            }
            else
            {
                board.DestroyMatches();
            }
        }
    }
}

