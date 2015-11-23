using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour 
{

	public void AddToBase (Vector3 pos)
	{
		transform.position = pos;
	}

}
