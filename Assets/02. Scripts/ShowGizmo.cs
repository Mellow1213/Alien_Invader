    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGizmo : MonoBehaviour
{
    private Color color = Color.green;
    private float radius = 0.5f;
    // Start is called before the first frame update
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(this.transform.position, radius);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
