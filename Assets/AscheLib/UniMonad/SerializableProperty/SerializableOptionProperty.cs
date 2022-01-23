using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AscheLib;

namespace AscheLib.UniMonad {
	[Serializable]
	public abstract class DrawableSerializableOptionBase {
	}

	[Serializable]
	public abstract class SerializableOptionPropertyBase<T> : DrawableSerializableOptionBase, IOptionMonad<T> {
		[SerializeField]
		T _value;
		[SerializeField]
		bool _isJust = true;

		public SerializableOptionPropertyBase() {
		}
		public SerializableOptionPropertyBase(T value, bool isJust) {
			_value = value;
			_isJust = isJust;
		}

		public IOptionResult<T> Run() {
			if (_isJust) {
				return Option.Return(_value).Run();
			}
			else {
				return Option.None<T>().Run();
			}
		}
	}

#if UNITY_2020_1_OR_NEWER
	[Serializable] public class SerializableOptionProperty<T> : SerializableOptionPropertyBase<T> {
		public SerializableOptionProperty () : base() { }
		public SerializableOptionProperty (T value, bool isJust) : base(value, isJust) { }
	}
#endif

	[Serializable]
	public class IntSerializableOptionProperty : SerializableOptionPropertyBase<int> {
		public IntSerializableOptionProperty() : base() { }
		public IntSerializableOptionProperty(int value, bool isJust) : base(value, isJust) { }
	}
	[Serializable]
	public class LongSerializableOptionProperty : SerializableOptionPropertyBase<long> {
		public LongSerializableOptionProperty() : base() { }
		public LongSerializableOptionProperty(long value, bool isJust) : base(value, isJust) { }
	}
	[Serializable]
	public class ByteSerializableOptionProperty : SerializableOptionPropertyBase<byte> {
		public ByteSerializableOptionProperty() : base() { }
		public ByteSerializableOptionProperty(byte value, bool isJust) : base(value, isJust) { }
	}
	[Serializable]
	public class FloatSerializableOptionProperty : SerializableOptionPropertyBase<float> {
		public FloatSerializableOptionProperty() : base() { }
		public FloatSerializableOptionProperty(float value, bool isJust) : base(value, isJust) { }
	}
	[Serializable]
	public class DoubleSerializableOptionProperty : SerializableOptionPropertyBase<double> {
		public DoubleSerializableOptionProperty() : base() { }
		public DoubleSerializableOptionProperty(double value, bool isJust) : base(value, isJust) { }
	}
	[Serializable]
	public class StringSerializableOptionProperty : SerializableOptionPropertyBase<string> {
		public StringSerializableOptionProperty() : base() { }
		public StringSerializableOptionProperty(string value, bool isJust) : base(value, isJust) { }
	}
	[Serializable]
	public class Vector2SerializableOptionProperty : SerializableOptionPropertyBase<Vector2> {
		public Vector2SerializableOptionProperty() : base() { }
		public Vector2SerializableOptionProperty(Vector2 value, bool isJust) : base(value, isJust) { }
	}
	[Serializable]
	public class Vector3SerializableOptionProperty : SerializableOptionPropertyBase<Vector3> {
		public Vector3SerializableOptionProperty() : base() { }
		public Vector3SerializableOptionProperty(Vector3 value, bool isJust) : base(value, isJust) { }
	}
	[Serializable]
	public class Vector4SerializableOptionProperty : SerializableOptionPropertyBase<Vector4> {
		public Vector4SerializableOptionProperty() : base() { }
		public Vector4SerializableOptionProperty(Vector4 value, bool isJust) : base(value, isJust) { }
	}
	[Serializable]
	public class ColorSerializableOptionProperty : SerializableOptionPropertyBase<Color> {
		public ColorSerializableOptionProperty() : base() { }
		public ColorSerializableOptionProperty(Color value, bool isJust) : base(value, isJust) { }
	}
	[Serializable]
	public class AnimationSerializableOptionProperty : SerializableOptionPropertyBase<Animation> {
		public AnimationSerializableOptionProperty() : base() { }
		public AnimationSerializableOptionProperty(Animation value, bool isJust) : base(value, isJust) { }
	}
	[Serializable]
	public class AnimatorSerializableOptionProperty : SerializableOptionPropertyBase<Animator> {
		public AnimatorSerializableOptionProperty() : base() { }
		public AnimatorSerializableOptionProperty(Animator value, bool isJust) : base(value, isJust) { }
	}
	[Serializable]
	public class TextureSerializableOptionProperty : SerializableOptionPropertyBase<Texture> {
		public TextureSerializableOptionProperty() : base() { }
		public TextureSerializableOptionProperty(Texture value, bool isJust) : base(value, isJust) { }
	}
	[Serializable]
	public class Texture2DSerializableOptionProperty : SerializableOptionPropertyBase<Texture2D> {
		public Texture2DSerializableOptionProperty() : base() { }
		public Texture2DSerializableOptionProperty(Texture2D value, bool isJust) : base(value, isJust) { }
	}
	[Serializable]
	public class SpriteSerializableOptionProperty : SerializableOptionPropertyBase<Sprite> {
		public SpriteSerializableOptionProperty() : base() { }
		public SpriteSerializableOptionProperty(Sprite value, bool isJust) : base(value, isJust) { }
	}
	[Serializable]
	public class GameObjectSerializableOptionProperty : SerializableOptionPropertyBase<GameObject> {
		public GameObjectSerializableOptionProperty() : base() { }
		public GameObjectSerializableOptionProperty(GameObject value, bool isJust) : base(value, isJust) { }
	}
}