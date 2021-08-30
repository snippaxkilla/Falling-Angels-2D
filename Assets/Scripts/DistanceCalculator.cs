using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    [SerializeField] private float maxDistancePlayer = 8f;

    public DevilBehaviour player; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer > maxDistancePlayer)
        {
            player.ResetGame();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, player.transform.position);
        Gizmos.DrawWireSphere(transform.position, maxDistancePlayer);
    }

}
