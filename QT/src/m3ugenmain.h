#ifndef M3UGENQTMAIN_H
#define M3UGENQTMAIN_H

#include <QMainWindow>

namespace Ui
{
    class CM3UGenMain;
}

namespace net
{
    namespace derpaul
    {
        namespace utility
        {
            namespace m3ugen
            {
                class CM3UGenMain : public QMainWindow
                {
                    Q_OBJECT

                public:
                    explicit CM3UGenMain(QWidget *parent = 0);
                    ~CM3UGenMain();

                private slots:
                    void on_BtnDir_clicked();
                    void on_BtnExit_clicked();
                    void on_BtnStart_clicked();

                private:
                    Ui::CM3UGenMain *ui;
                };
            }
        }
    }
}

#endif // M3UGENQTMAIN_H
