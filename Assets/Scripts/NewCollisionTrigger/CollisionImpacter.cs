using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CollisionImpacter : MonoBehaviour
{
    public UnityEvent OnSoftCollision;
    public UnityEvent OnCriticalCollision;
    public bool IsDestructable = true;
    public float _momentSpeed { get; private set; }
    [SerializeField] private float m_minimalSpeedReq;
    [SerializeField] private float m_criticalSpeedReq;
    [SerializeField] private AudioSource m_softCollisionSound;
    [SerializeField] private AudioSource m_criticalCollisionSound;
    [SerializeField] private List<GameObject> m_objectPieces;
    [SerializeField] private Renderer m_impacterRenderer;
    [SerializeField] private bool m_useTriggers = false;
    private PositionVelocityTracker _velocityTracker;
    private Rigidbody _rb;

    private void Start()
    {
        Initialize();
    }
    private void Initialize()
    {
        TryGetComponent<Renderer>(out var rend);
        m_impacterRenderer = m_impacterRenderer == null ? rend : m_impacterRenderer;

        TryGetComponent<PositionVelocityTracker>(out var velocityTracker);
        _velocityTracker = velocityTracker;

        TryGetComponent<Rigidbody>(out var rb);
        _rb = rb;

        _momentSpeed = 0f;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (_velocityTracker)
        {
            _momentSpeed = _velocityTracker.ObjectVelocity;
        }
        CalculateImpact(other.gameObject);
        Debug.Log("ffff");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!m_useTriggers) return;

        if (_velocityTracker)
        {
            _momentSpeed = _velocityTracker.ObjectVelocity;
        }

        CalculateImpact(other.gameObject);
    }
    private void CalculateImpact(GameObject other)
    {
        float resultSpeed = _momentSpeed;

        if (other.transform.TryGetComponent<PositionVelocityTracker>(out var otherVelocityTracker))
        {
            resultSpeed += otherVelocityTracker.ObjectVelocity;
        }

        if (resultSpeed >= m_minimalSpeedReq && resultSpeed <= m_criticalSpeedReq)
        {
            SoftCollision();
        }
        if (resultSpeed >= m_criticalSpeedReq)
        {
            CriticalCollision();
        }
    }
    private void CriticalCollision()
    {
        if (!IsDestructable)
        {
            SoftCollision();
            return;
        }

        if (_rb != null)
        {
            _rb.isKinematic = true;
            _rb.useGravity = false;
        }

        transform.GetComponent<Collider>().enabled = false;
        m_impacterRenderer.enabled = false;

        if (m_objectPieces != null || m_objectPieces.Count != 0)
        {
            foreach (var obj in m_objectPieces)
            {
                obj.SetActive(true);
            }
        }
        if (m_criticalCollisionSound != null)
        {
            m_criticalCollisionSound.Play();
        }
        OnCriticalCollision.Invoke();
    }

    private void SoftCollision()
    {
        if (m_softCollisionSound != null)
        {
            m_softCollisionSound.Play();
        }

        OnSoftCollision.Invoke();
    }




}
