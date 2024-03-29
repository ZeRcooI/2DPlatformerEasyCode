using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{  
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpforce = 8f;

    private Rigidbody2D rigidbody2d;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _sprite;

    [SerializeField] private GameObject _restartButton;

    private bool _canJump = true;//�������������

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // ������������ ������� ��� �������� ������� ������� A ��� D
        bool isMoving = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

        // ��������� �������� � ����������� �� ����, ���� �� ����� ����� ��� ������
        _animator.SetBool("isRuning", isMoving);

        // ����������� ������ ����� ��� ������
        if (isMoving)
        {
            if (Input.GetKey(KeyCode.A))
            {
                _sprite.flipX = true;
                transform.Translate(_speed * Time.deltaTime * Vector2.left);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _sprite.flipX = false;
                transform.Translate(_speed * Time.deltaTime * Vector2.right);
            }
        }

        //transform.Translate ������������ ��� ����������� ������� � ������������ �� ���������� �������.
        //Vector2.left - ��� ������, ����������� �����(������������� ����������� �� ��� X).

        //Time.deltaTime - ��� ��������, �������������� �����, ��������� � ������� ���������� �����.
        //������������� Time.deltaTime ������������ ������� �������� ������� ���������� �� ���������� ����.

        //������� ��� �������� � ���
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        //{
        //    animator.SetBool("isRuning", true);
        //}
        //else
        //{
        //    animator.SetBool("isRuning", false);
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(speed * Time.deltaTime * Vector2.left);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(speed * Time.deltaTime * Vector2.right);
        //}

        //GetKeyDown - ��� �����, ������� ����� ������������ ��� �����������, ���� �� ������ ������� �� ���������� � ������ ������ �������.
        //����� ��������� ���������� ��� ����������� ������
        if (Input.GetKeyDown(KeyCode.Space) && _canJump)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, _jumpforce);
            _canJump = false;// ��������� ��� ��� �������
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ��� ��������������� � ������ ����� ��������� ������
        if (collision.gameObject.CompareTag("Ground"))
        {
            _canJump = true;
        }
    }

    //private void OnDestroy()
    //{
    //    if (_restartButton != null)
    //    {
    //        _restartButton.SetActive(true);
    //    }
    //}

    public void ActivateRestartButton()
    {
        if (_restartButton != null)
        {
            _restartButton.SetActive(true);
        }
    }
}