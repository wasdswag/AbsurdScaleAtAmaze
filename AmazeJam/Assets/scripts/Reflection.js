#pragma strict

var plane : GameObject;
var character : GameObject;

  var offset : float;
  
  var directionFaced : Direction;
  
  function Update () {
  
      if(directionFaced == Direction.X){
          
          offset = (plane.transform.position.x - character.transform.position.x);
          
          transform.position.x = plane.transform.position.x + offset;
  
          transform.position.y = character.transform.position.y;
          transform.position.z = character.transform.position.z;
      }
      if(directionFaced == Direction.Y){
          
          offset = (plane.transform.position.y - character.transform.position.y);
          
          transform.position.x = character.transform.position.x;
          transform.position.y = plane.transform.position.y + offset;
          transform.position.z = character.transform.position.z;
      }
      if(directionFaced == Direction.Z){
          
          offset = (plane.transform.position.z - character.transform.position.z);
          
          transform.position.x = character.transform.position.x;
          transform.position.y = character.transform.position.y;
          transform.position.z = plane.transform.position.z + offset;
      }
  }
  
  //makes the possible directions 
  public enum Direction{
      X,Y,Z
  }