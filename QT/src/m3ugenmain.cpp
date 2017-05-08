#include "m3ugenmain.h"
#include "ui_m3ugenmain.h"

#include <QFileDialog>
#include <QString>
#include "searchengine.h"
#include "playlist.h"

namespace net
{
    namespace derpaul
    {
        namespace utility
        {
            namespace m3ugen
            {
                CM3UGenMain::CM3UGenMain(QWidget *parent) :
                    QMainWindow(parent),
                    ui(new Ui::CM3UGenMain)
                {
                    ui->setupUi(this);
                    ui->QMainWidget->setFixedSize(370, 120);
                }

                CM3UGenMain::~CM3UGenMain()
                {
                    delete ui;
                }

                void CM3UGenMain::on_BtnDir_clicked()
                {
                    QString BasePath = QFileDialog::getExistingDirectory
                                       (
                                         this,
                                         tr("Open Directory"),
                                         QDir::homePath(),
                                         QFileDialog::ShowDirsOnly | QFileDialog::DontResolveSymlinks
                                       );
                    ui->PathName->insert(BasePath);
                }

                void CM3UGenMain::on_BtnExit_clicked()
                {
                    QCoreApplication::quit();
                }

                void CM3UGenMain::on_BtnStart_clicked()
                {
                    QApplication::setOverrideCursor(Qt::WaitCursor);
                    CSearchEngine SearchEngine;
                    CPlaylist Playlist;
                    SearchEngine.PlaylistSet(Playlist);
                    SearchEngine.PerformSearch(ui->PathName->displayText());
                    QString InfoString = SearchEngine.InfoStringGet();
                    ui->statusBar->showMessage(InfoString);
                    QApplication::restoreOverrideCursor();
                }
            }
        }
    }
}
