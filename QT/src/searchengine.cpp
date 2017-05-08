#include "searchengine.h"
#include <QDir>
#include <QDirIterator>

namespace net
{
    namespace derpaul
    {
        namespace utility
        {
            namespace m3ugen
            {
                CSearchEngine::CSearchEngine()
                    : m_PlayList(nullptr)
                    , m_CountDirectories(1)
                    , m_CountFiles(0)
                    , m_CountPlaylists(0)
                {
                }

                QString CSearchEngine::InfoStringGet(void)
                {
                    QString InfoString = QString("Directories [%1], Files [%2], Playlists [%3]")
                                         .arg(m_CountDirectories)
                                         .arg(m_CountFiles)
                                         .arg(m_CountPlaylists);
                    return InfoString;
                }

                void CSearchEngine::PlaylistSet(CPlaylist &Playlist)
                {
                    m_PlayList = &Playlist;
                }

                void CSearchEngine::PerformSearch(QString Directory)
                {
                    SearchDirectories(Directory);
                    SearchFiles(Directory);
                }

                void CSearchEngine::SearchDirectories(QString Path)
                {
                    QDirIterator DirectoryHandler(Path, QDir::Dirs | QDir::NoDotAndDotDot);

                    while (DirectoryHandler.hasNext())
                    {
                        DirectoryHandler.next();
                        m_CountDirectories++;
                        PerformSearch(DirectoryHandler.filePath());
                    }
                }

                void CSearchEngine::SearchFiles(QString Path)
                {
                    QString Pattern = QString("*.%1").arg(net::derpaul::utility::m3ugen::FileExtension);
                    QDirIterator FileHandler(Path, QStringList() << Pattern, QDir::Files | QDir::NoDotAndDotDot);
                    QVector<QString> Filenames;
                    Filenames.clear();

                    while (FileHandler.hasNext())
                    {
                        FileHandler.next();
                        Filenames.push_back(FileHandler.fileName());
                        m_CountFiles++;
                    }

                    if (!Filenames.isEmpty())
                    {
                        m_PlayList->PlaylistCreate(Path, Filenames);
                        m_CountPlaylists++;
                    }
                }

            }
        }
    }
}
