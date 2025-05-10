using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class KyleRobot : MonoBehaviour
{
    [SerializeField]
    Animator _animator;

    private float _speed = 3;

    [SerializeField]
    AudioSource _audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void OnFootstep()
    {
        Debug.Log("OnFootstep");
    }

    bool _isPlayingAttack = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _animator.Play("IDLE");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            _animator.Play("WALK");
        }
        if (_isPlayingAttack)
            return;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _animator.Play("ATTACK");
        }

        bool InputMove = false;

        if(Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * Time.deltaTime * _speed;
            // transform.rotation = Quaternion.Euler(new Vector3 )
            InputMove = true;
            _isPlayingAttack = true;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * _speed;

            InputMove = true;
            _isPlayingAttack = true;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * Time.deltaTime * _speed;

            InputMove = true;
            _isPlayingAttack = true;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * _speed;

            InputMove = true;
            _isPlayingAttack = true;
        }
        if(InputMove == false)
        {
            _animator.Play("IDLE");
        }


        
    }
}
