# CMPM163HW3
CONTROLS Use WASD to move around the scenes. Use MOUSE to move the camera. Use SPACE to swtich scenes. Open the project in a window or use ALT-F4 to exit.  This scene features a music track I created on a PICO-8. Both the Glitch shader (used on the cylinders and on the dust particle system) and the Raining Light particle system respond to the audio of this track. The shader splits the audio into buckets and displaces one of its passes based on the buckets and an assigned ID. The Raining Light system looks for the highest frequency that passes a certain threshold in the audio and changes its color based on that frequency.  Use WASD to move around the scenes. Use MOUSE to move the camera. Use SPACE to swtich scenes. Open the project in a window or use ALT-F4 to exit. The Fire Sytem is modified by a PerlinNoise function that responds to time. The only variable modified here is the startLifespan of the particls, which determines its ultimate height.  The skybox is made out of the default particle texture and a render texture caught by a second camera in the scene.
