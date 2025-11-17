#version 330

layout(location=0) out vec4 FragColor;

in vec2 v_UV;

uniform sampler2D u_RGBTexture;
uniform float u_Time;

const float c_PI = 3.141592;

void main()
{
    FragColor = vec4(v_UV, 0, 1);
}
