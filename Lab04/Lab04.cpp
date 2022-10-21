#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/opencv.hpp>

using namespace std;
using namespace cv;

#define SOURCE_FIRST_IMAGE  "images/first.jpg"
#define SOURCE_SECOND_IMAGE  "images/second.jpg"
#define SOURCE_THIRD_IMAGE  "images/third.jpg"
#define SOURCE_FOURTH_IMAGE  "images/fourth.jpg"

Mat gray;
int tresh = 100;
RNG rng(12345);
bool isSecondFirstTask = false;

void thresh_callback(int, void*)
{
	Mat canny_output;
	Canny(gray, canny_output, tresh, tresh * 2);
	vector<vector<Point> > contours;
	vector<Vec4i> hierarchy;
	findContours(canny_output, contours, hierarchy, RETR_TREE, CHAIN_APPROX_SIMPLE);
	Mat drawing = Mat::zeros(canny_output.size(), CV_8UC3);
	std::cout << "---------------------------\n";
	std::cout << contours.size() << std::endl;
	std::cout << "---------------------------\n";
	for (size_t i = 0; i < contours.size(); i++)
	{
		Scalar color = Scalar(rng.uniform(0, 256), rng.uniform(0, 256), rng.uniform(0, 256));
		drawContours(drawing, contours, (int)i, color, 2, LINE_8, hierarchy, 0);
	}
	imshow(isSecondFirstTask ? "Contours 2" : "Contours", drawing);
}

void firstTask()
{
	int maxTreshold = 255;
	Mat src = imread(SOURCE_FIRST_IMAGE);
	cvtColor(src, gray, COLOR_BGR2GRAY);
	blur(gray, gray, Size(3, 3));

	const char* window = "Contours";
	namedWindow(window);
	createTrackbar("Canny thresh:", window, &tresh, maxTreshold, thresh_callback);
	thresh_callback(0, 0);
	waitKey();

	imshow("Source", src);
	waitKey();

	cvtColor(src, gray, COLOR_BGR2GRAY);
	blur(gray, gray, Size(3, 3));
	adaptiveThreshold(gray, gray, maxTreshold, ADAPTIVE_THRESH_GAUSSIAN_C, THRESH_BINARY, 81, -4);
	bitwise_not(gray, gray);
	imshow("gray", gray);
	waitKey();

	isSecondFirstTask = true;
	thresh_callback(0, 0);
	waitKey();

	cvtColor(src, gray, COLOR_BGR2GRAY);
	blur(gray, gray, Size(3, 3));
	adaptiveThreshold(gray, gray, maxTreshold, ADAPTIVE_THRESH_GAUSSIAN_C, THRESH_BINARY, 81, 0);
	bitwise_not(gray, gray);
	vector<vector<Point> > contours;
	vector<Vec4i> hierarchy;
	findContours(gray, contours, hierarchy, RETR_TREE, CHAIN_APPROX_SIMPLE);
	Mat drawing = Mat::zeros(gray.size(), CV_8UC3);
	for (size_t i = 0; i < contours.size(); i++)
	{
		Scalar color = Scalar(rng.uniform(0, 256), rng.uniform(0, 256), rng.uniform(0, 256));
		drawContours(drawing, contours, (int)i, color, 2, LINE_8, hierarchy, 0);
	}
	imshow("Contours 3", drawing);
	waitKey();
}

void myHough(Mat src, Mat dst, int threshold)
{
	vector<Vec2f> lines;
	HoughLines(src, lines, 1, CV_PI / 180, threshold);
	const int alpha = 1000;
	for (size_t i = 0; i < lines.size(); i++)
	{
		float rho = lines[i][0], theta = lines[i][1];
		double cs = cos(theta), sn = sin(theta);
		double x = rho * cs, y = rho * sn;
		Point pt1(cvRound(x + alpha * (-sn)), cvRound(y + alpha * cs));
		Point pt2(cvRound(x - alpha * (-sn)), cvRound(y - alpha * cs));
		line(dst, pt1, pt2, Scalar(0, 0, 255), 2);
	}
}

void myHoughP(Mat src, Mat dst, int threshold)
{
	vector<Vec4i> lines;
	HoughLinesP(src, lines, 1, CV_PI / 180, threshold, 50, 10);
	const int alpha = 1000;
	for (size_t i = 0; i < lines.size(); i++)
	{
		Vec4i l = lines[i];
		line(dst, Point(l[0], l[1]), Point(l[2], l[3]), Scalar(0, 0, 255), 1, LINE_AA);
	}
}

void secondTask()
{
	Mat mResult;
	Mat mMiddle;
	Mat mImage;
	
	mImage = imread(SOURCE_SECOND_IMAGE);
	imshow("The original image", mImage);
	cvtColor(mImage, mMiddle, COLOR_BGR2GRAY);
	Canny(mImage, mMiddle, 85, 150);
	mResult = mImage.clone();
	myHough(mMiddle, mResult, 180);
	imshow("The processed image", mResult);
	waitKey();

	mImage = imread(SOURCE_THIRD_IMAGE);
	imshow("The original image 2", mImage);
	medianBlur(mImage, mImage, 5);
	cvtColor(mImage, mMiddle, COLOR_BGR2GRAY);
	Canny(mImage, mMiddle, 100, 500);
	mResult = mImage.clone();
	myHoughP(mMiddle, mResult, 50);
	imshow("The processed image 2", mResult);
	waitKey();

	return;

	mImage = imread(SOURCE_SECOND_IMAGE);
	cvtColor(mImage, mMiddle, COLOR_BGR2GRAY);
	Canny(mImage, mMiddle, 200, 500);
	mResult = mImage.clone();

	vector<Vec2f> lines;
	HoughLines(mMiddle, lines, 1, CV_PI / 180, 100);
	const int alpha = 1000;
	double approximation = 2;
	//auto coefficientArr = new double[lines.size()];
	//Point** lines = new Point*[lines.size()];
	for (size_t i = 0; i < lines.size(); i++)
	{
		float rho = lines[i][0], theta = lines[i][1];
		double cs = cos(theta), sn = sin(theta);
		double x = rho * cs, y = rho * sn;
		Point pt1(cvRound(x + alpha * (-sn)), cvRound(y + alpha * cs));
		Point pt2(cvRound(x - alpha * (-sn)), cvRound(y - alpha * cs));

		// y = kx + b
		// y1 - x1k = y2 - x2k
		// y1 - y2 = k (x1 - x2)
		// (y1 - y2) / (x1 - x2) = k
		// k1 - k2 <= approximation

		//double coefficient = 

		//coefficientArr[0] = 
	}

	waitKey();
}

void thirdTask()
{
	Mat src = imread(SOURCE_FOURTH_IMAGE);
	Mat gray;
	cvtColor(src, gray, COLOR_BGR2GRAY);
	medianBlur(gray, gray, 7);
	adaptiveThreshold(gray, gray, 255, ADAPTIVE_THRESH_GAUSSIAN_C, THRESH_BINARY, 111, -3.5);
	imshow("src", src);
	waitKey();
	imshow("src", gray);
	waitKey();

	vector<Vec3f> circles;
	HoughCircles(gray, circles, HOUGH_GRADIENT, 1,
		gray.rows / 3,  // change this value to detect circles with different distances to each other
		100, 30, 50, 500);
	for (size_t i = 0; i < circles.size(); i++)
	{
		Vec3i c = circles[i];
		Point center = Point(c[0], c[1]);
		// circle center
		circle(src, center, 1, Scalar(0, 100, 100), 3, LINE_AA);
		// circle outline
		int radius = c[2];
		circle(src, center, radius, Scalar(255, 0, 255), 3, LINE_AA);
	}
	imshow("src", src);

	waitKey();
}

int main(int argc, char** argv) {
	//firstTask();
	//secondTask();
	thirdTask();
}