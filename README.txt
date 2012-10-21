*	Name: SMD Animation Merger				 
*	Author: Brett Didemus		
*	Platform: Windows				 
*	Date: October 2012						 
										 
*	Merge multi file valve source SMD	 
	bone animations into a single file	 

The SMD file format is the format valve uses for it's source games.
It stores, bones, animation, and mesh data. 

This application allows the selection of multi-file
animations in the *.smd file format and merge them into
one consecutive animation.

This is usefull if you are using an engine such as OGRE that defines mesh animations by
different key frame starting postions. Hence, your mesh needs all the animation keyframes exported
into a single mesh.

How to use
==================
Define an output SMD file on the form.
Browse and selected all the valve SMD animation files to merge.
Click Export.
Import new SMD into 3ds max or blender.