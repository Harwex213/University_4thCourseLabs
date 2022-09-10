#include <opencv2\opencv.hpp>
using namespace cv;

int main(int argc, char* argv[])
{
    VideoCapture capture(0);
    if (!capture.isOpened())
    {
        std::cerr << "Unable to open: " << std::endl;
        return 0;
    }

    Mat frame;
    Mat xGrad, yGrad, xGradAbs, yGradAbs, grad;
    Mat laplacianImg, laplacianImgAbs;
    Mat cannyImg;

    int state = 1;
    while (capture.isOpened())
    {
        capture >> frame;
        flip(frame, frame, 1);

        int keyboard = waitKey(30);
        switch (keyboard)
        {
        case '1': state = 1; break;
        case '2': state = 2; break;
        case '3': state = 3; break;
        case '4': state = 4; break;
        case '5': state = 5; break;
        case '6': state = 6; break;
        case '7': state = 7; break;
        case 'q':
            return 0;
        default:
            break;
        }

        switch (state)
        {
        case 1:

            break;
        case 2:
            GaussianBlur(frame, frame, Size(3, 3), 0, 0, BORDER_DEFAULT);
            morphologyEx(frame, frame, MORPH_GRADIENT, Mat());
            break;
        case 3:
            GaussianBlur(frame, frame, Size(3, 3), 0, 0, BORDER_DEFAULT);
            cvtColor(frame, frame, COLOR_RGB2GRAY);

            Sobel(frame, xGrad, CV_16S, 1, 0);
            Sobel(frame, yGrad, CV_16S, 0, 1);

            convertScaleAbs(xGrad, xGradAbs);
            convertScaleAbs(yGrad, yGradAbs);

            addWeighted(xGradAbs, 0.5, yGradAbs, 0.5, 0, grad);
            frame = grad;
            break;
        case 4:
            GaussianBlur(frame, frame, Size(3, 3), 0, 0, BORDER_DEFAULT);
            cvtColor(frame, frame, COLOR_RGB2GRAY);
            Laplacian(frame, laplacianImg, CV_16S);
            convertScaleAbs(laplacianImg, laplacianImgAbs);
            frame = laplacianImgAbs;
            break;
        case 5:
            GaussianBlur(frame, frame, Size(3, 3), 0, 0, BORDER_DEFAULT);
            cvtColor(frame, frame, COLOR_RGB2GRAY);
            Canny(frame, frame, 70, 120, 3);
            break;
        case 6:
            GaussianBlur(frame, frame, Size(3, 3), 0, 0, BORDER_DEFAULT);
            cvtColor(frame, frame, COLOR_RGB2GRAY);
            Canny(frame, frame, 10, 100, 5);
            break;
        case 7:
            GaussianBlur(frame, frame, Size(3, 3), 0, 0, BORDER_DEFAULT);
            cvtColor(frame, frame, COLOR_RGB2GRAY);
            Canny(frame, frame, 90, 200, 7);
            break;
        }

        imshow("Frame", frame);
    }

    return 0;
}
