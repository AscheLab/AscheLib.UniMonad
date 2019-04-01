using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AscheLib;

namespace AscheLib.UniMonad {
	[Serializable]
	public abstract class DrawableSerializableEitherBase {
	}

	[Serializable]
	public abstract class SerializableEitherPropertyBase<TLeft, TRight> : DrawableSerializableEitherBase, IEitherMonad<TLeft, TRight> {
		[SerializeField]
		TLeft _left;
		[SerializeField]
		TRight _right;
		[SerializeField]
		bool _isRight = true;

		public SerializableEitherPropertyBase() {
		}
		public SerializableEitherPropertyBase(TLeft left, TRight right, bool isRight) {
			_left = left;
			_right = right;
			_isRight = isRight;
		}

		public IEitherResult<TLeft, TRight> RunEither () {
			if(_isRight) {
				return Either.ReturnRight<TLeft, TRight>(_right).RunEither();
			}
			else {
				return Either.ReturnLeft<TLeft, TRight>(_left).RunEither();
			}
		}
	}

	[Serializable]
	public class LeftIntRightIntSerializableEitherProperty : SerializableEitherPropertyBase<int, int> {
		public LeftIntRightIntSerializableEitherProperty() : base() { }
		public LeftIntRightIntSerializableEitherProperty(int left, int right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftIntRightLongSerializableEitherProperty : SerializableEitherPropertyBase<int, long> {
		public LeftIntRightLongSerializableEitherProperty() : base() { }
		public LeftIntRightLongSerializableEitherProperty(int left, long right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftIntRightByteSerializableEitherProperty : SerializableEitherPropertyBase<int, byte> {
		public LeftIntRightByteSerializableEitherProperty() : base() { }
		public LeftIntRightByteSerializableEitherProperty(int left, byte right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftIntRightFloatSerializableEitherProperty : SerializableEitherPropertyBase<int, float> {
		public LeftIntRightFloatSerializableEitherProperty() : base() { }
		public LeftIntRightFloatSerializableEitherProperty(int left, float right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftIntRightDoubleSerializableEitherProperty : SerializableEitherPropertyBase<int, double> {
		public LeftIntRightDoubleSerializableEitherProperty() : base() { }
		public LeftIntRightDoubleSerializableEitherProperty(int left, double right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftIntRightStringSerializableEitherProperty : SerializableEitherPropertyBase<int, string> {
		public LeftIntRightStringSerializableEitherProperty() : base() { }
		public LeftIntRightStringSerializableEitherProperty(int left, string right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftIntRightVector2SerializableEitherProperty : SerializableEitherPropertyBase<int, Vector2> {
		public LeftIntRightVector2SerializableEitherProperty() : base() { }
		public LeftIntRightVector2SerializableEitherProperty(int left, Vector2 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftIntRightVector3SerializableEitherProperty : SerializableEitherPropertyBase<int, Vector3> {
		public LeftIntRightVector3SerializableEitherProperty() : base() { }
		public LeftIntRightVector3SerializableEitherProperty(int left, Vector3 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftIntRightVector4SerializableEitherProperty : SerializableEitherPropertyBase<int, Vector4> {
		public LeftIntRightVector4SerializableEitherProperty() : base() { }
		public LeftIntRightVector4SerializableEitherProperty(int left, Vector4 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftIntRightColorSerializableEitherProperty : SerializableEitherPropertyBase<int, Color> {
		public LeftIntRightColorSerializableEitherProperty() : base() { }
		public LeftIntRightColorSerializableEitherProperty(int left, Color right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftIntRightAnimationSerializableEitherProperty : SerializableEitherPropertyBase<int, Animation> {
		public LeftIntRightAnimationSerializableEitherProperty() : base() { }
		public LeftIntRightAnimationSerializableEitherProperty(int left, Animation right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftIntRightAnimatorSerializableEitherProperty : SerializableEitherPropertyBase<int, Animator> {
		public LeftIntRightAnimatorSerializableEitherProperty() : base() { }
		public LeftIntRightAnimatorSerializableEitherProperty(int left, Animator right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftIntRightTextureSerializableEitherProperty : SerializableEitherPropertyBase<int, Texture> {
		public LeftIntRightTextureSerializableEitherProperty() : base() { }
		public LeftIntRightTextureSerializableEitherProperty(int left, Texture right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftIntRightTexture2DSerializableEitherProperty : SerializableEitherPropertyBase<int, Texture2D> {
		public LeftIntRightTexture2DSerializableEitherProperty() : base() { }
		public LeftIntRightTexture2DSerializableEitherProperty(int left, Texture2D right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftIntRightSpriteSerializableEitherProperty : SerializableEitherPropertyBase<int, Sprite> {
		public LeftIntRightSpriteSerializableEitherProperty() : base() { }
		public LeftIntRightSpriteSerializableEitherProperty(int left, Sprite right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftIntRightGameObjectSerializableEitherProperty : SerializableEitherPropertyBase<int, GameObject> {
		public LeftIntRightGameObjectSerializableEitherProperty() : base() { }
		public LeftIntRightGameObjectSerializableEitherProperty(int left, GameObject right, bool isRight) : base(left, right, isRight) { }
	}

	[Serializable]
	public class LeftLongRightIntSerializableEitherProperty : SerializableEitherPropertyBase<long, int> {
		public LeftLongRightIntSerializableEitherProperty() : base() { }
		public LeftLongRightIntSerializableEitherProperty(long left, int right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftLongRightLongSerializableEitherProperty : SerializableEitherPropertyBase<long, long> {
		public LeftLongRightLongSerializableEitherProperty() : base() { }
		public LeftLongRightLongSerializableEitherProperty(long left, long right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftLongRightByteSerializableEitherProperty : SerializableEitherPropertyBase<long, byte> {
		public LeftLongRightByteSerializableEitherProperty() : base() { }
		public LeftLongRightByteSerializableEitherProperty(long left, byte right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftLongRightFloatSerializableEitherProperty : SerializableEitherPropertyBase<long, float> {
		public LeftLongRightFloatSerializableEitherProperty() : base() { }
		public LeftLongRightFloatSerializableEitherProperty(long left, float right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftLongRightDoubleSerializableEitherProperty : SerializableEitherPropertyBase<long, double> {
		public LeftLongRightDoubleSerializableEitherProperty() : base() { }
		public LeftLongRightDoubleSerializableEitherProperty(long left, double right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftLongRightStringSerializableEitherProperty : SerializableEitherPropertyBase<long, string> {
		public LeftLongRightStringSerializableEitherProperty() : base() { }
		public LeftLongRightStringSerializableEitherProperty(long left, string right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftLongRightVector2SerializableEitherProperty : SerializableEitherPropertyBase<long, Vector2> {
		public LeftLongRightVector2SerializableEitherProperty() : base() { }
		public LeftLongRightVector2SerializableEitherProperty(long left, Vector2 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftLongRightVector3SerializableEitherProperty : SerializableEitherPropertyBase<long, Vector3> {
		public LeftLongRightVector3SerializableEitherProperty() : base() { }
		public LeftLongRightVector3SerializableEitherProperty(long left, Vector3 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftLongRightVector4SerializableEitherProperty : SerializableEitherPropertyBase<long, Vector4> {
		public LeftLongRightVector4SerializableEitherProperty() : base() { }
		public LeftLongRightVector4SerializableEitherProperty(long left, Vector4 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftLongRightColorSerializableEitherProperty : SerializableEitherPropertyBase<long, Color> {
		public LeftLongRightColorSerializableEitherProperty() : base() { }
		public LeftLongRightColorSerializableEitherProperty(long left, Color right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftLongRightAnimationSerializableEitherProperty : SerializableEitherPropertyBase<long, Animation> {
		public LeftLongRightAnimationSerializableEitherProperty() : base() { }
		public LeftLongRightAnimationSerializableEitherProperty(long left, Animation right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftLongRightAnimatorSerializableEitherProperty : SerializableEitherPropertyBase<long, Animator> {
		public LeftLongRightAnimatorSerializableEitherProperty() : base() { }
		public LeftLongRightAnimatorSerializableEitherProperty(long left, Animator right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftLongRightTextureSerializableEitherProperty : SerializableEitherPropertyBase<long, Texture> {
		public LeftLongRightTextureSerializableEitherProperty() : base() { }
		public LeftLongRightTextureSerializableEitherProperty(long left, Texture right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftLongRightTexture2DSerializableEitherProperty : SerializableEitherPropertyBase<long, Texture2D> {
		public LeftLongRightTexture2DSerializableEitherProperty() : base() { }
		public LeftLongRightTexture2DSerializableEitherProperty(long left, Texture2D right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftLongRightSpriteSerializableEitherProperty : SerializableEitherPropertyBase<long, Sprite> {
		public LeftLongRightSpriteSerializableEitherProperty() : base() { }
		public LeftLongRightSpriteSerializableEitherProperty(long left, Sprite right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftLongRightGameObjectSerializableEitherProperty : SerializableEitherPropertyBase<long, GameObject> {
		public LeftLongRightGameObjectSerializableEitherProperty() : base() { }
		public LeftLongRightGameObjectSerializableEitherProperty(long left, GameObject right, bool isRight) : base(left, right, isRight) { }
	}

	[Serializable]
	public class LeftByteRightIntSerializableEitherProperty : SerializableEitherPropertyBase<byte, int> {
		public LeftByteRightIntSerializableEitherProperty() : base() { }
		public LeftByteRightIntSerializableEitherProperty(byte left, int right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftByteRightLongSerializableEitherProperty : SerializableEitherPropertyBase<byte, long> {
		public LeftByteRightLongSerializableEitherProperty() : base() { }
		public LeftByteRightLongSerializableEitherProperty(byte left, long right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftByteRightByteSerializableEitherProperty : SerializableEitherPropertyBase<byte, byte> {
		public LeftByteRightByteSerializableEitherProperty() : base() { }
		public LeftByteRightByteSerializableEitherProperty(byte left, byte right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftByteRightFloatSerializableEitherProperty : SerializableEitherPropertyBase<byte, float> {
		public LeftByteRightFloatSerializableEitherProperty() : base() { }
		public LeftByteRightFloatSerializableEitherProperty(byte left, float right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftByteRightDoubleSerializableEitherProperty : SerializableEitherPropertyBase<byte, double> {
		public LeftByteRightDoubleSerializableEitherProperty() : base() { }
		public LeftByteRightDoubleSerializableEitherProperty(byte left, double right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftByteRightStringSerializableEitherProperty : SerializableEitherPropertyBase<byte, string> {
		public LeftByteRightStringSerializableEitherProperty() : base() { }
		public LeftByteRightStringSerializableEitherProperty(byte left, string right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftByteRightVector2SerializableEitherProperty : SerializableEitherPropertyBase<byte, Vector2> {
		public LeftByteRightVector2SerializableEitherProperty() : base() { }
		public LeftByteRightVector2SerializableEitherProperty(byte left, Vector2 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftByteRightVector3SerializableEitherProperty : SerializableEitherPropertyBase<byte, Vector3> {
		public LeftByteRightVector3SerializableEitherProperty() : base() { }
		public LeftByteRightVector3SerializableEitherProperty(byte left, Vector3 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftByteRightVector4SerializableEitherProperty : SerializableEitherPropertyBase<byte, Vector4> {
		public LeftByteRightVector4SerializableEitherProperty() : base() { }
		public LeftByteRightVector4SerializableEitherProperty(byte left, Vector4 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftByteRightColorSerializableEitherProperty : SerializableEitherPropertyBase<byte, Color> {
		public LeftByteRightColorSerializableEitherProperty() : base() { }
		public LeftByteRightColorSerializableEitherProperty(byte left, Color right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftByteRightAnimationSerializableEitherProperty : SerializableEitherPropertyBase<byte, Animation> {
		public LeftByteRightAnimationSerializableEitherProperty() : base() { }
		public LeftByteRightAnimationSerializableEitherProperty(byte left, Animation right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftByteRightAnimatorSerializableEitherProperty : SerializableEitherPropertyBase<byte, Animator> {
		public LeftByteRightAnimatorSerializableEitherProperty() : base() { }
		public LeftByteRightAnimatorSerializableEitherProperty(byte left, Animator right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftByteRightTextureSerializableEitherProperty : SerializableEitherPropertyBase<byte, Texture> {
		public LeftByteRightTextureSerializableEitherProperty() : base() { }
		public LeftByteRightTextureSerializableEitherProperty(byte left, Texture right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftByteRightTexture2DSerializableEitherProperty : SerializableEitherPropertyBase<byte, Texture2D> {
		public LeftByteRightTexture2DSerializableEitherProperty() : base() { }
		public LeftByteRightTexture2DSerializableEitherProperty(byte left, Texture2D right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftByteRightSpriteSerializableEitherProperty : SerializableEitherPropertyBase<byte, Sprite> {
		public LeftByteRightSpriteSerializableEitherProperty() : base() { }
		public LeftByteRightSpriteSerializableEitherProperty(byte left, Sprite right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftByteRightGameObjectSerializableEitherProperty : SerializableEitherPropertyBase<byte, GameObject> {
		public LeftByteRightGameObjectSerializableEitherProperty() : base() { }
		public LeftByteRightGameObjectSerializableEitherProperty(byte left, GameObject right, bool isRight) : base(left, right, isRight) { }
	}

	[Serializable]
	public class LeftFloatRightIntSerializableEitherProperty : SerializableEitherPropertyBase<float, int> {
		public LeftFloatRightIntSerializableEitherProperty() : base() { }
		public LeftFloatRightIntSerializableEitherProperty(float left, int right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftFloatRightLongSerializableEitherProperty : SerializableEitherPropertyBase<float, long> {
		public LeftFloatRightLongSerializableEitherProperty() : base() { }
		public LeftFloatRightLongSerializableEitherProperty(float left, long right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftFloatRightByteSerializableEitherProperty : SerializableEitherPropertyBase<float, byte> {
		public LeftFloatRightByteSerializableEitherProperty() : base() { }
		public LeftFloatRightByteSerializableEitherProperty(float left, byte right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftFloatRightFloatSerializableEitherProperty : SerializableEitherPropertyBase<float, float> {
		public LeftFloatRightFloatSerializableEitherProperty() : base() { }
		public LeftFloatRightFloatSerializableEitherProperty(float left, float right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftFloatRightDoubleSerializableEitherProperty : SerializableEitherPropertyBase<float, double> {
		public LeftFloatRightDoubleSerializableEitherProperty() : base() { }
		public LeftFloatRightDoubleSerializableEitherProperty(float left, double right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftFloatRightStringSerializableEitherProperty : SerializableEitherPropertyBase<float, string> {
		public LeftFloatRightStringSerializableEitherProperty() : base() { }
		public LeftFloatRightStringSerializableEitherProperty(float left, string right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftFloatRightVector2SerializableEitherProperty : SerializableEitherPropertyBase<float, Vector2> {
		public LeftFloatRightVector2SerializableEitherProperty() : base() { }
		public LeftFloatRightVector2SerializableEitherProperty(float left, Vector2 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftFloatRightVector3SerializableEitherProperty : SerializableEitherPropertyBase<float, Vector3> {
		public LeftFloatRightVector3SerializableEitherProperty() : base() { }
		public LeftFloatRightVector3SerializableEitherProperty(float left, Vector3 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftFloatRightVector4SerializableEitherProperty : SerializableEitherPropertyBase<float, Vector4> {
		public LeftFloatRightVector4SerializableEitherProperty() : base() { }
		public LeftFloatRightVector4SerializableEitherProperty(float left, Vector4 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftFloatRightColorSerializableEitherProperty : SerializableEitherPropertyBase<float, Color> {
		public LeftFloatRightColorSerializableEitherProperty() : base() { }
		public LeftFloatRightColorSerializableEitherProperty(float left, Color right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftFloatRightAnimationSerializableEitherProperty : SerializableEitherPropertyBase<float, Animation> {
		public LeftFloatRightAnimationSerializableEitherProperty() : base() { }
		public LeftFloatRightAnimationSerializableEitherProperty(float left, Animation right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftFloatRightAnimatorSerializableEitherProperty : SerializableEitherPropertyBase<float, Animator> {
		public LeftFloatRightAnimatorSerializableEitherProperty() : base() { }
		public LeftFloatRightAnimatorSerializableEitherProperty(float left, Animator right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftFloatRightTextureSerializableEitherProperty : SerializableEitherPropertyBase<float, Texture> {
		public LeftFloatRightTextureSerializableEitherProperty() : base() { }
		public LeftFloatRightTextureSerializableEitherProperty(float left, Texture right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftFloatRightTexture2DSerializableEitherProperty : SerializableEitherPropertyBase<float, Texture2D> {
		public LeftFloatRightTexture2DSerializableEitherProperty() : base() { }
		public LeftFloatRightTexture2DSerializableEitherProperty(float left, Texture2D right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftFloatRightSpriteSerializableEitherProperty : SerializableEitherPropertyBase<float, Sprite> {
		public LeftFloatRightSpriteSerializableEitherProperty() : base() { }
		public LeftFloatRightSpriteSerializableEitherProperty(float left, Sprite right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftFloatRightGameObjectSerializableEitherProperty : SerializableEitherPropertyBase<float, GameObject> {
		public LeftFloatRightGameObjectSerializableEitherProperty() : base() { }
		public LeftFloatRightGameObjectSerializableEitherProperty(float left, GameObject right, bool isRight) : base(left, right, isRight) { }
	}

	[Serializable]
	public class LeftDoubleRightIntSerializableEitherProperty : SerializableEitherPropertyBase<double, int> {
		public LeftDoubleRightIntSerializableEitherProperty() : base() { }
		public LeftDoubleRightIntSerializableEitherProperty(double left, int right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftDoubleRightLongSerializableEitherProperty : SerializableEitherPropertyBase<double, long> {
		public LeftDoubleRightLongSerializableEitherProperty() : base() { }
		public LeftDoubleRightLongSerializableEitherProperty(double left, long right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftDoubleRightByteSerializableEitherProperty : SerializableEitherPropertyBase<double, byte> {
		public LeftDoubleRightByteSerializableEitherProperty() : base() { }
		public LeftDoubleRightByteSerializableEitherProperty(double left, byte right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftDoubleRightFloatSerializableEitherProperty : SerializableEitherPropertyBase<double, float> {
		public LeftDoubleRightFloatSerializableEitherProperty() : base() { }
		public LeftDoubleRightFloatSerializableEitherProperty(double left, float right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftDoubleRightDoubleSerializableEitherProperty : SerializableEitherPropertyBase<double, double> {
		public LeftDoubleRightDoubleSerializableEitherProperty() : base() { }
		public LeftDoubleRightDoubleSerializableEitherProperty(double left, double right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftDoubleRightStringSerializableEitherProperty : SerializableEitherPropertyBase<double, string> {
		public LeftDoubleRightStringSerializableEitherProperty() : base() { }
		public LeftDoubleRightStringSerializableEitherProperty(double left, string right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftDoubleRightVector2SerializableEitherProperty : SerializableEitherPropertyBase<double, Vector2> {
		public LeftDoubleRightVector2SerializableEitherProperty() : base() { }
		public LeftDoubleRightVector2SerializableEitherProperty(double left, Vector2 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftDoubleRightVector3SerializableEitherProperty : SerializableEitherPropertyBase<double, Vector3> {
		public LeftDoubleRightVector3SerializableEitherProperty() : base() { }
		public LeftDoubleRightVector3SerializableEitherProperty(double left, Vector3 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftDoubleRightVector4SerializableEitherProperty : SerializableEitherPropertyBase<double, Vector4> {
		public LeftDoubleRightVector4SerializableEitherProperty() : base() { }
		public LeftDoubleRightVector4SerializableEitherProperty(double left, Vector4 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftDoubleRightColorSerializableEitherProperty : SerializableEitherPropertyBase<double, Color> {
		public LeftDoubleRightColorSerializableEitherProperty() : base() { }
		public LeftDoubleRightColorSerializableEitherProperty(double left, Color right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftDoubleRightAnimationSerializableEitherProperty : SerializableEitherPropertyBase<double, Animation> {
		public LeftDoubleRightAnimationSerializableEitherProperty() : base() { }
		public LeftDoubleRightAnimationSerializableEitherProperty(double left, Animation right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftDoubleRightAnimatorSerializableEitherProperty : SerializableEitherPropertyBase<double, Animator> {
		public LeftDoubleRightAnimatorSerializableEitherProperty() : base() { }
		public LeftDoubleRightAnimatorSerializableEitherProperty(double left, Animator right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftDoubleRightTextureSerializableEitherProperty : SerializableEitherPropertyBase<double, Texture> {
		public LeftDoubleRightTextureSerializableEitherProperty() : base() { }
		public LeftDoubleRightTextureSerializableEitherProperty(double left, Texture right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftDoubleRightTexture2DSerializableEitherProperty : SerializableEitherPropertyBase<double, Texture2D> {
		public LeftDoubleRightTexture2DSerializableEitherProperty() : base() { }
		public LeftDoubleRightTexture2DSerializableEitherProperty(double left, Texture2D right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftDoubleRightSpriteSerializableEitherProperty : SerializableEitherPropertyBase<double, Sprite> {
		public LeftDoubleRightSpriteSerializableEitherProperty() : base() { }
		public LeftDoubleRightSpriteSerializableEitherProperty(double left, Sprite right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftDoubleRightGameObjectSerializableEitherProperty : SerializableEitherPropertyBase<double, GameObject> {
		public LeftDoubleRightGameObjectSerializableEitherProperty() : base() { }
		public LeftDoubleRightGameObjectSerializableEitherProperty(double left, GameObject right, bool isRight) : base(left, right, isRight) { }
	}

	[Serializable]
	public class LeftStringRightIntSerializableEitherProperty : SerializableEitherPropertyBase<string, int> {
		public LeftStringRightIntSerializableEitherProperty() : base() { }
		public LeftStringRightIntSerializableEitherProperty(string left, int right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftStringRightLongSerializableEitherProperty : SerializableEitherPropertyBase<string, long> {
		public LeftStringRightLongSerializableEitherProperty() : base() { }
		public LeftStringRightLongSerializableEitherProperty(string left, long right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftStringRightByteSerializableEitherProperty : SerializableEitherPropertyBase<string, byte> {
		public LeftStringRightByteSerializableEitherProperty() : base() { }
		public LeftStringRightByteSerializableEitherProperty(string left, byte right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftStringRightFloatSerializableEitherProperty : SerializableEitherPropertyBase<string, float> {
		public LeftStringRightFloatSerializableEitherProperty() : base() { }
		public LeftStringRightFloatSerializableEitherProperty(string left, float right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftStringRightDoubleSerializableEitherProperty : SerializableEitherPropertyBase<string, double> {
		public LeftStringRightDoubleSerializableEitherProperty() : base() { }
		public LeftStringRightDoubleSerializableEitherProperty(string left, double right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftStringRightStringSerializableEitherProperty : SerializableEitherPropertyBase<string, string> {
		public LeftStringRightStringSerializableEitherProperty() : base() { }
		public LeftStringRightStringSerializableEitherProperty(string left, string right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftStringRightVector2SerializableEitherProperty : SerializableEitherPropertyBase<string, Vector2> {
		public LeftStringRightVector2SerializableEitherProperty() : base() { }
		public LeftStringRightVector2SerializableEitherProperty(string left, Vector2 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftStringRightVector3SerializableEitherProperty : SerializableEitherPropertyBase<string, Vector3> {
		public LeftStringRightVector3SerializableEitherProperty() : base() { }
		public LeftStringRightVector3SerializableEitherProperty(string left, Vector3 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftStringRightVector4SerializableEitherProperty : SerializableEitherPropertyBase<string, Vector4> {
		public LeftStringRightVector4SerializableEitherProperty() : base() { }
		public LeftStringRightVector4SerializableEitherProperty(string left, Vector4 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftStringRightColorSerializableEitherProperty : SerializableEitherPropertyBase<string, Color> {
		public LeftStringRightColorSerializableEitherProperty() : base() { }
		public LeftStringRightColorSerializableEitherProperty(string left, Color right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftStringRightAnimationSerializableEitherProperty : SerializableEitherPropertyBase<string, Animation> {
		public LeftStringRightAnimationSerializableEitherProperty() : base() { }
		public LeftStringRightAnimationSerializableEitherProperty(string left, Animation right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftStringRightAnimatorSerializableEitherProperty : SerializableEitherPropertyBase<string, Animator> {
		public LeftStringRightAnimatorSerializableEitherProperty() : base() { }
		public LeftStringRightAnimatorSerializableEitherProperty(string left, Animator right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftStringRightTextureSerializableEitherProperty : SerializableEitherPropertyBase<string, Texture> {
		public LeftStringRightTextureSerializableEitherProperty() : base() { }
		public LeftStringRightTextureSerializableEitherProperty(string left, Texture right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftStringRightTexture2DSerializableEitherProperty : SerializableEitherPropertyBase<string, Texture2D> {
		public LeftStringRightTexture2DSerializableEitherProperty() : base() { }
		public LeftStringRightTexture2DSerializableEitherProperty(string left, Texture2D right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftStringRightSpriteSerializableEitherProperty : SerializableEitherPropertyBase<string, Sprite> {
		public LeftStringRightSpriteSerializableEitherProperty() : base() { }
		public LeftStringRightSpriteSerializableEitherProperty(string left, Sprite right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftStringRightGameObjectSerializableEitherProperty : SerializableEitherPropertyBase<string, GameObject> {
		public LeftStringRightGameObjectSerializableEitherProperty() : base() { }
		public LeftStringRightGameObjectSerializableEitherProperty(string left, GameObject right, bool isRight) : base(left, right, isRight) { }
	}
	
	[Serializable]
	public class LeftVector2RightIntSerializableEitherProperty : SerializableEitherPropertyBase<Vector2, int> {
		public LeftVector2RightIntSerializableEitherProperty() : base() { }
		public LeftVector2RightIntSerializableEitherProperty(Vector2 left, int right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector2RightLongSerializableEitherProperty : SerializableEitherPropertyBase<Vector2, long> {
		public LeftVector2RightLongSerializableEitherProperty() : base() { }
		public LeftVector2RightLongSerializableEitherProperty(Vector2 left, long right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector2RightByteSerializableEitherProperty : SerializableEitherPropertyBase<Vector2, byte> {
		public LeftVector2RightByteSerializableEitherProperty() : base() { }
		public LeftVector2RightByteSerializableEitherProperty(Vector2 left, byte right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector2RightFloatSerializableEitherProperty : SerializableEitherPropertyBase<Vector2, float> {
		public LeftVector2RightFloatSerializableEitherProperty() : base() { }
		public LeftVector2RightFloatSerializableEitherProperty(Vector2 left, float right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector2RightDoubleSerializableEitherProperty : SerializableEitherPropertyBase<Vector2, double> {
		public LeftVector2RightDoubleSerializableEitherProperty() : base() { }
		public LeftVector2RightDoubleSerializableEitherProperty(Vector2 left, double right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector2RightStringSerializableEitherProperty : SerializableEitherPropertyBase<Vector2, string> {
		public LeftVector2RightStringSerializableEitherProperty() : base() { }
		public LeftVector2RightStringSerializableEitherProperty(Vector2 left, string right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector2RightVector2SerializableEitherProperty : SerializableEitherPropertyBase<Vector2, Vector2> {
		public LeftVector2RightVector2SerializableEitherProperty() : base() { }
		public LeftVector2RightVector2SerializableEitherProperty(Vector2 left, Vector2 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector2RightVector3SerializableEitherProperty : SerializableEitherPropertyBase<Vector2, Vector3> {
		public LeftVector2RightVector3SerializableEitherProperty() : base() { }
		public LeftVector2RightVector3SerializableEitherProperty(Vector2 left, Vector3 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector2RightVector4SerializableEitherProperty : SerializableEitherPropertyBase<Vector2, Vector4> {
		public LeftVector2RightVector4SerializableEitherProperty() : base() { }
		public LeftVector2RightVector4SerializableEitherProperty(Vector2 left, Vector4 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector2RightColorSerializableEitherProperty : SerializableEitherPropertyBase<Vector2, Color> {
		public LeftVector2RightColorSerializableEitherProperty() : base() { }
		public LeftVector2RightColorSerializableEitherProperty(Vector2 left, Color right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector2RightAnimationSerializableEitherProperty : SerializableEitherPropertyBase<Vector2, Animation> {
		public LeftVector2RightAnimationSerializableEitherProperty() : base() { }
		public LeftVector2RightAnimationSerializableEitherProperty(Vector2 left, Animation right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector2RightAnimatorSerializableEitherProperty : SerializableEitherPropertyBase<Vector2, Animator> {
		public LeftVector2RightAnimatorSerializableEitherProperty() : base() { }
		public LeftVector2RightAnimatorSerializableEitherProperty(Vector2 left, Animator right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector2RightTextureSerializableEitherProperty : SerializableEitherPropertyBase<Vector2, Texture> {
		public LeftVector2RightTextureSerializableEitherProperty() : base() { }
		public LeftVector2RightTextureSerializableEitherProperty(Vector2 left, Texture right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector2RightTexture2DSerializableEitherProperty : SerializableEitherPropertyBase<Vector2, Texture2D> {
		public LeftVector2RightTexture2DSerializableEitherProperty() : base() { }
		public LeftVector2RightTexture2DSerializableEitherProperty(Vector2 left, Texture2D right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector2RightSpriteSerializableEitherProperty : SerializableEitherPropertyBase<Vector2, Sprite> {
		public LeftVector2RightSpriteSerializableEitherProperty() : base() { }
		public LeftVector2RightSpriteSerializableEitherProperty(Vector2 left, Sprite right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector2RightGameObjectSerializableEitherProperty : SerializableEitherPropertyBase<Vector2, GameObject> {
		public LeftVector2RightGameObjectSerializableEitherProperty() : base() { }
		public LeftVector2RightGameObjectSerializableEitherProperty(Vector2 left, GameObject right, bool isRight) : base(left, right, isRight) { }
	}
	
	[Serializable]
	public class LeftVector3RightIntSerializableEitherProperty : SerializableEitherPropertyBase<Vector3, int> {
		public LeftVector3RightIntSerializableEitherProperty() : base() { }
		public LeftVector3RightIntSerializableEitherProperty(Vector3 left, int right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector3RightLongSerializableEitherProperty : SerializableEitherPropertyBase<Vector3, long> {
		public LeftVector3RightLongSerializableEitherProperty() : base() { }
		public LeftVector3RightLongSerializableEitherProperty(Vector3 left, long right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector3RightByteSerializableEitherProperty : SerializableEitherPropertyBase<Vector3, byte> {
		public LeftVector3RightByteSerializableEitherProperty() : base() { }
		public LeftVector3RightByteSerializableEitherProperty(Vector3 left, byte right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector3RightFloatSerializableEitherProperty : SerializableEitherPropertyBase<Vector3, float> {
		public LeftVector3RightFloatSerializableEitherProperty() : base() { }
		public LeftVector3RightFloatSerializableEitherProperty(Vector3 left, float right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector3RightDoubleSerializableEitherProperty : SerializableEitherPropertyBase<Vector3, double> {
		public LeftVector3RightDoubleSerializableEitherProperty() : base() { }
		public LeftVector3RightDoubleSerializableEitherProperty(Vector3 left, double right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector3RightStringSerializableEitherProperty : SerializableEitherPropertyBase<Vector3, string> {
		public LeftVector3RightStringSerializableEitherProperty() : base() { }
		public LeftVector3RightStringSerializableEitherProperty(Vector3 left, string right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector3RightVector2SerializableEitherProperty : SerializableEitherPropertyBase<Vector3, Vector2> {
		public LeftVector3RightVector2SerializableEitherProperty() : base() { }
		public LeftVector3RightVector2SerializableEitherProperty(Vector3 left, Vector2 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector3RightVector3SerializableEitherProperty : SerializableEitherPropertyBase<Vector3, Vector3> {
		public LeftVector3RightVector3SerializableEitherProperty() : base() { }
		public LeftVector3RightVector3SerializableEitherProperty(Vector3 left, Vector3 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector3RightVector4SerializableEitherProperty : SerializableEitherPropertyBase<Vector3, Vector4> {
		public LeftVector3RightVector4SerializableEitherProperty() : base() { }
		public LeftVector3RightVector4SerializableEitherProperty(Vector3 left, Vector4 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector3RightColorSerializableEitherProperty : SerializableEitherPropertyBase<Vector3, Color> {
		public LeftVector3RightColorSerializableEitherProperty() : base() { }
		public LeftVector3RightColorSerializableEitherProperty(Vector3 left, Color right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector3RightAnimationSerializableEitherProperty : SerializableEitherPropertyBase<Vector3, Animation> {
		public LeftVector3RightAnimationSerializableEitherProperty() : base() { }
		public LeftVector3RightAnimationSerializableEitherProperty(Vector3 left, Animation right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector3RightAnimatorSerializableEitherProperty : SerializableEitherPropertyBase<Vector3, Animator> {
		public LeftVector3RightAnimatorSerializableEitherProperty() : base() { }
		public LeftVector3RightAnimatorSerializableEitherProperty(Vector3 left, Animator right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector3RightTextureSerializableEitherProperty : SerializableEitherPropertyBase<Vector3, Texture> {
		public LeftVector3RightTextureSerializableEitherProperty() : base() { }
		public LeftVector3RightTextureSerializableEitherProperty(Vector3 left, Texture right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector3RightTexture2DSerializableEitherProperty : SerializableEitherPropertyBase<Vector3, Texture2D> {
		public LeftVector3RightTexture2DSerializableEitherProperty() : base() { }
		public LeftVector3RightTexture2DSerializableEitherProperty(Vector3 left, Texture2D right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector3RightSpriteSerializableEitherProperty : SerializableEitherPropertyBase<Vector3, Sprite> {
		public LeftVector3RightSpriteSerializableEitherProperty() : base() { }
		public LeftVector3RightSpriteSerializableEitherProperty(Vector3 left, Sprite right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector3RightGameObjectSerializableEitherProperty : SerializableEitherPropertyBase<Vector3, GameObject> {
		public LeftVector3RightGameObjectSerializableEitherProperty() : base() { }
		public LeftVector3RightGameObjectSerializableEitherProperty(Vector3 left, GameObject right, bool isRight) : base(left, right, isRight) { }
	}
	
	[Serializable]
	public class LeftVector4RightIntSerializableEitherProperty : SerializableEitherPropertyBase<Vector4, int> {
		public LeftVector4RightIntSerializableEitherProperty() : base() { }
		public LeftVector4RightIntSerializableEitherProperty(Vector4 left, int right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector4RightLongSerializableEitherProperty : SerializableEitherPropertyBase<Vector4, long> {
		public LeftVector4RightLongSerializableEitherProperty() : base() { }
		public LeftVector4RightLongSerializableEitherProperty(Vector4 left, long right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector4RightByteSerializableEitherProperty : SerializableEitherPropertyBase<Vector4, byte> {
		public LeftVector4RightByteSerializableEitherProperty() : base() { }
		public LeftVector4RightByteSerializableEitherProperty(Vector4 left, byte right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector4RightFloatSerializableEitherProperty : SerializableEitherPropertyBase<Vector4, float> {
		public LeftVector4RightFloatSerializableEitherProperty() : base() { }
		public LeftVector4RightFloatSerializableEitherProperty(Vector4 left, float right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector4RightDoubleSerializableEitherProperty : SerializableEitherPropertyBase<Vector4, double> {
		public LeftVector4RightDoubleSerializableEitherProperty() : base() { }
		public LeftVector4RightDoubleSerializableEitherProperty(Vector4 left, double right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector4RightStringSerializableEitherProperty : SerializableEitherPropertyBase<Vector4, string> {
		public LeftVector4RightStringSerializableEitherProperty() : base() { }
		public LeftVector4RightStringSerializableEitherProperty(Vector4 left, string right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector4RightVector2SerializableEitherProperty : SerializableEitherPropertyBase<Vector4, Vector2> {
		public LeftVector4RightVector2SerializableEitherProperty() : base() { }
		public LeftVector4RightVector2SerializableEitherProperty(Vector4 left, Vector2 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector4RightVector3SerializableEitherProperty : SerializableEitherPropertyBase<Vector4, Vector3> {
		public LeftVector4RightVector3SerializableEitherProperty() : base() { }
		public LeftVector4RightVector3SerializableEitherProperty(Vector4 left, Vector3 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector4RightVector4SerializableEitherProperty : SerializableEitherPropertyBase<Vector4, Vector4> {
		public LeftVector4RightVector4SerializableEitherProperty() : base() { }
		public LeftVector4RightVector4SerializableEitherProperty(Vector4 left, Vector4 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector4RightColorSerializableEitherProperty : SerializableEitherPropertyBase<Vector4, Color> {
		public LeftVector4RightColorSerializableEitherProperty() : base() { }
		public LeftVector4RightColorSerializableEitherProperty(Vector4 left, Color right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector4RightAnimationSerializableEitherProperty : SerializableEitherPropertyBase<Vector4, Animation> {
		public LeftVector4RightAnimationSerializableEitherProperty() : base() { }
		public LeftVector4RightAnimationSerializableEitherProperty(Vector4 left, Animation right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector4RightAnimatorSerializableEitherProperty : SerializableEitherPropertyBase<Vector4, Animator> {
		public LeftVector4RightAnimatorSerializableEitherProperty() : base() { }
		public LeftVector4RightAnimatorSerializableEitherProperty(Vector4 left, Animator right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector4RightTextureSerializableEitherProperty : SerializableEitherPropertyBase<Vector4, Texture> {
		public LeftVector4RightTextureSerializableEitherProperty() : base() { }
		public LeftVector4RightTextureSerializableEitherProperty(Vector4 left, Texture right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector4RightTexture2DSerializableEitherProperty : SerializableEitherPropertyBase<Vector4, Texture2D> {
		public LeftVector4RightTexture2DSerializableEitherProperty() : base() { }
		public LeftVector4RightTexture2DSerializableEitherProperty(Vector4 left, Texture2D right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector4RightSpriteSerializableEitherProperty : SerializableEitherPropertyBase<Vector4, Sprite> {
		public LeftVector4RightSpriteSerializableEitherProperty() : base() { }
		public LeftVector4RightSpriteSerializableEitherProperty(Vector4 left, Sprite right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftVector4RightGameObjectSerializableEitherProperty : SerializableEitherPropertyBase<Vector4, GameObject> {
		public LeftVector4RightGameObjectSerializableEitherProperty() : base() { }
		public LeftVector4RightGameObjectSerializableEitherProperty(Vector4 left, GameObject right, bool isRight) : base(left, right, isRight) { }
	}
	
	[Serializable]
	public class LeftColorRightIntSerializableEitherProperty : SerializableEitherPropertyBase<Color, int> {
		public LeftColorRightIntSerializableEitherProperty() : base() { }
		public LeftColorRightIntSerializableEitherProperty(Color left, int right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftColorRightLongSerializableEitherProperty : SerializableEitherPropertyBase<Color, long> {
		public LeftColorRightLongSerializableEitherProperty() : base() { }
		public LeftColorRightLongSerializableEitherProperty(Color left, long right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftColorRightByteSerializableEitherProperty : SerializableEitherPropertyBase<Color, byte> {
		public LeftColorRightByteSerializableEitherProperty() : base() { }
		public LeftColorRightByteSerializableEitherProperty(Color left, byte right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftColorRightFloatSerializableEitherProperty : SerializableEitherPropertyBase<Color, float> {
		public LeftColorRightFloatSerializableEitherProperty() : base() { }
		public LeftColorRightFloatSerializableEitherProperty(Color left, float right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftColorRightDoubleSerializableEitherProperty : SerializableEitherPropertyBase<Color, double> {
		public LeftColorRightDoubleSerializableEitherProperty() : base() { }
		public LeftColorRightDoubleSerializableEitherProperty(Color left, double right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftColorRightStringSerializableEitherProperty : SerializableEitherPropertyBase<Color, string> {
		public LeftColorRightStringSerializableEitherProperty() : base() { }
		public LeftColorRightStringSerializableEitherProperty(Color left, string right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftColorRightVector2SerializableEitherProperty : SerializableEitherPropertyBase<Color, Vector2> {
		public LeftColorRightVector2SerializableEitherProperty() : base() { }
		public LeftColorRightVector2SerializableEitherProperty(Color left, Vector2 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftColorRightVector3SerializableEitherProperty : SerializableEitherPropertyBase<Color, Vector3> {
		public LeftColorRightVector3SerializableEitherProperty() : base() { }
		public LeftColorRightVector3SerializableEitherProperty(Color left, Vector3 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftColorRightVector4SerializableEitherProperty : SerializableEitherPropertyBase<Color, Vector4> {
		public LeftColorRightVector4SerializableEitherProperty() : base() { }
		public LeftColorRightVector4SerializableEitherProperty(Color left, Vector4 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftColorRightColorSerializableEitherProperty : SerializableEitherPropertyBase<Color, Color> {
		public LeftColorRightColorSerializableEitherProperty() : base() { }
		public LeftColorRightColorSerializableEitherProperty(Color left, Color right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftColorRightAnimationSerializableEitherProperty : SerializableEitherPropertyBase<Color, Animation> {
		public LeftColorRightAnimationSerializableEitherProperty() : base() { }
		public LeftColorRightAnimationSerializableEitherProperty(Color left, Animation right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftColorRightAnimatorSerializableEitherProperty : SerializableEitherPropertyBase<Color, Animator> {
		public LeftColorRightAnimatorSerializableEitherProperty() : base() { }
		public LeftColorRightAnimatorSerializableEitherProperty(Color left, Animator right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftColorRightTextureSerializableEitherProperty : SerializableEitherPropertyBase<Color, Texture> {
		public LeftColorRightTextureSerializableEitherProperty() : base() { }
		public LeftColorRightTextureSerializableEitherProperty(Color left, Texture right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftColorRightTexture2DSerializableEitherProperty : SerializableEitherPropertyBase<Color, Texture2D> {
		public LeftColorRightTexture2DSerializableEitherProperty() : base() { }
		public LeftColorRightTexture2DSerializableEitherProperty(Color left, Texture2D right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftColorRightSpriteSerializableEitherProperty : SerializableEitherPropertyBase<Color, Sprite> {
		public LeftColorRightSpriteSerializableEitherProperty() : base() { }
		public LeftColorRightSpriteSerializableEitherProperty(Color left, Sprite right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftColorRightGameObjectSerializableEitherProperty : SerializableEitherPropertyBase<Color, GameObject> {
		public LeftColorRightGameObjectSerializableEitherProperty() : base() { }
		public LeftColorRightGameObjectSerializableEitherProperty(Color left, GameObject right, bool isRight) : base(left, right, isRight) { }
	}
	
	[Serializable]
	public class LeftAnimationRightIntSerializableEitherProperty : SerializableEitherPropertyBase<Animation, int> {
		public LeftAnimationRightIntSerializableEitherProperty() : base() { }
		public LeftAnimationRightIntSerializableEitherProperty(Animation left, int right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimationRightLongSerializableEitherProperty : SerializableEitherPropertyBase<Animation, long> {
		public LeftAnimationRightLongSerializableEitherProperty() : base() { }
		public LeftAnimationRightLongSerializableEitherProperty(Animation left, long right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimationRightByteSerializableEitherProperty : SerializableEitherPropertyBase<Animation, byte> {
		public LeftAnimationRightByteSerializableEitherProperty() : base() { }
		public LeftAnimationRightByteSerializableEitherProperty(Animation left, byte right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimationRightFloatSerializableEitherProperty : SerializableEitherPropertyBase<Animation, float> {
		public LeftAnimationRightFloatSerializableEitherProperty() : base() { }
		public LeftAnimationRightFloatSerializableEitherProperty(Animation left, float right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimationRightDoubleSerializableEitherProperty : SerializableEitherPropertyBase<Animation, double> {
		public LeftAnimationRightDoubleSerializableEitherProperty() : base() { }
		public LeftAnimationRightDoubleSerializableEitherProperty(Animation left, double right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimationRightStringSerializableEitherProperty : SerializableEitherPropertyBase<Animation, string> {
		public LeftAnimationRightStringSerializableEitherProperty() : base() { }
		public LeftAnimationRightStringSerializableEitherProperty(Animation left, string right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimationRightVector2SerializableEitherProperty : SerializableEitherPropertyBase<Animation, Vector2> {
		public LeftAnimationRightVector2SerializableEitherProperty() : base() { }
		public LeftAnimationRightVector2SerializableEitherProperty(Animation left, Vector2 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimationRightVector3SerializableEitherProperty : SerializableEitherPropertyBase<Animation, Vector3> {
		public LeftAnimationRightVector3SerializableEitherProperty() : base() { }
		public LeftAnimationRightVector3SerializableEitherProperty(Animation left, Vector3 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimationRightVector4SerializableEitherProperty : SerializableEitherPropertyBase<Animation, Vector4> {
		public LeftAnimationRightVector4SerializableEitherProperty() : base() { }
		public LeftAnimationRightVector4SerializableEitherProperty(Animation left, Vector4 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimationRightColorSerializableEitherProperty : SerializableEitherPropertyBase<Animation, Color> {
		public LeftAnimationRightColorSerializableEitherProperty() : base() { }
		public LeftAnimationRightColorSerializableEitherProperty(Animation left, Color right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimationRightAnimationSerializableEitherProperty : SerializableEitherPropertyBase<Animation, Animation> {
		public LeftAnimationRightAnimationSerializableEitherProperty() : base() { }
		public LeftAnimationRightAnimationSerializableEitherProperty(Animation left, Animation right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimationRightAnimatorSerializableEitherProperty : SerializableEitherPropertyBase<Animation, Animator> {
		public LeftAnimationRightAnimatorSerializableEitherProperty() : base() { }
		public LeftAnimationRightAnimatorSerializableEitherProperty(Animation left, Animator right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimationRightTextureSerializableEitherProperty : SerializableEitherPropertyBase<Animation, Texture> {
		public LeftAnimationRightTextureSerializableEitherProperty() : base() { }
		public LeftAnimationRightTextureSerializableEitherProperty(Animation left, Texture right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimationRightTexture2DSerializableEitherProperty : SerializableEitherPropertyBase<Animation, Texture2D> {
		public LeftAnimationRightTexture2DSerializableEitherProperty() : base() { }
		public LeftAnimationRightTexture2DSerializableEitherProperty(Animation left, Texture2D right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimationRightSpriteSerializableEitherProperty : SerializableEitherPropertyBase<Animation, Sprite> {
		public LeftAnimationRightSpriteSerializableEitherProperty() : base() { }
		public LeftAnimationRightSpriteSerializableEitherProperty(Animation left, Sprite right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimationRightGameObjectSerializableEitherProperty : SerializableEitherPropertyBase<Animation, GameObject> {
		public LeftAnimationRightGameObjectSerializableEitherProperty() : base() { }
		public LeftAnimationRightGameObjectSerializableEitherProperty(Animation left, GameObject right, bool isRight) : base(left, right, isRight) { }
	}
	
	[Serializable]
	public class LeftAnimatorRightIntSerializableEitherProperty : SerializableEitherPropertyBase<Animator, int> {
		public LeftAnimatorRightIntSerializableEitherProperty() : base() { }
		public LeftAnimatorRightIntSerializableEitherProperty(Animator left, int right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimatorRightLongSerializableEitherProperty : SerializableEitherPropertyBase<Animator, long> {
		public LeftAnimatorRightLongSerializableEitherProperty() : base() { }
		public LeftAnimatorRightLongSerializableEitherProperty(Animator left, long right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimatorRightByteSerializableEitherProperty : SerializableEitherPropertyBase<Animator, byte> {
		public LeftAnimatorRightByteSerializableEitherProperty() : base() { }
		public LeftAnimatorRightByteSerializableEitherProperty(Animator left, byte right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimatorRightFloatSerializableEitherProperty : SerializableEitherPropertyBase<Animator, float> {
		public LeftAnimatorRightFloatSerializableEitherProperty() : base() { }
		public LeftAnimatorRightFloatSerializableEitherProperty(Animator left, float right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimatorRightDoubleSerializableEitherProperty : SerializableEitherPropertyBase<Animator, double> {
		public LeftAnimatorRightDoubleSerializableEitherProperty() : base() { }
		public LeftAnimatorRightDoubleSerializableEitherProperty(Animator left, double right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimatorRightStringSerializableEitherProperty : SerializableEitherPropertyBase<Animator, string> {
		public LeftAnimatorRightStringSerializableEitherProperty() : base() { }
		public LeftAnimatorRightStringSerializableEitherProperty(Animator left, string right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimatorRightVector2SerializableEitherProperty : SerializableEitherPropertyBase<Animator, Vector2> {
		public LeftAnimatorRightVector2SerializableEitherProperty() : base() { }
		public LeftAnimatorRightVector2SerializableEitherProperty(Animator left, Vector2 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimatorRightVector3SerializableEitherProperty : SerializableEitherPropertyBase<Animator, Vector3> {
		public LeftAnimatorRightVector3SerializableEitherProperty() : base() { }
		public LeftAnimatorRightVector3SerializableEitherProperty(Animator left, Vector3 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimatorRightVector4SerializableEitherProperty : SerializableEitherPropertyBase<Animator, Vector4> {
		public LeftAnimatorRightVector4SerializableEitherProperty() : base() { }
		public LeftAnimatorRightVector4SerializableEitherProperty(Animator left, Vector4 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimatorRightColorSerializableEitherProperty : SerializableEitherPropertyBase<Animator, Color> {
		public LeftAnimatorRightColorSerializableEitherProperty() : base() { }
		public LeftAnimatorRightColorSerializableEitherProperty(Animator left, Color right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimatorRightAnimationSerializableEitherProperty : SerializableEitherPropertyBase<Animator, Animation> {
		public LeftAnimatorRightAnimationSerializableEitherProperty() : base() { }
		public LeftAnimatorRightAnimationSerializableEitherProperty(Animator left, Animation right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimatorRightAnimatorSerializableEitherProperty : SerializableEitherPropertyBase<Animator, Animator> {
		public LeftAnimatorRightAnimatorSerializableEitherProperty() : base() { }
		public LeftAnimatorRightAnimatorSerializableEitherProperty(Animator left, Animator right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimatorRightTextureSerializableEitherProperty : SerializableEitherPropertyBase<Animator, Texture> {
		public LeftAnimatorRightTextureSerializableEitherProperty() : base() { }
		public LeftAnimatorRightTextureSerializableEitherProperty(Animator left, Texture right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimatorRightTexture2DSerializableEitherProperty : SerializableEitherPropertyBase<Animator, Texture2D> {
		public LeftAnimatorRightTexture2DSerializableEitherProperty() : base() { }
		public LeftAnimatorRightTexture2DSerializableEitherProperty(Animator left, Texture2D right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimatorRightSpriteSerializableEitherProperty : SerializableEitherPropertyBase<Animator, Sprite> {
		public LeftAnimatorRightSpriteSerializableEitherProperty() : base() { }
		public LeftAnimatorRightSpriteSerializableEitherProperty(Animator left, Sprite right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftAnimatorRightGameObjectSerializableEitherProperty : SerializableEitherPropertyBase<Animator, GameObject> {
		public LeftAnimatorRightGameObjectSerializableEitherProperty() : base() { }
		public LeftAnimatorRightGameObjectSerializableEitherProperty(Animator left, GameObject right, bool isRight) : base(left, right, isRight) { }
	}
	
	[Serializable]
	public class LeftTextureRightIntSerializableEitherProperty : SerializableEitherPropertyBase<Texture, int> {
		public LeftTextureRightIntSerializableEitherProperty() : base() { }
		public LeftTextureRightIntSerializableEitherProperty(Texture left, int right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTextureRightLongSerializableEitherProperty : SerializableEitherPropertyBase<Texture, long> {
		public LeftTextureRightLongSerializableEitherProperty() : base() { }
		public LeftTextureRightLongSerializableEitherProperty(Texture left, long right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTextureRightByteSerializableEitherProperty : SerializableEitherPropertyBase<Texture, byte> {
		public LeftTextureRightByteSerializableEitherProperty() : base() { }
		public LeftTextureRightByteSerializableEitherProperty(Texture left, byte right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTextureRightFloatSerializableEitherProperty : SerializableEitherPropertyBase<Texture, float> {
		public LeftTextureRightFloatSerializableEitherProperty() : base() { }
		public LeftTextureRightFloatSerializableEitherProperty(Texture left, float right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTextureRightDoubleSerializableEitherProperty : SerializableEitherPropertyBase<Texture, double> {
		public LeftTextureRightDoubleSerializableEitherProperty() : base() { }
		public LeftTextureRightDoubleSerializableEitherProperty(Texture left, double right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTextureRightStringSerializableEitherProperty : SerializableEitherPropertyBase<Texture, string> {
		public LeftTextureRightStringSerializableEitherProperty() : base() { }
		public LeftTextureRightStringSerializableEitherProperty(Texture left, string right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTextureRightVector2SerializableEitherProperty : SerializableEitherPropertyBase<Texture, Vector2> {
		public LeftTextureRightVector2SerializableEitherProperty() : base() { }
		public LeftTextureRightVector2SerializableEitherProperty(Texture left, Vector2 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTextureRightVector3SerializableEitherProperty : SerializableEitherPropertyBase<Texture, Vector3> {
		public LeftTextureRightVector3SerializableEitherProperty() : base() { }
		public LeftTextureRightVector3SerializableEitherProperty(Texture left, Vector3 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTextureRightVector4SerializableEitherProperty : SerializableEitherPropertyBase<Texture, Vector4> {
		public LeftTextureRightVector4SerializableEitherProperty() : base() { }
		public LeftTextureRightVector4SerializableEitherProperty(Texture left, Vector4 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTextureRightColorSerializableEitherProperty : SerializableEitherPropertyBase<Texture, Color> {
		public LeftTextureRightColorSerializableEitherProperty() : base() { }
		public LeftTextureRightColorSerializableEitherProperty(Texture left, Color right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTextureRightAnimationSerializableEitherProperty : SerializableEitherPropertyBase<Texture, Animation> {
		public LeftTextureRightAnimationSerializableEitherProperty() : base() { }
		public LeftTextureRightAnimationSerializableEitherProperty(Texture left, Animation right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTextureRightAnimatorSerializableEitherProperty : SerializableEitherPropertyBase<Texture, Animator> {
		public LeftTextureRightAnimatorSerializableEitherProperty() : base() { }
		public LeftTextureRightAnimatorSerializableEitherProperty(Texture left, Animator right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTextureRightTextureSerializableEitherProperty : SerializableEitherPropertyBase<Texture, Texture> {
		public LeftTextureRightTextureSerializableEitherProperty() : base() { }
		public LeftTextureRightTextureSerializableEitherProperty(Texture left, Texture right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTextureRightTexture2DSerializableEitherProperty : SerializableEitherPropertyBase<Texture, Texture2D> {
		public LeftTextureRightTexture2DSerializableEitherProperty() : base() { }
		public LeftTextureRightTexture2DSerializableEitherProperty(Texture left, Texture2D right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTextureRightSpriteSerializableEitherProperty : SerializableEitherPropertyBase<Texture, Sprite> {
		public LeftTextureRightSpriteSerializableEitherProperty() : base() { }
		public LeftTextureRightSpriteSerializableEitherProperty(Texture left, Sprite right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTextureRightGameObjectSerializableEitherProperty : SerializableEitherPropertyBase<Texture, GameObject> {
		public LeftTextureRightGameObjectSerializableEitherProperty() : base() { }
		public LeftTextureRightGameObjectSerializableEitherProperty(Texture left, GameObject right, bool isRight) : base(left, right, isRight) { }
	}
	
	[Serializable]
	public class LeftTexture2DRightIntSerializableEitherProperty : SerializableEitherPropertyBase<Texture2D, int> {
		public LeftTexture2DRightIntSerializableEitherProperty() : base() { }
		public LeftTexture2DRightIntSerializableEitherProperty(Texture2D left, int right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTexture2DRightLongSerializableEitherProperty : SerializableEitherPropertyBase<Texture2D, long> {
		public LeftTexture2DRightLongSerializableEitherProperty() : base() { }
		public LeftTexture2DRightLongSerializableEitherProperty(Texture2D left, long right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTexture2DRightByteSerializableEitherProperty : SerializableEitherPropertyBase<Texture2D, byte> {
		public LeftTexture2DRightByteSerializableEitherProperty() : base() { }
		public LeftTexture2DRightByteSerializableEitherProperty(Texture2D left, byte right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTexture2DRightFloatSerializableEitherProperty : SerializableEitherPropertyBase<Texture2D, float> {
		public LeftTexture2DRightFloatSerializableEitherProperty() : base() { }
		public LeftTexture2DRightFloatSerializableEitherProperty(Texture2D left, float right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTexture2DRightDoubleSerializableEitherProperty : SerializableEitherPropertyBase<Texture2D, double> {
		public LeftTexture2DRightDoubleSerializableEitherProperty() : base() { }
		public LeftTexture2DRightDoubleSerializableEitherProperty(Texture2D left, double right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTexture2DRightStringSerializableEitherProperty : SerializableEitherPropertyBase<Texture2D, string> {
		public LeftTexture2DRightStringSerializableEitherProperty () : base() { }
		public LeftTexture2DRightStringSerializableEitherProperty(Texture2D left, string right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTexture2DRightVector2SerializableEitherProperty : SerializableEitherPropertyBase<Texture2D, Vector2> {
		public LeftTexture2DRightVector2SerializableEitherProperty () : base() { }
		public LeftTexture2DRightVector2SerializableEitherProperty(Texture2D left, Vector2 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTexture2DRightVector3SerializableEitherProperty : SerializableEitherPropertyBase<Texture2D, Vector3> {
		public LeftTexture2DRightVector3SerializableEitherProperty() : base() { }
		public LeftTexture2DRightVector3SerializableEitherProperty(Texture2D left, Vector3 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTexture2DRightVector4SerializableEitherProperty : SerializableEitherPropertyBase<Texture2D, Vector4> {
		public LeftTexture2DRightVector4SerializableEitherProperty() : base() { }
		public LeftTexture2DRightVector4SerializableEitherProperty(Texture2D left, Vector4 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTexture2DRightColorSerializableEitherProperty : SerializableEitherPropertyBase<Texture2D, Color> {
		public LeftTexture2DRightColorSerializableEitherProperty() : base() { }
		public LeftTexture2DRightColorSerializableEitherProperty(Texture2D left, Color right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTexture2DRightAnimationSerializableEitherProperty : SerializableEitherPropertyBase<Texture2D, Animation> {
		public LeftTexture2DRightAnimationSerializableEitherProperty() : base() { }
		public LeftTexture2DRightAnimationSerializableEitherProperty(Texture2D left, Animation right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTexture2DRightAnimatorSerializableEitherProperty : SerializableEitherPropertyBase<Texture2D, Animator> {
		public LeftTexture2DRightAnimatorSerializableEitherProperty() : base() { }
		public LeftTexture2DRightAnimatorSerializableEitherProperty(Texture2D left, Animator right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTexture2DRightTextureSerializableEitherProperty : SerializableEitherPropertyBase<Texture2D, Texture> {
		public LeftTexture2DRightTextureSerializableEitherProperty() : base() { }
		public LeftTexture2DRightTextureSerializableEitherProperty(Texture2D left, Texture right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTexture2DRightTexture2DSerializableEitherProperty : SerializableEitherPropertyBase<Texture2D, Texture2D> {
		public LeftTexture2DRightTexture2DSerializableEitherProperty() : base() { }
		public LeftTexture2DRightTexture2DSerializableEitherProperty(Texture2D left, Texture2D right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTexture2DRightSpriteSerializableEitherProperty : SerializableEitherPropertyBase<Texture2D, Sprite> {
		public LeftTexture2DRightSpriteSerializableEitherProperty() : base() { }
		public LeftTexture2DRightSpriteSerializableEitherProperty(Texture2D left, Sprite right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftTexture2DRightGameObjectSerializableEitherProperty : SerializableEitherPropertyBase<Texture2D, GameObject> {
		public LeftTexture2DRightGameObjectSerializableEitherProperty() : base() { }
		public LeftTexture2DRightGameObjectSerializableEitherProperty(Texture2D left, GameObject right, bool isRight) : base(left, right, isRight) { }
	}
	
	[Serializable]
	public class LeftSpriteRightIntSerializableEitherProperty : SerializableEitherPropertyBase<Sprite, int> {
		public LeftSpriteRightIntSerializableEitherProperty() : base() { }
		public LeftSpriteRightIntSerializableEitherProperty(Sprite left, int right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftSpriteRightLongSerializableEitherProperty : SerializableEitherPropertyBase<Sprite, long> {
		public LeftSpriteRightLongSerializableEitherProperty() : base() { }
		public LeftSpriteRightLongSerializableEitherProperty(Sprite left, long right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftSpriteRightByteSerializableEitherProperty : SerializableEitherPropertyBase<Sprite, byte> {
		public LeftSpriteRightByteSerializableEitherProperty() : base() { }
		public LeftSpriteRightByteSerializableEitherProperty(Sprite left, byte right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftSpriteRightFloatSerializableEitherProperty : SerializableEitherPropertyBase<Sprite, float> {
		public LeftSpriteRightFloatSerializableEitherProperty() : base() { }
		public LeftSpriteRightFloatSerializableEitherProperty(Sprite left, float right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftSpriteRightDoubleSerializableEitherProperty : SerializableEitherPropertyBase<Sprite, double> {
		public LeftSpriteRightDoubleSerializableEitherProperty() : base() { }
		public LeftSpriteRightDoubleSerializableEitherProperty(Sprite left, double right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftSpriteRightStringSerializableEitherProperty : SerializableEitherPropertyBase<Sprite, string> {
		public LeftSpriteRightStringSerializableEitherProperty () : base() { }
		public LeftSpriteRightStringSerializableEitherProperty(Sprite left, string right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftSpriteRightVector2SerializableEitherProperty : SerializableEitherPropertyBase<Sprite, Vector2> {
		public LeftSpriteRightVector2SerializableEitherProperty () : base() { }
		public LeftSpriteRightVector2SerializableEitherProperty(Sprite left, Vector2 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftSpriteRightVector3SerializableEitherProperty : SerializableEitherPropertyBase<Sprite, Vector3> {
		public LeftSpriteRightVector3SerializableEitherProperty() : base() { }
		public LeftSpriteRightVector3SerializableEitherProperty(Sprite left, Vector3 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftSpriteRightVector4SerializableEitherProperty : SerializableEitherPropertyBase<Sprite, Vector4> {
		public LeftSpriteRightVector4SerializableEitherProperty() : base() { }
		public LeftSpriteRightVector4SerializableEitherProperty(Sprite left, Vector4 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftSpriteRightColorSerializableEitherProperty : SerializableEitherPropertyBase<Sprite, Color> {
		public LeftSpriteRightColorSerializableEitherProperty() : base() { }
		public LeftSpriteRightColorSerializableEitherProperty(Sprite left, Color right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftSpriteRightAnimationSerializableEitherProperty : SerializableEitherPropertyBase<Sprite, Animation> {
		public LeftSpriteRightAnimationSerializableEitherProperty() : base() { }
		public LeftSpriteRightAnimationSerializableEitherProperty(Sprite left, Animation right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftSpriteRightAnimatorSerializableEitherProperty : SerializableEitherPropertyBase<Sprite, Animator> {
		public LeftSpriteRightAnimatorSerializableEitherProperty() : base() { }
		public LeftSpriteRightAnimatorSerializableEitherProperty(Sprite left, Animator right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftSpriteRightTextureSerializableEitherProperty : SerializableEitherPropertyBase<Sprite, Texture> {
		public LeftSpriteRightTextureSerializableEitherProperty() : base() { }
		public LeftSpriteRightTextureSerializableEitherProperty(Sprite left, Texture right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftSpriteRightTexture2DSerializableEitherProperty : SerializableEitherPropertyBase<Sprite, Texture2D> {
		public LeftSpriteRightTexture2DSerializableEitherProperty() : base() { }
		public LeftSpriteRightTexture2DSerializableEitherProperty(Sprite left, Texture2D right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftSpriteRightSpriteSerializableEitherProperty : SerializableEitherPropertyBase<Sprite, Sprite> {
		public LeftSpriteRightSpriteSerializableEitherProperty() : base() { }
		public LeftSpriteRightSpriteSerializableEitherProperty(Sprite left, Sprite right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftSpriteRightGameObjectSerializableEitherProperty : SerializableEitherPropertyBase<Sprite, GameObject> {
		public LeftSpriteRightGameObjectSerializableEitherProperty() : base() { }
		public LeftSpriteRightGameObjectSerializableEitherProperty(Sprite left, GameObject right, bool isRight) : base(left, right, isRight) { }
	}
	
	[Serializable]
	public class LeftGameObjectRightIntSerializableEitherProperty : SerializableEitherPropertyBase<GameObject, int> {
		public LeftGameObjectRightIntSerializableEitherProperty() : base() { }
		public LeftGameObjectRightIntSerializableEitherProperty(GameObject left, int right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftGameObjectRightLongSerializableEitherProperty : SerializableEitherPropertyBase<GameObject, long> {
		public LeftGameObjectRightLongSerializableEitherProperty() : base() { }
		public LeftGameObjectRightLongSerializableEitherProperty(GameObject left, long right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftGameObjectRightByteSerializableEitherProperty : SerializableEitherPropertyBase<GameObject, byte> {
		public LeftGameObjectRightByteSerializableEitherProperty() : base() { }
		public LeftGameObjectRightByteSerializableEitherProperty(GameObject left, byte right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftGameObjectRightFloatSerializableEitherProperty : SerializableEitherPropertyBase<GameObject, float> {
		public LeftGameObjectRightFloatSerializableEitherProperty() : base() { }
		public LeftGameObjectRightFloatSerializableEitherProperty(GameObject left, float right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftGameObjectRightDoubleSerializableEitherProperty : SerializableEitherPropertyBase<GameObject, double> {
		public LeftGameObjectRightDoubleSerializableEitherProperty() : base() { }
		public LeftGameObjectRightDoubleSerializableEitherProperty(GameObject left, double right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftGameObjectRightStringSerializableEitherProperty : SerializableEitherPropertyBase<GameObject, string> {
		public LeftGameObjectRightStringSerializableEitherProperty () : base() { }
		public LeftGameObjectRightStringSerializableEitherProperty(GameObject left, string right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftGameObjectRightVector2SerializableEitherProperty : SerializableEitherPropertyBase<GameObject, Vector2> {
		public LeftGameObjectRightVector2SerializableEitherProperty () : base() { }
		public LeftGameObjectRightVector2SerializableEitherProperty(GameObject left, Vector2 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftGameObjectRightVector3SerializableEitherProperty : SerializableEitherPropertyBase<GameObject, Vector3> {
		public LeftGameObjectRightVector3SerializableEitherProperty() : base() { }
		public LeftGameObjectRightVector3SerializableEitherProperty(GameObject left, Vector3 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftGameObjectRightVector4SerializableEitherProperty : SerializableEitherPropertyBase<GameObject, Vector4> {
		public LeftGameObjectRightVector4SerializableEitherProperty() : base() { }
		public LeftGameObjectRightVector4SerializableEitherProperty(GameObject left, Vector4 right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftGameObjectRightColorSerializableEitherProperty : SerializableEitherPropertyBase<GameObject, Color> {
		public LeftGameObjectRightColorSerializableEitherProperty() : base() { }
		public LeftGameObjectRightColorSerializableEitherProperty(GameObject left, Color right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftGameObjectRightAnimationSerializableEitherProperty : SerializableEitherPropertyBase<GameObject, Animation> {
		public LeftGameObjectRightAnimationSerializableEitherProperty() : base() { }
		public LeftGameObjectRightAnimationSerializableEitherProperty(GameObject left, Animation right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftGameObjectRightAnimatorSerializableEitherProperty : SerializableEitherPropertyBase<GameObject, Animator> {
		public LeftGameObjectRightAnimatorSerializableEitherProperty() : base() { }
		public LeftGameObjectRightAnimatorSerializableEitherProperty(GameObject left, Animator right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftGameObjectRightTextureSerializableEitherProperty : SerializableEitherPropertyBase<GameObject, Texture> {
		public LeftGameObjectRightTextureSerializableEitherProperty() : base() { }
		public LeftGameObjectRightTextureSerializableEitherProperty(GameObject left, Texture right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftGameObjectRightTexture2DSerializableEitherProperty : SerializableEitherPropertyBase<GameObject, Texture2D> {
		public LeftGameObjectRightTexture2DSerializableEitherProperty() : base() { }
		public LeftGameObjectRightTexture2DSerializableEitherProperty(GameObject left, Texture2D right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftGameObjectRightSpriteSerializableEitherProperty : SerializableEitherPropertyBase<GameObject, Sprite> {
		public LeftGameObjectRightSpriteSerializableEitherProperty() : base() { }
		public LeftGameObjectRightSpriteSerializableEitherProperty(GameObject left, Sprite right, bool isRight) : base(left, right, isRight) { }
	}
	[Serializable]
	public class LeftGameObjectRightGameObjectSerializableEitherProperty : SerializableEitherPropertyBase<GameObject, GameObject> {
		public LeftGameObjectRightGameObjectSerializableEitherProperty() : base() { }
		public LeftGameObjectRightGameObjectSerializableEitherProperty(GameObject left, GameObject right, bool isRight) : base(left, right, isRight) { }
	}
}