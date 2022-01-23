using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AscheLib;

namespace AscheLib.UniMonad {
	[Serializable]
	public abstract class DrawableSerializableTryBase {
	}

	[Serializable]
	public abstract class SerializableTryPropertyBase<T> : DrawableSerializableTryBase, ITryMonad<T> {
		[SerializeField]
		T _succeededValue;
		[SerializeField]
		string _faultedMessage = "";
		[SerializeField]
		bool _isSucceeded = true;

		public SerializableTryPropertyBase() {
		}
		public SerializableTryPropertyBase(T succeededValue, string faultedMessage, bool isSucceeded) {
			_succeededValue = succeededValue;
			_faultedMessage = faultedMessage;
			_isSucceeded = isSucceeded;
		}

		public ITryResult<T> Run() {
			if (_isSucceeded) {
				return Try.Return(_succeededValue).Run();
			}
			else {
				return Try.Throw<T>(new Exception(_faultedMessage)).Run();
			}
		}
	}

	[Serializable]
	public class IntSerializableTryProperty : SerializableTryPropertyBase<int> {
		public IntSerializableTryProperty() : base() { }
		public IntSerializableTryProperty(int succeededValue, string faultedMessage, bool isSucceeded) : base(succeededValue, faultedMessage, isSucceeded) { }
	}
	[Serializable]
	public class LongSerializableTryProperty : SerializableTryPropertyBase<long> {
		public LongSerializableTryProperty() : base() { }
		public LongSerializableTryProperty(long succeededValue, string faultedMessage, bool isSucceeded) : base(succeededValue, faultedMessage, isSucceeded) { }
	}
	[Serializable]
	public class ByteSerializableTryProperty : SerializableTryPropertyBase<byte> {
		public ByteSerializableTryProperty() : base() { }
		public ByteSerializableTryProperty(byte succeededValue, string faultedMessage, bool isSucceeded) : base(succeededValue, faultedMessage, isSucceeded) { }
	}
	[Serializable]
	public class FloatSerializableTryProperty : SerializableTryPropertyBase<float> {
		public FloatSerializableTryProperty() : base() { }
		public FloatSerializableTryProperty(float succeededValue, string faultedMessage, bool isSucceeded) : base(succeededValue, faultedMessage, isSucceeded) { }
	}
	[Serializable]
	public class DoubleSerializableTryProperty : SerializableTryPropertyBase<double> {
		public DoubleSerializableTryProperty() : base() { }
		public DoubleSerializableTryProperty(double succeededValue, string faultedMessage, bool isSucceeded) : base(succeededValue, faultedMessage, isSucceeded) { }
	}
	[Serializable]
	public class StringSerializableTryProperty : SerializableTryPropertyBase<string> {
		public StringSerializableTryProperty() : base() { }
		public StringSerializableTryProperty(string succeededValue, string faultedMessage, bool isSucceeded) : base(succeededValue, faultedMessage, isSucceeded) { }
	}
	[Serializable]
	public class Vector2SerializableTryProperty : SerializableTryPropertyBase<Vector2> {
		public Vector2SerializableTryProperty() : base() { }
		public Vector2SerializableTryProperty(Vector2 succeededValue, string faultedMessage, bool isSucceeded) : base(succeededValue, faultedMessage, isSucceeded) { }
	}
	[Serializable]
	public class Vector3SerializableTryProperty : SerializableTryPropertyBase<Vector3> {
		public Vector3SerializableTryProperty() : base() { }
		public Vector3SerializableTryProperty(Vector3 succeededValue, string faultedMessage, bool isSucceeded) : base(succeededValue, faultedMessage, isSucceeded) { }
	}
	[Serializable]
	public class Vector4SerializableTryProperty : SerializableTryPropertyBase<Vector4> {
		public Vector4SerializableTryProperty() : base() { }
		public Vector4SerializableTryProperty(Vector4 succeededValue, string faultedMessage, bool isSucceeded) : base(succeededValue, faultedMessage, isSucceeded) { }
	}
	[Serializable]
	public class ColorSerializableTryProperty : SerializableTryPropertyBase<Color> {
		public ColorSerializableTryProperty() : base() { }
		public ColorSerializableTryProperty(Color succeededValue, string faultedMessage, bool isSucceeded) : base(succeededValue, faultedMessage, isSucceeded) { }
	}
	[Serializable]
	public class AnimationSerializableTryProperty : SerializableTryPropertyBase<Animation> {
		public AnimationSerializableTryProperty() : base() { }
		public AnimationSerializableTryProperty(Animation succeededValue, string faultedMessage, bool isSucceeded) : base(succeededValue, faultedMessage, isSucceeded) { }
	}
	[Serializable]
	public class AnimatorSerializableTryProperty : SerializableTryPropertyBase<Animator> {
		public AnimatorSerializableTryProperty() : base() { }
		public AnimatorSerializableTryProperty(Animator succeededValue, string faultedMessage, bool isSucceeded) : base(succeededValue, faultedMessage, isSucceeded) { }
	}
	[Serializable]
	public class TextureSerializableTryProperty : SerializableTryPropertyBase<Texture> {
		public TextureSerializableTryProperty() : base() { }
		public TextureSerializableTryProperty(Texture succeededValue, string faultedMessage, bool isSucceeded) : base(succeededValue, faultedMessage, isSucceeded) { }
	}
	[Serializable]
	public class Texture2DSerializableTryProperty : SerializableTryPropertyBase<Texture2D> {
		public Texture2DSerializableTryProperty() : base() { }
		public Texture2DSerializableTryProperty(Texture2D succeededValue, string faultedMessage, bool isSucceeded) : base(succeededValue, faultedMessage, isSucceeded) { }
	}
	[Serializable]
	public class SpriteSerializableTryProperty : SerializableTryPropertyBase<Sprite> {
		public SpriteSerializableTryProperty() : base() { }
		public SpriteSerializableTryProperty(Sprite succeededValue, string faultedMessage, bool isSucceeded) : base(succeededValue, faultedMessage, isSucceeded) { }
	}
	[Serializable]
	public class GameObjectSerializableTryProperty : SerializableTryPropertyBase<GameObject> {
		public GameObjectSerializableTryProperty() : base() { }
		public GameObjectSerializableTryProperty(GameObject succeededValue, string faultedMessage, bool isSucceeded) : base(succeededValue, faultedMessage, isSucceeded) { }
	}
}