using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VMovement : MonoBehaviour
{
    [SerializeField] Vector3 topPosition;
    [SerializeField] Vector3 bottomPosition;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move(bottomPosition));
    }

    IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 0.20f)
        {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * (speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;
        StartCoroutine(Move(newTarget));
    }
}