#include "mainwindow.h"
#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);

    a.setFont(QFont("Microsoft Yahei", 9));


    MainWindow w;
    w.show();

    return a.exec();
}
