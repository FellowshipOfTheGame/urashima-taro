using UnityEngine;
using System.Collections;

using System.Collections.Generic;

namespace Pathfinding 
{
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class ZombieDestinationSetter : VersionedMonoBehaviour 
	{
		/// <summary>The object that the AI should move to</summary>
		//private Transform target;
		private bool isPlayerLocation = false;
		IAstarAI ai;

		public Transform defaultLocation;
		public Transform playerLocation;

        void OnEnable () 
		{
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () 
		{
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () 
		{
			if (Input.GetButtonDown("Horizontal"))
			{
				//if (playerLocation.position != null && ai != null) ai.destination = playerLocation.position;
				isPlayerLocation = true;
				//Debug.Log(ai == null);
			}
			else if (Input.GetButtonUp("Horizontal"))
            {
				//if (defaultLocation != null && ai != null) ai.destination = defaultLocation.position;
				isPlayerLocation = false;
			}

			switch(isPlayerLocation)
            {
				case true:
					if (playerLocation.position != null && ai != null) ai.destination = playerLocation.position;
					break;
				case false:
					if (defaultLocation != null && ai != null) ai.destination = defaultLocation.position;
					break;
			}

		}
	}
}
