#version 330

in vec3 a_Position;
in vec4 a_Color;

out vec4 v_Color;

uniform float u_Time;

const float c_PI = 3.141592;

void main()
{
	float value = fract(u_Time) * 2 - 1; //-1~1
	float rad = (value + 1) * c_PI; //0~2PI
	float y = cos(rad);
	float x = sin(rad);

	vec4 newPosition = vec4(a_Position, 1);
	//newPosition.xy -= 1; // 사각형을 가운데로 옮기는 첫번 째 방법
	newPosition.xy = newPosition.xy 
							+ fract(u_Time) * 0.5 * vec2(x, y);//사각형이 왼쪽에서 오른쪽 까지 반복 이동
	gl_Position = newPosition;

	v_Color = a_Color;
}