#Move this file to documents to it work correctly. This may be put somewhere else in future versions

import bpy
import os

bpy.context.scene.render.engine = "CYCLES"


bpy.ops.render.render(animation=True)
bpy.ops.wm.quit_blender()