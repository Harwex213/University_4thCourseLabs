#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2\opencv.hpp>
using namespace cv;
using namespace std;

int main(int argc, char* argv[])
{


    Mat image1, image2;
    int k, i;

    const char* right_cam_gst = "nvcamerasrc sensor-id=0 ! video/x-raw(memory:NVMM),\
                                              width=(int)1280,\
                                              height=(int)720,\
                                              format=(string)I420,\
                                              framerate=(fraction)60/1 ! nvvidconv flip-method=2 ! video/x-raw,\
                                              format=(string)I420 ! videoconvert ! video/x-raw,\
                                              format=(string)BGR ! appsink";



    VideoCapture cap1 = VideoCapture(0);



    for (;;)
    {
        const clock_t begin_time = clock();
        cap1 >> image1;

        imshow("window", image1);


        if (waitKey(1) == 27)
            break;
        cout << float(clock() - begin_time) / CLOCKS_PER_SEC << "\n" << std::flush;
    }

}