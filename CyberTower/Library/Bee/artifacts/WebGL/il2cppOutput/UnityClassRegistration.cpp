extern "C" void RegisterStaticallyLinkedModulesGranular()
{
	void RegisterModule_SharedInternals();
	RegisterModule_SharedInternals();

	void RegisterModule_Core();
	RegisterModule_Core();

	void RegisterModule_Animation();
	RegisterModule_Animation();

	void RegisterModule_Audio();
	RegisterModule_Audio();

	void RegisterModule_Director();
	RegisterModule_Director();

	void RegisterModule_IMGUI();
	RegisterModule_IMGUI();

	void RegisterModule_Input();
	RegisterModule_Input();

	void RegisterModule_InputLegacy();
	RegisterModule_InputLegacy();

	void RegisterModule_JSONSerialize();
	RegisterModule_JSONSerialize();

	void RegisterModule_ParticleSystem();
	RegisterModule_ParticleSystem();

	void RegisterModule_Physics();
	RegisterModule_Physics();

	void RegisterModule_Physics2D();
	RegisterModule_Physics2D();

	void RegisterModule_RuntimeInitializeOnLoadManagerInitializer();
	RegisterModule_RuntimeInitializeOnLoadManagerInitializer();

	void RegisterModule_Subsystems();
	RegisterModule_Subsystems();

	void RegisterModule_TextRendering();
	RegisterModule_TextRendering();

	void RegisterModule_TextCoreFontEngine();
	RegisterModule_TextCoreFontEngine();

	void RegisterModule_TextCoreTextEngine();
	RegisterModule_TextCoreTextEngine();

	void RegisterModule_UI();
	RegisterModule_UI();

	void RegisterModule_UIElementsNative();
	RegisterModule_UIElementsNative();

	void RegisterModule_UIElements();
	RegisterModule_UIElements();

	void RegisterModule_VR();
	RegisterModule_VR();

	void RegisterModule_WebGL();
	RegisterModule_WebGL();

	void RegisterModule_XR();
	RegisterModule_XR();

}

template <typename T> void RegisterUnityClass(const char*);
template <typename T> void RegisterStrippedType(int, const char*, const char*);

void InvokeRegisterStaticallyLinkedModuleClasses()
{
	// Do nothing (we're in stripping mode)
}

class AnimationClip; template <> void RegisterUnityClass<AnimationClip>(const char*);
class Animator; template <> void RegisterUnityClass<Animator>(const char*);
class AnimatorController; template <> void RegisterUnityClass<AnimatorController>(const char*);
class AnimatorOverrideController; template <> void RegisterUnityClass<AnimatorOverrideController>(const char*);
class Avatar; template <> void RegisterUnityClass<Avatar>(const char*);
class AvatarMask; template <> void RegisterUnityClass<AvatarMask>(const char*);
class Motion; template <> void RegisterUnityClass<Motion>(const char*);
class RuntimeAnimatorController; template <> void RegisterUnityClass<RuntimeAnimatorController>(const char*);
class AudioBehaviour; template <> void RegisterUnityClass<AudioBehaviour>(const char*);
class AudioClip; template <> void RegisterUnityClass<AudioClip>(const char*);
class AudioListener; template <> void RegisterUnityClass<AudioListener>(const char*);
class AudioManager; template <> void RegisterUnityClass<AudioManager>(const char*);
class AudioMixer; template <> void RegisterUnityClass<AudioMixer>(const char*);
class AudioMixerGroup; template <> void RegisterUnityClass<AudioMixerGroup>(const char*);
class AudioMixerSnapshot; template <> void RegisterUnityClass<AudioMixerSnapshot>(const char*);
class AudioSource; template <> void RegisterUnityClass<AudioSource>(const char*);
class SampleClip; template <> void RegisterUnityClass<SampleClip>(const char*);
class Behaviour; template <> void RegisterUnityClass<Behaviour>(const char*);
class BuildSettings; template <> void RegisterUnityClass<BuildSettings>(const char*);
class Camera; template <> void RegisterUnityClass<Camera>(const char*);
namespace Unity { class Component; } template <> void RegisterUnityClass<Unity::Component>(const char*);
class ComputeShader; template <> void RegisterUnityClass<ComputeShader>(const char*);
class Cubemap; template <> void RegisterUnityClass<Cubemap>(const char*);
class CubemapArray; template <> void RegisterUnityClass<CubemapArray>(const char*);
class DelayedCallManager; template <> void RegisterUnityClass<DelayedCallManager>(const char*);
class EditorExtension; template <> void RegisterUnityClass<EditorExtension>(const char*);
class GameManager; template <> void RegisterUnityClass<GameManager>(const char*);
class GameObject; template <> void RegisterUnityClass<GameObject>(const char*);
class GlobalGameManager; template <> void RegisterUnityClass<GlobalGameManager>(const char*);
class GraphicsSettings; template <> void RegisterUnityClass<GraphicsSettings>(const char*);
class InputManager; template <> void RegisterUnityClass<InputManager>(const char*);
class LevelGameManager; template <> void RegisterUnityClass<LevelGameManager>(const char*);
class Light; template <> void RegisterUnityClass<Light>(const char*);
class LightingSettings; template <> void RegisterUnityClass<LightingSettings>(const char*);
class LightmapSettings; template <> void RegisterUnityClass<LightmapSettings>(const char*);
class LightProbes; template <> void RegisterUnityClass<LightProbes>(const char*);
class LowerResBlitTexture; template <> void RegisterUnityClass<LowerResBlitTexture>(const char*);
class Material; template <> void RegisterUnityClass<Material>(const char*);
class Mesh; template <> void RegisterUnityClass<Mesh>(const char*);
class MeshFilter; template <> void RegisterUnityClass<MeshFilter>(const char*);
class MeshRenderer; template <> void RegisterUnityClass<MeshRenderer>(const char*);
class MonoBehaviour; template <> void RegisterUnityClass<MonoBehaviour>(const char*);
class MonoManager; template <> void RegisterUnityClass<MonoManager>(const char*);
class MonoScript; template <> void RegisterUnityClass<MonoScript>(const char*);
class NamedObject; template <> void RegisterUnityClass<NamedObject>(const char*);
class Object; template <> void RegisterUnityClass<Object>(const char*);
class PlayerSettings; template <> void RegisterUnityClass<PlayerSettings>(const char*);
class PreloadData; template <> void RegisterUnityClass<PreloadData>(const char*);
class QualitySettings; template <> void RegisterUnityClass<QualitySettings>(const char*);
namespace UI { class RectTransform; } template <> void RegisterUnityClass<UI::RectTransform>(const char*);
class ReflectionProbe; template <> void RegisterUnityClass<ReflectionProbe>(const char*);
class Renderer; template <> void RegisterUnityClass<Renderer>(const char*);
class RenderSettings; template <> void RegisterUnityClass<RenderSettings>(const char*);
class RenderTexture; template <> void RegisterUnityClass<RenderTexture>(const char*);
class ResourceManager; template <> void RegisterUnityClass<ResourceManager>(const char*);
class RuntimeInitializeOnLoadManager; template <> void RegisterUnityClass<RuntimeInitializeOnLoadManager>(const char*);
class Shader; template <> void RegisterUnityClass<Shader>(const char*);
class ShaderNameRegistry; template <> void RegisterUnityClass<ShaderNameRegistry>(const char*);
class Skybox; template <> void RegisterUnityClass<Skybox>(const char*);
class SortingGroup; template <> void RegisterUnityClass<SortingGroup>(const char*);
class Sprite; template <> void RegisterUnityClass<Sprite>(const char*);
class SpriteAtlas; template <> void RegisterUnityClass<SpriteAtlas>(const char*);
class SpriteRenderer; template <> void RegisterUnityClass<SpriteRenderer>(const char*);
class TagManager; template <> void RegisterUnityClass<TagManager>(const char*);
class TextAsset; template <> void RegisterUnityClass<TextAsset>(const char*);
class Texture; template <> void RegisterUnityClass<Texture>(const char*);
class Texture2D; template <> void RegisterUnityClass<Texture2D>(const char*);
class Texture2DArray; template <> void RegisterUnityClass<Texture2DArray>(const char*);
class Texture3D; template <> void RegisterUnityClass<Texture3D>(const char*);
class TimeManager; template <> void RegisterUnityClass<TimeManager>(const char*);
class TrailRenderer; template <> void RegisterUnityClass<TrailRenderer>(const char*);
class Transform; template <> void RegisterUnityClass<Transform>(const char*);
class PlayableDirector; template <> void RegisterUnityClass<PlayableDirector>(const char*);
class ParticleSystem; template <> void RegisterUnityClass<ParticleSystem>(const char*);
class ParticleSystemRenderer; template <> void RegisterUnityClass<ParticleSystemRenderer>(const char*);
class Collider; template <> void RegisterUnityClass<Collider>(const char*);
class PhysicsManager; template <> void RegisterUnityClass<PhysicsManager>(const char*);
class Rigidbody; template <> void RegisterUnityClass<Rigidbody>(const char*);
class BoxCollider2D; template <> void RegisterUnityClass<BoxCollider2D>(const char*);
class CircleCollider2D; template <> void RegisterUnityClass<CircleCollider2D>(const char*);
class Collider2D; template <> void RegisterUnityClass<Collider2D>(const char*);
class Physics2DSettings; template <> void RegisterUnityClass<Physics2DSettings>(const char*);
class PhysicsMaterial2D; template <> void RegisterUnityClass<PhysicsMaterial2D>(const char*);
class Rigidbody2D; template <> void RegisterUnityClass<Rigidbody2D>(const char*);
namespace TextRendering { class Font; } template <> void RegisterUnityClass<TextRendering::Font>(const char*);
namespace TextRenderingPrivate { class TextMesh; } template <> void RegisterUnityClass<TextRenderingPrivate::TextMesh>(const char*);
namespace UI { class Canvas; } template <> void RegisterUnityClass<UI::Canvas>(const char*);
namespace UI { class CanvasGroup; } template <> void RegisterUnityClass<UI::CanvasGroup>(const char*);
namespace UI { class CanvasRenderer; } template <> void RegisterUnityClass<UI::CanvasRenderer>(const char*);

void RegisterAllClasses()
{
void RegisterBuiltinTypes();
RegisterBuiltinTypes();
	//Total: 89 non stripped classes
	//0. AnimationClip
	RegisterUnityClass<AnimationClip>("Animation");
	//1. Animator
	RegisterUnityClass<Animator>("Animation");
	//2. AnimatorController
	RegisterUnityClass<AnimatorController>("Animation");
	//3. AnimatorOverrideController
	RegisterUnityClass<AnimatorOverrideController>("Animation");
	//4. Avatar
	RegisterUnityClass<Avatar>("Animation");
	//5. AvatarMask
	RegisterUnityClass<AvatarMask>("Animation");
	//6. Motion
	RegisterUnityClass<Motion>("Animation");
	//7. RuntimeAnimatorController
	RegisterUnityClass<RuntimeAnimatorController>("Animation");
	//8. AudioBehaviour
	RegisterUnityClass<AudioBehaviour>("Audio");
	//9. AudioClip
	RegisterUnityClass<AudioClip>("Audio");
	//10. AudioListener
	RegisterUnityClass<AudioListener>("Audio");
	//11. AudioManager
	RegisterUnityClass<AudioManager>("Audio");
	//12. AudioMixer
	RegisterUnityClass<AudioMixer>("Audio");
	//13. AudioMixerGroup
	RegisterUnityClass<AudioMixerGroup>("Audio");
	//14. AudioMixerSnapshot
	RegisterUnityClass<AudioMixerSnapshot>("Audio");
	//15. AudioSource
	RegisterUnityClass<AudioSource>("Audio");
	//16. SampleClip
	RegisterUnityClass<SampleClip>("Audio");
	//17. Behaviour
	RegisterUnityClass<Behaviour>("Core");
	//18. BuildSettings
	RegisterUnityClass<BuildSettings>("Core");
	//19. Camera
	RegisterUnityClass<Camera>("Core");
	//20. Component
	RegisterUnityClass<Unity::Component>("Core");
	//21. ComputeShader
	RegisterUnityClass<ComputeShader>("Core");
	//22. Cubemap
	RegisterUnityClass<Cubemap>("Core");
	//23. CubemapArray
	RegisterUnityClass<CubemapArray>("Core");
	//24. DelayedCallManager
	RegisterUnityClass<DelayedCallManager>("Core");
	//25. EditorExtension
	RegisterUnityClass<EditorExtension>("Core");
	//26. GameManager
	RegisterUnityClass<GameManager>("Core");
	//27. GameObject
	RegisterUnityClass<GameObject>("Core");
	//28. GlobalGameManager
	RegisterUnityClass<GlobalGameManager>("Core");
	//29. GraphicsSettings
	RegisterUnityClass<GraphicsSettings>("Core");
	//30. InputManager
	RegisterUnityClass<InputManager>("Core");
	//31. LevelGameManager
	RegisterUnityClass<LevelGameManager>("Core");
	//32. Light
	RegisterUnityClass<Light>("Core");
	//33. LightingSettings
	RegisterUnityClass<LightingSettings>("Core");
	//34. LightmapSettings
	RegisterUnityClass<LightmapSettings>("Core");
	//35. LightProbes
	RegisterUnityClass<LightProbes>("Core");
	//36. LowerResBlitTexture
	RegisterUnityClass<LowerResBlitTexture>("Core");
	//37. Material
	RegisterUnityClass<Material>("Core");
	//38. Mesh
	RegisterUnityClass<Mesh>("Core");
	//39. MeshFilter
	RegisterUnityClass<MeshFilter>("Core");
	//40. MeshRenderer
	RegisterUnityClass<MeshRenderer>("Core");
	//41. MonoBehaviour
	RegisterUnityClass<MonoBehaviour>("Core");
	//42. MonoManager
	RegisterUnityClass<MonoManager>("Core");
	//43. MonoScript
	RegisterUnityClass<MonoScript>("Core");
	//44. NamedObject
	RegisterUnityClass<NamedObject>("Core");
	//45. Object
	//Skipping Object
	//46. PlayerSettings
	RegisterUnityClass<PlayerSettings>("Core");
	//47. PreloadData
	RegisterUnityClass<PreloadData>("Core");
	//48. QualitySettings
	RegisterUnityClass<QualitySettings>("Core");
	//49. RectTransform
	RegisterUnityClass<UI::RectTransform>("Core");
	//50. ReflectionProbe
	RegisterUnityClass<ReflectionProbe>("Core");
	//51. Renderer
	RegisterUnityClass<Renderer>("Core");
	//52. RenderSettings
	RegisterUnityClass<RenderSettings>("Core");
	//53. RenderTexture
	RegisterUnityClass<RenderTexture>("Core");
	//54. ResourceManager
	RegisterUnityClass<ResourceManager>("Core");
	//55. RuntimeInitializeOnLoadManager
	RegisterUnityClass<RuntimeInitializeOnLoadManager>("Core");
	//56. Shader
	RegisterUnityClass<Shader>("Core");
	//57. ShaderNameRegistry
	RegisterUnityClass<ShaderNameRegistry>("Core");
	//58. Skybox
	RegisterUnityClass<Skybox>("Core");
	//59. SortingGroup
	RegisterUnityClass<SortingGroup>("Core");
	//60. Sprite
	RegisterUnityClass<Sprite>("Core");
	//61. SpriteAtlas
	RegisterUnityClass<SpriteAtlas>("Core");
	//62. SpriteRenderer
	RegisterUnityClass<SpriteRenderer>("Core");
	//63. TagManager
	RegisterUnityClass<TagManager>("Core");
	//64. TextAsset
	RegisterUnityClass<TextAsset>("Core");
	//65. Texture
	RegisterUnityClass<Texture>("Core");
	//66. Texture2D
	RegisterUnityClass<Texture2D>("Core");
	//67. Texture2DArray
	RegisterUnityClass<Texture2DArray>("Core");
	//68. Texture3D
	RegisterUnityClass<Texture3D>("Core");
	//69. TimeManager
	RegisterUnityClass<TimeManager>("Core");
	//70. TrailRenderer
	RegisterUnityClass<TrailRenderer>("Core");
	//71. Transform
	RegisterUnityClass<Transform>("Core");
	//72. PlayableDirector
	RegisterUnityClass<PlayableDirector>("Director");
	//73. ParticleSystem
	RegisterUnityClass<ParticleSystem>("ParticleSystem");
	//74. ParticleSystemRenderer
	RegisterUnityClass<ParticleSystemRenderer>("ParticleSystem");
	//75. Collider
	RegisterUnityClass<Collider>("Physics");
	//76. PhysicsManager
	RegisterUnityClass<PhysicsManager>("Physics");
	//77. Rigidbody
	RegisterUnityClass<Rigidbody>("Physics");
	//78. BoxCollider2D
	RegisterUnityClass<BoxCollider2D>("Physics2D");
	//79. CircleCollider2D
	RegisterUnityClass<CircleCollider2D>("Physics2D");
	//80. Collider2D
	RegisterUnityClass<Collider2D>("Physics2D");
	//81. Physics2DSettings
	RegisterUnityClass<Physics2DSettings>("Physics2D");
	//82. PhysicsMaterial2D
	RegisterUnityClass<PhysicsMaterial2D>("Physics2D");
	//83. Rigidbody2D
	RegisterUnityClass<Rigidbody2D>("Physics2D");
	//84. Font
	RegisterUnityClass<TextRendering::Font>("TextRendering");
	//85. TextMesh
	RegisterUnityClass<TextRenderingPrivate::TextMesh>("TextRendering");
	//86. Canvas
	RegisterUnityClass<UI::Canvas>("UI");
	//87. CanvasGroup
	RegisterUnityClass<UI::CanvasGroup>("UI");
	//88. CanvasRenderer
	RegisterUnityClass<UI::CanvasRenderer>("UI");

}
