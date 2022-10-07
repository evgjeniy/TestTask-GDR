using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(TrailRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _timeToNextPoint;

    private Animator _animator;
    private List<Vector2> _points;
    private Vector2 _startPosition;
    private float _time;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<CircleCollider2D>().isTrigger = true;
        
        _points = new List<Vector2>();
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (_points.Count == 0) return;

        _time += Time.deltaTime / _timeToNextPoint;
        transform.position = Vector2.Lerp(_startPosition, _points[0], _time);

        if ((Vector2)transform.position == _points[0])
        {
            ResetPosition();
            _points.Remove(_points[0]);
        }
    }

    public void AddPoint(Vector2 point)
    {
        if (!_animator.GetBool("IsBurst")) 
            _points.Add(point);
    }

    public void RemoveMovePoints()
    {
        ResetPosition();
        _points.Clear();
    }

    private void ResetPosition()
    {
        _time = 0;
        _startPosition = transform.position;
    }

    public void SetAnimation(bool isBurst) => _animator.SetBool("IsBurst", isBurst);
}
