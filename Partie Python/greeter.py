from PIL import Image
import numpy as np
import skimage
import collections
import dlib
import cv2
import matplotlib.pyplot as plt
import os
import PIL
import glob
import receiveslack
import sendslack

receiveslack.SendSlack()
detector = dlib.get_frontal_face_detector()
predictor = dlib.shape_predictor('shape_predictor_68_face_landmarks.dat')
img = dlib.load_rgb_image('sample.jpg')
rect = detector(img)[0]
sp = predictor(img, rect)
landmarks = np.array([[p.x, p.y] for p in sp.parts()])
outline = landmarks[[*range(17), *range(26, 16, -1)]]
Y, X = skimage.draw.polygon(outline[:, 1], outline[:, 0])

cropped_img = np.zeros(img.shape, dtype=np.uint8)
cropped_img[Y, X] = img[Y, X]
correct_img = cv2.cvtColor(cropped_img, cv2.COLOR_BGR2RGB)
cv2.imwrite('images/test2.png', correct_img)


minx, miny = outline.min(axis=0)


maxx, maxy = outline.max(axis=0)


LargeurX = maxx - minx
LongueurY = maxy - miny


testimg = np.ones((LongueurY + 5, LargeurX + 5, 3), dtype=np.uint8)
testimg[Y - miny, X - minx] = cropped_img[Y, X]
cv2.imwrite('images/testaggrandi.png', testimg)

correct_img_test = cv2.cvtColor(testimg, cv2.COLOR_BGR2RGB)

cv2.imwrite('images/correcttest.png', correct_img_test)

img = Image.open('images/correcttest.png')

img2 = img.resize((LongueurY + 5,  LargeurX + 5 + 150))
img2 = np.array(img2)
img2 = cv2.cvtColor(img2, cv2.COLOR_BGR2RGB)

cv2.imwrite('images/resized.png', img2)

src_img = testimg[Y - miny, X - minx]
average_color_row = np.average(src_img, axis=0)
average_color = np.average(average_color_row, axis=0)

LongOverLayX = LongueurY + 250

LongOverLayY = LargeurX + 250

d_img = np.ones((LongOverLayX, LongOverLayY, 3), dtype=np.uint8)
d_img[:, :] = average_color
cv2.imwrite('images/testaverage.png', d_img)

# png

img = Image.open("images/correcttest.png")
img = img.convert("RGBA")

datas = img.getdata()
newData = []

for item in datas:
    if item[0] == 255 and item[1] == 255 and item[2] == 255:
        newData.append((255, 255, 255, 0))
    else:
        newData.append(item)

img.putdata(newData)
img.save("images/pngfiled.png", "PNG")


# copy

img = Image.open("images/resized.png")
img_w, img_h = img.size
background = Image.open("images/testaverage.png")
bg_w, bg_h = background.size
offset = ((bg_w - img_w) // 2, (bg_h - img_h))   #(bg_h - img_h) // 2)
background.paste(img, offset)
background.save('images/resized_centered.png')



with open("images/resized_centered.png", "rb") as image:
    f = image.read()
    b = bytearray(f)
    
sendslack.greet2( 'getmyID.',
  'DayAtTheBeach222456.jpg',
  b)


"""src_img = testimg[Y - miny, X - minx]
average_color_row = np.average(src_img, axis=0)
average_color = np.average(average_color_row, axis=0)

d_img = np.ones((LongueurY + 10,LargeurX + 10,3), dtype=np.uint8)
d_img[:,:] = average_color
cv2.imwrite('testaverage.png',d_img)"""


"""
src_img = cropped_img[Y, X]
average_color_row = np.average(src_img, axis=0)
average_color = np.average(average_color_row, axis=0)
print(average_color)

d_img = np.ones((2450,2450,3), dtype=np.uint8)
d_img[:,:] = average_color
cv2.imwrite('testaverage.png',d_img)
cv2.imwrite('color.png',d_img)

src_img = cv2.imread('testaverage.png')
average_color_row = np.average(src_img, axis=0)
average_color = np.average(average_color_row, axis=0)
print(average_color)"""
"""image2 = np.ones((3000,3000,3), dtype=np.uint8)
image2[:,:] = average_color
image2[Y,X] = correct_img[Y,X]
cv2.imwrite('image2.png',image2)
image3 = Image.open('image2.png')
image4 = Image.resize((1000,1000))
cv2.imwrite('image4.png',image4)
img2 = np.ones((2450,2450,3), dtype=np.uint8)
img2[:,:] = average_color
img2[Y, X] = correct_img[Y, X]
cv2.imwrite('testcolor.png',img2)
img = Image.open("croparent.png")



correctpng = Image.open('resized_centered.png')
rgba = correctpng.convert("RGBA")
datas = rgba.getdata()
  
newData = []
for item in datas:
    if item[0] == 0 and item[1] == 0 and item[2] == 0:  # finding black colour by its RGB value
        # storing a transparent value when we find a black colour
        newData.append((255, 255, 255, 0))
    else:
        newData.append(item)  # other colours remain unchanged
  
rgba.putdata(newData)
rgba.save("lastpic.png", "PNG")

image = Image.open('lastpic.png')
print(image.size)

resized_image = image.resize((5000,5000))
print(resized_image.size)
resized_image = np.array(resized_image)
cv2.imwrite('lastpic2.png', resized_image)

image = Image.open('lastpic2.png')
correct_resized_image = cv2.cvtColor(resized_image,cv2.COLOR_BGR2RGB)
cv2.imwrite('lastpic3.png', correct_resized_image)

correctpng = Image.open('correcttest.png')
rgba = correctpng.convert("RGBA")
datas = rgba.getdata()
  
newData = []
for item in datas:
    if item[0] == 0 and item[1] == 0 and item[2] == 0:  # finding black colour by its RGB value
        # storing a transparent value when we find a black colour
        newData.append((255, 255, 255, 0))
    else:
        newData.append(item)  # other colours remain unchanged
  
rgba.putdata(newData)
rgba.save("croparent.png", "PNG")

"""
