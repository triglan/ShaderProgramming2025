#version 330

layout(location=0) out vec4 FragColor;

in vec2 v_UV;

void main()
{
	//FragColor = vec4(u_Color.r, u_Color.g, u_Color.b, u_Color.a);
	FragColor = vec4(v_UV,0,1);
}
