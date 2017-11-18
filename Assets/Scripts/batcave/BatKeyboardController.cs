using UnityEngine;

namespace BatCave {
	/// <summary>
	/// A scriptable object that allows controlling the bat using the keyboard.
	/// </summary>
	[CreateAssetMenu(menuName = "Bat Controller/Keyboard")]

	public class BatKeyboardController : BatController {

		private bool wantsToFlyUp;

		/// <summary>
		/// Returns true if space is pressed dwon.
		/// </summary>
		public override bool WantsToFlyUp() {
			// Handle keyboard input.
			if (Input.GetKeyDown(KeyCode.Space)) {
				wantsToFlyUp = true;
			} else if (Input.GetKeyUp(KeyCode.Space)) {
				wantsToFlyUp = false;
			}
			return wantsToFlyUp;
		}
}
}
