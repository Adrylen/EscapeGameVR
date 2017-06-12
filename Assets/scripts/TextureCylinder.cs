using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureCylinder : MonoBehaviour {
	private int i;

	void Start () {
		MeshFilter mf = GetComponent<MeshFilter> ();
		Mesh mesh = mf != null ? mf.mesh : null;

		if(mesh == null || mesh.uv.Length != 88) {
			Debug.Log("Script must be attached to a cylinder");
			return;
		}

		float[,] colors = new float[,] {
			// Side bottom points
			{ 0.0f, 1.0f },	//  0
			{ 1.0f, 1.0f },	//  1
			{ 2.0f, 1.0f },	//  2
			{ 3.0f, 1.0f },	//  3
			{ 4.0f, 1.0f },	//  4
			{ 5.0f, 1.0f },	//  5
			{ 6.0f, 1.0f },	//  6
			{ 7.0f, 1.0f },	//  7
			{ 8.0f, 1.0f },	//  8
			{ 9.0f, 1.0f },	//  9
			{10.0f, 1.0f },	// 10
			{11.0f, 1.0f },	// 11
			{12.0f, 1.0f },	// 12
			{13.0f, 1.0f },	// 13
			{14.0f, 1.0f },	// 14
			{15.0f, 1.0f },	// 15
			{16.0f, 1.0f },	// 16
			{17.0f, 1.0f },	// 17
			{18.0f, 1.0f },	// 18
			{19.0f, 1.0f },	// 19

			// Side top points
			{ 0.0f, 2.0f },	// 20
			{ 1.0f, 2.0f },	// 21
			{ 2.0f, 2.0f },	// 22
			{ 3.0f, 2.0f },	// 23
			{ 4.0f, 2.0f },	// 24
			{ 5.0f, 2.0f },	// 25
			{ 6.0f, 2.0f },	// 26
			{ 7.0f, 2.0f },	// 27
			{ 8.0f, 2.0f },	// 28
			{ 9.0f, 2.0f },	// 29
			{10.0f, 2.0f },	// 30
			{11.0f, 2.0f },	// 31
			{12.0f, 2.0f },	// 32
			{13.0f, 2.0f },	// 33
			{14.0f, 2.0f },	// 34
			{15.0f, 2.0f },	// 35
			{16.0f, 2.0f },	// 36
			{17.0f, 2.0f },	// 37
			{18.0f, 2.0f },	// 38
			{19.0f, 2.0f },	// 39

			// Center
			{10.0f, 0.0f },	// 40	// Bottom
			{10.0f, 3.0f },	// 41	// Top

			// Missed first band 
			{ 9.0f, 1.0f },	// 42	// Bottom	theta = 0
			{ 9.0f, 2.0f },	// 43	// Top 		theta = 0

			// Missed second band
			{19.0f, 1.0f },	// 44	// Bottom	theta = pi
			{19.0f, 2.0f },	// 45	// Top 		theta = pi
			{20.0f, 2.0f },	// 46	// Top		theta = -9pi/10
			{20.0f, 1.0f },	// 47	// Bottom	theta = -9pi/10

			// Bottom circle
			{ 1.0f, 1.0f },	// 48
			{ 0.0f, 1.0f },	// 49
			{ 2.0f, 1.0f },	// 50
			{ 3.0f, 1.0f },	// 51
			{ 4.0f, 1.0f },	// 52
			{ 5.0f, 1.0f },	// 53
			{ 6.0f, 1.0f },	// 54
			{ 7.0f, 1.0f },	// 55
			{ 8.0f, 1.0f },	// 56
			{ 9.0f, 1.0f },	// 57
			{10.0f, 1.0f },	// 58
			{11.0f, 1.0f },	// 59
			{12.0f, 1.0f },	// 60
			{13.0f, 1.0f },	// 61
			{14.0f, 1.0f },	// 62
			{15.0f, 1.0f },	// 63
			{16.0f, 1.0f },	// 64
			{17.0f, 1.0f },	// 65
			{18.0f, 1.0f },	// 66
			{19.0f, 1.0f },	// 67

			// Top circle
			{ 0.0f, 2.0f },	// 68
			{ 1.0f, 2.0f },	// 69
			{ 2.0f, 2.0f },	// 70
			{ 3.0f, 2.0f },	// 71
			{ 4.0f, 2.0f },	// 72
			{ 5.0f, 2.0f },	// 73
			{ 6.0f, 2.0f },	// 74
			{ 7.0f, 2.0f },	// 75
			{ 8.0f, 2.0f },	// 76
			{ 9.0f, 2.0f },	// 77
			{10.0f, 2.0f },	// 78
			{11.0f, 2.0f },	// 79
			{12.0f, 2.0f },	// 80
			{13.0f, 2.0f },	// 81
			{14.0f, 2.0f },	// 82
			{15.0f, 2.0f },	// 83
			{16.0f, 2.0f },	// 84
			{17.0f, 2.0f },	// 85
			{18.0f, 2.0f },	// 86
			{19.0f, 2.0f }	// 87
		};

		Vector2[] uvs = new Vector2[mesh.vertices.Length];

		for (int i = 0; i < mesh.vertices.Length; ++i) {
			uvs [i] = new Vector2 (colors[i, 0] / 20.0f, colors[i, 1] / 3.0f);
		}

//		i = 0; Debug.Log ("I : "+i+" | X : "+mesh.vertices[i].x * 2.0f+" | Y : "+mesh.vertices[i].y+" | Z : "+mesh.vertices[i].z * 2.0f);

		// Bandes paires
//		for (int j = 0; j < 20; j+=2) {
//			uvs[j]		= new Vector2( ((float)		j)	/ 21.0f, 1.0f / 3.0f);
//			uvs[j+1]	= new Vector2( ((float)	(j+1))	/ 21.0f, 1.0f / 3.0f);
//			uvs[j+21]	= new Vector2( ((float)	(j+1))	/ 21.0f, 2.0f / 3.0f);
//			uvs[j+20]	= new Vector2( ((float)		j)	/ 21.0f, 2.0f / 3.0f);
//		}

		//uvs[42] = new Vector2(0.0f / 21.0f, 1.0f / 3.0f);
		//uvs[43] = new Vector2(0.0f / 21.0f, 2.0f / 3.0f);

		// uvs[40]	= new Vector2(0.000f, 0.000f);	// Bottom	center
		// uvs[41]	= new Vector2(0.000f, 0.000f);	// Top		center

		// uvs[48]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = -8pi/10
		// uvs[49]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = -9pi/10
		// uvs[50]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = -7pi/10
		// uvs[51]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = -6pi/10
		// uvs[52]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = -5pi/10
		// uvs[53]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = -4pi/10
		// uvs[54]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = -3pi/10
		// uvs[55]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = -2pi/10
		// uvs[56]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = -1pi/10
		// uvs[57]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = -0
		// uvs[58]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = 1pi/10
		// uvs[59]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = 2pi/10
		// uvs[60]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = 3pi/10
		// uvs[61]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = 4pi/10
		// uvs[62]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = 5pi/10
		// uvs[63]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = 6pi/10
		// uvs[64]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = 7pi/10
		// uvs[65]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = 8pi/10
		// uvs[66]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = 9pi/10
		// uvs[67]	= new Vector2(0.000f, 0.000f);	// Bottom	theta = pi

		// uvs[68]	= new Vector2(0.000f, 0.000f);	// Top		theta = -8pi/10
		// uvs[69]	= new Vector2(0.000f, 0.000f);	// Top		theta = -9pi/10
		// uvs[70]	= new Vector2(0.000f, 0.000f);	// Top		theta = -7pi/10
		// uvs[71]	= new Vector2(0.000f, 0.000f);	// Top		theta = -6pi/10
		// uvs[72]	= new Vector2(0.000f, 0.000f);	// Top		theta = -5pi/10
		// uvs[73]	= new Vector2(0.000f, 0.000f);	// Top		theta = -4pi/10
		// uvs[74]	= new Vector2(0.000f, 0.000f);	// Top		theta = -3pi/10
		// uvs[75]	= new Vector2(0.000f, 0.000f);	// Top		theta = -2pi/10
		// uvs[76]	= new Vector2(0.000f, 0.000f);	// Top		theta = -1pi/10
		// uvs[77]	= new Vector2(0.000f, 0.000f);	// Top		theta = -0
		// uvs[78]	= new Vector2(0.000f, 0.000f);	// Top		theta = 1pi/10
		// uvs[79]	= new Vector2(0.000f, 0.000f);	// Top		theta = 2pi/10
		// uvs[80]	= new Vector2(0.000f, 0.000f);	// Top		theta = 3pi/10
		// uvs[81]	= new Vector2(0.000f, 0.000f);	// Top		theta = 4pi/10
		// uvs[82]	= new Vector2(0.000f, 0.000f);	// Top		theta = 5pi/10
		// uvs[83]	= new Vector2(0.000f, 0.000f);	// Top		theta = 6pi/10
		// uvs[84]	= new Vector2(0.000f, 0.000f);	// Top		theta = 7pi/10
		// uvs[85]	= new Vector2(0.000f, 0.000f);	// Top		theta = 8pi/10
		// uvs[86]	= new Vector2(0.000f, 0.000f);	// Top		theta = 9pi/10
		// uvs[87]	= new Vector2(0.000f, 0.000f);	// Top		theta = pi

		mesh.uv = uvs;
	}
}
