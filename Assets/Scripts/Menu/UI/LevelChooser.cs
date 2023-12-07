using Unity.VisualScripting;
using UnityEngine;

public class LevelChooser : MonoBehaviour
{
	[SerializeField] private LevelButton prefab;
	[SerializeField] private int levelCount;
	[SerializeField] private Transform spawnContainer;
	[SerializeField] private SavePropertiesController saveController;

	private void Start()
	{
		for (int i = 0; i < levelCount; i++)
		{
			var button = Instantiate(prefab, spawnContainer);
			button.Level = i;

			if ((int)saveController.GetPropertyValue(SaveType.LevelsPassed, PropertyType.Int) >= i)
			{
				button.Interactable = true;
			}
			else
			{
				button.Interactable = false;
			}
		}
	}
}
