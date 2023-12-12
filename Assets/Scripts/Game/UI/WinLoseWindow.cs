using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseWindow : MonoBehaviour
{
	[SerializeField] private Image winImage;
	[SerializeField] private Image loseImage;
	[SerializeField] private TMP_Text resultText;
	[SerializeField] private TMP_Text coinsText;
	[SerializeField] private TMP_Text gemsText;
	[SerializeField] private GameObject coinsContainer;
	[SerializeField] private GameObject gemsContainer;
	private Action OnHideAction;
	
	
	public void ShowWindow(bool result, int gems = 0, int coins = 0)
	{
		gameObject.SetActive(true);
		
		gemsText.text = gems.ToString();
		coinsText.text = coins.ToString();
		
		gemsContainer.SetActive(gems != 0);
		coinsContainer.SetActive(coins != 0);
		
		resultText.text = result ? "YOU WIN" : "YOU  LOSE";
		winImage.enabled = result;
		loseImage.enabled = !result;
	}
	
	public void Hide(Action onHideAction)
	{
		OnHideAction = onHideAction;
	}
	
	public void HideAction()
	{
		OnHideAction();
		gameObject.SetActive(false);
	}
}
