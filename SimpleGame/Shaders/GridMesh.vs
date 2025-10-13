#version 330

in vec3 a_Position;
out vec4 v_Color;
uniform float u_Time;

const float c_PI = 3.141592;
const float flagSize = 0.25;
const float flagSpeed = 4;

void main()
{
	//a_Position.x -0.5 ~ 0.5
	vec4 newPosition = vec4(a_Position, 1);

	float value = a_Position.x + 0.5; //0~1

	newPosition.y = newPosition.y * (1 - value);

	float dX = 0;
	float dY = value * flagSize * sin(2 * value * c_PI + u_Time * flagSpeed);
	//�ݴ�� �����̰� ������ -u_Time, ������ �ϰ� ������ u_Time�� ���

	newPosition += vec4(dX, dY, 0, 0);

	gl_Position = newPosition;

	float newColor = (sin(2 * value * c_PI + u_Time * flagSpeed) + 1) / 2;	//0~1
	v_Color = vec4(newColor);
}
