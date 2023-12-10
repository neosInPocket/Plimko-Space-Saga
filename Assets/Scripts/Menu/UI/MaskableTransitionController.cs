using System.Collections;
using UnityEngine;

public class MaskableTransitionController : MonoBehaviour
{
	[SerializeField] private MaskableTransition menuTransition;
	[SerializeField] private MaskableTransition storeTransition;
	[SerializeField] private MaskableTransition optionsTransition;
	[SerializeField] private Transform transitionLine;
	private MaskableTransition currentScreen;

	private void Start()
	{
		currentScreen = menuTransition;
	}

	public void MenuToStore(MaskableTransition target)
	{

		StopAllCoroutines();
		currentScreen.PlayTransition(true);
		target.PlayTransition(false);
		StartCoroutine(LineTransition());
		currentScreen = target;
	}

	private IEnumerator LineTransition()
	{
		var linePosition = transitionLine.position;
		var worldPosition = Vector2.one;

		while (currentScreen.IsPlaying)
		{
			worldPosition = Camera.main.ScreenToWorldPoint(new Vector2(currentScreen.CurrentX + 3 * Screen.width / 4, 0));
			linePosition.x = worldPosition.x;

			transitionLine.position = linePosition;
			yield return new WaitForEndOfFrame();
		}
	}
}
