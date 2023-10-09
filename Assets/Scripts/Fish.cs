using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _rewardClick;
    [SerializeField] private int _rewardCatch;
    [SerializeField] private int _dethIndex;
    public Vector2 _movment;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movment * _moveSpeed * Time.fixedDeltaTime);
    }

    public void ifDecelerationEffect()
    {
        _moveSpeed = _moveSpeed / 2;
    }

    public void renameMove(GameObject hook)
    {
        _moveSpeed = 0;
        hook.GetComponent<Hook>().addRewardFish(_rewardClick, _rewardCatch);
    }

    public int GetDethIndex()
    {
        return _dethIndex;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Wall wall = collision.GetComponent<Wall>();
        if (wall != null)
        {
            Destroy(gameObject);
        }
        Hook hook = collision.GetComponent<Hook>();
        if(hook != null)
        {
            hook.catchFish(gameObject); 
        }
    }
}