using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpawningnBallSpawner : MonoBehaviour
{
	[SerializeField] private SpawningBall ballPrefab;
	[SerializeField] private float delay;
	[SerializeField] private Vector2 xBounds;
	[SerializeField] private float yBound;
	[SerializeField] private int poolSize;
	
	public bool Enabled { get; set; }
	private bool isSpawning;
	private List<SpawningBall> ballsPool;
	private Vector2 screenSize;
	
	private void Start()
	{
		screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		
		for (int i = 0; i < poolSize; i++)
		{
			var ball = Instantiate(ballPrefab, transform);
			ball.gameObject.SetActive(false);
			ballsPool.Add(ball);
		}
		
		Enabled = true;
		Debug.LogError("Delete");
	}
	
	private void Update()
	{
		if (!Enabled)
		{
			StopAllCoroutines();
			return;
		}
		
		if (isSpawning) return;
		
		StartCoroutine(SpawnCoroutine());
	}
	
	private IEnumerator SpawnCoroutine()
	{
		isSpawning = true;
		float randomX = Random.Range(xBounds.x * screenSize.x - screenSize.x, xBounds.y * screenSize.x - screenSize.x);
		float y = screenSize.y * yBound - screenSize.y;
		Vector2 position = new Vector2(randomX, y);
		
		var inactiveBall = ballsPool.FirstOrDefault(x => !x.gameObject.activeSelf);
		if (inactiveBall == null)
		{
			var ball = Instantiate(ballPrefab, position, Quaternion.identity, transform);
		}
		else
		{
			inactiveBall.gameObject.SetActive(true);
			inactiveBall.transform.position = position;
		}
		
		yield return new WaitForSeconds(delay);
	}
}
