import numpy as np
import cv2
 
# # Load an color image in grayscale
# # "D:\UTAC\Test (copy)\1658313667_7908478.png"

#img = cv2.imread(r"D:\UTAC\Test (copy)\1658313655_274079.png",cv2.COLOR_BGR2GRAY)

img = cv2.imread(r"C:\Users\Jirawat\Desktop\1658373620_5534577.png",cv2.IMREAD_GRAYSCALE)
# # show image
# # ret,thresh1 = cv2.threshold(img,120,200,cv2.THRESH_BINARY)
# avg = np.average(img)

# print(avg >= 3.0)
# # cv2.imshow('image',img)

# # cv2.imshow('image2',thresh1)


def on_type():
	min = cv2.getTrackbarPos('Threshold Min : ', 'test') 
	max = cv2.getTrackbarPos('Threshold Max : ', 'test' )
	ret , dst = cv2.threshold (img,min,max,cv2.THRESH_BINARY_INV) 
	print(dst)
	contours, _ = cv2.findContours(dst, cv2.RETR_LIST, cv2.CHAIN_APPROX_SIMPLE)
	for c in contours:
		rect = cv2.boundingRect(c)
		#if rect[2] < 10 or rect[3] < 10: continue
		print (cv2.contourArea(c))
		x,y,w,h = rect
		img2 = cv2.cvtColor(img,cv2.COLOR_GRAY2BGR)
		cv2.rectangle(img2,(x,y),(x+w,y+h),(0,255,0),2)
		cv2.putText(img2,'Moth Detected',(x+w+10,y+h),0,0.3,(0,255,0))
		cv2.imshow('test',img2)
	# contours,hierarchy = cv2.findContours(dst,cv2.RETR_TREE,cv2.CHAIN_APPROX_SIMPLE)
	# length = len(contours)
	# maxArea = -1
	# if length > 0:
	# 	for i in range(length):  # find the biggest contour (according to area)
	# 		temp = contours[i]
	# 		area = cv2.contourArea(temp)
	# 		if area > maxArea:
	# 			maxArea = area
	# 			ci = i

	# 	res = contours[ci]
	# 	hull = cv2.convexHull(res) #applying convex hull technique
	# 	#print(res)
	# 	print("TEST")
	# 	print([hull])
	# 	print("finish")
	# 	imgColor = cv2.cvtColor(img,cv2.COLOR_GRAY2BGR)
	# 	#drawing = np.zeros(imgColor.shape, np.uint8)
	# 	#cv2.drawContours(imgColor, [res], 0, (0, 255, 0), 2) #drawing contours 
	# 	cv2.drawContours(imgColor, [hull], 0, (0, 0, 255), 3) #drawing convex hull
	# 	cv2.imshow('test', imgColor)
	# 	return

	


def callbackMin(a):
	print(a)
	on_type()

def callbackMax(a):
	print(a)
	on_type()




cv2.namedWindow('test')
cv2.createTrackbar('Threshold Min : ', 'test', 0, 255, callbackMin)
cv2.createTrackbar('Threshold Max : ', 'test', 0, 255, callbackMax)
# Do whatever you want with contours
cv2.imshow('test', img)
cv2.waitKey(0)
cv2.destroyAllWindows()





