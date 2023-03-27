using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 4f;
    [SerializeField]
    private float _jumpPower = 8f;
    [SerializeField]
    private float _groundedLayLength = 1.3f;
    [SerializeField]
    private LayerMask _layerMask = default;
    [SerializeField]
    private SelfMadeStateMachine _stateMachine = default;

    private Rigidbody2D _rigidbody2D = null;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.freezeRotation = true;
    }

    private void Update()
    {
        // 移動とジャンプの処理
        var h = Input.GetAxisRaw("Horizontal") * _moveSpeed;
        var v = _rigidbody2D.velocity.y;

        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, _groundedLayLength, _layerMask);

        if (hit.collider != null &&
            Input.GetKeyDown(KeyCode.Space))
        {
            v = _jumpPower;
        }

        _rigidbody2D.velocity = new Vector2(h, v);

        // ステートマシンの状態変更
        if (hit.collider == null)
        {
            _stateMachine.Conditions = Conditions.Jump;
        }
        else if (Mathf.Abs(_rigidbody2D.velocity.x) > 0.01f)
        {
            _stateMachine.Conditions = Conditions.Move;
        }
        else
        {
            _stateMachine.Conditions = Conditions.Idle;
        }
    }

    private void OnDrawGizmos()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, _groundedLayLength, _layerMask);

        if (hit.collider != null)
        {
            Debug.DrawRay(this.transform.position, Vector3.down * _groundedLayLength, Color.red);
        }
        else
        {
            Debug.DrawRay(this.transform.position, Vector3.down * _groundedLayLength, Color.blue);
        }
    }
}
