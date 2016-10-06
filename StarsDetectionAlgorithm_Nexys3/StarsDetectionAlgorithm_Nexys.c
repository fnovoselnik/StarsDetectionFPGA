#include <stdio.h>
#include <stdlib.h>
#include "platform.h"
#include "xparameters.h"
#include "xil_types.h"
#include "xuartlite_l.h"
#include "xgpio.h"
#include "xstatus.h"
#include "xil_testmem.h"
#include "memory_config.h"

int main()
{
	// platform initialization (LED will indicate the stages of processing)
    init_platform();
    XGpio leds;
    XGpio_Initialize(&leds, XPAR_LEDS_8BITS_DEVICE_ID);
    XGpio_SetDataDirection(&leds, 1, 0x00000000);

    u8 temp;
    int d = 0;

    int image_sum = 0;
    u8 x, y; 
    
	// image size (in pixels)
    int N = 250;
    int M = 200;


	// storing image values (1D array) to Nexys3 Spartan-6 FPGA memory
    for(d = 0; d < M*N; d++){
    	// LED 2 indicates the program is ready to receive data from C# application 
    	XGpio_DiscreteWrite(&leds, 1, 0x02); 
    	temp =  XUartLite_RecvByte(XPAR_RS232_UART_1_BASEADDR);
    	XGpio_DiscreteWrite(&leds, 1, 0x04); // LED 3
    	// sum all pixel values
    	image_sum += temp;
        Xil_Out32LE(XPAR_MICRON_RAM_MEM0_BASEADDR + d*sizeof(int), temp);
        }
	
    XGpio_DiscreteWrite(&leds, 1, 0x08); //LED 4

    int i,j,m,n;
    int stars[100] = {0}; // for stars coordinates
    int z = 0;
    int l;

	// size of window (pixels)
    int windowN = 5;
    int windowM = 5;

    float window_avg;
    float image_avg;

    int index;
    int max;
    int maxIndex;

    int imageValue;


	// Average of image
	image_avg = image_sum/(M*N);
	
	// Stars detection algorithm. Moving window scans through an image (row by row). It finds pixel with maximum intensity (max) inside
	// window and its index (maxIndex) in an array (1D). Then calculates the average value of pixels inside window. In case the average 
	// intensity of window is bigger than average value of whole image it is considered as a star. Algorithm stores the index (maxIndex)
	// of the pixel with highest intensity i.e. center of the star
	
	for (m = 0; m < M; m += windowM){
		for(n = 0; n < N; n += windowN){

			window_avg = 0;
			max = -1;
			maxIndex = -1;
			for (j = 0; j < windowM; ++j){
				for (i = 0; i < windowN; ++i){

					index = (m + j) * N + (n + i);
					imageValue = Xil_In32LE(XPAR_MICRON_RAM_MEM0_BASEADDR + index*sizeof(int));

					if (imageValue > max)
					{
						max = imageValue;
						maxIndex = index;
					}

					window_avg += imageValue;
				}
			}

			window_avg /= (windowM * windowN);
			if (window_avg > 1.1*image_avg)
			{
				stars[z++] = maxIndex;
			}


		}

	}

	XGpio_DiscreteWrite(&leds, 1, 0x10); //LED 5 indicates the algorithm has finished
	for(d=0; d<666600000/12; d++); //delay

	// As it works with 1D array it is needed to convert the values to x,y coordinates on image and send it to C# application
	for (l = 0; l < 99; l++)
	{
		y = stars[l] / N;
		x = stars[l] % N;
		XUartLite_SendByte(XPAR_RS232_UART_1_BASEADDR, x);
		XUartLite_SendByte(XPAR_RS232_UART_1_BASEADDR, y);

	}
	
	// LED 6 indicates the coordinates are sent back to C# application
	XGpio_DiscreteWrite(&leds, 1, 0x20);

    return 0;
}
