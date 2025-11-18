#version 330

layout(location=0) out vec4 FragColor;

in vec2 v_UV;

uniform sampler2D u_RGBTexture;
uniform float u_Time;

const float c_PI = 3.141592;

void Test(){
	vec2 newUV = v_UV;
    float dx = 0;
    float dy = 0.1 * sin(v_UV.x * 16 * c_PI + u_Time);
    newUV += vec2(dx, dy);
    vec4 sampledColor = texture(u_RGBTexture, newUV);
    FragColor = sampledColor;
}

void Circles(){
    vec2 newUV = v_UV;  //0~1 left top (0,0)
    vec2 center = vec2(0.5, 0.5);
    float d = distance(newUV, center);
    vec4 newColor = vec4(d);
    
    if(d>0.5)
        newColor = vec4(1.0, 0.0, 0.0, 1.0);
    else
        newColor = vec4(0.0, 0.0, 1.0, 1.0);

    FragColor = newColor;
}

void main()
{
    //Test();
    Circles();
}
