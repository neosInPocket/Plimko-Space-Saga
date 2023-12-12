using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingZoneController : MonoBehaviour
{
	private List<SpawningBall> targetBalls;
	
	private void Update()
	{
		foreach (var ball in targetBalls)
		{
			
		}
	}
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<SpawningBall>(out SpawningBall ball))
		{
			targetBalls.Add(ball);
		}
	}
	
	private void OnTriigerExit2D(Collider2D collider)
	{
		if (collider.TryGetComponent<SpawningBall>(out SpawningBall ball))
		{
			targetBalls.Remove(ball);
		}
	}
}
