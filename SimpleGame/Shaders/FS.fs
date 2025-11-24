#version 330

layout(location=0) out vec4 FragColor;

in vec2 v_UV;

uniform sampler2D u_RGBTexture;
uniform sampler2D u_DigitTexture;
uniform sampler2D u_NumTexture;

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
    vec2 newUV = vec2(v_UV.x, v_UV.y);  //0~1 left top (0,0)
    float x = newUV.y;  //0~1
    float y = 1 - newUV.x; // 0~1~0

    float three = 1.0/3.0;
    float six = 2.0/3.0;
    if(y < three && x > three && x < six){
        x = newUV.x - three;
        y = newUV.y - three;
    }
    if(y > three && y < six && x > three && x < six){
        x = newUV.x;
        y = newUV.y;
    }
    if(y > six && x > three && x < six){
        x = newUV.x + three;
        y = newUV.y + three;
    }

    vec4 newColor = texture(u_RGBTexture, vec2(x,y));
    FragColor = newColor;
}

void Q2(){
    vec2 newUV = vec2(v_UV.x, v_UV.y);  //0~1 left top (0,0)

    float x = 0;
    float y = 0;
    if(newUV.y < 0.5){
    x = fract(newUV.x * 2) + 0.5;  //0~1, 0~1, 0~1
    //float y = (floor(newUV.x*3))/3 + v_UV.y / 3; // 0~1~0
    y = fract(newUV.y * 2);
    }else{
        x = fract(newUV.x * 2);
        y = fract(newUV.y * 2);
    }

    vec4 newColor = texture(u_RGBTexture, vec2(x,y));
    FragColor = newColor;
}

void Brick_Horizontal(){
    vec2 newUV = vec2(v_UV.x, v_UV.y);  //0~1 left top (0,0)

    float x = 0;
    float y = 0;
    if(newUV.y < 0.5){
    //x = fract(newUV.x * 2) + 0.5;  //0~1, 0~1, 0~1
    x = newUV.x * 2 + 0.5;  //?? 0.5~2.5
    //float y = (floor(newUV.x*3))/3 + v_UV.y / 3; // 0~1~0
    y = fract(newUV.y * 2);
    }else{
        x = fract(newUV.x * 2);
        y = fract(newUV.y * 2);
    }

    vec4 newColor = texture(u_RGBTexture, vec2(x,y));
    FragColor = newColor;
}

void Brick_Horizontal_professor(){
    vec2 newUV = vec2(v_UV.x, v_UV.y);  //0~1 left top (0,0)

    float rCount = 2;
    float sAmount = 0.5;
    float x = fract(newUV.x*rCount) + floor(newUV.y*rCount + 1) * sAmount; 
    float y = fract(newUV.y*rCount);

    vec4 newColor = texture(u_RGBTexture, vec2(x,y));
    FragColor = newColor;
}

void Brick_Vertical(){
    vec2 newUV = vec2(v_UV.x, v_UV.y);  //0~1 left top (0,0)

    //float x = fract(newUV.x*2) + floor(newUV.y*2 + 1) * 0.5; 
    float x = fract(newUV.x*2); 
    float y = fract(newUV.y*2) + floor(newUV.x*2) * 0.5;

    vec4 newColor = texture(u_RGBTexture, vec2(x,y));
    FragColor = newColor;
}

void Brick_Horizontal_AI(){
    // 2 x 2 타일 생성
    vec2 tileUV = v_UV * 2.0;
    
    // row : 0 = 아래줄, 1 = 위줄
    float row = floor(tileUV.y);

    // 아래줄: 온전한 타일 두 개
    // 위줄: 반칸/온전/반칸 구조 → x 좌표에 절반 오프셋
    float xOffset = (row == 1.0) ? 0.5 : 0.0;

    // fract 로 반복 영역 자르기
    float u = fract(tileUV.x + xOffset);
    float v = fract(tileUV.y);

    vec4 color = texture(u_RGBTexture, vec2(u, v));
    FragColor = color;
}

void Digit(){
    FragColor = texture(u_DigitTexture, v_UV);
}

void Digit_Num(){
    int digit = 3;

    float offX = 0.2 * floor(u_Time);//시험에 여기가 빈칸
    float offY = 0.5 * floor(u_Time/5);

    float tx = 0.2 * v_UV.x + offX;
    float ty = 0.5 * v_UV.y + offY;

    FragColor = texture(u_NumTexture, vec2(tx, ty));
}

void Digit_Num_Professor(){
    int digit = int(u_Time) % 10;

    int tileIndex = (digit + 9) % 10; // 원래는 1~0인데 0~9로 구현하기 위해서 +9를 해준 것
    float offX = float(tileIndex % 5) / 5;//시험에 여기가 빈칸
    float offY = floor(float(tileIndex) / 5) / 2;

    float tx = v_UV.x / 5 + offX;
    float ty = v_UV.y / 2 + offY;

    FragColor = texture(u_NumTexture, vec2(tx, ty));
}
void main()
{
    //Test();
    //Circles();
    //Flag();
    //Q1();
    //Q2();
    //Brick_Horizontal();
    //Brick_Horizontal_professor();
    //Brick_Vertical();
    //Brick_Horizontal_AI();
    //Digit();
    //Digit_Num();
    Digit_Num_Professor();
}
