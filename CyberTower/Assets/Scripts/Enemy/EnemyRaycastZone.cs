using UnityEngine;

public class EnemyRaycastZone : MonoBehaviour
{
    public Collider2D[] units;
    public float _attackRadius;
    public LayerMask _unitMask;

    private void Update()
    {
        units = Physics2D.OverlapCircleAll(transform.position, _attackRadius, _unitMask);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
}