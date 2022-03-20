using UnityEngine;
using UnityEngine.Scripting;

namespace Siccity.GLTFUtility
{
	/// <summary>
	/// KHR_lights_punctual gltfNode extension
	/// glTF extension that enables lights to nodes
	/// see: https://github.com/KhronosGroup/glTF/blob/master/extensions/2.0/Khronos/KHR_lights_punctual/schema/glTF.KHR_lights_punctual.schema.json
	/// </summary>
	[Preserve]
	public class KHR_lights_punctual : GLTFNode.IExtension
	{
		public const float intensityCorrector = 0.05f;
		public const float rangeCorrector = 0.5f;

		public int light;

		public void Apply(GLTFLight lightInfo, Transform transform)
		{
			Light light = transform.gameObject.AddComponent<Light>();
			light.intensity = lightInfo.intensity * intensityCorrector;
			light.color = lightInfo.color;
			light.shadows = LightShadows.Soft;

			switch (lightInfo.type)
			{
				case LightType.directional:
					light.type = UnityEngine.LightType.Directional;
					break;
				case LightType.point:
					light.type = UnityEngine.LightType.Point;
					light.range = lightInfo.range * rangeCorrector;
					break;
				case LightType.spot:
					light.type = UnityEngine.LightType.Spot;
					light.range = lightInfo.range * rangeCorrector;

					if (lightInfo.spot != null)
					{
						light.innerSpotAngle = lightInfo.spot.innerConeAngle * Mathf.Rad2Deg;
						light.spotAngle = lightInfo.spot.outerConeAngle * Mathf.Rad2Deg;
					}
					break;
			}
		}
	}
}