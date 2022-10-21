#include <cstdlib>
#include <iostream>
#include <mutex>
#include <thread>
#include <chrono>
#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2\opencv.hpp>
#include <Windows.h>
using namespace cv;
using namespace std;

std::mutex g_mutex;
Mat frame;
bool on = true;

// consumer thread function
void consumer() {

setlocale(LC_ALL, "ru");
	const char* faceCascadeFilename = "haarcascade_frontalface_default.xml";
	const char* eyeCascadeFilename = "haarcascade_eye.xml";
	const char* smileCascadeFilename = "haarcascade_smile.xml";
	const char* haarcascade_lefteye_2splits = "haarcascade_lefteye_2splits.xml";

	CascadeClassifier faceCascade;
	CascadeClassifier eyeCascade;
	CascadeClassifier smileCascade;
	CascadeClassifier leftEyeCascade;
	if (!faceCascade.load(faceCascadeFilename))
	{
		cout << "The face detection cascade classifier was not found! !" << endl;
		return;
	}
	if (!eyeCascade.load(eyeCascadeFilename))
	{
		cout << "The eye detection cascade classifier was not found! !" << endl;
		return;
	}
	if (!smileCascade.load(smileCascadeFilename))
	{
		cout << "The smile detection cascade classifier was not found! !" << endl;
		return;
	}
	if (!leftEyeCascade.load(haarcascade_lefteye_2splits))
	{
		cout << "The left eye detection cascade classifier was not found! !" << endl;
		return;
	}

	vector<Rect> faces, eyes, smiles, leftEyes;
	Mat hyGray;
	Mat localFrame;
	int i = 0;

	while (cv::waitKey(1) != 27) {
		std::unique_lock<std::mutex> ul(g_mutex);
		localFrame = frame;
		ul.unlock();

		if (localFrame.empty())
		{
			continue;
		}

		cv::cvtColor(localFrame, hyGray, cv::ColorConversionCodes::COLOR_BGR2GRAY);
		equalizeHist(hyGray, hyGray);
		faceCascade.detectMultiScale(hyGray, faces, 1.2, 5, 0, Size(30, 30));
		for (auto face : faces)
		{
			rectangle(localFrame, Rect(face.x, face.y, face.width, face.height), Scalar(0, 0, 255), 3);
			Mat face_ = hyGray(face);

			eyeCascade.detectMultiScale(face_, eyes, 1.2, 2, 0, Size(30, 30));
			if (eyes.size() == 1)
			{
				std::cout << "Вы одноглазый Джо!\n";
			}
			if (eyes.size() == 4)
			{
				std::cout << "Вы паук?\n";
			}
			for (auto eye : eyes)
			{
				Point eyeCenter(face.x + eye.x + eye.width / 2, face.y + eye.y + eye.height / 2);
				int radius = cvRound((eye.width + eye.height) * 0.25);
				circle(localFrame, eyeCenter, radius, Scalar(0, 255, 0), 3);
			}

			//leftEyeCascade.detectMultiScale(face_, leftEyes, 1.2, 2, 0, Size(30, 30));
			//for (auto leftEye : leftEyes)
			//{
			//	Point eyeCenter(face.x + leftEye.x + leftEye.width / 2, face.y + leftEye.y + leftEye.height / 2);
			//	int radius = cvRound((leftEye.width + leftEye.height) * 0.25);
			//	circle(localFrame, eyeCenter, radius, Scalar(0, 255, 0), 3);
			//}
			//smileCascade.detectMultiScale(face_, smiles, 1.2, 2, 0, Size(30, 30));
			//for (auto smile : smiles)
			//{
			//	rectangle(localFrame, Rect(face.x + smile.x, face.y + smile.y, smile.width, smile.height), Scalar(0, 0, 255), 3);
			//}
		}

		imshow("test", localFrame);
	}
	on = false;
}

// producer thread function
void producer() {
	cv::VideoCapture cap(0);
	cap.set(CAP_PROP_FPS, 60);

	Mat localframe;

	while (on) {
		cap >> localframe;

		std::unique_lock<std::mutex> ul(g_mutex);
		localframe.copyTo(frame);
		ul.unlock();
	}
}

void consumerThread() { consumer(); }

void producerThread() { producer(); }

int main() {
	std::thread t2(producerThread);
	std::thread t1(consumerThread);
	t2.join();
	t1.join();
	return 0;
}