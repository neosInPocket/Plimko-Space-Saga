using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class TutorialWindow : MonoBehaviour
{
	[SerializeField] private TMP_Text tutorialText;
	private Action OnEndAction;
	
	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
		
		Touch.onFingerDown += OnFingerDown;
	}
	
	public void Show(Action endAction)
	{
		gameObject.SetActive(true);
		OnEndAction = endAction;
	}
	
	private void OnFingerDown(Finger finger)
	{
		
	}
}
