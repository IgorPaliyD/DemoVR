using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBebra : MonoBehaviour
{
    [SerializeField] private float moveHeight;
    [SerializeField] private float moveSpeed;
    private Vector3 defaultPosition;
    private bool isActive=false;

    private void Awake()
    {
        defaultPosition = this.transform.position;
    }
    public void MoveBebra()
    {
        if (!isActive)
        {
            isActive = true;
            StartCoroutine(MoveBebra(new Vector3(defaultPosition.x, 
                defaultPosition.y + moveHeight, 
                defaultPosition.z)));
        }
    }

    public void ReturnBebra()
    {
        if (isActive)
        {
            isActive = false;
            StartCoroutine(MoveBebra(defaultPosition));
        }
    }

    private IEnumerator MoveBebra(Vector3 targetPosition)
    {
        for (var i = 0f; i <= 1f; i += Time.deltaTime * moveSpeed)
        {
            this.transform.position = Vector3.Lerp(transform.position, targetPosition, i);
            yield return null;
        }   
    }
}
