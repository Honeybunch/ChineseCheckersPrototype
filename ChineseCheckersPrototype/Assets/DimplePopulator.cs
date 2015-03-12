using UnityEngine;
using System.Collections;

public class DimplePopulator : MonoBehaviour 
{
	public GameObject ballObject;

	//Simple material to draw some basic circles
	float ballRadius;
	GameObject redBallObjectOne;
	GameObject blueBallObjectOne;

	Dimple redDimpleOne;
	Dimple redDimpleTwo;
	Dimple redDimpleThree;
	Dimple blueDimpleOne;
	Dimple blueDimpleTwo;
	Dimple blueDimpleThree;
	Dimple noneDimpleOne;
	Dimple noneDimpleTwo;
	Dimple noneDimpleThree;
	Dimple noneDimpleFour;

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

		Vector3 noneOnePos =    centerPosition + new Vector3(-1.5f, .05f, 0f);
		Vector3 noneTwoPos =    centerPosition + new Vector3(-.5f, .05f, 0f);
		Vector3 noneThreePos =  centerPosition + new Vector3(.5f, .05f, 0f);
		Vector3 noneFourPos =   centerPosition + new Vector3(1.5f, .05f, 0f);
		
		Vector3 blueOnePos = 	centerPosition + new Vector3(-1.0f, .05f, -.5f);
		Vector3 blueTwoPos = 	centerPosition + new Vector3(	 0, .05f, -.5f);
		Vector3 blueThreePos = 	centerPosition + new Vector3( 1.0f, .05f, -.5f);
		Vector3 blueFourPos = 	centerPosition + new Vector3(-0.5f, .05f, -1.0f);
		Vector3 blueFivePos = 	centerPosition + new Vector3( 0.5f, .05f, -1.0f);
		Vector3 blueSixPos = 	centerPosition + new Vector3(	 0, .05f, -1.5f);
		
		redDimpleOne = 	new Dimple(TeamColor.RED, redOnePos);
		redDimpleTwo = 	new Dimple(TeamColor.RED, redTwoPos);
		redDimpleThree = new Dimple(TeamColor.RED, redThreePos);
		//Dimple redDimpleFour = 	new Dimple(TeamColor.RED, redFourPos);
		//Dimple redDimpleFive = 	new Dimple(TeamColor.RED, redFivePos);
		//Dimple redDimpleSix = 	new Dimple(TeamColor.RED, redSixPos);

		noneDimpleOne	= new Dimple(TeamColor.NONE, noneOnePos);
		noneDimpleTwo 	= new Dimple(TeamColor.NONE, noneTwoPos);
		noneDimpleThree	= new Dimple(TeamColor.NONE, noneThreePos);
		noneDimpleFour 	= new Dimple(TeamColor.NONE, noneFourPos);

		blueDimpleOne 	= 	new Dimple(TeamColor.BLUE, blueOnePos);
		blueDimpleTwo 	= 	new Dimple(TeamColor.BLUE, blueTwoPos);
		blueDimpleThree =new Dimple(TeamColor.BLUE, blueThreePos);
		//Dimple blueDimpleFour = new Dimple(TeamColor.BLUE, blueFourPos);
		//Dimple blueDimpleFive = new Dimple(TeamColor.BLUE, blueFivePos);
		//Dimple blueDimpleSix = 	new Dimple(TeamColor.BLUE, blueSixPos);

		//Create ball game objects
		redBallObjectOne = GameObject.Instantiate(ballObject) as GameObject;
		blueBallObjectOne = GameObject.Instantiate(ballObject) as GameObject;

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


		/*neighbor population*/
		redDimpleOne.AddNeighboringDimple(new Neighbor(redDimpleTwo, Direction.RIGHT));
		redDimpleOne.AddNeighboringDimple(new Neighbor(noneDimpleOne, Direction.DOWN_LEFT));
		redDimpleOne.AddNeighboringDimple(new Neighbor(noneDimpleTwo, Direction.DOWN_RIGHT));

		//redDimpleTwo.AddNeighboringDimple(new Neighbor(redDimpleOne, Direction.LEFT));
		redDimpleTwo.AddNeighboringDimple(new Neighbor(redDimpleThree, Direction.RIGHT));
		redDimpleTwo.AddNeighboringDimple(new Neighbor(noneDimpleTwo, Direction.DOWN_LEFT));
		redDimpleTwo.AddNeighboringDimple(new Neighbor(noneDimpleThree, Direction.DOWN_RIGHT));

		//redDimpleThree.AddNeighboringDimple(new Neighbor(redDimpleTwo, Direction.LEFT));
		redDimpleThree.AddNeighboringDimple(new Neighbor(noneDimpleThree, Direction.DOWN_LEFT));
		redDimpleThree.AddNeighboringDimple(new Neighbor(noneDimpleFour, Direction.DOWN_RIGHT));

		//noneDimpleOne.AddNeighboringDimple(new Neighbor(redDimpleOne, Direction.UP_RIGHT));
		noneDimpleOne.AddNeighboringDimple(new Neighbor(blueDimpleOne, Direction.DOWN_RIGHT));		
		noneDimpleOne.AddNeighboringDimple(new Neighbor(noneDimpleTwo, Direction.RIGHT));

		noneDimpleTwo.AddNeighboringDimple(new Neighbor(noneDimpleThree, Direction.RIGHT));
		noneDimpleTwo.AddNeighboringDimple(new Neighbor(blueDimpleOne, Direction.DOWN_LEFT));
		noneDimpleTwo.AddNeighboringDimple(new Neighbor(blueDimpleTwo, Direction.DOWN_RIGHT));

		noneDimpleThree.AddNeighboringDimple(new Neighbor(noneDimpleFour, Direction.RIGHT));
		noneDimpleThree.AddNeighboringDimple(new Neighbor(blueDimpleTwo, Direction.DOWN_LEFT));
		noneDimpleThree.AddNeighboringDimple(new Neighbor(blueDimpleThree, Direction.DOWN_RIGHT));

		noneDimpleFour.AddNeighboringDimple(new Neighbor(blueDimpleThree,Direction.DOWN_LEFT));

		blueDimpleOne.AddNeighboringDimple(new Neighbor(blueDimpleTwo,Direction.RIGHT));

		blueDimpleTwo.AddNeighboringDimple(new Neighbor(blueDimpleThree,Direction.RIGHT));
		//////
	}

	void Update(){
		if(redBallObjectOne.GetComponent<Ball>().updateDimple){
			redBallObjectOne.GetComponent<Ball>().updateDimple = false;
			redBallObjectOne.transform.position = redBallObjectOne.GetComponent<Ball>().currentDimple.position;
		}

		foreach(Neighbor n in redDimpleOne.neighbors){

		}
	}


}
