using UnityEngine;
using UnityEngine.InputSystem;

public class move : MonoBehaviour
{
    MoveType moveType;
    private Rigidbody2D rb2d;
    [SerializeField]
    private int MoveSpped = 20;
    public void Left(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            moveType = MoveType.Left;
            DEBUG_moveType();
        }
        if(context.canceled)
        {
            moveType = MoveType.Stop;
            DEBUG_moveType();
        }
    }

    public void Right(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            moveType = MoveType.Right;
            DEBUG_moveType();
        }
        if(context.canceled)
        {
            moveType = MoveType.Stop;
            DEBUG_moveType();
        }
    }
    void DEBUG_moveType()
    {
#if DEBUG
        Debug.Log(moveType);
#endif
    }
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb2d.velocity = new Vector2((int)moveType * MoveSpped,rb2d.velocity.y);
    }
}

enum MoveType
{
    Left = -1,
    Right = 1,
    Stop = 0
}