using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodPoint : MonoBehaviour
{
    public enum PodType { General, Family }
    public PodType podType;

    private void OnDrawGizmos()
    {
        Gizmos.color = podType == PodType.General ? Color.blue : Color.green;
        Gizmos.DrawSphere(transform.position + Vector3.up * 0.5f, 0.3f);
    }
}
