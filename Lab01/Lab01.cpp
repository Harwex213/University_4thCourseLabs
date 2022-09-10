#include <opencv2\opencv.hpp>
#include <stdio.h>
using namespace cv;

#define SOURCE_IMAGE_PATH "images/cat.jpg"
#define SUNSET_IMAGE_PATH "images/dark.jpg"
#define SAVE_IMAGE_PREFIX "images/save_"

void requestToSave(Mat image, const char* name)
{
    char answer;
    std::cout << "Do you want to save a shown picture? (y/n): ";
    std::cin >> answer; std::cout << std::endl;
    if (answer != 'y')
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

void showHistogramOfImage(Mat gray, const char* winImgName, const char* winHistName)
{
    int histSize = 256;
    float range[] = { 0, 256 };
    const float* histRange = { range };
    bool uniform = true;
    bool accumulate = false;
    Mat grayHist;
    calcHist(&gray, 1, 0, Mat(), grayHist, 1, &histSize, &histRange, uniform, accumulate);

    int hist_w = 512, hist_h = 400;
    int bin_w = cvRound((double)hist_w / histSize);
    Mat histImage(hist_h, hist_w, CV_8UC1, Scalar(0, 0, 0));
    normalize(grayHist, grayHist, 0, histImage.rows, NORM_MINMAX, -1, Mat());

    for (int i = 1; i < histSize; i++)
    {
        line(histImage, Point(bin_w * (i - 1), hist_h - cvRound(grayHist.at<float>(i - 1))),
            Point(bin_w * (i), hist_h - cvRound(grayHist.at<float>(i))),
            Scalar(255, 0, 0), 2, 8, 0);
    }

    imshow(winImgName, gray);
    imshow(winHistName, histImage);
    waitKey();
}

void main()
{
    Mat source = imread(SOURCE_IMAGE_PATH, ImreadModes::IMREAD_COLOR);
    imshow("my cat", source);
    waitKey();

    Mat gray;
    cvtColor(source, gray, cv::COLOR_BGR2GRAY);
    std::cout << gray.channels() << std::endl;
    imshow("my cat, but gray", gray);
    waitKey();
    requestToSave(gray, "cat-gray");

    threshold(gray, gray, 120, 255, THRESH_BINARY);
    imshow("my cat, but black-white", gray);
    waitKey();
    requestToSave(gray, "cat-binary");

    Mat dark = imread(SUNSET_IMAGE_PATH, ImreadModes::IMREAD_COLOR);
    cvtColor(dark, gray, cv::COLOR_BGR2GRAY);
    showHistogramOfImage(gray, "Source image", "Histogram 1");
    waitKey();
    equalizeHist(gray, gray);
    showHistogramOfImage(gray, "After equelize hist image", "Histogram 2");
    waitKey();

}