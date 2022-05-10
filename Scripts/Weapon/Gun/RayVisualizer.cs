using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayVisualizer : MonoBehaviour
{
    [Header("Ray")]
    public LineRenderer Ray;
    public LayerMask hitRayMask;
    public float distance = 100;

    [Header("Reticle Point")]
    public GameObject reticlePoint;
    public bool showReticle = true;

    private void Awake()
    {
        Off();
    }

    public void On()
    {
        StopAllCoroutines();
        StartCoroutine(Process());
    }

    public void Off()
    {
        StopAllCoroutines();

        Ray.enabled = false;
        reticlePoint.SetActive(false);
    }

    private IEnumerator Process()
    {
        while (true)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, distance, hitRayMask))
            {
                Ray.SetPosition(1, transform.InverseTransformPoint(hitInfo.point));
                Ray.enabled = true;

                reticlePoint.transform.position = hitInfo.point;
                reticlePoint.SetActive(showReticle);
            }
            else
            {
                Ray.enabled = false;

                reticlePoint.SetActive(false);
            }

            yield return null;
        }
    }
}
