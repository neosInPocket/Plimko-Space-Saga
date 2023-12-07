using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
	[SerializeField] private TMP_Text levelText;
	[SerializeField] private Button button;

	private int level;
	public int Level
	{
		get => level;
		set
		{
			level = value;
			levelText.text = (value + 1).ToString();
		}
	}

	public bool Interactable
	{
		get => button.interactable;
		set => button.interactable = value;
	}
}
