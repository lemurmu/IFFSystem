#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QDesktopWidget>
#include <QFile>
#include <QImage>
#include <QPixmap>
#include <QStringList>
#include <QDateTime>

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    this->InitForm();
    this->InitTable();
    this->setGeometry(qApp->desktop()->availableGeometry());
}

MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::InitForm(){
    this->setProperty("Form", true);
    this->setGeometry(qApp->desktop()->availableGeometry());
    this->setWindowTitle("无边框窗体测试");
    this->setWindowFlags(Qt::FramelessWindowHint | Qt::WindowSystemMenuHint | Qt::WindowMinimizeButtonHint);

    ui->labTitle->setText("敌我信号侦收识别系统");
    ui->widgetTitle->setProperty("form", "title");
    ui->widgetTop->setProperty("nav", "top");//设置为导航
    ui->labTitle->setFont(QFont("Microsoft Yahei", 20));
    ui->labIcon->setScaledContents(true);

    QImage im;
    im.load(":/Image/company.ico");
    ui->labIcon->setPixmap( QPixmap::fromImage(im));
    //设置lable相对于父类的位置
    ui->labIcon->setGeometry(im.rect());
//    ui->labIcon->setSizePolicy(QSizePolicy::Ignored,QSizePolicy::Ignored);
//    ui->labIcon->setScaledContents(true);
    ui->labIcon->show();
    this->setWindowTitle(ui->labTitle->text());

    QSize icoSize(32, 32);
    int icoWidth = 85;

    //设置顶部导航按钮
    QList<QToolButton *> tbtns = ui->widgetTop->findChildren<QToolButton *>();
    foreach (QToolButton *btn, tbtns) {
        btn->setIconSize(icoSize);
        btn->setMinimumWidth(icoWidth);
    }

    ui->toolBox->setStyleSheet(QString::fromUtf8("#toolBox{border:1px solid #67696B; margin-left:1px;margin-right=0px; padding:1px}"));
    ui->widgetMain->setStyleSheet(QString::fromUtf8("#widgetMain{border:1px solid #67696B; margin:1px;padding:1px}"));
    ui->tableWidget->setStyleSheet(QString::fromUtf8("#tableWidget{margin-left:3px}"));


    QList<int> widths;
    widths << 100 << 650;
    ui->splitterV->setSizes(widths);

    QList<int> heights;
    heights << 400 << 200;
    ui->splitterH->setSizes(heights);

    //加载样式
    QString qssFile = ":/qss/flatblack.css";
    QFile file(qssFile);

    if (file.open(QFile::ReadOnly)) {
        QString qss = QLatin1String(file.readAll());
        QString paletteColor = qss.mid(20, 7);
        qApp->setPalette(QPalette(QColor(paletteColor)));
        qApp->setStyleSheet(qss);
        file.close();
    }

}


void MainWindow::InitTable(){
    //设置列数和列宽
    int width = qApp->desktop()->availableGeometry().width() - 120;
    ui->tableWidget->setColumnCount(12);
//    ui->tableWidget->setColumnWidth(0, width * 0.06);
//    ui->tableWidget->setColumnWidth(1, width * 0.10);
//    ui->tableWidget->setColumnWidth(2, width * 0.06);
//    ui->tableWidget->setColumnWidth(3, width * 0.10);
//    ui->tableWidget->setColumnWidth(4, width * 0.15);
    ui->tableWidget->verticalHeader()->setDefaultSectionSize(25);

    QStringList headText;
    headText << "时标" << "飞机地址码" << "机尾号" << "国籍" << "航班号/注册号"<<"飞机属性"<<"经度"<<"纬度"<<"高度"<<"航速"<<"航向"<<"附加报文";
    ui->tableWidget->setHorizontalHeaderLabels(headText);
    ui->tableWidget->setSelectionBehavior(QAbstractItemView::SelectRows);
    ui->tableWidget->setEditTriggers(QAbstractItemView::NoEditTriggers);
    ui->tableWidget->setSelectionMode(QAbstractItemView::SingleSelection);
    ui->tableWidget->setAlternatingRowColors(true);
    ui->tableWidget->verticalHeader()->setVisible(false);
    ui->tableWidget->horizontalHeader()->setStretchLastSection(true);

    //设置行高
    ui->tableWidget->setRowCount(300);

    for (int i = 0; i < 300; i++) {
        ui->tableWidget->setRowHeight(i, 24);

        //        QTableWidgetItem *itemDeviceID = new QTableWidgetItem(QString::number(i + 1));
        //        QTableWidgetItem *itemDeviceName = new QTableWidgetItem(QString("测试设备%1").arg(i + 1));
        //        QTableWidgetItem *itemDeviceAddr = new QTableWidgetItem(QString::number(i + 1));
        //        QTableWidgetItem *itemContent = new QTableWidgetItem("防区告警");
        QTableWidgetItem *itemTime = new QTableWidgetItem(QDateTime::currentDateTime().toString("yyyy-MM-dd hh:mm:ss"));//时标
        QTableWidgetItem *icao=new QTableWidgetItem("780AEE");
        QTableWidgetItem *taiNumber=new QTableWidgetItem("B-6578");
        QTableWidgetItem *nation=new QTableWidgetItem("中国");
        QTableWidgetItem *flightNumber=new QTableWidgetItem("CSC5689");
        QTableWidgetItem *property=new QTableWidgetItem("重型(>=3000磅)");
        QTableWidgetItem *longt=new QTableWidgetItem("103.4512");
        QTableWidgetItem *lat=new QTableWidgetItem("30.54");
        QTableWidgetItem *height=new QTableWidgetItem("8000");
        QTableWidgetItem *airSpend=new QTableWidgetItem("400");
        QTableWidgetItem *airDirection=new QTableWidgetItem("65");
        QTableWidgetItem *modeData=new QTableWidgetItem("78-0A-EE-36-45-78-51-21-45-78-F2-E2-45-1B-30");

        icao->setTextAlignment(Qt::AlignCenter);
        taiNumber->setTextAlignment(Qt::AlignCenter);
        nation->setTextAlignment(Qt::AlignCenter);
        flightNumber->setTextAlignment(Qt::AlignCenter);
        property->setTextAlignment(Qt::AlignCenter);
        longt->setTextAlignment(Qt::AlignCenter);
        lat->setTextAlignment(Qt::AlignCenter);
        height->setTextAlignment(Qt::AlignCenter);
        airSpend->setTextAlignment(Qt::AlignCenter);
        airDirection->setTextAlignment(Qt::AlignCenter);
        modeData->setTextAlignment(Qt::AlignCenter);


        ui->tableWidget->setItem(i, 0, itemTime);
        ui->tableWidget->setItem(i, 1, icao);
        ui->tableWidget->setItem(i, 2, taiNumber);
        ui->tableWidget->setItem(i, 3, nation);
        ui->tableWidget->setItem(i, 4, flightNumber);
        ui->tableWidget->setItem(i, 5, property);
        ui->tableWidget->setItem(i, 6, longt);
        ui->tableWidget->setItem(i, 7, lat);
        ui->tableWidget->setItem(i, 8, height);
        ui->tableWidget->setItem(i, 9, airSpend);
        ui->tableWidget->setItem(i, 10, airDirection);
        ui->tableWidget->setItem(i, 11, modeData);
    }
}

void MainWindow::on_btnMenu_Min_clicked(){
    showMinimized();
}

void MainWindow::on_btnMenu_Max_clicked(){
    if (max) {
        this->setGeometry(location);
        this->setProperty("canMove", true);
    } else {
        location = this->geometry();
        this->setGeometry(qApp->desktop()->availableGeometry());
        this->setProperty("canMove", false);
    }

    max = !max;
}

void MainWindow::on_btnMenu_Close_clicked(){
    close();
}
