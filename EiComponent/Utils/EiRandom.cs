﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Eitrum
{
	public class EiRandom : EiCoreSingleton<EiRandom>
	{
		#region Variables

		protected System.Random random;
		protected int seed = 0;

		#endregion

		#region Properties

		public static int Seed {
			get {
				return Instance.seed;
			}
			set {
				Instance.SetSeed (value);
			}
		}

		public virtual int _Seed {
			get {
				return seed;
			}
			set {
				SetSeed (value);
			}
		}

		#region Default Data Types

		public static int Int {
			get {
				return Instance.random.Next ();
			}
		}

		public float _Int {
			get {
				return (float)random.Next ();
			}
		}

		public static float Float {
			get {
				return (float)Instance.random.NextDouble ();
			}
		}

		public float _Float {
			get {
				return (float)random.NextDouble ();
			}
		}

		public static double Double {
			get {
				return Instance.random.NextDouble ();
			}
		}

		public double _Double {
			get {
				return random.NextDouble ();
			}
		}

		#endregion

		#region Unity Data Types

		public static Quaternion Rotation2D {
			get {
				return Quaternion.Euler (0f, 0f, Float * 360f);
			}
		}

		public Quaternion _Rotation2D {
			get {
				return Quaternion.Euler (0f, 0f, _Float * 360f);
			}
		}

		public static Quaternion Rotation {
			get {
				return Quaternion.Euler (Float * 360f, Float * 360f, 0f);
			}
		}

		public Quaternion _Rotation {
			get {
				return Quaternion.Euler (_Float * 360f, _Float * 360f, 0f);
			}
		}

		public static Vector2 OnUnitCircle {
			get {
				return Rotation2D * Vector2.up;
			}
		}

		public Vector2 _OnUnitCircle {
			get {
				return _Rotation2D * Vector2.up;
			}
		}

		public static Vector3 OnUnitSphere {
			get {
				return Rotation * Vector3.forward;
			}
		}

		public Vector3 _OnUnitSphere {
			get {
				return _Rotation * Vector3.forward;
			}
		}

		public static Vector3 InsideUnitSphere {
			get {
				var value = Float;
				value = 1f - (value * value * value);
				return OnUnitSphere * value;
			}
		}

		public Vector3 _InsideUnitSphere {
			get {
				var value = _Float;
				value = 1f - (value * value * value);
				return _OnUnitSphere * value;
			}
		}

		#endregion

		#endregion

		#region Constructors

		public EiRandom ()
		{
			seed = (instance == null) ? DateTime.UtcNow.Millisecond : Int;
			random = new System.Random (seed);
		}

		public EiRandom (int seed)
		{
			random = new System.Random (seed);
			this.seed = seed;
		}

		#endregion

		#region Helper

		public virtual void SetSeed (int seed)
		{
			this.seed = seed;
			random = new System.Random (seed);
		}

		public T _Element<T> (IList<T> list)
		{
			return list [_Range (list.Count)];
		}

		public T _Element<T> (T[] array)
		{
			return array [_Range (array.Length)];
		}

		public static T Element<T> (IList<T> list)
		{
			return list [Range (list.Count)];
		}

		public static T Element<T> (T[] array)
		{
			return array [Range (array.Length)];
		}

		#endregion

		#region Range

		/// <summary>
		/// Get a random number between 0 and specified count.
		/// </summary>
		/// <param name="min">Minimum.</param>
		/// <param name="max">Max.</param>
		public int _Range (int count)
		{
			return random.Next (count);
		}

		/// <summary>
		/// Get a random number from starting of min to max exlusivly.
		/// </summary>
		/// <param name="min">Minimum.</param>
		/// <param name="max">Max.</param>
		public int _Range (int min, int max)
		{
			return random.Next (min, max);
		}

		/// <summary>
		/// Get a random number between 0 and specified count.
		/// </summary>
		/// <param name="min">Minimum.</param>
		/// <param name="max">Max.</param>
		public static int Range (int count)
		{
			return Instance.random.Next (count);
		}

		/// <summary>
		/// Get a random number from starting of min to max exlusivly.
		/// </summary>
		/// <param name="min">Minimum.</param>
		/// <param name="max">Max.</param>
		public static int Range (int min, int max)
		{
			return Instance.random.Next (min, max);
		}

		public static float Range (float min, float max)
		{
			if (min > max) {
				var temp = min;
				min = max;
				max = temp;
			}
			var val = (float)Double;
			var range = max - min;
			return min + val * range;
		}

		public static double Range (double min, double max)
		{
			if (min > max) {
				var temp = min;
				min = max;
				max = temp;
			}
			var range = max - min;
			return min + Double * range;
		}

		#endregion
	}
}