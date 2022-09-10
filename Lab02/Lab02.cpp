#include <opencv2\opencv.hpp>
using namespace cv;

//#define SHOW_TASK1
//#define SHOW_TASK2


#define CAT_IMAGE_PATH      "images/cat.jpg"
#define CELLS_IMAGE_PATH    "images/cells.jpg"
#define SAVE_IMAGE_PREFIX	"images/save_"

bool toSave = true;

void requestToSave(Mat, const char*);
void showHistogramOfImage(Mat);
Mat normalizeImage(Mat);

void main()
{
    Mat img = imread(CAT_IMAGE_PATH, ImreadModes::IMREAD_COLOR);
    imshow("my cat", img);
    waitKey();

#ifdef SHOW_TASK1
    {
        Mat clone = img.clone();
        const float kernelData[] = {
            -0.25f, -0.5f, -0.25f,
            -0.25f, 3.5f, -0.25f,
            -0.25f, -0.5f, -0.25f,
        };
        const Mat kernel(3, 3, CV_32FC1, (float*)kernelData);
        filter2D(clone, clone, -1, kernel);
        imshow("my cat, but contrasted", clone);
        requestToSave(clone, "cat-contrasted");
    }

    {
        Mat clone = img.clone();
        const float kernelData[] = {
            0.1f, 0.2f, 0.1f,
            0.2f, 0.42f, 0.2f,
            0.1f, 0.2f, 0.1f,
        };
        const Mat kernel(3, 3, CV_32FC1, (float*)kernelData);
        filter2D(clone, clone, -1, kernel);
        imshow("my cat, but overlight blured", clone);
        requestToSave(clone, "clear");
    }

    {
        Mat clone = img.clone();
        const float kernelData[] = {
            0.15f, 0.25f, 0.15f,
            0.25f, -0.45f, 0.25f,
            0.15f, 0.25f, 0.15f,
        };
        const Mat kernel(3, 3, CV_32FC1, (float*)kernelData);
        filter2D(clone, clone, -1, kernel);
        imshow("my cat, but blured", clone);
        requestToSave(clone, "bright");
    }
    waitKey();
#endif // SHOW_TASK1


#ifdef SHOW_TASK2
    Mat clone = img.clone();
    blur(img, clone, Size(5, 5));
    imshow("my cat, but blured", clone);
    requestToSave(clone, "cat-blured");

    clone = img.clone();
    GaussianBlur(img, clone, Size(5, 5), 0);
    imshow("my cat, but blured with Gauss help", clone);
    requestToSave(clone, "cat-gaussian-blured");

    clone = img.clone();
    medianBlur(img, clone, 7);
    imshow("my cat, but median blured", clone);
    requestToSave(clone, "cat-median-blured");
    waitKey();
#endif // SHOW_TASK2

    img = imread(CELLS_IMAGE_PATH, ImreadModes::IMREAD_COLOR);
    imshow("cells", img);
    waitKey();

    {
        Mat gray;
        cvtColor(img, gray, cv::COLOR_BGR2GRAY);
        threshold(gray, gray, 40, 255, THRESH_BINARY);
        imshow("cells after binarization", gray);
        waitKey();
        requestToSave(gray, "cells-binary");

        Mat imgEroded;
        erode(gray, imgEroded, Mat());
        imshow("binary cells after erodion", imgEroded);
        waitKey();
        requestToSave(imgEroded, "cells-binary-erodion");

        Mat imgDilated;
        dilate(imgEroded, imgDilated, Mat());
        imshow("binary cells after dilation", imgDilated);
        waitKey();
        requestToSave(imgDilated, "cells-binary-erodion-dilation");

        morphologyEx(imgDilated, gray, MORPH_GRADIENT, Mat());
        imshow("morph gradient", gray);
        waitKey();
        requestToSave(gray, "cells-binary-erodion-dilation-gradient");
    }

    {
        Mat gray;
        cvtColor(img, gray, cv::COLOR_BGR2GRAY);
        adaptiveThreshold(gray, gray, 255, ADAPTIVE_THRESH_GAUSSIAN_C, THRESH_BINARY, 251, -10);
        imshow("cells after adaptive binarization", gray);
        waitKey();

        Mat imgEroded;
        erode(gray, imgEroded, Mat());
        imshow("binary cells 2 after erodion", imgEroded);
        waitKey();
        requestToSave(imgEroded, "cells-adaptive-binary-erodion");

        Mat imgDilated;
        dilate(imgEroded, imgDilated, Mat());
        imshow("binary cells 2 after dilation", imgDilated);
        waitKey();
        requestToSave(imgDilated, "cells-adaptive-binary-erodion-dilation");

        morphologyEx(imgDilated, gray, MORPH_GRADIENT, Mat());
        imshow("morph gradient 2", gray);
        waitKey();
        requestToSave(gray, "cells-adaptive-binary-dilation-gradient");
    }
}

void requestToSave(Mat image, const char* name)
{
    if (toSave == false)
    {
        return;
    }

    String picture_save_name = String(SAVE_IMAGE_PREFIX) + name + String(".png");
    if (imwrite(picture_save_name, image, { IMWRITE_PAM_FORMAT_RGB }))
    {
        std::cout << "Successfully saved as " << picture_save_name << " .\n\n";
    }
    else
    {
        std::cout << "Failed to save image as " << picture_save_name << " .\n\n";
    }
}
