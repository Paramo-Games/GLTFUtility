using Newtonsoft.Json;
using Siccity.GLTFUtility.Converters;
using UnityEngine;
using UnityEngine.Scripting;

namespace Siccity.GLTFUtility
{
	// https://github.com/KhronosGroup/glTF/blob/master/extensions/2.0/Khronos/KHR_lights_punctual/README.md
	public class GLTFLight
	{
		#region Serialization
		[JsonConverter(typeof(ColorRGBConverter))] public Color color = Color.black;
		public string name = "";
		public float intensity = 1;
		public float range = 10;
		[JsonProperty(Required = Required.Always), JsonConverter(typeof(EnumConverter))] public LightType type;
		public Spot spot;

		[Preserve]
		public class Spot
		{
			public float innerConeAngle;
			public float outerConeAngle = Mathf.PI / 4f;
		}
		#endregion
	}
}