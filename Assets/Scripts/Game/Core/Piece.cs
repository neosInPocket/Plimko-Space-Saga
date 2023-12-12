using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;


public class Piece : MonoBehaviour
{
	[SerializeField] private CircleCollider2D circleCollider;
	[SerializeField] private Rigidbody2D rigidBody;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private CircleCollider2D magnetZone;
	[SerializeField] private float magnetStrength;
	
	public bool Enabled
	{
		get => magnetZone.gameObject.activeSelf;
		set
		{
			magnetZone.gameObject.SetActive(value);
			
			if (!value)
			{
				targetBalls.Clear();
			}
		}
	}
	
	private List<SpawningBall> targetBalls;
	private Color currentAttractedColor;
	
	private void Start()
	{
		targetBalls = new List<SpawningBall>();
	}
	
	public void ToggleMagnet(Color color)
	{
		if (!Enabled)
		{
			Enabled = true;
			currentAttractedColor = color;
		}
		else
		{
			if (currentAttractedColor == color)
			{
				Enabled = false;
			}
			else
			{
				currentAttractedColor = color;
			}
		}
		
		currentAttractedColor = color;
	}
	
	private void Update()
	{
		if (targetBalls.Count == 0 || !Enabled) return;
		
		foreach (var ball in targetBalls)
		{
			var difference = ball.transform.position - transform.position;
			var direction = difference.normalized;
			var distance = difference.sqrMagnitude;
			var traveled = distance / circleCollider.radius;
			
			ball.Rigid.velocity = Vector2.Lerp(ball.Rigid.velocity, direction * magnetStrength, 1 - traveled);
		}
	}
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<SpawningBall>(out SpawningBall ball))
		{
			targetBalls.Add(ball);
		}
	}
	
	private void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.TryGetComponent<SpawningBall>(out SpawningBall ball))
		{
			targetBalls.Remove(ball);
		}
	}
}
