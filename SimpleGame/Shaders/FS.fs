#version 330

layout(location=0) out vec4 FragColor;

in vec2 v_UV;

uniform sampler2D u_RGBTexture;
uniform float u_Time;

const float c_PI = 3.141592;

void main()
{
    vec2 newUV = v_UV;
    float dx = 0;
    float dy = 0;
    newUV += vec2(dx, dy);

    vec4 sampledColor = texture(u_RGBTexture, newUV);
    sampledColor += texture(u_RGBTexture, vec2(newUV.x - 0.02, newUV.y));
    sampledColor += texture(u_RGBTexture, vec2(newUV.x - 0.04, newUV.y));
    sampledColor += texture(u_RGBTexture, vec2(newUV.x - 0.06, newUV.y));


    FragColor = sampledColor;
}
