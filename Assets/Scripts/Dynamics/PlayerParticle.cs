using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    private Transform player;

    //finding the player to place the particles on him
    private void Start()
    {
        player = FindObjectOfType<DevilBehaviour>().transform;
    }

   //gives the position and adjusting the z value because particles are meant to be for 3d
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -1);
    }
}
