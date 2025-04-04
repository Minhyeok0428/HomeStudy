using UnityEngine;

public class PangPlayer : MonoBehaviour
{
    public enum STATE
    {
        IDLE,
        MOVE,
        HITTED,
    }

    [SerializeField]
    private Sprite[] IdleSprites;

    [SerializeField]
    private Sprite[] WalkSprites;

    private STATE _currentState;

    private float _speed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Debug.Log("PangPlayerCreated");
        _currentState = STATE.IDLE;
    }
    private void MoveInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
    }
    private void IDLE_Action()
    {
        Debug.Log("Idle Action");
        MoveInput();




    }    
    private void MOVE_Action()
    {
        Debug.Log("Move Action");
        MoveInput();
    }    
    private void HITTED_Action()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch(_currentState)
        {
            case STATE.IDLE:
                IDLE_Action();
                break;
            case STATE.MOVE:
                MOVE_Action();
                break;
            case STATE.HITTED:
                HITTED_Action();
                break;
        }

        if(Input.GetMouseButtonDown(0))
        {
            _currentState = STATE.MOVE;
        }
        if(Input.GetMouseButtonDown(1))
        {
            _currentState = STATE.IDLE;
        }    
    }
}
