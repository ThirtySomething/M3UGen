#include "m3ugenmain.h"
#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    net::derpaul::utility::m3ugen::CM3UGenMain w;
    w.show();
    return a.exec();
}
