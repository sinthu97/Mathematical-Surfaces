using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
	public delegate float Function(float x, float z, float t);

	public enum FunctionName { Wave, MultiWave, Ripple,Sphere,Torus}

	static Function[] functions = { Wave, MultiWave, Ripple, Sphere, Torus};

	public static Function GetFunction(FunctionName name)
	{
		return functions[(int)name];
	}

	public static float Wave(float x , float z, float t )
	{
		return Sin(PI * (x + z + t));
	}
		
	public static float MultiWave(float x, float z, float t)
	{
		float y = Sin(PI * (x + 0.5f * t));
		y += 0.5f * Sin(2f * PI * (z + t));
		y += Sin(PI * (x + z + 0.25f * t));
		return y * (1f / 2.5f);
	}

	public static float Ripple(float x, float z, float t)
	{
		float d = Sqrt(x * x + z * z);
		float y = Sin(PI * (4f * d - t));
		return y / (1f + 10f * d);
	}

	public static Vector3 Sphere(float u, float v, float t)
	{
		float r = 0.9f + 0.1f * Sin(PI * (6f * u + 4f * v + t));
		float s = r * = Cos(0.5f * PI * v);
		Vector3 p;
		p.x = s * Sin(PI * u);
		p.y = r * Sin(PI * 0.5f * v);
		p.z = s * Cos(PI * u);
		return p;
	}

	public static Vector3 Torus(float u, float v, float t)
	{
		float r1 = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * t));
		float r2 = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 2f * t));
		float s = r1 + r2 * Cos(PI * v);
		Vector3 p;
		p.x = s * Sin(PI * u);
		p.y = r2 * Sin(PI * v);
		p.z = s * Cos(PI * u);
		return p;
	}

}
