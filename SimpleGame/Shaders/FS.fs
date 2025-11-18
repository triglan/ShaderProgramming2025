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
    
    float value = sin(d*4*c_PI * 5 - u_Time);
    vec4 newColor = vec4(value);
    FragColor = newColor;
}

void Flag(){
    //왼쪽 아래를 0,0으로 바꾸기
    vec2 newUV = vec2(v_UV.x, v_UV.y);  //0~1 
    vec4 newColor = vec4(0);

    float width = 0.2 * (1 - newUV.x);
    float sinValue = newUV.x * 0.2 * sin(newUV.x * 2 * c_PI + u_Time * 2);

    if(newUV.y < sinValue + width && newUV.y > sinValue - width){
        newColor = vec4(1);
    }else{
        discard;
    }

    FragColor = newColor;

}

void Q1(){
    vec2 newUV = vec2(v_UV.x, v_UV.y);  //0~1
    vec4 newColor = texture(u_RGBTexture, newUV);

    FragColor = newColor;
}

void main()
{
    //Test();
    //Circles();
    //Flag();
    Q1();
}
