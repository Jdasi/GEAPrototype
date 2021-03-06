﻿using UnityEngine;

using System.Collections;



public class CameraController : MonoBehaviour 

{

	[SerializeField] Transform character;



	private Vector3 moveTemp;



	[SerializeField] float speed = 1;

	[SerializeField] float xDifference;

	[SerializeField] float yDifference;



	[SerializeField] float movementThreshold = 0.5f;



	void Update () 

	{

		if (character.transform.position.x > transform.position.x) 

		{

			xDifference = character.transform.position.x - transform.position.x;

		} 

		else 

		{

			xDifference = transform.position.x - character.transform.position.x;

		}



		if (character.transform.position.y > transform.position.y) 

		{

			yDifference = character.transform.position.y - transform.position.y;

		} 

		else 

		{

			yDifference = transform.position.y - character.transform.position.y;

		}



		//xDifference = character.transform.position.x - transform.position.x;

		//yDifference = character.transform.position.y - transform.position.y;



		if (xDifference >= movementThreshold || yDifference >= movementThreshold) 

		{

			moveTemp = character.transform.position;

			moveTemp.z = - 5;



			transform.position = Vector3.MoveTowards (transform.position, moveTemp, speed * Time.deltaTime);

		}

	}

}