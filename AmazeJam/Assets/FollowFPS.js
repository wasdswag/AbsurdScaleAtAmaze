var target : Transform; //the enemy's target
var moveSpeed = 3; //move speed
var rotationSpeed = 3; //speed of turning

private var myTransform : Transform; //current transform data of this enemy

function Awake()
{
    myTransform = transform; //cache transform data for easy access/preformance
}



function Update () {
    //rotate to look at the player
    myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
    Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);

    //move towards the player
    myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;


}