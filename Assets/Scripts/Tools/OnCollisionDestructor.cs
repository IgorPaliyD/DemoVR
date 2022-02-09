using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class OnCollisionDestructor : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent OnSimpleCollision;
    public UnityEvent OnCriticalCollision;
    [SerializeField] private List<GameObject> m_objectPieces;
    [SerializeField] private float m_criticalVelocity;
    [SerializeField] private float m_minVelocity;
    private Renderer _objectRenderer;
    private bool _canBeBreaked = true;
    private Rigidbody _rb;
    private PositionVelocityTracker _objectVelocityTracker;
    private void Start()
    {
        Initialize();
    }
    private void Initialize()
    {
        TryGetComponent<Renderer>(out var render);
        _objectRenderer = render;

        TryGetComponent<Rigidbody>(out var rb);
        _rb = rb;

        TryGetComponent<PositionVelocityTracker>(out var vel);
        _objectVelocityTracker = vel;
    }

    public void AllowBreak()
    {
        _canBeBreaked = true;
    }
    public void DenyBreak()
    {
        _canBeBreaked = false;
    }
    private void OnCollisionEnter(Collision other)
    {
        var point = other.contacts[0];
        if (_objectVelocityTracker != null)
        {
            if (_objectVelocityTracker.ObjectVelocity >= m_minVelocity && _objectVelocityTracker.ObjectVelocity <= m_criticalVelocity) SimpleCollision();
            if (_objectVelocityTracker.ObjectVelocity >= m_criticalVelocity) CriticalCollision();
        }
        if (other.transform.TryGetComponent<PositionVelocityTracker>(out var posVel))
        {
            var collisionVelocity = posVel.ObjectVelocity;
            if (collisionVelocity <= m_criticalVelocity && collisionVelocity >= m_minVelocity) SimpleCollision();
            if (collisionVelocity >= m_criticalVelocity) CriticalCollision();
        }



    }
    private void CriticalCollision()
    {
        if (!_canBeBreaked)
        {
            SimpleCollision();
            return;
        }
        OnCriticalCollision.Invoke();
        transform.GetComponent<Collider>().enabled = false;
        _objectRenderer.enabled = false;
        _rb.useGravity = false;
        _rb.isKinematic = true;
        foreach (var piece in m_objectPieces)
        {
            piece.SetActive(true);
        }

    }
    private void SimpleCollision()
    {
        OnSimpleCollision.Invoke();
        Debug.Log("simple coll");
    }
}
