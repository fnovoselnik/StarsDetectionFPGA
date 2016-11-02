# StarsDetectionFPGA

####C# application - loading greyscale image and sending it over Serial port (UART) to Nexys3 Spartan-6 FPGA. After an image is processed, it receives coordinates of detected stars and marks detections on original image.

####Nexys3 Spartan-6 FPGA - runs image processing algorithm for stars detection on night sky image (written in C)

###Stars detection algorithm:<br />
1. Calculates average of whole image <br />
2. Moving window over image (size of window is predefined) <br />
3. If average intensity inside window is larger than image average it assumes it is star<br />
4. Finds pixel with maximum intensity inside window (center of the star) <br />
5. Sends coordinates (x,y) of detected stars back to C# application over Serial Port (UART) <br />
