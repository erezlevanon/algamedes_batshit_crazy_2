using UnityEngine;

namespace BatCave {
	/// <summary>
	/// A scriptable object that allows getting control from several bat controllers.
	/// </summary>
	[CreateAssetMenu(menuName = "Bat Controller/AI")]

	public class BatAIController : BatController {

		public float downDistance;
		public float upDistance;

		private bool wantsToFlyUp;
		private Transform batTransform;
		private RaycastHit2D hit;
		private Vector2 directionDown;
		private Vector2 directionUp;

		public void OnEnable() {
			wantsToFlyUp = false;
			directionDown = new Vector2(1, -3);
			directionUp = new Vector2(1, 3);
			GameObject bat = GameObject.Find("Bat");
			if (!bat) return;
			batTransform = bat.transform;
		}

		/// <summary>
		/// Returns true if any of the controllers wants the bat to fly up.
		/// </summary>
		public override bool WantsToFlyUp() {
			// Handle keyboard input.
			hit = Physics2D.Raycast (batTransform.position, directionDown);
			if (hit.collider != null) {
				if (hit.distance < downDistance)
					wantsToFlyUp = true;
			}
			hit = Physics2D.Raycast (batTransform.position, directionUp);
			if (hit.collider != null) {
				if (hit.distance < upDistance)
					wantsToFlyUp = false;
			}
			return wantsToFlyUp; 
		}
}
}
