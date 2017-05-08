#include "playlist.h"
#include <QDir>
#include <QDebug>

namespace net
{
    namespace derpaul
    {
        namespace utility
        {
            namespace m3ugen
            {
                CPlaylist::CPlaylist()
                {
                }

                void CPlaylist::PlaylistCreate(QString PathRaw, QVector<QString> &Filenames)
                {
                    QString Path = QDir::toNativeSeparators(PathRaw);
                    int Pos = Path.lastIndexOf(QDir::separator());
                    QString Filename = QString("%1%2%3.%4").arg(PathRaw).arg(QDir::separator()).arg(Path.mid(Pos + 1)).arg(
                                         net::derpaul::utility::m3ugen::PlaylistExtension);
                    QFile Playlist(Filename);

                    if (Playlist.open(QFile::ReadWrite | QFile::Text))
                    {
                        QTextStream out(&Playlist);

                        for (QVector<QString>::iterator CurrentFilename = Filenames.begin(); CurrentFilename != Filenames.end();
                             CurrentFilename++)
                        {
                            out << *CurrentFilename << endl;
                        }

                        Playlist.close();
                    }
                }

            }
        }
    }
}
