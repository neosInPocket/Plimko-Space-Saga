using UnityEngine;

public class SpawningBall : MonoBehaviour
{
	[SerializeField] private CircleCollider2D circleCollider2D;
	[SerializeField] private Rigidbody2D rigid2D;
	[SerializeField] private SpriteRenderer spriteRenderer;
	public Rigidbody2D Rigid => rigid2D;
	
	private void Start()
	{
		
	}
}
