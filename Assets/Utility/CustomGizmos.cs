using UnityEngine;

public class CustomGizmos : MonoBehaviour
{
    [SerializeField] Transform source;
    [SerializeField] Transform target;

    // Start is called before the first frame update
    private void OnDrawGizmosSelected()
    {
        if (source != null && target != null)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(source.position, target.position);
        }
    }
}
