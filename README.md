
 # Mean Curvature Shader for Unity 


<div align="center">
    <img src="https://github.com/JacobRThompson/Unity-MeanCurvatureShader/blob/master/Misc/DemoImage.png?raw=true" 
    alt="Demonstration Image" width="50%" />
</div>

##### <div  align="center" style="margin-left: 10%; margin-right: 10%"> Sample output. Max curvature mapped to (255,255,255); min curvature mapped to (0,0,0); exponent of 3.5 used. </div>

A senior seminar project used to fulfill the requirements for a bachelor of
mathematics degree. The accompanying paper can be found
[here](https://github.com/JacobRThompson/Unity-MeanCurvatureShader/blob/master/Misc/SeminarPaper.pdf),
while a video demonstration can be downloaded
[here.](https://github.com/JacobRThompson/Unity-MeanCurvatureShader/blob/master/Misc/DemoAnimation.mp4?raw=true)

## Description:

Once applied to a material, this shader leverages Unity's shader graph system
and GPU differentiation to generate a heat map of game object's mean curvature
everywhere along its surface. This robust tool works with most opaque models and
prefabs out of the box. Target game objects do require valid `Mesh.normals`
data, however. When working with procedurally-generated or broken meshes, the
use of `Mesh.RecalculateNormals()` is recommended.

<div align="center">
    <img src="Misc/demo1.gif" width="50%" />
</div>

## Use:

Place [Mean Curvature.shadergraph](https://github.com/JacobRThompson/Unity-MeanCurvatureShader/blob/master/Assets/Shaders/Mean%20Curvature.shadergraph)
and
[Sigmoid.shadersubgraph](https://github.com/JacobRThompson/Unity-MeanCurvatureShader/blob/master/Assets/Shaders/Sigmoid.shadersubgraph)
from this repo's
Assets/Shaders folder into any
project using Unity's [High-Definition Render Pipeline](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@8.1/manual/Getting-started-with-HDRP.html) (HDRP) or [Lightweight Render
Pipeline](https://docs.unity3d.com/Packages/com.unity.render-pipelines.lightweight@5.10/manual/getting-started-with-lwrp.html)
(LWRP). Apply the mean curvature shader to a target material. In its current
form, this shader does not interact with Unity's lighting models. This can be
remedied by copying the contents of `Mean Curvature.shadergraph` into a lit
shader graph [(guide)](https://docs.unity3d.com/Packages/com.unity.render-pipelines.lightweight@6.7/manual/ShaderGraph.html).

For color selection, curvatures are mapped to values between 0 and 1 using
a modified sigmoid curve:

<div align="center">
    <a href="https://www.codecogs.com/eqnedit.php?latex=\dpi{120}&space;\large&space;\frac{1}{1&plus;k^{-x}}" target="_blank"><img src="https://latex.codecogs.com/svg.latex?\dpi{120}&space;\large&space;\frac{1}{1&plus;k^{-x}}" title="\large \frac{1}{1+k^{-x}}" /></a>
</div>

where k is the value of `Exponent Base` within the shader. Higher values result in
positive and negative curvatures getting mapped closer to `MaxColor` and
`MinColor` respectively. When `ApplyHighlight` is enabled, curvatures (before
sigmoid is applied) equal to
or approaching `HighlightValue` are mapped to
`HighlightColor`.

## Limitations:
**(See paper for more information)**
- **Some amount of data is lost due to screen-space transformations. We advise
  against using this for numerical applications**

- **The coloration of objects is dependent on camera position; moving the camera
  will slightly change the color of any target**

- **Whenever multiple vertices of a game object lie on the same pixel, visual
  artifacts are introduced into the final render**

- **The resolution of the user's monitor dramatically affects the behavior of
  this shader**

## Included Scenes:

- **DynamicMesh:** When in play mode, this shader is applied to a
  continuously-deforming mesh. Standard WASD controls are used for player
  movement. Camera sensitivity and movement speed are controlled by the `main
  camera` game object.
- **Sandbox:** A scene showing the shader applied to various standard test
  models and a collection of rocks that can be found
  [here.](https://assetstore.unity.com/packages/3d/props/exterior/rock-package-118182)
  
- **ScreenSpaceDistortion:** Each object is colored according
  to its normal data, but half of the included objects are also sent to and from
  screen space. Moving the camera in edit mode reveals the loss of
  information and bizarre behavior that can 
  occur when moving between spaces. 