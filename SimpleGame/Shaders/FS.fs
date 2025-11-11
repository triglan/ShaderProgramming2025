#version 330

layout(location=0) out vec4 FragColor;

in vec2 v_UV;
uniform float u_Time;

const float c_PI = 3.141592;

void main()
{
    // 중심(0.5, 0.5)을 기준으로 좌표 이동
    vec2 uv = v_UV - vec2(0.5);
    float dist = length(uv); // 중심으로부터의 거리

    // 격자 주파수
    float freq = 8.0;

    // 기본 격자무늬
    float xValue = abs(sin(v_UV.x * 2.0 * c_PI * freq));
    float yValue = abs(sin(v_UV.y * 2.0 * c_PI * freq));
    float grid = xValue * yValue;

    // 중심에서 퍼져나가는 물결 효과
    float wave = sin(dist * 30.0 - u_Time * 5.0); // 30.0은 파 간격, 5.0은 속도
    wave = smoothstep(0.0, 1.0, wave * 0.5 + 0.5); // 부드러운 변화로 보정

    // 격자와 물결 결합
    float final = grid * wave;

    FragColor = vec4(vec3(final), 1.0);
}
