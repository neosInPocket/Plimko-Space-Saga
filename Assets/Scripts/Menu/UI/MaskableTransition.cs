using UnityEngine;
using UnityEngine.UI;

public class MaskableTransition : MaskableGraphic
{
	[SerializeField] private float transitionSpeed;

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();

		Vector2 a = new Vector2(0, 0);
		Vector2 b = new Vector2(0, 50);
		Vector2 c = new Vector2(100, 0);
		Vector2 d = new Vector2(100, 100);

		var color = Color.white;

		vh.AddUIVertexQuad(
			new UIVertex[]
			{
				new UIVertex { position = a, color = color },
				new UIVertex { position = b, color = color },
				new UIVertex { position = c, color = color },
				new UIVertex { position = d, color = color }
			}
		);
	}

	private void Update()
	{
		SetVerticesDirty();
	}
}
