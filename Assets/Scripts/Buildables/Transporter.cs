using UnityEngine;

public class Transporter : MonoBehaviour, IPlacable
{
    [SerializeField] private LayerMask _nexusMask;
    [SerializeField] private LayerMask _nodeMask;
    [SerializeField] private float _searchRadius;
    private Collider[] _node;
    public void Place()
    {
        // Connect singular found node to nexus
        _node[0].GetComponentInParent<Node>().Connect();
    }
    public bool CanPlace()
    {
        Collider[] nexus = Physics.OverlapSphere(transform.position, _searchRadius, _nexusMask);
        _node = Physics.OverlapSphere(transform.position, _searchRadius, _nodeMask);
        return nexus.Length == 1 && _node.Length == 1;
    }
}
