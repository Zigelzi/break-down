using UnityEngine;

public class CustomGizmos : MonoBehaviour
{
    [SerializeField] Transform source;
    [SerializeField] Transform target;

    private void Start()
    {
        source = transform;
    }

    // Start is called before the first frame update
    private void OnDrawGizmosSelected()
    {
        if (source != null && target != null)
        {
            Gizmos.color = Color.magenta;
            Vector3 halfway = source.position - (source.position - target.position) / 2;
            Debug.Log(halfway);
            Gizmos.DrawLine(source.position, halfway);
        }
    }
}
