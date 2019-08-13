#ifndef PLAYLIST_H
#define PLAYLIST_H

#include <QString>
#include <QVector>

namespace net
{
    namespace derpaul
    {
        namespace utility
        {
            namespace m3ugen
            {
                static QString PlaylistExtension = "m3u";
                class CPlaylist
                {
                public:
                    CPlaylist();
                    void PlaylistCreate(QString PathRaw, QVector<QString> &Filenames);
                };
            }
        }
    }
}

#endif // PLAYLIST_H
