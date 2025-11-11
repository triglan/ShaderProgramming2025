#version 330

layout(location=0) out vec4 FragColor;

in vec2 v_UV;

const float c_PI = 3.141592;

void main()
{
	vec4 newColor = vec4(0);
	//float xValue= pow(abs(sin(v_UV.x * 2 * c_PI * 4)), 0.5);
	float xValue= abs(sin(v_UV.x * 2 * c_PI * 4));
	float yValue= abs(sin(v_UV.y * 2 * c_PI * 4));
	
	float merge = xValue * yValue;
	
	vec3 vec3Color = vec3(merge);
	newColor = vec4(vec3Color, 1);
	FragColor = newColor;
}
