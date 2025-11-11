#version 330

in vec3 a_Position;

out vec2 v_UV;

//a_Position, -1~1
void main()
{
	vec4 newPosition = vec4(a_Position, 1);
	gl_Position = newPosition;
}
