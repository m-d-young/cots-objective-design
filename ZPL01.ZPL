# single lens shape factor code
# michael dennis young
# 2022-02-02

surf_01 = PVHX()    # call the value from hx and assign it as surface 1
surf_02 = PVHY()    # call the value from hy and assign it as surface 2

radius_01 = 1 / CURV(surf_01)   # convert curvature of surface 1 to radius of curvature
radius_02 = 1 / CURV(surf_02)   # convert curvature of surface 2 to radius of curvature

# calculate the shape_factor from the radii of curvature

shape_factor = -(radius_01 + radius_02)/(radius_01 - radius_02)

# assign an operand value based on the shape factor
# the operand value is a function that is zero at -1, 0, 1 and continuous in between
# with symmetric line shapes between the zero values.

operand_value = ABSO(shape_factor) * ABSO(1 - ABSO(shape_factor))

OPTRETURN 0, operand_value  # assign the operand value to the global value 0
                            # and pass the value to the merit function operand

# change log
# 2022-02-02    initial composition