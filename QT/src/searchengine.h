#ifndef SEARCHENGINE_H
#define SEARCHENGINE_H

#include <QString>
#include "playlist.h"

namespace net
{
    namespace derpaul
    {
        namespace utility
        {
            namespace m3ugen
            {
                const QString FileExtension = "mp3";
                class CSearchEngine
                {
                public:
                    CSearchEngine();

                    QString InfoStringGet(void);
                    void PerformSearch(QString Directory);
                    void PlaylistSet(CPlaylist &Playlist);

                protected:
                    CPlaylist* m_PlayList;
                    int m_CountDirectories;
                    int m_CountFiles;
                    int m_CountPlaylists;

                    void SearchDirectories(QString Path);
                    void SearchFiles(QString Path);
                };
            }
        }
    }
}

#endif // SEARCHENGINE_H
