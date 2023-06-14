# :goggles: Using Quest Pro EyeTracking for Gathering Attention Data
[Yong Thorvue](https://github.com/tut203383/) | [Ioh Nishijima]()

Jean Monnet University (UJM)

Imaging and Light in Extended Reality (IMLEX)

## Implementation Environment
#### HardWare
* Quest Pro headset
* Window with GPU 

#### SoftWare
* Unity: 2021.3.23f1
* Oculus App
* Meta Quest Developer hub

#### [Source Code](https://github.com/tut203383/QuestPro_EyeTracking/blob/master/ProjectEyeTrackingGaze/)

## Eye Tracking Setting
Implemention of eye tracking on Quest Pro based on [this page](https://note.com/npaka/n/n3761152ae06c). It is Japanese language, 
you may need to use a browser translater to be able to go through it. The eye tracking function on Quest pro current is available for only position and rotation transformation. It is not able to measure the pupil diameter. The scripts for both eye are [EyeGazeController.cs](https://github.com/tut203383/QuestPro_EyeTracking/blob/master/ProjectEyeTrackingGaze/EyeGazeController.cs) and [EyeGazeController2.cs](https://github.com/tut203383/QuestPro_EyeTracking/blob/master/ProjectEyeTrackingGaze/EyeGazeController2.cs)

Besides, we implemented lasers for both eye that breaks off when it hits an object. This enable us to detect where user is looking at (e.g. distance: far & near objects). 
We used Ray and LineRenderer in this implementation, Scripts are [Laser.cs](https://github.com/tut203383/QuestPro_EyeTracking/blob/master/ProjectEyeTrackingGaze/Laser.cs) and [Laser2.cs](https://github.com/tut203383/QuestPro_EyeTracking/blob/master/ProjectEyeTrackingGaze/Laser1.cs)

Here, we also tried out with particle system that when the laser(line of sight) hit an object then the particles was emitted.[HeatmapGenerator.cs](https://github.com/tut203383/QuestPro_EyeTracking/blob/master/ProjectEyeTrackingGaze/HeatmapGenerator.cs)
![Example of using particle system](https://github.com/tut203383/QuestPro_EyeTracking/blob/master/video.gif)

## Hand Tracking Setting
We implemented hand tracking for grabing and picking up an objects. This implementation is based on [this page](https://note.com/oshimu/n/n72d4d72eb1c9). The scripts we used is [InterctionCollider.cs](https://github.com/tut203383/QuestPro_EyeTracking/blob/master/ProjectEyeTrackingGaze/InterctionCollider.cs)

## Heatmap Generation
To generate heat map, we first have to combined both line sight (Laser.cs & Laser2.cs) to one center line sight for correctly generate heatmap when looking at close objects. Here we could receive the global position of hiting point and UV coordinate of hitting point at an object this enable us to bring these value to Shader which can visualize the attention data heatmap in real-time and save it as CSV file. The scripts for this implementation are [bothEyeController.cs](https://github.com/tut203383/QuestPro_EyeTracking/blob/master/ProjectEyeTrackingGaze/bothEyeController.cs), [WritePlease.cs](https://github.com/tut203383/QuestPro_EyeTracking/blob/master/ProjectEyeTrackingGaze/WritePlease.cs) and [HeatMapShader 1.shader](https://github.com/tut203383/QuestPro_EyeTracking/blob/master/ProjectEyeTrackingGaze/HeatMapShader1.shader)

## Result
![Result of heatmap in unity](https://github.com/tut203383/QuestPro_EyeTracking/blob/master/Result.gif)


### Future work
* Solving the issue of not being able to obtain UV coordinates from objects with attached Rigid Body
* Real-time visualization of gaze on 3D objects using shaders

### Acknowledgements
We are grateful to Professor Philippe Colantoni for giving guidance and idea of this project as well as providing Quest Pro headset and enable Developer mode on Quest pro for Eye tracking. 
