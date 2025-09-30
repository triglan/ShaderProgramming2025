#version 330

in vec3 a_Position;
in float a_Value;
in vec4 a_Color;

out vec4 v_Color;
in float a_STime;
in vec3 a_Vel;
in float a_LifeTime;
in float a_Mass;
in float a_Period;

uniform float u_Time;
uniform vec3 u_Force;

const float c_PI = 3.141592;
const vec2 c_G = vec2(0, -9.8);

void raining(){
	float lifeTime = a_LifeTime;
	float newAlpha = 1.0;
	vec4 newPosition = vec4(a_Position, 1);
	float newTime = u_Time - a_STime;

	if(newTime > 0)
	{
		float t = fract(newTime / lifeTime) * lifeTime;// t: 0~lifetime
		float tt = t*t;

		float forceX = u_Force.x * 10 + c_G.x * a_Mass;
		float forceY = u_Force.y + c_G.y * a_Mass;
		
		float aX = forceX / a_Mass;
		float aY = forceY / a_Mass;

		float x = a_Vel.x * t + 0.5 * aX * tt;					
		float y = a_Vel.y * t + 0.5 * aY * tt;

		newPosition.xy += vec2(x, y);
		newAlpha = 1 - t/lifeTime; // t/lt는 0~1이 나올거임
	}else{
		newPosition.xy = vec2(-100000, 0);
	}

	gl_Position = newPosition;
	v_Color = vec4(a_Color.rgb, newAlpha);
}

void sinParticle(){
	vec4 centerC = vec4(1, 0, 0, 1);
	vec4 borderC = vec4(1, 1, 1, 0);

	float lifeTime = a_LifeTime;
	float newTime = u_Time - a_STime;
	vec4 newPosition = vec4(a_Position, 1);
	float newAlpha = 1.0;
	vec4 newColor = vec4(1,1,1,1);

	if(newTime > 0){
		float period = a_Period * 1;
		float rep = 20;
		float t = fract(newTime/lifeTime)*lifeTime;
		float tt = t*t;

		float x = 2 * t - 1;
		float y = t * sin(rep * t * c_PI * period) * (a_Value - 0.5) * 2;
		y *=  sin(fract(newTime/lifeTime)*c_PI);
			
		newPosition.xy += vec2(x, y);
		newAlpha = 1 - t/lifeTime;

		newColor = mix(centerC, borderC, abs(y*4));
	}else{
		newPosition.xy = vec2(0.9, 0.9);
	}

	
	gl_Position = newPosition;
	//v_Color = vec4(a_Color.rgb, newAlpha);
	v_Color = vec4(newColor.rgb, newAlpha);
}

void circleParticle(){
	float lifeTime = a_LifeTime;
	float newTime = u_Time - a_STime;
	vec4 newPosition = vec4(a_Position, 1);
	float newAlpha = 1.0;

	if(newTime > 0){
		float t = fract(newTime/lifeTime)*lifeTime;
		float tt = t*t;

		float x = sin(a_Value * 2 * c_PI);
		float y = cos(a_Value * 2 * c_PI);

		float newX = x + 0.5 * c_G.x*tt;
		float newY = y + 0.5 * c_G.y*tt;

		newPosition.xy += vec2(newX, newY);	//S_0
		newAlpha = 1 - t/lifeTime;
	}else{
		newPosition.xy = vec2(0.9, 0.9);
	}
	gl_Position = newPosition;
	v_Color = vec4(a_Color.rgb, newAlpha);
}

void main()
{
	//raining();
	//sinParticle();
	circleParticle();
}