#version 330

in vec3 a_Position;
in float a_Radius;
in vec4 a_Color;

out vec4 v_Color;

uniform float u_Time;

const float c_PI = 3.141592;
const vec2 c_G = vec2(0, 9.8);

void main()
{
	float t = fract(u_Time/2.0)*2.0;
	float tt = t*t;
	float value = fract(u_Time) * 2 - 1; //-1~1
	float rad = (value + 1) * c_PI; //0~2PI
	float x = 0;					//a_Radius * cos(rad);
	float y = -0.5 * c_G.y * tt;		//a_Radius * sin(rad);

	vec4 newPosition = vec4(a_Position, 1);
	newPosition.xy += vec2(x, y);//사각형이 왼쪽에서 오른쪽 까지 반복 이동 -> 나선형 원운동
	gl_Position = newPosition;

	v_Color = a_Color;
}