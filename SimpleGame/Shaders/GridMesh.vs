#version 330

in vec3 a_Position;
out vec4 v_Color;
uniform float u_Time;

const float c_PI = 3.141592;
const float flagSize = 0.25;
const float flagSpeed = 4;

void Flag(){
	//a_Position.x -0.5 ~ 0.5
	vec4 newPosition = vec4(a_Position, 1);

	float value = a_Position.x + 0.5; //0~1

	newPosition.y = newPosition.y * (1 - value);

	float dX = 0;
	float dY = value * flagSize * sin(2 * value * c_PI + u_Time * flagSpeed);
	//반대로 움직이고 싶으면 -u_Time, 빠르게 하고 싶으면 u_Time을 배수

	newPosition += vec4(dX, dY, 0, 0);

	gl_Position = newPosition;

	float newColor = (sin(2 * value * c_PI + u_Time * flagSpeed) + 1) / 2;	//0~1
	v_Color = vec4(newColor);
}

void Wave()
{
	vec4 newPosition = vec4(a_Position, 1);
	float dX = 0; 
	float dY = 0;

	vec2 pos = vec2(a_Position.xy);
	vec2 cen = vec2(0, 0);
	float d = distance(pos, cen); //거리
	

	float newColor = 1;

	/*if(d<0.5){
		newColor = 1;
	}else{
		newColor = 0;
	}*/

	float value = 0.5 - d;
	value = clamp(value, 0, 1);
	value = ceil(value);
	
	newPosition += vec4(dX, dY, 0, 0);
	gl_Position = newPosition;

	v_Color = vec4(value);
}

void main()
{
	//Flag();
	Wave();
}
