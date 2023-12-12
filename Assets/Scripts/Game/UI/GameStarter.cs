using UnityEngine;

public class GameStarter : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private LevelEngine levelEngine;

	public void FadeGame()
	{
		animator.SetTrigger("start");
	}

	public void StartLevelEngine()
	{
		levelEngine.StartLevel();
	}
}
