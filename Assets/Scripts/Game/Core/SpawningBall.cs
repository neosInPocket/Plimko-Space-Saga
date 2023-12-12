using UnityEngine;

public class SpawningBall : MonoBehaviour
{
	[SerializeField] private CircleCollider2D circleCollider2D;
	[SerializeField] private Rigidbody2D rigid2D;
	[SerializeField] private SpriteRenderer spriteRenderer;
	public Rigidbody2D Rigid => rigid2D;

	public Color CurrentColor
	{
		get => currentColor;
		set
		{
			currentColor = value;
			spriteRenderer.color = value;
		}
	}

	private Color currentColor;

	private void Start()
	{

	}
}
