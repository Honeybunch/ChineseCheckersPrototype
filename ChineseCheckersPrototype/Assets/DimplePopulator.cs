using UnityEngine;
using System.Collections;

public class DimplePopulator : MonoBehaviour 
{
	public GameObject ballObject;

	//Simple material to draw some basic circles
	float ballRadius;

	//We need to populate all the dimples
	void Start () 
	{
		//Setup dimples and balls
		Vector3 centerPosition = gameObject.transform.position;

		Vector3 redOnePos = 	centerPosition + new Vector3(-1.0f, .05f, .5f);
		Vector3 redTwoPos = 	centerPosition + new Vector3(	 0, .05f, .5f);
		Vector3 redThreePos = 	centerPosition + new Vector3( 1.0f, .05f, .5f);
		Vector3 redFourPos = 	centerPosition + new Vector3(-0.5f, .05f, 1.0f);
		Vector3 redFivePos = 	centerPosition + new Vector3( 0.5f, .05f, 1.0f);
		Vector3 redSixPos = 	centerPosition + new Vector3(	 0, .05f, 1.5f);

		Vector3 blueOnePos = 	centerPosition + new Vector3(-1.0f, .05f, -.5f);
		Vector3 blueTwoPos = 	centerPosition + new Vector3(	 0, .05f, -.5f);
		Vector3 blueThreePos = 	centerPosition + new Vector3( 1.0f, .05f, -.5f);
		Vector3 blueFourPos = 	centerPosition + new Vector3(-0.5f, .05f, -1.0f);
		Vector3 blueFivePos = 	centerPosition + new Vector3( 0.5f, .05f, -1.0f);
		Vector3 blueSixPos = 	centerPosition + new Vector3(	 0, .05f, -1.5f);

		Dimple redDimpleOne = 	new Dimple(TeamColor.RED, redOnePos);
		Dimple redDimpleTwo = 	new Dimple(TeamColor.RED, redTwoPos);
		Dimple redDimpleThree = new Dimple(TeamColor.RED, redThreePos);
		Dimple redDimpleFour = 	new Dimple(TeamColor.RED, redFourPos);
		Dimple redDimpleFive = 	new Dimple(TeamColor.RED, redFivePos);
		Dimple redDimpleSix = 	new Dimple(TeamColor.RED, redSixPos);

		Dimple blueDimpleOne = 	new Dimple(TeamColor.BLUE, blueOnePos);
		Dimple blueDimpleTwo = 	new Dimple(TeamColor.BLUE, blueTwoPos);
		Dimple blueDimpleThree =new Dimple(TeamColor.BLUE, blueThreePos);
		Dimple blueDimpleFour = new Dimple(TeamColor.BLUE, blueFourPos);
		Dimple blueDimpleFive = new Dimple(TeamColor.BLUE, blueFivePos);
		Dimple blueDimpleSix = 	new Dimple(TeamColor.BLUE, blueSixPos);

		//Create ball game objects
		GameObject redBallObjectOne = GameObject.Instantiate(ballObject) as GameObject;
		GameObject blueBallObjectOne = GameObject.Instantiate(ballObject) as GameObject;

		redBallObjectOne.AddComponent<Ball>();
		blueBallObjectOne.AddComponent<Ball>();

		redBallObjectOne.GetComponent<Ball>().BallColor = TeamColor.RED;
		blueBallObjectOne.GetComponent<Ball>().BallColor = TeamColor.BLUE;

		redBallObjectOne.transform.position = blueTwoPos;
		blueBallObjectOne.transform.position = redTwoPos;

		redDimpleTwo.toggleOccupied();
		blueDimpleTwo.toggleOccupied();

		redBallObjectOne.GetComponent<Ball>().currentDimple = redDimpleTwo;
		blueBallObjectOne.GetComponent<Ball>().currentDimple = blueDimpleTwo;


		ballRadius = ballObject.transform.localScale.x;
	}
}
