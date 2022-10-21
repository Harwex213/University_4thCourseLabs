#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/opencv.hpp>
#include <iostream>
#include <cmath>

using namespace std;
using namespace cv;

#define SOURCE_LEAF  "images/leaf.jpg"
#define SOURCE_LEAF_CHANGED  "images/leaf-changed.jpg"
#define SOURCE_CHESSBOARD  "images/chessboard.png"
#define SOURCE_BOOK_PATH  "images/art.jpg"

const char* source_window = "Source image";
const char* corners_window = "Corners detected";
Mat src, src_gray;

int circleRadius = 5;
int thresh = 100;
int max_thresh = 255;

void task1_test()
{
	src = imread(SOURCE_LEAF);
	imshow(source_window, src);
	waitKey();

	cvtColor(src, src_gray, COLOR_BGR2GRAY);
	Mat dst = Mat::zeros(src.size(), CV_32FC1);
	cornerHarris(src_gray, dst, 2, 3, 0.04);
	Mat dst_norm;
	normalize(dst, dst_norm, 0, 255, NORM_MINMAX, CV_32FC1, Mat());
	Mat copy = src.clone();
	for (int i = 0; i < dst_norm.rows; i++)
	{
		for (int j = 0; j < dst_norm.cols; j++)
		{
			if ((int)dst_norm.at<float>(i, j) > thresh)
			{
				circle(copy, Point(j, i), circleRadius, Scalar(0, 0, 255), FILLED);
			}
		}
	}
	imshow(source_window, copy);

	waitKey();
}

void task1_test2()
{
	src = imread(SOURCE_LEAF_CHANGED);
	imshow(source_window, src);
	waitKey();

	cvtColor(src, src_gray, COLOR_BGR2GRAY);
	Mat dst = Mat::zeros(src.size(), CV_32FC1);
	cornerHarris(src_gray, dst, 2, 3, 0.04);
	Mat dst_norm;
	normalize(dst, dst_norm, 0, 255, NORM_MINMAX, CV_32FC1, Mat());
	Mat copy = src.clone();
	for (int i = 0; i < dst_norm.rows; i++)
	{
		for (int j = 0; j < dst_norm.cols; j++)
		{
			if ((int)dst_norm.at<float>(i, j) > thresh)
			{
				circle(copy, Point(j, i), circleRadius, Scalar(0, 0, 255), FILLED);
			}
		}
	}
	imshow(source_window, copy);

	waitKey();
}

void task1()
{
	task1_test();
	task1_test2();

	src = imread(SOURCE_CHESSBOARD);
	cvtColor(src, src_gray, COLOR_BGR2GRAY);
	imshow(source_window, src_gray);
	waitKey();

	Mat dst = Mat::zeros(src.size(), CV_32FC1);
	cornerHarris(src_gray, dst, 2, 3, 0.04);
	Mat dst_norm;
	normalize(dst, dst_norm, 0, 255, NORM_MINMAX, CV_32FC1, Mat());
	Mat copy = src.clone();
	for (int i = 0; i < dst_norm.rows; i++)
	{
		for (int j = 0; j < dst_norm.cols; j++)
		{
			if ((int)dst_norm.at<float>(i, j) > thresh)
			{
				circle(copy, Point(j, i), circleRadius, Scalar(0, 0, 255), FILLED);
			}
		}
	}
	imshow(source_window, copy);

	waitKey();
}

int maxCorners = 10;
RNG rng(12345);
void task2_test()
{
	src = imread(SOURCE_LEAF);
	imshow(source_window, src);
	waitKey();
	cvtColor(src, src_gray, COLOR_BGR2GRAY);

	double qualityLevel = 0.01;
	double minDistance = 10;
	int blockSize = 3;
	int gradientSize = 3;
	vector<Point2f> corners;
	Mat copy = src.clone();
	goodFeaturesToTrack(src_gray, corners, maxCorners, qualityLevel, minDistance, Mat(), blockSize, gradientSize);

	for (size_t i = 0; i < corners.size(); i++)
	{
		circle(copy, corners[i], circleRadius, Scalar(0, 0, 255), FILLED);
	}
	imshow(source_window, copy);

	waitKey();
}

void task2_test2()
{
	src = imread(SOURCE_LEAF_CHANGED);
	imshow(source_window, src);
	waitKey();
	cvtColor(src, src_gray, COLOR_BGR2GRAY);

	double qualityLevel = 0.01;
	double minDistance = 10;
	int blockSize = 3;
	int gradientSize = 3;
	vector<Point2f> corners;
	Mat copy = src.clone();
	goodFeaturesToTrack(src_gray, corners, maxCorners, qualityLevel, minDistance, Mat(), blockSize, gradientSize);

	for (size_t i = 0; i < corners.size(); i++)
	{
		circle(copy, corners[i], circleRadius, Scalar(0, 0, 255), FILLED);
	}
	imshow(source_window, copy);

	waitKey();
}

void task2()
{
	task2_test();
	task2_test2();

	src = imread(SOURCE_CHESSBOARD);
	cvtColor(src, src_gray, COLOR_BGR2GRAY);
	imshow(source_window, src);
	waitKey();

	double qualityLevel = 0.01;
	double minDistance = 10;
	int blockSize = 3;
	int gradientSize = 3;
	vector<Point2f> corners;
	Mat copy = src.clone();
	goodFeaturesToTrack(src_gray, corners, maxCorners, qualityLevel, minDistance, Mat(), blockSize, gradientSize);

	for (size_t i = 0; i < corners.size(); i++)
	{
		circle(copy, corners[i], circleRadius, Scalar(0, 0, 255), FILLED);
	}
	imshow(source_window, copy);

	waitKey();
}

void task3()
{
	Mat output, input = imread(SOURCE_BOOK_PATH);

	Point2f inputQuad[4];
	inputQuad[0] = Point2f(45, 335);
	inputQuad[1] = Point2f(775, 1175);
	inputQuad[2] = Point2f(1115, 860);
	inputQuad[3] = Point2f(520, 235);
	//inputQuad[0] = Point2f(31, 443);
	//inputQuad[1] = Point2f(414, 957);
	//inputQuad[2] = Point2f(751, 625);
	//inputQuad[3] = Point2f(356, 302);

	int width_AD = sqrt(pow((inputQuad[0].x - inputQuad[3].x), 2) + pow((inputQuad[0].y - inputQuad[3].y), 2));
	int width_BC = sqrt(pow((inputQuad[1].x - inputQuad[2].x), 2) + pow((inputQuad[1].y - inputQuad[2].y), 2));
	int maxWidth = max(width_AD, width_BC);

	int height_AB = sqrt(pow((inputQuad[0].x - inputQuad[1].x), 2) + pow((inputQuad[0].y - inputQuad[1].y), 2));
	int height_CD = sqrt(pow((inputQuad[2].x - inputQuad[3].x), 2) + pow((inputQuad[2].y - inputQuad[3].y), 2));
	int maxHeight = max(height_AB, height_CD);

	Point2f outputQuad[4];
	outputQuad[0] = Point2f(0, 0);
	outputQuad[1] = Point2f(0, maxHeight * 2);
	outputQuad[2] = Point2f(maxWidth * 2, maxHeight * 2);
	outputQuad[3] = Point2f(maxWidth * 2, 0);

	Mat M = getPerspectiveTransform(inputQuad, outputQuad);

	warpPerspective(input, output, M, Size(maxWidth * 2, maxHeight  * 2));

	imshow("Input", input);
	imshow("Output", output);
	waitKey();
}

int main(int argc, char** argv)
{
	//task1();
	//task2();
	task3();
	
	return 0;
}