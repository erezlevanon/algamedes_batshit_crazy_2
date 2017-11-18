using UnityEngine;

namespace BatCave {
	/// <summary>
	/// A scriptable object that allow a simple AI to control the bat.
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
		/// Returns true if the ai wants the bat to fly up.
		/// if close to floor - go up until close to cieling, then go down until close to floor.
		/// </summary>
		public override bool WantsToFlyUp() {
			// check downward distance. start going up if close.
			hit = Physics2D.Raycast (batTransform.position, directionDown);
			if (hit.collider != null) {
				if (hit.distance < downDistance)
					wantsToFlyUp = true;
			}

			// check upward distance. stop going up if close.
			hit = Physics2D.Raycast (batTransform.position, directionUp);
			if (hit.collider != null) {
				if (hit.distance < upDistance)
					wantsToFlyUp = false;
			}

			return wantsToFlyUp; 
		}
}
}
