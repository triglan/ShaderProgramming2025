#version 330

in vec3 a_Position;
in float a_Radius;
in vec4 a_Color;

out vec4 v_Color;
in float a_STime;
in vec3 a_Vel;

uniform float u_Time;

const float c_PI = 3.141592;
const vec2 c_G = vec2(0, 9.8);

void main()
{
	float lifeTime = 1.0;
	float newAlpha = 1.0;
	vec4 newPosition = vec4(a_Position, 1);
	float newTime = u_Time - a_STime;

	if(newTime > 0)
	{
		float t = fract(newTime / lifeTime) * lifeTime;// t: 0~lifetime
		float tt = t*t;
		float x = a_Vel.x * t + 0.5 * c_G.x*tt;					
		float y = a_Vel.y * t + 0.5 * c_G.y*tt - 0.5 * c_G.y * tt;
		newPosition.xy += vec2(x, y);
		newAlpha = 1 - t/lifeTime; // t/lt는 0~1이 나올거임
	}else{
		newPosition.xy = vec2(-100000, 0);
	}

	gl_Position = newPosition;
	v_Color = vec4(a_Color.rgb, newAlpha);
}